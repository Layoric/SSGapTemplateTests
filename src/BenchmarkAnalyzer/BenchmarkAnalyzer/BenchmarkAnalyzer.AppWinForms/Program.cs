using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using CefSharp;
using ServiceStack;
using ServiceStack.Text;

namespace BenchmarkAnalyzer.AppWinForms
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Cef.Initialize(new CefSettings());

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Licensing.RegisterLicense("DARREN-e1JlZjpEQVJSRU4sTmFtZTpEYXJyZW4gUmVpZCxUeXBlOkJ1c2luZXNzLEhhc2g6a3d2TFdaYmJSY2oydWNxTFp4NFh1L0t0eXdqaXBhUExlSFM4VlhodjducEt6cCtheDlvVWI4OTJPZ1FxUmNLZVVlbksxV3JQZUYybGYwdTYxMTFpc2p0Tm9QRDFGbGtweExpZUxmS05zQUErSkFUb1N3V0JwTk16d0g2SWF0ei9qY0dzdXBJcFVUVVk1RFUwUTJDK3Z3UkpoYWhlY0JPZVE1ajBrc0YxYkRnPSxFeHBpcnk6MjAyMC0wMS0yMn0=");
            new AppHost().Init().Start("http://*:1337/");
            "ServiceStack SelfHost listening at {0} ".Fmt(HostUrl).Print();
            Application.Run(new FormMain());
        }

        public static string HostUrl = "http://localhost:1337/";
    }
}
