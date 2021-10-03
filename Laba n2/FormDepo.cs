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
        /// Объект от  класса-депо
        /// </summary>
        private readonly Depo<Lokomotiv> depo;

        /// <summary>
        /// Констурктор
        /// </summary>
        public FormDepo()
        {
            InitializeComponent();
            depo = new Depo<Lokomotiv>(pictureBoxDepo.Width, pictureBoxDepo.Height);
            Draw();
        }

        /// <summary>
        /// Метод отрисовки депо
        /// </summary>
        private void Draw()
        {
            Bitmap bmp = new Bitmap(pictureBoxDepo.Width, pictureBoxDepo.Height);
            Graphics gr = Graphics.FromImage(bmp);
            depo.Draw(gr);
            pictureBoxDepo.Image = bmp;
        }

        /// <summary>
        /// Обработка нажатия кнопки "Припарковать локомотив"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonSetLokomotiv_Click(object sender, EventArgs e)
        {
            ColorDialog dialog = new ColorDialog();
            if(dialog.ShowDialog() == DialogResult.OK)
            {
                var lokomotiv = new Lokomotiv(100, 1000, dialog.Color);
                if(depo + lokomotiv)
                {
                    Draw();
                }
                else
                {
                    MessageBox.Show("Парковка переполнена");
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
            Random rnd = new Random();
            ColorDialog dialog = new ColorDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                ColorDialog dialogDop = new ColorDialog();
                if (dialogDop.ShowDialog() == DialogResult.OK)
                {
                    var lokomotiv = new MonoRels(100, 1000, dialog.Color, dialogDop.Color, true, true, rnd.Next(1,4), rnd.Next(1,4));
                    if (depo + lokomotiv)
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
        /// Обработка нажатия кнопки "Забрать"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonTake_Click(object sender, EventArgs e)
        {
            if(maskedTextBoxTake.Text != "")
            {
                var lokomotiv = depo - Convert.ToInt32(maskedTextBoxTake.Text);
                if(lokomotiv != null)
                {
                    FormLokomotiv form = new FormLokomotiv();
                    form.SetLokomotiv(lokomotiv);
                    form.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Это место не занято!");
                }
                Draw();
            }
        }
    }
}
