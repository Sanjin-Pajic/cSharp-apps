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

namespace DLWMS.WinForms.IB200262.DB
{
    public partial class frmNovaKonsultacijaIB200262 : Form
    {
        Student _student = new Student();
        public frmNovaKonsultacijaIB200262(Student noviStudent)
        {
            InitializeComponent();
            _student = noviStudent;
        }

        private void frmNovaKonsultacijaIB200262_Load(object sender, EventArgs e)
        {
            comboBox1.DataSource = DLWMSdb.Baza.Predmeti.ToList();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var novaKonsultacija = new StudentKonsultacija()
            {
                Id = DLWMSdb.Baza.StudentiKonsultacije.Count() + 1,
                Student = _student,
                Predmet = comboBox1.SelectedItem as Predmet,
                VrijemeOdrzavanja = dateTimePicker1.Value,
                Napomena = textBox1.Text,
            };
            DLWMSdb.Baza.StudentiKonsultacije.Add(novaKonsultacija);
            DLWMSdb.Baza.SaveChanges();
            this.Close();
        }
    }
}
