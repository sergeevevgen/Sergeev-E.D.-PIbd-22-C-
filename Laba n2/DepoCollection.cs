using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
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
		/// Метод записи информации в файл
		/// </summary>
		/// <param name="text">>Строка, которую следует записать</param>
		/// <param name="stream">Поток для записи</param>
		/*private void WriteToFile(string text, FileStream stream)
        {
			byte[] info = new UTF8Encoding(true).GetBytes(text);
			stream.Write(info, 0, info.Length);
        }*/

		/// <summary>
		/// Сохранение информации по локомотивам в депо в файл
		/// </summary>
		/// <param name="filename">Путь и имя файла</param>
		/// <returns></returns>
		public bool SaveData(string filename)
        {
			if(File.Exists(filename))
			{
				File.Delete(filename);
			}
			using (StreamWriter sw = new StreamWriter(filename))
            {
				sw.WriteLine("DepoCollection");
				foreach(var level in depoStages)
                {
					sw.WriteLine($"Depo{separator}{level.Key}");
					ITransport lokomotiv = null;
					for(int i = 0; (lokomotiv = level.Value.GetNext(i)) != null; i++)
                    {
						if(lokomotiv != null)
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
			return true;
        }

		/// <summary>
		/// Сохранение информации по локомотивам в депо в файл
		/// </summary>
		/// <param name="filename">Путь и имя файла</param>
		/// <returns></returns>
		/*public bool SaveData(string filename)
        {
			if(File.Exists(filename))
            {
				File.Delete(filename);
            }
			using (FileStream fs = new FileStream(filename, FileMode.Create))
            {
				WriteToFile($"DepoCollection{Environment.NewLine}", fs);
				foreach (var level in depoStages)
                {
					//Начинаем упаковку
					WriteToFile($"Depo{separator}{level.Key}{Environment.NewLine}", fs);
					ITransport lokomotiv = null;
					for(int i = 0; (lokomotiv = level.Value.GetNext(i)) != null; i++)
                    {
						if(lokomotiv != null)
                        {
							//Если место непустое
							//Записываем тип локомотива
							if (lokomotiv.GetType().Name == "Lokomotiv")
                            {
								WriteToFile($"Lokomotiv{separator}", fs);
                            }
							if(lokomotiv.GetType().Name == "MonoRels")
                            {
								WriteToFile($"MonoRels{separator}", fs);
							}
							//Записываем характеристики
							WriteToFile(lokomotiv + Environment.NewLine, fs);
                        }
                    }
				}
            }
			return true;
        }*/


		/// <summary>
		/// Загрузка информации по локомотивам в депо из файла
		/// </summary>
		/// <param name="filename"></param>
		/// <returns></returns>
		public bool LoadData(string filename)
        {
			if (!File.Exists(filename))
			{
				return false;
			}
			
			using (StreamReader sr = new StreamReader(filename))
            {
				string line = sr.ReadLine();
				if (line.Contains("DepoCollection"))
				{
					depoStages.Clear();
				}
				else
				{
					return false;
				}

				Vehicle lokomotiv = null;
				string key = string.Empty;
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
					if((depoStages[key] + lokomotiv) == -1)
                    {
						return false;
                    }
					
                }
			}
			return true;
        }
		/// <summary>
        /// Загрузка информации по локомотивам в депо из файла
        /// </summary>
        /// <param name="filename"></param>
        /// <returns></returns>
		/*public bool LoadData(string filename)
        {
			if(!File.Exists(filename))
            {
				return false;
            }
			string bufferTextFromFile = "";
			using (FileStream fs = new FileStream(filename, FileMode.Open))
			{
				byte[] b = new byte[fs.Length];
				UTF8Encoding temp = new UTF8Encoding(true);
				while (fs.Read(b, 0, b.Length) > 0)
				{
					bufferTextFromFile += temp.GetString(b);
				}
			}
			bufferTextFromFile = bufferTextFromFile.Replace("\r", "");
			var strs = bufferTextFromFile.Split('\n');
			if (strs[0].Contains("DepoCollection"))
			{
				//очищаем записи
				depoStages.Clear();
			}
			else
			{
				//если нет такой записи, то это не те данные
				return false;
			}
			Vehicle lokomotiv = null;
			string key = string.Empty;
			for(int i = 1; i < strs.Length; ++i)
            {
				if(strs[i].Contains("Depo"))
                {
					key = strs[i].Split(separator)[1];
					depoStages.Add(key, new Depo<Vehicle>(pictureWidth, pictureHeight));
					continue;
                }

				if(string.IsNullOrEmpty(strs[i]))
                {
					continue;
                }

				if(strs[i].Split(separator)[0] == "Lokomotiv")
                {
					lokomotiv = new Lokomotiv(strs[i].Split(separator)[1]);
                }
				else if(strs[i].Split(separator)[0] == "MonoRels")
                {
					lokomotiv = new MonoRels(strs[i].Split(separator)[1]);
                }
				var result = depoStages[key] + lokomotiv;
				if (result == -1)
					return false;
            }
			return true;
		}*/
	}
}
