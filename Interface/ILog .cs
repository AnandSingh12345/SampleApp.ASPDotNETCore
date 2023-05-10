using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleApp.ASPDotNETCore.Interface
{
    public interface ILog
    {
        void Information(string message);       
        void Error(string message);
    }
}
