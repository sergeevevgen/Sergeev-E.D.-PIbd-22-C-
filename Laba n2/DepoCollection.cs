using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

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
        /// Разделитель для записи информации в файл
        /// </summary>
		private readonly char separator = ':';

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

		/// <summary>
		/// Сохранение информации по локомотивам в депо в файл
		/// </summary>
		/// <param name="filename">Путь и имя файла</param>
		/// <returns></returns>
		public void SaveData(string filename)
        {
			if(File.Exists(filename))
			{
				File.Delete(filename);
			}
			using (StreamWriter sw = new StreamWriter(filename))
            {
				//Последовательно записываем в файл строки
				sw.WriteLine("DepoCollection");
				foreach(var level in depoStages)
                {
					sw.WriteLine($"Depo{separator}{level.Key}");
					foreach(ITransport lokomotiv in level.Value)
                    {
						if(lokomotiv.GetType().Name == "Lokomotiv")
                        {
							sw.Write($"Lokomotiv{separator}");
                        }
						if(lokomotiv.GetType().Name == "MonoRels")
                        {
							sw.Write($"MonoRels{separator}");
                        }
						sw.WriteLine(lokomotiv);
                    }
                }
            }
        }

		/// <summary>
		/// Загрузка информации по локомотивам в депо из файла
		/// </summary>
		/// <param name="filename"></param>
		/// <returns></returns>
		public void LoadData(string filename)
        {
			if (!File.Exists(filename))
			{
				//Не найден файл!
				throw new FileNotFoundException();
			}
			
			//Последовательно считывает строки
			using (StreamReader sr = new StreamReader(filename))
            {
				string line = sr.ReadLine();
				if (line.Contains("DepoCollection"))
				{
					//Очищаем записи
					depoStages.Clear();
				}
				else
				{
					//Если нет такой строчки, то неверный формат данных
					throw new FormatException();
				}

				string key = string.Empty;
				Vehicle lokomotiv = null;
				while ((line = sr.ReadLine()) != null)
				{
					if (line.Contains("Depo"))
                    {
						key = line.Split(separator)[1];
						depoStages.Add(key, new Depo<Vehicle>(pictureWidth, pictureHeight));
						continue;
                    }
					else if(line.Contains("Lokomotiv"))
                    {
						lokomotiv = new Lokomotiv(line.Split(separator)[1]);
                    }
					else if (line.Contains("MonoRels"))
                    {
						lokomotiv = new MonoRels(line.Split(separator)[1]);
                    }
					//Добавляем объект в депо, если есть свободное место
					if((depoStages[key] + lokomotiv) == -1)
                    {
						//Ошибка загрузки транспорта
						throw new TypeLoadException();
                    }
                }
			}
        }
	}
}
