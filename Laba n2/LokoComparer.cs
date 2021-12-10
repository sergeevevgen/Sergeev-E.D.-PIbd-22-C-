using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba_n2
{
    class LokoComparer : IComparer<Vehicle>
    {
        /// <summary>
        /// Метод сравнения двух объектов типа "Vehicle"
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public int Compare(Vehicle x, Vehicle y)
        {
            var type1 = x.GetType().Name;
            var type2 = y.GetType().Name;
            //Если типы "Локомотив", то используем метод сравнения Локомотивов
            if(type1 == type2 && type1 == "Lokomotiv")
            {
                return ComparerLoko(x as Lokomotiv, y as Lokomotiv);
            }
            //Если типы "Монорельс", то используем метод сравнения Монорельс
            if (type1 == type2 && type1 == "MonoRels")
            {
                return ComparerMonoRels(x as MonoRels, y as MonoRels);
            }
            //Если типы не равны и первый из них "Локомотив",
            //то другой - "Монорельс" (Локомотив > Монорельс)
            if(type1 != type2 && type1 == "Lokomotiv")
            {
                return -1;
            }
            //Если типы не равны и первый из них не "Локомотив" (Монорельс),
            //то другой - "локомотив" (Локомотив > Монорельс)
            return 1;
        }

        /// <summary>
        /// Метод сравнения двух объектов типа "Lokomotiv"
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        private int ComparerLoko(Lokomotiv x, Lokomotiv y)
        {
            if(x.MaxSpeed != y.MaxSpeed)
            {
                return x.MaxSpeed.CompareTo(y.MaxSpeed);
            }
            if(x.Weight != y.Weight)
            {
                return x.Weight.CompareTo(y.Weight);
            }
            if(x.MainColor != y.MainColor)
            {
                return x.MainColor.Name.CompareTo(y.MainColor.Name);
            }
            return 0;
        }

        /// <summary>
        /// Метод сравнения двух объектов типа "MonoRels"
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        private int ComparerMonoRels(MonoRels x, MonoRels y)
        {
            var res = ComparerLoko(x, y);
            if (res != 0)
            {
                return res;
            }
            if (x.DopColor != y.DopColor)
            {
                return x.DopColor.Name.CompareTo(y.DopColor.Name);
            }
            if(x.NumOfDoors != y.NumOfDoors)
            {
                return x.NumOfDoors.CompareTo(y.NumOfDoors);
            }
            if(x.NumOfWins != y.NumOfWins)
            {
                return x.NumOfWins.CompareTo(y.NumOfWins);
            }
            if(x.Lamp != y.Lamp)
            {
                return x.Lamp.CompareTo(y.Lamp);
            }
            if(x.AirCooler != y.AirCooler)
            {
                return x.AirCooler.CompareTo(y.AirCooler);
            }
            return 0;
        }
    }
}
