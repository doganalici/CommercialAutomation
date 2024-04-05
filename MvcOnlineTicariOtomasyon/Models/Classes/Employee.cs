﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Classes
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string FirstName { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string LastName { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(250)]
        public string Image { get; set; }

        public ICollection<SalesActivities> SalesActivitiess { get; set; }
        public int DepartmentId { get; set; }
        public virtual Department Department { get; set; }
    }
}