using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba_n2
{
    /// <summary>
    /// Класс-ошибка "Если на парковке уже заняты все места"
    /// </summary>
    class DepoOverflowException : Exception
    {
        public DepoOverflowException() : base("На парковке нет свободных мест")
        { }
    }
}
