using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WcfService.Logic
{
    public static class Factory
    {
        public static IMusicProcessor GetIMusicProcessorInstance()
        {
            return new MusicProcessor(new Utilities.DataAccess());
        }
    }
}
