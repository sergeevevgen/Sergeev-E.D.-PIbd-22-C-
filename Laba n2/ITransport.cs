using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Laba_n2
{
    //Интерфейс транспорта
    public interface ITransport
    {
        /// <summary>
        /// Установка начальной позиции
        /// </summary>
        /// <param name="x" - координата по оси X></param>
        /// <param name="y" - координата по оси Y></param>
        /// <param name="width" - ширина PictureBoxa приложения></param>
        /// <param name="height" - длина PictureBoxa приложения></param>
        void SetPosition(int x, int y, int width, int height);

        /// <summary>
        /// Отрисовка
        /// </summary>
        /// <param name="g" - объект класса Graphics, в котором будет находиться мой транспорт></param>
        void DrawTransport(Graphics g);

        /// <summary>
        /// Изменение направления движения
        /// </summary>
        /// <param name="direction" - направление (берется из перечисления Enum)></param>
        void MoveTransport(Direction direction);

        /// <summary>
        /// Смена основного цвета
        /// </summary>
        /// <param name="color">Цвет</param>
        void SetMainColor(Color color);
    }
}
