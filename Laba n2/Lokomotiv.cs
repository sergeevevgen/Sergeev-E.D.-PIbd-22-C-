using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Laba_n2
{
    class Lokomotiv : Vehicle, IEquatable<Lokomotiv>
    {
        /// <summary>
        /// Ширина отрисовки монорельса
        /// </summary>
        private readonly int lokomotivWidth = 105;

        /// <summary>
        /// Высота отрисовки монорельса
        /// </summary>
        private readonly int lokomotivHeight = 50;

        /// <summary>
        /// Разделитель для записи информации по объекту в файл
        /// </summary>
        protected readonly char separator = ';';

        /// <summary>
        /// Конструктор для создания локомотива
        /// </summary>
        /// <param name="maxSpeed" - максимальная скорость Локомотива></param>
        /// <param name="weight" - вес локомотива></param>
        /// <param name="mainColor" - основной цвет локомотива></param>
        public Lokomotiv(int maxSpeed, int weight, Color mainColor)
        {
            MaxSpeed = maxSpeed;
            Weight = weight;
            MainColor = mainColor;
        }

        /// <summary>
        /// Конструктор для дочернего класса, чтобы создавать Монорельс
        /// </summary>
        /// <param name="maxSpeed" - максимальная скорость></param>
        /// <param name="weight" - вес></param>
        /// <param name="mainColor" - основной цвет></param>
        /// <param name="lokomotivWidth" - ширина объекта></param>
        /// <param name="lokomotivHeight" - высота объекта></param>
        protected Lokomotiv(int maxSpeed, int weight, Color mainColor, int lokomotivWidth, int lokomotivHeight)
        {
            MaxSpeed = maxSpeed;
            Weight = weight;
            MainColor = mainColor;
            this.lokomotivWidth = lokomotivWidth;
            this.lokomotivHeight = lokomotivHeight;
        }

        
        /// <summary>
        /// Конструктор для  загрузки с файла
        /// </summary>
        /// <param name="info">Информация по объекту</param>
        public Lokomotiv(string info)
        {
            string[] strs = info.Split(separator);
            if(strs.Length == 3)
            {
                MaxSpeed = Convert.ToInt32(strs[0]);
                Weight = Convert.ToInt32(strs[1]);
                MainColor = Color.FromName(strs[2]);
            }
        }

        /// <summary>
        /// Метод изменения направления движения
        /// </summary>
        /// <param name="direction" - направление></param>
        public override void MoveTransport(Direction direction)
        {
            //один "шаг"
            int step = MaxSpeed * 100 / Weight;
            switch (direction)
            {
                // вправо
                case Direction.Right:
                    if (_startPosX + step < _pictureWidth - lokomotivWidth)
                    {
                        _startPosX += step;
                    }
                    break;
                //влево
                case Direction.Left:
                    if (_startPosX - step > 0)
                    {
                        _startPosX -= step;
                    }
                    break;
                //вверх
                case Direction.Up:
                    if (_startPosY - step > 0)
                    {
                        _startPosY -= step;
                    }
                    break;
                //вниз
                case Direction.Down:
                    if (_startPosY + step < _pictureHeight - lokomotivHeight)
                    {
                        _startPosY += step;
                    }
                    break;
            }
        }

        /// <summary>
        /// Отрисовка Локомотива
        /// </summary>
        /// <param name="g" - объект класса Graphics, в котором будет находиться мой транспорт></param>
        public override void DrawTransport(Graphics g)
        {
            //Создание карандаша и кисти для рисования
            Pen pen = new Pen(Color.Black);
            Brush brush = new SolidBrush(Color.White);

            //Отрисовка верхней части кузова монорельса
            Point[] points = new Point[] { new Point(((int)_startPosX) + 7, (int)_startPosY), new Point(((int)_startPosX) + 97, (int)_startPosY), new Point(((int)_startPosX) + 97, ((int)_startPosY) + 17),
            new Point(((int)_startPosX) + 2, ((int)_startPosY) + 17) };
            g.FillPolygon(brush, points);
            g.DrawPolygon(pen, points);

            //Отрисовка нижней части кузова монорельса
            brush = new SolidBrush(MainColor);
            points = new Point[] { new Point(((int)_startPosX) + 2, ((int)_startPosY) + 17), new Point(((int)_startPosX) + 97, ((int)_startPosY) + 17), new Point(((int)_startPosX) + 97, ((int)_startPosY) + 34),
            new Point(((int)_startPosX) + 2, ((int)_startPosY) + 34) };
            g.FillPolygon(brush, points);
            g.DrawPolygon(pen, points);

            //Отрисовка трансмиссии
            brush = new SolidBrush(Color.Black);
            //левая часть
            points = new Point[] { new Point(((int)_startPosX) + 3, ((int)_startPosY) + 34), new Point(((int)_startPosX) + 2, ((int)_startPosY) + 35), new Point(((int)_startPosX) + 1, ((int)_startPosY) + 36),
            new Point(((int)_startPosX), ((int)_startPosY) + 37), new Point(((int)_startPosX) - 1, ((int)_startPosY) + 38), new Point(((int)_startPosX), ((int)_startPosY) + 39), new Point(((int)_startPosX) + 1, ((int)_startPosY) + 40),
            new Point(((int)_startPosX) + 7, ((int)_startPosY) + 40), new Point(((int)_startPosX) + 7, ((int)_startPosY) + 39), new Point(((int)_startPosX) + 8, ((int)_startPosY) + 38), new Point(((int)_startPosX) + 9, ((int)_startPosY) + 37),
            new Point(((int)_startPosX) + 10, ((int)_startPosY) + 36), new Point(((int)_startPosX) + 10, ((int)_startPosY) + 35)};
            g.FillPolygon(brush, points);
            //средняя часть н1
            points = new Point[] { new Point(((int)_startPosX) + 10, ((int)_startPosY) + 35), new Point(((int)_startPosX) + 11, ((int)_startPosY) + 36), new Point(((int)_startPosX) + 12, ((int)_startPosY) + 37), new Point(((int)_startPosX) + 13, ((int)_startPosY) + 38),
            new Point(((int)_startPosX) + 14, ((int)_startPosY) + 39), new Point(((int)_startPosX) + 15, ((int)_startPosY) + 40), new Point(((int)_startPosX) + 29, ((int)_startPosY) + 40), new Point(((int)_startPosX) + 30, ((int)_startPosY) + 39),
            new Point(((int)_startPosX) + 31, ((int)_startPosY) + 38), new Point(((int)_startPosX) + 32, ((int)_startPosY) + 37), new Point(((int)_startPosX) + 33, ((int)_startPosY) + 36), new Point(((int)_startPosX) + 34, ((int)_startPosY) + 35)};
            g.FillPolygon(brush, points);
            //средняя часть н2
            points = new Point[] { new Point(((int)_startPosX) + 61, ((int)_startPosY) + 35), new Point(((int)_startPosX) + 62, ((int)_startPosY) + 36), new Point(((int)_startPosX) + 63, ((int)_startPosY) + 37),
            new Point(((int)_startPosX) + 64, ((int)_startPosY) + 38), new Point(((int)_startPosX) + 65, ((int)_startPosY) + 39), new Point(((int)_startPosX) + 66, ((int)_startPosY) + 40), new Point(((int)_startPosX) + 79, ((int)_startPosY) + 40), new Point(((int)_startPosX) + 80, ((int)_startPosY) + 39),
            new Point(((int)_startPosX) + 81, ((int)_startPosY) + 38), new Point(((int)_startPosX) + 82, ((int)_startPosY) + 37), new Point(((int)_startPosX) + 83, ((int)_startPosY) + 36), new Point(((int)_startPosX) + 84, ((int)_startPosY) + 35)};
            g.FillPolygon(brush, points);
            //задняя часть
            points = new Point[] { new Point(((int)_startPosX) + 96, ((int)_startPosY) + 34), new Point(((int)_startPosX) + 97, ((int)_startPosY) + 35), new Point(((int)_startPosX) + 98, ((int)_startPosY) + 36),
            new Point(((int)_startPosX) + 99, ((int)_startPosY) + 37), new Point(((int)_startPosX) + 100, ((int)_startPosY) + 38), new Point(((int)_startPosX) + 99, ((int)_startPosY) + 39), new Point(((int)_startPosX) + 98, ((int)_startPosY) + 40),
            new Point(((int)_startPosX) + 94, ((int)_startPosY) + 40), new Point(((int)_startPosX) + 93, ((int)_startPosY) + 39), new Point(((int)_startPosX) + 92, ((int)_startPosY) + 38), new Point(((int)_startPosX) + 91, ((int)_startPosY) + 37),
            new Point(((int)_startPosX) + 90, ((int)_startPosY) + 36), new Point(((int)_startPosX) + 89, ((int)_startPosY) + 36), new Point(((int)_startPosX) + 84, ((int)_startPosY) + 35)};
            g.FillPolygon(brush, points);

            //Отрисовка колёс
            brush = new SolidBrush(Color.White);
            g.FillEllipse(brush, _startPosX + 8, _startPosY + 35, 11, 11);
            g.FillEllipse(brush, _startPosX + 30, _startPosY + 35, 11, 11);
            g.FillEllipse(brush, _startPosX + 58, _startPosY + 35, 11, 11);
            g.FillEllipse(brush, _startPosX + 80, _startPosY + 35, 11, 11);
            //Заливка колёс цветом
            g.DrawEllipse(pen, _startPosX + 8, _startPosY + 35, 11, 11);
            g.DrawEllipse(pen, _startPosX + 30, _startPosY + 35, 11, 11);
            g.DrawEllipse(pen, _startPosX + 58, _startPosY + 35, 11, 11);
            g.DrawEllipse(pen, _startPosX + 80, _startPosY + 35, 11, 11);
             
            //Отрисовка задней части кузова
            brush = new SolidBrush(Color.Black);
            g.FillRectangle(brush, _startPosX + 97, _startPosY + 3, 5, 28);

            //Отрисовка окна
            pen = new Pen(Color.Blue);
            brush = new SolidBrush(Color.Aquamarine);
            g.DrawRectangle(pen, _startPosX + 9, _startPosY + 3, 8, 11);
            g.FillRectangle(brush, _startPosX + 10, _startPosY + 4, 7, 10);

            //Отрисовка двери
            brush = new SolidBrush(Color.White);
            pen = new Pen(Color.Black);
            g.DrawRectangle(pen, _startPosX + 32, _startPosY + 3, 8, 28);
            g.FillRectangle(brush, _startPosX + 33, _startPosY + 4, 7, 27);
        }


        /// Переопределение метода ToString() для записи информации об объекте в файл
        public override string ToString()
        {
            return $"{MaxSpeed}{separator}{Weight}{separator}{MainColor.Name}";
        }

        /// <summary>
        /// Метод интерфейса IEquatable для класса Lokomotiv
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool Equals(Lokomotiv other)
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
            if (!(obj is Lokomotiv lokoObj))
                return false;
            else
                return Equals(lokoObj);
        }
    }
}
