using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BenchmarkAnalyzer.ServiceModel.Types;
using ServiceStack;

namespace BenchmarkAnalyzer.ServiceInterface
{
    public static class ModelExtensions
    {
        public static DisplayResult ToDisplayResult(this TestResult from)
        {
            var to = from.ConvertTo<DisplayResult>();
            to.Host = from.Hostname;
            return to;
        }
    }
}
