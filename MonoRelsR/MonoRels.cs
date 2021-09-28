using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace MonoRelsR
{
    /// <summary>
    /// Класс отрисовки монорельса
    /// </summary>

    class MonoRels
    {
        Random r = new Random();
        /// <summary>
        /// Координата Х отрисовки монорельса
        /// </summary>
        private int _startPosX;

        /// <summary>
        /// Координата Y отрисовки монорельса
        /// </summary>
        private int _startPosY;

        /// <summary>
        /// Ширина окна отрисовки
        /// </summary>
        private int _pictureWidth = 900;

        /// <summary>
        /// Высота окна отрисовки
        /// </summary>
        private int _pictureHeight = 500;

        /// <summary>
        /// Ширина отрисовки монорельса
        /// </summary>
        private readonly int monoRelsWidth = 105;

        /// <summary>
        /// Высота отрисовки монорельса
        /// </summary>
        private readonly int monoRelsHeight = 50;

        /// <summary>
        /// Максимальная скорость монорельса
        /// </summary>
        public int MaxSpeed { private set; get; }

        /// <summary>
        /// Вес монорельса
        /// </summary>
        public int Weight { private set; get; }

        /// <summary>
        /// Основной цвет кузова верхней части
        /// </summary>
        public Color MainColor { private set; get; }

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

        /// <summary>
        /// Признак наличия фар
        /// </summary>
        public bool Lamp { private set; get; }

        ///<summary>
        /// Признак наличия воздухозаборников
        /// </summary>
        public bool AirCooler { private set; get; }

        /// <summary>
        /// Инициализация свойств (скорость, масса, основной цвет, второй основной цвет, дополнительный цвет, признак наличия фары, признак наличия воздухозаборников)
        /// </summary>
        public void Init(int maxSpeed, int weight, Color mainColor, Color dopColor, bool lamp, bool airCooler)
        {
            MaxSpeed = maxSpeed;
            Weight = weight;
            MainColor = mainColor;
            DopColor = dopColor;
            Lamp = lamp;
            AirCooler = airCooler;
            NumOfDoors = r.Next(1, 4);
            NumOfWins = r.Next(1, 4);
        }

        /// <summary>
        /// Установка позиции автомобиля
        /// </summary>
        /// <param name="x">Координата X</param>
        /// <param name="y">Координата Y</param>
        /// <param name="width">Ширина картинки</param>
        /// <param name="height">Высота картинки</param>
        public void SetPosition(int x, int y, int width, int height)
        {
            _startPosX = x;
            _startPosY = y;
            _pictureWidth = width;
            _pictureHeight = height;
        }

        /// <summary>
        /// Изменение направления перемещения
        /// </summary>
        public void MoveTransport(Direction direction)
        {
            int step = MaxSpeed * 100 / Weight;
            switch (direction)
            {
                // вправо
                case Direction.Right:
                    if (_startPosX + step < _pictureWidth - monoRelsWidth)
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
                    if (_startPosY + step < _pictureHeight - monoRelsHeight)
                    {
                        _startPosY += step;
                    }
                    break;
            }
        }

        /// <summary>
        /// Отрисовка монорельса
        /// </summary>
        public void DrawTransport(Graphics g)
        {
            //Создание карандаша и кисти для рисования
            Pen pen = new Pen(Color.Black);
            Brush brush = new SolidBrush(MainColor);

            //Отрисовка верхней части кузова монорельса
            Point[] points = new Point[] { new Point(_startPosX + 7, _startPosY), new Point(_startPosX + 97, _startPosY), new Point(_startPosX + 97, _startPosY + 17),
            new Point(_startPosX + 2, _startPosY + 17) };
            g.FillPolygon(brush, points);
            g.DrawPolygon(pen, points);

            //Отрисовка нижней части кузова монорельса
            brush = new SolidBrush(DopColor);
            points = new Point[] { new Point(_startPosX + 2, _startPosY + 17), new Point(_startPosX + 97, _startPosY + 17), new Point(_startPosX + 97, _startPosY + 34),
            new Point(_startPosX + 2, _startPosY + 34) };
            g.FillPolygon(brush, points);
            g.DrawPolygon(pen, points);

            //Отрисовка трансмиссии
            brush = new SolidBrush(Color.Black);
            points = new Point[] { new Point(_startPosX + 2, _startPosY + 34), new Point(_startPosX + 15, _startPosY + 40), new Point(_startPosX + 84, _startPosY + 40), new Point(_startPosX + 97, _startPosY + 34) };
            g.FillPolygon(brush, points);
            g.DrawPolygon(pen, points);

            //Отрисовка задней части
            brush = new SolidBrush(Color.Black);
            g.FillRectangle(brush, _startPosX + 97, _startPosY + 3, 5, 28);

            //Отрисовка фар
            if (Lamp)
            {
                brush = new SolidBrush(Color.Yellow);
                g.DrawRectangle(pen, _startPosX + 2, _startPosY + 24, 6, 5);
                g.FillRectangle(brush, _startPosX + 3, _startPosY + 25, 5, 4);
            }

            //Отрисовка воздухозаборников
            if (AirCooler)
            {
                brush = new SolidBrush(Color.White);
                g.DrawRectangle(pen, _startPosX + 18, _startPosY - 5, 17, 5);
                g.FillRectangle(brush, _startPosX + 19, _startPosY - 4, 16, 4);
                g.DrawRectangle(pen, _startPosX + 75, _startPosY - 5, 17, 5);
                g.FillRectangle(brush, _startPosX + 76, _startPosY - 4, 16, 4);
            }

            //Отрисовка окон
            pen = new Pen(Color.Blue);
            if (NumOfWins >= 1)
            {
                brush = new SolidBrush(Color.White);
                g.DrawRectangle(pen, _startPosX + 9, _startPosY + 3, 8, 11);
                g.FillRectangle(brush, _startPosX + 10, _startPosY + 4, 7, 10);
            }
            if (NumOfWins >= 2)
            {
                brush = new SolidBrush(Color.White);
                g.DrawRectangle(pen, _startPosX + 19, _startPosY + 3, 8, 11);
                g.FillRectangle(brush, _startPosX + 20, _startPosY + 4, 7, 10);
            }
            if (NumOfWins == 3)
            {
                brush = new SolidBrush(Color.White);
                g.DrawRectangle(pen, _startPosX + 86, _startPosY + 3, 8, 11);
                g.FillRectangle(brush, _startPosX + 87, _startPosY + 4, 7, 10);
            }

            //Отрисовка дверей
            if (NumOfDoors >= 1)
            {
                brush = new SolidBrush(DopColor);
                pen = new Pen(Color.Black);
                g.DrawRectangle(pen, _startPosX + 32, _startPosY + 3, 8, 28);
                g.FillRectangle(brush, _startPosX + 33, _startPosY + 4, 7, 27);
            }
            if (NumOfDoors >= 2)
            {
                g.DrawRectangle(pen, _startPosX + 50, _startPosY + 3, 8, 28);
                g.FillRectangle(brush, _startPosX + 51, _startPosY + 4, 7, 27);
            }
            if (NumOfDoors == 3)
            {
                g.DrawRectangle(pen, _startPosX + 68, _startPosY + 3, 8, 28);
                g.FillRectangle(brush, _startPosX + 69, _startPosY + 4, 7, 27);
            }
        }
    }
}
