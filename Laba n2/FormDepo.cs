using System;
using NLog;
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
        /// Логгер
        /// </summary>
        private readonly Logger logger;

        /// <summary>
        /// Констурктор
        /// </summary>
        public FormDepo()
        {
            InitializeComponent();
            depoCollection = new DepoCollection(pictureBoxDepo.Width, pictureBoxDepo.Height);
            logger = LogManager.GetCurrentClassLogger();
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
        /// Обработка нажатия кнопки "Забрать"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonTake_Click(object sender, EventArgs e)
        {
            if(listBoxLevels.SelectedIndex > -1 && maskedTextBoxTake.Text != "")
            {
                try
                {
                    var lokomotiv = depoCollection[listBoxLevels.SelectedItem.ToString()] -
                   Convert.ToInt32(maskedTextBoxTake.Text);

                    if (lokomotiv != null)
                    {
                        FormLokomotiv form = new FormLokomotiv();
                        form.SetLokomotiv(lokomotiv);
                        form.ShowDialog();
                        logger.Info("Изъят локомотив/монорельс " + lokomotiv + " с места " + maskedTextBoxTake.Text);
                        Draw();
                    }
                }
                catch(DepoPlaceNotFoundException ex)
                {
                    logger.Warn(ex.Message);
                    MessageBox.Show(ex.Message, "Не найдено", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch(Exception ex)
                {
                    logger.Warn(ex.Message);
                    MessageBox.Show(ex.Message, "Неизвестная ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
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
                logger.Warn("Не введено название депо");
                return;
            }
            logger.Info("Добавили депо " + textBoxNewLevelName.Text);
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
            logger.Info("Перешли в депо " + listBoxLevels.SelectedItem.ToString());
            Draw();
        }

        /// <summary>
        /// Обработка нажатия кнопки "Удалить депо" 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonDeleteDepo_Click(object sender, EventArgs e)
        {
            //Удаляет выбранную парковку в ListBoxe
            if (listBoxLevels.SelectedIndex > -1)
            {
                if (MessageBox.Show($"Удалить депо {listBoxLevels.SelectedItem.ToString()}?",
                    "Удаление", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    logger.Info("Удалили депо " + listBoxLevels.SelectedItem.ToString());
                    depoCollection.DelDepo(listBoxLevels.SelectedItem.ToString());
                    ReloadLevels();
                }
            }
        }

        /// <summary>
        /// Обработка нажатия на кнопку добавить (открывается форма с выбором конфигурации объекта)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonAddLoko_Click(object sender, EventArgs e)
        {
            if (listBoxLevels.SelectedIndex > -1)
            {
                var formLokoConfig = new FormLokomotivConfig();
                formLokoConfig.AddEvent(AddLoko);
                formLokoConfig.Show();
            }
        }

        /// <summary>
        /// Метод добавления объекта
        /// </summary>
        /// <param name="loko"></param>
        private void AddLoko(Vehicle loko)
        {
            if(loko != null && listBoxLevels.SelectedIndex > -1)
            {
                try
                {
                    if (depoCollection[listBoxLevels.SelectedItem.ToString()] + loko != -1)
                    {
                        Draw();
                        logger.Info("Добавлен локомотив/монорельс " + loko);
                    }
                    else
                    {
                        logger.Warn("Локомотив/Монорельс не удалось поставить(");
                        MessageBox.Show("Локомотив/Монорельс не удалось поставить(");
                    }
                    Draw();
                }
                catch (DepoOverflowException ex)
                {
                    logger.Warn(ex.Message);
                    MessageBox.Show(ex.Message, "Переполнение", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (DepoAlreadyHaveException ex)
                {
                    logger.Warn(ex.Message);
                    MessageBox.Show(ex.Message, "Дублирование", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    logger.Warn(ex.Message);
                    MessageBox.Show(ex.Message, "Неизвестная ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        /// Обработка нажатия на пункт меню "Сохранить"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    depoCollection.SaveData(saveFileDialog.FileName);
                    MessageBox.Show("Сохранение прошло успешно", "Результат",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    logger.Info("Сохранено в файл " + saveFileDialog.FileName);
                }
                catch (Exception ex)
                {
                    logger.Warn(ex.Message);
                    MessageBox.Show(ex.Message, "Неизвестная ошибка при сохранении", MessageBoxButtons.OK,
                       MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        /// Обработка нажатия на пункт меню "Загрузить"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void загрузитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    depoCollection.LoadData(openFileDialog.FileName);
                    MessageBox.Show("Загрузили", "Результат", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    logger.Info("Загружено из файла " + openFileDialog.FileName);
                    ReloadLevels();
                    Draw();
                }
                catch (DepoOccupiedPlaceException ex)
                {
                    logger.Warn(ex.Message);
                    MessageBox.Show(ex.Message, "Занятое место", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    logger.Warn(ex.Message);
                    MessageBox.Show(ex.Message, "Неизвестная ошибка при загрузке", MessageBoxButtons.OK,
                       MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        /// Обработка нажатия на кнопку "Сортировать"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonSort_Click(object sender, EventArgs e)
        {
            if (listBoxLevels.SelectedIndex > -1)
            {
                depoCollection[listBoxLevels.SelectedItem.ToString()].Sort();
                Draw();
                logger.Info("Сортировка уровней");
            }
        }
    }
}
