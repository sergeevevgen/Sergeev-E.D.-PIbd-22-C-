using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MonoRelsR
{
	public partial class FormMonoRels : Form
	{
		//Создание объекта от класса MonoRels
		MonoRels monor;

		//Конструктор
		public FormMonoRels()
		{
			InitializeComponent();
		}

		//Главная функция, отрисовывающая всю картинку
		private void Draw()
		{
			//создать объект от класса Bitmap, которое будет представлять из
			//себя «полотно», на котором будет отрисовываться монорельс
			Bitmap bmp = new Bitmap(pictureBoxMonoRels.Width, pictureBoxMonoRels.Height);
			//от объекта Bitmap получим объект Graphics, с помощью которого
			//будет отрисовываться монорельс
			Graphics gr = Graphics.FromImage(bmp);
			//вызвать метод отрисовки класса MonoRels для рисования
			//монорельса на полотне;
			monor.DrawTransport(gr);
			//передать полученный рисунок на pictureBox
			pictureBoxMonoRels.Image = bmp;
		}

		// Обработка нажатия "Стрелочек"
		private void buttonMove_Click(object sender, EventArgs e)
		{
			//Если объект инициализирован
			if (monor != null)
			{
				//получаем имя кнопки
				string name = (sender as Button).Name;
				switch (name)
				{
					case "buttonUp":
						monor.MoveTransport(Direction.Up);
						break;
					case "buttonDown":
						monor.MoveTransport(Direction.Down);
						break;
					case "buttonLeft":
						monor.MoveTransport(Direction.Left);
						break;
					case "buttonRight":
						monor.MoveTransport(Direction.Right);
						break;
				}
				Draw();
			}
		}

		// Обработка нажатия кнопки "Создать"
		private void buttonCreate_Click(object sender, EventArgs e)
		{

			Random rnd = new Random();
			monor = new MonoRels();
			monor.Init(rnd.Next(100, 300), rnd.Next(1000, 2000), Color.Red, Color.FromArgb(rnd.Next(1, 256), rnd.Next(1, 256), rnd.Next(1, 256)), true, true);
			monor.SetPosition(rnd.Next(10, 100), rnd.Next(10, 100), pictureBoxMonoRels.Width, pictureBoxMonoRels.Height);
			Draw();
		}
	}
}
