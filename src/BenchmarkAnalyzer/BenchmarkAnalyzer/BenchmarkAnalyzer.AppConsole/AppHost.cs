﻿using BenchmarkAnalyzer.Resources;
using BenchmarkAnalyzer.ServiceInterface;
using Funq;
using ServiceStack;
using ServiceStack.Razor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BenchmarkAnalyzer.ServiceModel;
using BenchmarkAnalyzer.ServiceModel.Types;
using ServiceStack.Configuration;
using ServiceStack.Data;
using ServiceStack.Host;
using ServiceStack.OrmLite;
using ServiceStack.VirtualPath;
using ServiceStack.Web;

namespace BenchmarkAnalyzer.AppConsole
{
    public class AppHost : AppSelfHostBase
    {
        /// <summary>
        /// Default constructor.
        /// Base constructor requires a name and assembly to locate web service classes. 
        /// </summary>
        public AppHost()
            : base("BenchmarkAnalyzer.AppConsole", typeof(MyServices).Assembly)
        {

        }

        /// <summary>
        /// Application specific configuration
        /// This method should initialize any IoC resources utilized by your web service classes.
        /// </summary>
        /// <param name="container"></param>
        public override void Configure(Container container)
        {
            Plugins.Add(new RequestLogsFeature());
            Plugins.Add(new CorsFeature());
            Plugins.Add(new PostmanFeature());
            Plugins.Add(new RazorFormat
            {
                LoadFromAssemblies = { typeof(CefResources).Assembly },
            });

            SetConfig(new HostConfig
            {
                DebugMode = true,
                EmbeddedResourceBaseTypes = { typeof(AppHost), typeof(CefResources) }
            });

            container.Register<IDbConnectionFactory>(c =>
                new OrmLiteConnectionFactory(":memory:", SqliteDialect.Provider));

            ImportData();
        }

        private void ImportData()
        {
            var dir = new FileSystemVirtualPathProvider(this, BaseDir ?? Config.WebHostPhysicalPath);

            var fileSettings = dir.GetFile("app.settings");
            var appSettings = fileSettings != null
                ? new DictionarySettings(fileSettings.ReadAllText().ParseKeyValueText(delimiter: " "))
                : new DictionarySettings();

            var fileServerLabels = dir.GetFile("server.labels");
            var serverLabels = fileServerLabels != null
                ? fileServerLabels.ReadAllText().ParseKeyValueText(delimiter: " ")
                : null;

            var fileTestLabels = dir.GetFile("test.labels");
            var testLabels = fileTestLabels != null
                ? fileTestLabels.ReadAllText().ParseKeyValueText(delimiter: " ")
                : null;

            using (var admin = Resolve<AdminServices>())
            {
                var db = admin.Db;
                db.DropAndCreateTable<TestPlan>();
                db.DropAndCreateTable<TestRun>();
                db.DropAndCreateTable<TestResult>();

                const int planId = 1;
                admin.CreateTestPlan(new TestPlan
                {
                    Id = planId,
                    Name = appSettings.Get("TestPlanName", "Benchmarks"),
                    ServerLabels = serverLabels,
                    TestLabels = testLabels,
                });

                var testRun = admin.CreateTestRun(planId);


                var files = UploadFile != null
                    ? dir.GetAllMatchingFiles(UploadFile)
                    : dir.GetAllMatchingFiles("*.txt")
                        .Concat(dir.GetAllMatchingFiles("*.zip"));

                admin.Request = new BasicRequest
                {
                    Files = files.Map(x => new HttpFile
                    {
                        ContentLength = x.Length,
                        ContentType = MimeTypes.GetMimeType(x.Name),
                        FileName = x.Name,
                        InputStream = x.OpenRead(),
                    } as IHttpFile).ToArray()
                };

                if (admin.Request.Files.Length > 0)
                {
                    admin.Post(new UploadTestResults
                    {
                        TestPlanId = 1,
                        TestRunId = testRun.Id,
                        CreateNewTestRuns = true,
                    });
                }
            }
        }

        public string BaseUrl { get; set; }
        public string BaseDir { get; set; }
        public string UploadFile { get; set; }

        public string GetStartUrl()
        {
            using (var db = Resolve<IDbConnectionFactory>().Open())
            {
                var testResult = db.Single<TestResult>(q => q.OrderBy(x => x.Id));
                var testPlan = testResult != null ? db.SingleById<TestPlan>(testResult.TestPlanId) : null;

                return testPlan != null
                    ? BaseUrl.CombineWith("{0}?id={1}".Fmt(testPlan.Slug, testResult.TestRunId))
                    : BaseUrl;
            }
        }
    }
}
