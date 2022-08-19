using DLWMS.WinForms.DB;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DLWMS.WinForms.IB200262
{
    public partial class frmPretragaIB200262 : Form
    {
        public frmPretragaIB200262()
        {
            InitializeComponent();
        }

        private void frmPretragaIB200262_Load(object sender, EventArgs e)
        {
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = DLWMSdb.Baza.Studenti.ToList();
            comboBox1.Text = comboBox1.Items[0].ToString();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            Filtriraj();
        }

        private void Filtriraj()
        {
            var filterIme = textBox1.Text.ToLower();
            var filterGodina = int.Parse(comboBox1.Text);
            if (string.IsNullOrEmpty(filterIme) || string.IsNullOrWhiteSpace(filterIme))
                dataGridView1.DataSource = DLWMSdb.Baza.Studenti.ToList();
            else
            {
                var listaStudenata = DLWMSdb.Baza.Studenti.Where(x => x.ImePrezime.ToLower().Contains(filterIme) && x.GodinaStudija == filterGodina).ToList();
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = listaStudenata;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Filtriraj();
        }
    }
}
