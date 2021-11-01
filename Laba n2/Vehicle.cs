using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Laba_n2
{
    public abstract class Vehicle : ITransport
    {
        /// <summary>
        /// Левая координата отрисовки транспортного средства
        /// </summary>
        protected float _startPosX;

        /// <summary>
        /// Правая кооридната отрисовки транспортного средства
        /// </summary>
        protected float _startPosY;

        /// <summary>
        /// Ширина окна отрисовки
        /// </summary>
        protected int _pictureWidth;

        /// <summary>
        /// Высота окна отрисовки
        /// </summary>
        protected int _pictureHeight;

        /// <summary>
        /// Максимальная скорость транспортного средства
        /// </summary>
        public int MaxSpeed { protected set; get; }

        /// <summary>
        /// Вес транспортного средства
        /// </summary>
        public int Weight { protected set; get; }

        /// <summary>
        /// Основной цвет кузова
        /// </summary>
        public Color MainColor { protected set; get; }

        /// <summary>
        /// Установка начальной позиции
        /// </summary>
        /// <param name="x" - координата по оси X></param>
        /// <param name="y" - координата по оси Y></param>
        /// <param name="width" - ширина PictureBoxa приложения></param>
        /// <param name="height" - длина PictureBoxa приложения></param>
        public void SetPosition(int x, int y, int width, int height)
        {
            _startPosX = x;
            _startPosY = y;
            _pictureWidth = width;
            _pictureHeight = height;
        }

        /// <summary>
        /// Установка основного цвета
        /// </summary>
        /// <param name="color"></param>
        public void SetMainColor(Color color)
        {
            MainColor = color;
        }

        /// <summary>
        /// Отрисовка
        /// </summary>
        /// <param name="g" - объект класса Graphics, в котором будет находиться мой транспорт></param>
        public abstract void DrawTransport(Graphics g);

        /// <summary>
        /// Изменение направления движения
        /// </summary>
        /// <param name="direction" - направление (берется из перечисления Enum)></param>
        public abstract void MoveTransport(Direction direction);
    }
}
