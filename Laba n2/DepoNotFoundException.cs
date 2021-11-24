using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba_n2
{
    /// <summary>
    /// Класс-ошибка Если не найден локомотив/монорельс по определенному месту
    /// </summary>
    class DepoNotFoundException : Exception
    {
        public DepoNotFoundException(int i) : base("Не найден автомобиль по месту" + i)
        { }
    }
}
