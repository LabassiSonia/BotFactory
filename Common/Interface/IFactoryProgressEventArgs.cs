using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Common.Interface
{
    public interface IFactoryProgressEventArgs
    {
        object Bot { get; set; }
    }
}