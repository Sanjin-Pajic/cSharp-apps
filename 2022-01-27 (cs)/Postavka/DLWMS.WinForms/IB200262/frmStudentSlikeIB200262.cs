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
using DLWMS.WinForms.Helpers;

namespace DLWMS.WinForms.IB200262
{
    public partial class frmStudentSlikeIB200262 : Form
    {
        StudentPredmet _student = new StudentPredmet();
        public frmStudentSlikeIB200262(StudentPredmet noviStudent)
        {
            InitializeComponent();
            _student = noviStudent;
        }

        private void frmStudentSlikeIB200262_Load(object sender, EventArgs e)
        {   
        }
    }
}
