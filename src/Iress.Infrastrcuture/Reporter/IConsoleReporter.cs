using System;
using System.Collections.Generic;
using System.Text;

namespace Iress.Infrastrcuture.Reporter
{
    public interface IConsoleReporter
    {
        void Report(string message);
    }
}
