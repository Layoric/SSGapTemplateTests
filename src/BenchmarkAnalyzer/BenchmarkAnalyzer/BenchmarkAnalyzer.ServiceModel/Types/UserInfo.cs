using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BenchmarkAnalyzer.ServiceModel.Types
{
    public class UserInfo
    {
        public int Id { get; set; }
        public int UserAuthId { get; set; }
        public string DisplayName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ProfileUrl64 { get; set; }
    }
}
