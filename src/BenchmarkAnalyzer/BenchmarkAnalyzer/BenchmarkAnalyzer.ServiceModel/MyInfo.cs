using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceStack;

namespace BenchmarkAnalyzer.ServiceModel
{
    [Route("/myinfo")]
    public class MyInfo { }

    [Route("/reset")]
    public class Reset { }
}
