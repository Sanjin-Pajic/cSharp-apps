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
    public partial class frmKonsultacijeIB200262 : Form
    {
        Student _student = new WinForms.Student();
        public frmKonsultacijeIB200262(Student noviStudent)
        {
            InitializeComponent();
            _student = noviStudent;
        }

        private void frmKonsultacijeIB200262_Load(object sender, EventArgs e)
        {
            dataGridView1.AutoGenerateColumns = false;
            UcitajKonsultacije();
        }

        private void UcitajKonsultacije()
        {
            try
            {
                var listaStudenata = DLWMSdb.Baza.StudentiKonsultacije.Where(x => x.Student.Id == _student.Id).ToList();
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = listaStudenata;
                label2.Text = _student.ToString();
                this.Text = "Broj zapisa konsultacija: " + listaStudenata.Count.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + Environment.NewLine + ex.InnerException?.Message);
            }


        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex==4)
            {
                IzbrisiKonsultaciju();
            }
        }

        private void IzbrisiKonsultaciju()
        {
            var trenutnaKonsultacija = dataGridView1.SelectedRows[0].DataBoundItem as StudentKonsultacija;
            DLWMSdb.Baza.StudentiKonsultacije.Remove(trenutnaKonsultacija);
            DLWMSdb.Baza.SaveChanges();
            UcitajKonsultacije();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //var novaForma = new frmNovaKonsultacijaIB200262(_student).ShowDialog();
            var novaForma = new frmNovaKonsultacijaIB200262(_student).ShowDialog();
            UcitajKonsultacije();
        }
    }
}
