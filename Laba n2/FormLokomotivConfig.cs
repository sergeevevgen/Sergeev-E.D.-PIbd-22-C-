using System;
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
    public partial class FormLokomotivConfig : Form
    {
        /// <summary>
        /// Поле-выбранный локомотив
        /// </summary>
        Vehicle lokomotiv = null;

        /// <summary>
        /// Событие
        /// </summary>
        private event Action<Vehicle> eventAddVehicle;

        /// <summary>
        /// Конструктор
        /// </summary>
        public FormLokomotivConfig()
        {
            InitializeComponent();
            //Привязывание к панелям события MouseDown
            panelBlack.MouseDown += panelColor_MouseDown;
            panelYellow.MouseDown += panelColor_MouseDown;
            panelBlue.MouseDown += panelColor_MouseDown;
            panelGray.MouseDown += panelColor_MouseDown;
            panelGreen.MouseDown += panelColor_MouseDown;
            panelOrange.MouseDown += panelColor_MouseDown;
            panelRed.MouseDown += panelColor_MouseDown;
            panelWhite.MouseDown += panelColor_MouseDown;

            //Лямбда-выражение
            buttonCancel.Click += (object sender, EventArgs e) => { Close(); };
        }

        /// <summary>
        /// Отрисовка локомотива/монорельса
        /// </summary>
        private void DrawLokomotiv()
        {
            if (lokomotiv != null)
            {
                Bitmap bmp = new Bitmap(pictureBoxShow.Width, pictureBoxShow.Height);
                Graphics gr = Graphics.FromImage(bmp);
                lokomotiv.SetPosition(5, 5, pictureBoxShow.Width, pictureBoxShow.Height);
                lokomotiv.DrawTransport(gr);
                pictureBoxShow.Image = bmp;
            }
        }

        /// <summary>
        /// Добавление события
        /// </summary>
        /// <param name="ev"></param>
        public void AddEvent(Action<Vehicle> ev)
        {
            if(eventAddVehicle == null)
            {
                eventAddVehicle = new Action<Vehicle>(ev);
            }
            else
            {
                eventAddVehicle += ev;
            }
        }

        /// <summary>
        /// Отправляем цвет с панели
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void panelColor_MouseDown(object sender, MouseEventArgs e)
        {
            if (sender is Panel)
            {
                (sender as Panel).DoDragDrop((sender as Panel).BackColor, DragDropEffects.Move |
                DragDropEffects.Copy);
            }
        }

        /// <summary>
        /// Передаем информацию (содержащийся текст) при нажатии на Label
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void labelLoko_MouseDown(object sender, MouseEventArgs e)
        {
            labelLoko.DoDragDrop(labelLoko.Text, DragDropEffects.Move |
            DragDropEffects.Copy);
        }

        /// <summary>
        /// Передаем информацию (содержащийся текст) при нажатии на Label
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void labelMono_MouseDown(object sender, MouseEventArgs e)
        {
            labelMono.DoDragDrop(labelMono.Text, DragDropEffects.Move |
            DragDropEffects.Copy);
        }

        /// <summary>
        /// Проверка  получаемой информации (соответствие её типа к требуемому)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void panelShow_DragEnter(object sender, DragEventArgs e)
        {
            if(e.Data.GetDataPresent(DataFormats.Text))
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        /// <summary>
        /// Действия при приеме перетаскиваемой информации
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void panelShow_DragDrop(object sender, DragEventArgs e)
        {
            switch (e.Data.GetData(DataFormats.Text).ToString())
            {
                case "Локомотив":
                    lokomotiv = new Lokomotiv((int)numericUpDownMaxSpeed.Value,
                        (int)numericUpDownWeight.Value, Color.White);
                    break;
                case "Монорельс":
                    lokomotiv = new MonoRels((int)numericUpDownMaxSpeed.Value,
                        (int)numericUpDownWeight.Value, Color.White, Color.Black, checkBoxLamp.Checked,
                        checkBoxAirCooler.Checked, (int)numericUpDownNumOfWins.Value,
                        (int)numericUpDownNumOfDoors.Value);
                    break;
            }
            DrawLokomotiv();
        }

        /// <summary>
        /// Проверка получаемой информации (соответствие её типа требуемому)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void labelMainC_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(Color)))
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        /// <summary>
        /// Принимаем основной цвет
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void labelMainC_DragDrop(object sender, DragEventArgs e)
        {
            if (lokomotiv != null)
                lokomotiv.SetMainColor((Color)e.Data.GetData(typeof(Color)));
            DrawLokomotiv();
        }

        /// <summary>
        /// Принимаем доп. цвет
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void labelDopColor_DragDrop(object sender, DragEventArgs e)
        {
            if (lokomotiv != null)
            {
                if (lokomotiv is MonoRels)
                {
                    (lokomotiv as MonoRels).SetDopColor((Color)e.Data.GetData(typeof(Color)));
                }
            }
            DrawLokomotiv();
        }

        /// <summary>
        /// Добавление локомотива/монорельса (запуск события, если оно непустое)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonAdd_Click(object sender, EventArgs e)
        {
            eventAddVehicle?.Invoke(lokomotiv);
            Close();
        }
    }
}
