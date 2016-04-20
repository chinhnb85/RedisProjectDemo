using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RequireJsDemo.Responsive
{
    public interface ICacheStatus
    {
        bool IsCacheEnabled { get; }
        bool IsCacheRunning { get; }
    }
}