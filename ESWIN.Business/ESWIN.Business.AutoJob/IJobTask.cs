using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ESWIN.Util.Model;

namespace ESWIN.Business.AutoJob
{
    public interface IJobTask
    {
        Task<TData> Start();
    }
}
