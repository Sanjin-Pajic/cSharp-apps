using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLWMS.WinForms.IB200262.DB
{
    [Table("StudentKonsultacije")]
    public class StudentKonsultacija
    {
        public int Id { get; set; }
        public virtual Student Student { get; set; }
        public virtual Predmet Predmet { get; set; }
        public DateTime VrijemeOdrzavanja { get; set; }
        public string Napomena { get; set; }
    }
}
