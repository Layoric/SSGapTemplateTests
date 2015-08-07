using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using ServiceStack;

namespace BenchmarkAnalyzer
{
    public class Global : System.Web.HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            Licensing.RegisterLicense("DARREN-e1JlZjpEQVJSRU4sTmFtZTpEYXJyZW4gUmVpZCxUeXBlOkJ1c2luZXNzLEhhc2g6a3d2TFdaYmJSY2oydWNxTFp4NFh1L0t0eXdqaXBhUExlSFM4VlhodjducEt6cCtheDlvVWI4OTJPZ1FxUmNLZVVlbksxV3JQZUYybGYwdTYxMTFpc2p0Tm9QRDFGbGtweExpZUxmS05zQUErSkFUb1N3V0JwTk16d0g2SWF0ei9qY0dzdXBJcFVUVVk1RFUwUTJDK3Z3UkpoYWhlY0JPZVE1ajBrc0YxYkRnPSxFeHBpcnk6MjAyMC0wMS0yMn0=");
            new AppHost().Init();
        }
    }
}