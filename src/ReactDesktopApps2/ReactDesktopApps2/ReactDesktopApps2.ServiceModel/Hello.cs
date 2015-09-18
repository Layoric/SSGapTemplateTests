using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ServiceStack;

namespace ReactDesktopApps2.ServiceModel
{
    [Route("/hello/{Name}")]
    public class Hello : IReturn<HelloResponse>
    {
        public string Name { get; set; }
    }

    public class HelloResponse
    {
        public string Result { get; set; }
    }
}