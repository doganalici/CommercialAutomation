using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Classes
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30,ErrorMessage ="En fazla 30 karakter yazabilirsiniz!")]
        [Required(ErrorMessage = "Bu alanı boş geçemezsiniz!")]
        public string FirstName { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30,ErrorMessage = "En fazla 30 karakter yazabilirsiniz!")]
        [Required(ErrorMessage ="Bu alanı boş geçemezsiniz!")]
        public string LastName { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(17, ErrorMessage = "En fazla 17 karakter yazabilirsiniz!")]
        [Required(ErrorMessage = "Bu alanı boş geçemezsiniz!")]
        public string City { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(50, ErrorMessage = "En fazla 50 karakter yazabilirsiniz!")]
        [Required(ErrorMessage = "Bu alanı boş geçemezsiniz!")]
        public string Mail { get; set; }

        public bool Status { get; set; }
        public ICollection<SalesActivities> SalesActivitiess { get; set; }


    }
}