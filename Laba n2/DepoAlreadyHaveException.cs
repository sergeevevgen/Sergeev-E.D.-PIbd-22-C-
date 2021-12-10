using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba_n2
{
    /// <summary>
    /// Класс-ошибка "Если на парковке уже есть локомотив с такими же характеристиками"
    /// </summary>
    class DepoAlreadyHaveException : Exception
    {
        /// <summary>
        /// Конструктор
        /// </summary>
        public DepoAlreadyHaveException() : base("В депо уже есть такой локомотив") { }
    }
}
