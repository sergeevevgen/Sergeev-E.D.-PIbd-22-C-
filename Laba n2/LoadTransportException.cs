using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba_n2
{
    class LoadTransportException : Exception
    {
        public LoadTransportException(Vehicle loko) : base("Не удалось загрузить " + ((Lokomotiv) loko).ToString() + " в депо") { }
    }
}
