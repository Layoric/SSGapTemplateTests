using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BenchmarkAnalyzer.ServiceModel.Types;
using ServiceStack;

namespace BenchmarkAnalyzer.ServiceModel
{
    [Route("/testplans/{Id}/edit")]
    [Route("/testplans/{Id}/testruns/{TestRunId}/edit")]
    public class EditTestPlan : IReturn<TestPlan>
    {
        public int Id { get; set; }
        public int? TestRunId { get; set; }
    }

    public class EditTestPlanResponse
    {
        public int Id { get; set; }
        public int? TestRunId { get; set; }
        public string Name { get; set; }
        public string Slug { get; set; }
        public Dictionary<string, string> ServerLabels { get; set; }
        public Dictionary<string, string> TestLabels { get; set; }
        public DateTime CreatedDate { get; set; }

        public ResponseStatus ResponseStatus { get; set; }
    }
}
