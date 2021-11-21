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
    public partial class FormDepo : Form
    {
        /// <summary>
        /// Объект от  класса-коллекции депо
        /// </summary>
        private readonly DepoCollection depoCollection;

        /// <summary>
        /// Конструктор
        /// </summary>
        public FormDepo()
        {
            InitializeComponent();
            depoCollection = new DepoCollection(pictureBoxDepo.Width, pictureBoxDepo.Height);
        }

        /// <summary>
        /// Заполнение listBoxLevels
        /// </summary>
        private void ReloadLevels()
        {
            int index = listBoxLevels.SelectedIndex;

            listBoxLevels.Items.Clear();
            for(int i = 0; i < depoCollection.Keys.Count; ++i)
            {
                listBoxLevels.Items.Add(depoCollection.Keys[i]);
            }

            if(listBoxLevels.Items.Count > 0 && (index == -1 || index >= listBoxLevels.Items.Count))
            {
                listBoxLevels.SelectedIndex = 0;
            }
            else if(listBoxLevels.Items.Count > 0 && index > -1 && 
                index < listBoxLevels.Items.Count)
            {
                listBoxLevels.SelectedIndex = index;
            }
            else if(listBoxLevels.Items.Count == 0)
                pictureBoxDepo.Image = null;
                
        }

        /// <summary>
        /// Метод отрисовки депо
        /// </summary>
        private void Draw()
        {
            if (listBoxLevels.SelectedIndex > -1)
            {
                Bitmap bmp = new Bitmap(pictureBoxDepo.Width, 
                    pictureBoxDepo.Height);
                Graphics gr = Graphics.FromImage(bmp);
                depoCollection[listBoxLevels.SelectedItem.ToString()].Draw(gr);
                pictureBoxDepo.Image = bmp;
            }
        }

        /// <summary>
        /// Обработка нажатия кнопки "Припарковать локомотив"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonSetLokomotiv_Click(object sender, EventArgs e)
        {
            if (listBoxLevels.SelectedIndex > -1)
            {
                ColorDialog dialog = new ColorDialog();
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    var lokomotiv = new Lokomotiv(100, 1000, dialog.Color);
                    if ((depoCollection[listBoxLevels.SelectedItem.ToString()] + lokomotiv) != -1)
                    {
                        Draw();
                    }
                    else
                    {
                        MessageBox.Show("Парковка переполнена");
                    }
                }
            }
        }

        /// <summary>
        /// Обработка нажатия кнопки "Припарковать Монорельс"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonSetMonoRels_Click(object sender, EventArgs e)
        {
            if (listBoxLevels.SelectedIndex > -1)
            {
                Random rnd = new Random();

                ColorDialog dialog = new ColorDialog();
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    ColorDialog dialogDop = new ColorDialog();
                    if (dialogDop.ShowDialog() == DialogResult.OK)
                    {
                        var lokomotiv = new MonoRels(100, 1000, dialog.Color, dialogDop.Color, true, true, rnd.Next(1, 4), rnd.Next(1, 4));
                        if ((depoCollection[listBoxLevels.SelectedItem.ToString()] + lokomotiv) != -1)
                        {
                            Draw();
                        }
                        else
                        {
                            MessageBox.Show("Парковка переполнена");
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Обработка нажатия кнопки "Забрать"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonTake_Click(object sender, EventArgs e)
        {
            if(listBoxLevels.SelectedIndex > -1 && maskedTextBoxTake.Text != "")
            {
                var lokomotiv = depoCollection[listBoxLevels.SelectedItem.ToString()] -
                    Convert.ToInt32(maskedTextBoxTake.Text);
                if(lokomotiv != null)
                {
                    FormLokomotiv form = new FormLokomotiv();
                    form.SetLokomotiv(lokomotiv);
                    form.ShowDialog();
                }
                Draw();
            }
        }

       
        /// <summary>
        /// Обработка нажатия кнопки "Добавить депо"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonAddDepo_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxNewLevelName.Text))
            {
                MessageBox.Show("Введите название депо", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            depoCollection.AddDepo(textBoxNewLevelName.Text);
            ReloadLevels();
        }

        /// <summary>
        /// Метод обработки выбора элемента на listBoxLevels
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listBoxLevels_SelectedIndexChanged(object sender, EventArgs e)
        {
            Draw();
        }

        /// <summary>
        /// Обработка нажатия кнопки "Удалить депо" 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonDeleteDepo_Click(object sender, EventArgs e)
        {
            //Удаляет выбранную парковку по имени, которое выбрано в ListBoxe
            if (listBoxLevels.SelectedIndex > -1)
            {
                if (MessageBox.Show($"Удалить парковку {listBoxLevels.SelectedItem.ToString()}?",
                    "Удаление", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    depoCollection.DelDepo(listBoxLevels.SelectedItem.ToString());
                    ReloadLevels();
                }
            }
        }
    }
}
