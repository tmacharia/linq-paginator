using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Common
{
    public enum HttpVerb
    {
        [Description("GET Request")]
        GET,
        [Description("POST Request")]
        POST
    }
}
