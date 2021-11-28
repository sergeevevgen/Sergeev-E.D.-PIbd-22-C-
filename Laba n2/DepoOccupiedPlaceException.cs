using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba_n2
{
    /// <summary>
    /// Класс-ошибка Если выбранное место занято
    /// </summary>
    class DepoOccupiedPlaceException : Exception 
    {
        public DepoOccupiedPlaceException() : base("Место занято")
        { }
    }
}
