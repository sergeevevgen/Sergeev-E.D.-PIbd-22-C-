using System.Collections.Generic;
using System.Collections;
using System.Drawing;
namespace Laba_n2
{
    /// <summary>
    /// Параметризованный класс для хранения набора объектов от интерфейса ITransport
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Depo<T> : IEnumerator<T>, IEnumerable<T>
        where T : class, ITransport
    {
        /// <summary>
        /// Лист хранимых объектов
        /// </summary>
        private readonly List<T> _places;

        /// <summary>
        /// Максимальное кол-во мест в депо
        /// </summary>
        private readonly int _maxCount;

        /// <summary>
        /// Ширина окна отрисовки депо
        /// </summary>
        private readonly int pictureWidth;

        /// <summary>
        /// Высота окна отрисовки депо
        /// </summary>
        private readonly int pictureHeight;

        /// <summary>
        /// Ширина места в депо
        /// </summary>
        private readonly int _placeSizeWidth = 140;

        /// <summary>
        /// Высота места в депо
        /// </summary>
        private readonly int _placeSizeHeight = 70;

        /// <summary>
        /// Текущий элемент для вывода через IEnumerator (будет обращаться по своему 
        /// индексу к ключу словаря, по которому будет возвращаться запись)
        /// </summary>
        private int _currentIndex;

        /// <summary>
        /// Текущий элемент
        /// </summary>
        public T Current => _places[_currentIndex];

        /// <summary>
        /// Текущий элемент
        /// </summary>
        object IEnumerator.Current => _places[_currentIndex];

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="picWidth" - ширина окна отрисовки></param>
        /// <param name="picHeight" - высота окна отрисовки></param>
        public Depo(int picWidth, int picHeight)
        {
            int width = picWidth / _placeSizeWidth;
            int height = picHeight / _placeSizeHeight;
            _maxCount = width * height;
            pictureWidth = picWidth;
            pictureHeight = picHeight;
            _places = new List<T>();
            _currentIndex = -1;
        }

        /// <summary>
        /// Перегрузка оператора сложения
        /// Логика действия: в депо добавляется локомотив/монорельс
        /// </summary>
        /// <param name="d" - Депо></param>
        /// <param name="lokomotiv" - добавляемый локомотив/монорельс></param>
        /// <returns></returns>
        public static int operator +(Depo<T> d, T lokomotiv)
        {
            if (d._places.Count >= d._maxCount)
            {
                //Переполнение депо
                throw new DepoOverflowException();
            }
            if(d._places.Contains(lokomotiv))
            {
                throw new DepoAlreadyHaveException();
            }

            d._places.Add(lokomotiv);
            return d._places.Count - 1;
        }

        /// <summary>
        /// Перегрузка оператора вычитания
        /// Логика действия: из депо забираем локомотив/монорельс
        /// </summary>
        /// <param name="d">Депо</param>
        /// <param name="index">Индекс места, с которого пытемся извлечь объект</param>
        /// <returns></returns>
        public static T operator -(Depo<T> d, int index)
        {
            if (index > -1 && index < d._places.Count)
            {
                var dopLoko = d._places[index];
                d._places.RemoveAt(index);
                return dopLoko;
            }
            //Не найдено место
            throw new DepoPlaceNotFoundException(index);
        }

        /// <summary>
        /// Метод отрисовки депо
        /// </summary>
        /// <param name="g"></param>
        public void Draw(Graphics g)
        {
            //Отрисовка линий разметки
            DrawMarking(g);

            //Отрисовка объектов
            int x = 17, y = 10;
            for(int i = 0; i < _places.Count; ++i)
            {
                if (i % (pictureWidth / _placeSizeWidth) == 0 && i != 0)
                {
                    y += 70;
                    x = 17;
                }
                _places[i].SetPosition(x, y, 1, 1);
                _places[i].DrawTransport(g);
                x += 140;
            }
        }

        /// <summary>
        /// Метод отрисовки линий разметки
        /// </summary>
        /// <param name="g"></param>
        private void DrawMarking(Graphics g)
        {
            Pen pen = new Pen(Color.Black, 3);

            for(int i = 0; i < pictureWidth / _placeSizeWidth; i++)
            {
                for(int j = 0; j < pictureHeight / _placeSizeHeight + 1; j++)
                {
                    //Горизонтальные линии
                    g.DrawLine(pen, i * _placeSizeWidth, j * _placeSizeHeight, i *
                    _placeSizeWidth + _placeSizeWidth / 2, j * _placeSizeHeight);
                }
                //Вертикальные линии
                g.DrawLine(pen, i * _placeSizeWidth, 0, i * _placeSizeWidth,
                (pictureHeight / _placeSizeHeight) * _placeSizeHeight);
            }
        }

        /// <summary>
        /// Функция получения элемента из списка
        /// </summary>
        /// <param name="index">номер элемента</param>
        /// <returns></returns>
        public T GetNext(int index)
        {
            if(index > -1 && index < _places.Count)
            {
                return _places[index];
            }
            return null;
        }

        /// <summary>
        /// Сортировка локомотивов в депо
        /// </summary>
        public void Sort() => _places.Sort((IComparer<T>)new LokoComparer());

        /// <summary>
        /// Метод интерфейса IEnumerator, вызываемый при удалении объекта
        /// </summary>
        public void Dispose()
        { }

        /// <summary>
        /// Метод интерфейса IEnumerator для перехода к следующему элементу или к началу коллекции
        /// </summary>
        /// <returns></returns>
        public bool MoveNext()
        {
            if (_currentIndex < _places.Count - 1)
            {
                _currentIndex++;
                return true;
            }
            _currentIndex = -1;
            return false;
        }

        /// <summary>
        /// Метод интерфейса IEnumerator для сброса и возврата к началу коллекции
        /// </summary>
        public void Reset()
        {
            _currentIndex = -1;
        }

        /// <summary>
        /// Метод интерфейса IEnumerable
        /// </summary>
        /// <returns></returns>
        public IEnumerator<T> GetEnumerator()
        {
            return this;
        }

        /// <summary>
        /// Метод интерфейса IEnumerable
        /// </summary>
        /// <returns></returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this;
        }
    }
}
