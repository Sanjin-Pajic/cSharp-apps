using DLWMS.WinForms.DB;
using DLWMS.WinForms.IB200262.DB;
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
            dataGridView1.AutoGenerateColumns = false;
        }

        private void frmPretragaIB200262_Load(object sender, EventArgs e)
        {
            UcitajRezultate();
            
        }

        private void UcitajRezultate()
        {
            var filter = textBox1.Text.ToLower();
            var listaStudenata = DLWMSdb.Baza.StudentiPredmeti.ToList();
            if (!string.IsNullOrEmpty(filter))
                listaStudenata = DLWMSdb.Baza.StudentiPredmeti.Where(x => x.Predmet.Naziv.ToLower().Contains(filter)).ToList();
            dataGridView1.DataSource = listaStudenata;
            this.Text = "Ukupno zapisa: " + listaStudenata.Count.ToString();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            UcitajRezultate();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex==4)
            {
                if (MessageBox.Show("Da li zelite izbrisati zapis?", "Upozorenje", MessageBoxButtons.YesNo) == DialogResult.Yes){
                    var trenutniZapis = dataGridView1.SelectedRows[0].DataBoundItem as StudentPredmet;
                    DLWMSdb.Baza.StudentiPredmeti.Remove(trenutniZapis);
                    DLWMSdb.Baza.SaveChanges();
                    UcitajRezultate();
                }
            }
            else if (e.ColumnIndex == 5)
            {
                var odabraniStudent = dataGridView1.SelectedRows[0].DataBoundItem as StudentPredmet;
                var novaForma = new frmStudentSlikeIB200262(odabraniStudent).ShowDialog();
            }
        }
    }
}
