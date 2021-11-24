using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba_n2
{
    /// <summary>
    /// Класс-ошибка Если неверный формат данных
    /// </summary>
    class DataBadFormatException : Exception
    {
        public DataBadFormatException() : base("Неверный формат данных в файле")
        { }
    }
}
