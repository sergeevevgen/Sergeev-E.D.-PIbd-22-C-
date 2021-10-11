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

		readonly Dictionary<string, Depo<Vehicle>> depoStages;

		public List<string> Keys => depoStages.Keys.ToList();

		private readonly int pictureWidth;

		private readonly int pictureHeight;


		public DepoCollection(int pictureWidth, int pictureHeight)
		{
			depoStages = new Dictionary<string, Depo<Vehicle>>();
			this.pictureWidth = pictureWidth;
			this.pictureHeight = pictureHeight;
		}

		public void AddDepo(string name)
		{
			if (!depoStages.ContainsKey(name))
				depoStages.Add(name, new Depo<Vehicle>(pictureWidth, pictureHeight));
		}

		public void DelDepo(string name)
		{
			if(depoStages.ContainsKey(name))
				depoStages.Remove(name);
		}

		public Depo<Vehicle> this[string ind]
		{
			
			get 
			{ 
				if(depoStages.ContainsKey(ind))
					return depoStages[ind];
				return null;
			}
		}
	}
}
