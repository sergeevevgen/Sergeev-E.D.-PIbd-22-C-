using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba_n2
{
	/// <summary>
	/// Класс-коллекция депо
	/// </summary>
	public class DepoCollection
    {
		/// <summary>
		/// Словарь (хранилище) с депо
		/// </summary>
		readonly Dictionary<string, Depo<Vehicle>> depoStages;

		/// <summary>
		/// Возвращение списка названий депо
		/// </summary
		public List<string> Keys => depoStages.Keys.ToList();

		/// <summary>
		/// Ширина окна отрисовки
		/// </summary>
		private readonly int pictureWidth;

		/// <summary>
		/// Высота окна отрисовки
		/// </summary>
		private readonly int pictureHeight;


		/// <summary>
		/// Конструктор
		/// </summary>
		/// <param name="pictureWidth">Ширина окна отрисовки</param>
		/// <param name="pictureHeight">Высота окна отрисовки</param>
		public DepoCollection(int pictureWidth, int pictureHeight)
		{
			depoStages = new Dictionary<string, Depo<Vehicle>>();
			this.pictureWidth = pictureWidth;
			this.pictureHeight = pictureHeight;
		}

		/// <summary>
		/// Добавление парковки
		/// </summary>
		/// <param name="name">Название парковки</param>
		public void AddDepo(string name)
		{
			if (!depoStages.ContainsKey(name))
				depoStages.Add(name, new Depo<Vehicle>(pictureWidth, pictureHeight));
		}

		/// <summary>
		/// Удаление парковки
		/// </summary>
		/// <param name="name">Название парковки</param>
		public void DelDepo(string name)
		{
			if (depoStages.ContainsKey(name))
				depoStages.Remove(name);
		}

		/// <summary>
		/// Доступ к парковке через индексатор
		/// </summary>
		/// <param name="ind">индекс элемента</param>
		/// <returns></returns>
		public Depo<Vehicle> this[string ind]
		{
			get
			{
				if (depoStages.ContainsKey(ind))
					return depoStages[ind];
				return null;
			}
		}
	}
}
