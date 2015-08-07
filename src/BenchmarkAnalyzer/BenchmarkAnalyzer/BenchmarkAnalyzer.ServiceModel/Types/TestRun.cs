using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceStack.DataAnnotations;

namespace BenchmarkAnalyzer.ServiceModel.Types
{
    public class TestRun
    {
        [AutoIncrement]
        public int Id { get; set; }
        public int UserAuthId { get; set; }
        public int TestPlanId { get; set; }
        public string SeriesId { get; set; }
        public DateTime CreatedDate { get; set; }

        [Ignore]
        public int TestResultsCount { get; set; }
    }
}
