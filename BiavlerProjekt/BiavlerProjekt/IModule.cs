using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;

namespace BiavlerProjekt
{
    public interface IModule
    {
        void Initialize(SimpleContainer container);
    }
}
