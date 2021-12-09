using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Laba_n2
{
    class MonoRels : Lokomotiv, IEquatable<MonoRels>
    {
        /// <summary>
        /// Дополнительный цвет
        /// </summary>
        public Color DopColor { private set; get; }

        /// <summary>
        /// Кол-во дверей
        /// </summary>
        public int NumOfDoors { private set; get; }

        /// <summary>
        /// Кол-во окон 
        /// </summary>
        public int NumOfWins { private set; get; }

        ///<summary>
        /// Признак наличия фар
        /// </summary>
        public bool Lamp { private set; get; }

        ///<summary>
        /// Признак наличия воздухозаборников
        /// </summary>
        public bool AirCooler { private set; get; }

        /// <summary>
        /// Конструктор класса
        /// </summary>
        /// <param name="maxSpeed" - максимальная скорость></param>
        /// <param name="weight" - вес></param>
        /// <param name="mainColor" - основной цвет></param>
        /// <param name="dopColor" - дополнительный цвет></param>
        /// <param name="lamp" - признак наличия фар></param>
        /// <param name="airCooler" - признак наличия воздухозаборников></param>
        /// <param name="numOfWins" - кол-во окон></param>
        /// <param name="numOfDoors" - кол-во дверей></param>
        public MonoRels(int maxSpeed, int weight, Color mainColor, Color dopColor,
        bool lamp, bool airCooler, int numOfWins, int numOfDoors) : base(maxSpeed, weight, mainColor, 105, 50)
        {
            DopColor = dopColor;
            Lamp = lamp;
            AirCooler = airCooler;
            NumOfWins = numOfWins;
            NumOfDoors = numOfDoors;
        }

        /// <summary>
        /// Конструктор для загрузки с файла
        /// </summary>
        /// <param name="info">Информация</param>
        public MonoRels(string info) : base(info)
        {
            string[] strs = info.Split(separator);
            if(strs.Length == 8)
            {
                MaxSpeed = Convert.ToInt32(strs[0]);
                Weight = Convert.ToInt32(strs[1]);
                MainColor = Color.FromName(strs[2]);
                DopColor = Color.FromName(strs[3]);
                NumOfDoors = Convert.ToInt32(strs[4]);
                NumOfWins = Convert.ToInt32(strs[5]);
                Lamp = Convert.ToBoolean(strs[6]);
                AirCooler = Convert.ToBoolean(strs[7]);
            }
        }

        /// <summary>
        /// Отрисовка Монорельса
        /// </summary>
        /// <param name="g" - объект класса Graphics, в котором будет находиться мой транспорт></param>
        public override void DrawTransport(Graphics g)
        {
            //Отрисовка основной части монорельса с помощью метода базового класса
            base.DrawTransport(g);
            
            //Отрисовка дополнительных элементов
            //создание кисти и карандаша
            Pen pen = new Pen(Color.Black);

            //Отрисовка новой трансмиссии
            Brush brush = new SolidBrush(Color.Black);
            Point[] points = new Point[] { new Point(((int)_startPosX) - 3, ((int)_startPosY) + 34),
            new Point(((int)_startPosX) + 9, ((int)_startPosY) + 46), new Point(((int)_startPosX) + 90, ((int)_startPosY) + 46),
            new Point(((int)_startPosX) + 102, ((int)_startPosY) + 34) };
            g.FillPolygon(brush, points);
            g.DrawPolygon(pen, points);

            //Отрисовка фары
            if (Lamp)
            {
                brush = new SolidBrush(Color.Yellow);
                g.DrawRectangle(pen, _startPosX + 2, _startPosY + 24, 6, 5);
                g.FillRectangle(brush, _startPosX + 3, _startPosY + 25, 5, 4);
            }

            //Отрисовка воздухозаборников
            if (AirCooler)
            {
                brush = new SolidBrush(DopColor);
                g.DrawRectangle(pen, _startPosX + 18, _startPosY - 5, 17, 5);
                g.FillRectangle(brush, _startPosX + 19, _startPosY - 4, 16, 4);
                g.DrawRectangle(pen, _startPosX + 75, _startPosY - 5, 17, 5);
                g.FillRectangle(brush, _startPosX + 76, _startPosY - 4, 16, 4);
            }

            //Отрисовка окон
            pen = new Pen(Color.Blue);
            if (NumOfWins >= 2)
            {
                brush = new SolidBrush(Color.Aquamarine);
                g.DrawRectangle(pen, _startPosX + 19, _startPosY + 3, 8, 11);
                g.FillRectangle(brush, _startPosX + 20, _startPosY + 4, 7, 10);
            }
            if (NumOfWins >= 3)
            {
                g.DrawRectangle(pen, _startPosX + 86, _startPosY + 3, 8, 11);
                g.FillRectangle(brush, _startPosX + 87, _startPosY + 4, 7, 10);
            }

            //Отрисовка дверей
            if (NumOfDoors >= 2)
            {
                pen = new Pen(Color.Black);
                brush = new SolidBrush(Color.White);
                g.DrawRectangle(pen, _startPosX + 50, _startPosY + 3, 8, 28);
                g.FillRectangle(brush, _startPosX + 51, _startPosY + 4, 7, 27);
            }
            if (NumOfDoors >= 3)
            {
                g.DrawRectangle(pen, _startPosX + 68, _startPosY + 3, 8, 28);
                g.FillRectangle(brush, _startPosX + 69, _startPosY + 4, 7, 27);
            }
        }

        /// <summary>
        /// Метод для смены доп. цвета
        /// </summary>
        /// <param name="color"></param>
        public void SetDopColor(Color color)
        {
            DopColor = color;
        }

        //Переопределение метода ToString() у базового класса
        public override string ToString()
        {
            return $"{base.ToString()}{separator}{DopColor.Name}{separator}{NumOfDoors}{separator}{NumOfWins}{separator}{Lamp}{separator}{AirCooler}";
        }

        /// <summary>
        /// Метод интерфейса IEquatable для класса SportCar
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool Equals(MonoRels other)
        {
            if (other == null)
                return false;
            if (GetType().Name != other.GetType().Name)
                return false;
            if (MaxSpeed != other.MaxSpeed)
                return false;
            if (Weight != other.Weight)
                return false;
            if (MainColor != other.MainColor)
                return false;
            if (DopColor != other.DopColor)
                return false;
            if (NumOfDoors != other.NumOfDoors)
                return false;
            if (NumOfWins != other.NumOfWins)
                return false;
            if (Lamp != other.Lamp)
                return false;
            if (AirCooler != other.AirCooler)
                return false;

            return true;
        }

        /// <summary>
        /// Перегрузка метода от object
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            if (!(obj is MonoRels monoObj))
                return false;
            else
                return Equals(monoObj);
        }
    }
}
