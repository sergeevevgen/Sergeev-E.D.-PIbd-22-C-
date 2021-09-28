﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Laba_n2
{
    public partial class FormLokomotiv : Form
    {
        private ITransport lokomotiv;
        public FormLokomotiv()
        {
            InitializeComponent();
        }

        private void Draw()
        {
            //создать объект от класса Bitmap, которое будет представлять из
            //себя «полотно», на котором будет рисовать автомобиль;
            Bitmap bmp = new Bitmap(pictureBoxLokomotiv.Width, pictureBoxLokomotiv.Height);
            //от объекта Bitmap получить объект Graphics, с помощью которого
            //будет отрисовываться автомобиль;
            Graphics gr = Graphics.FromImage(bmp);
            //Отрисовывает объект
            lokomotiv.DrawTransport(gr);
            //передать полученный рисунок на pictureBox
            pictureBoxLokomotiv.Image = bmp;
        }

        private void buttonCreateLokomotiv_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();
            lokomotiv = new Lokomotiv(rnd.Next(100,300), rnd.Next(1000,2000), Color.DarkRed);
            lokomotiv.SetPosition(rnd.Next(10,100), rnd.Next(10,100), pictureBoxLokomotiv.Width, pictureBoxLokomotiv.Height);
            Draw();
        }

        private void buttonCreateMonoRels_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();
            lokomotiv = new MonoRels(rnd.Next(100,300), rnd.Next(1000,2000), Color.DeepPink, Color.Red,
            true, true, rnd.Next(1,4), rnd.Next(1,4));
            lokomotiv.SetPosition(rnd.Next(10,100), rnd.Next(10,100), pictureBoxLokomotiv.Width,
            pictureBoxLokomotiv.Height);
            Draw();
        }

        // Обработка нажатия "Стрелочек"
        private void buttonMove_Click(object sender, EventArgs e)
        {
            if (lokomotiv != null)
            {
                //получаем имя кнопки
                string name = (sender as Button).Name;
                switch (name)
                {
                    case "buttonUp":
                        lokomotiv.MoveTransport(Direction.Up);
                        break;
                    case "buttonDown":
                        lokomotiv.MoveTransport(Direction.Down);
                        break;
                    case "buttonLeft":
                        lokomotiv.MoveTransport(Direction.Left);
                        break;
                    case "buttonRight":
                        lokomotiv.MoveTransport(Direction.Right);
                        break;
                }
                Draw();
            }
        }
    }
}
