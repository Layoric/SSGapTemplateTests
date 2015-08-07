using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceStack;

namespace BenchmarkAnalyzer.ServiceModel
{
    [Route("/ping")]
    public class Ping { } //healthcheck by AWS

    public class PingResponse
    {
        public string Result { get; set; }
        public ResponseStatus ResponseStatus { get; set; }
    }
}
