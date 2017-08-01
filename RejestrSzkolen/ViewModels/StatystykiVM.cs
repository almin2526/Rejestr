using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace RejestrSzkolen.ViewModels
{
    public class StatystykiVM
    {
        [DataType(DataType.Date)]
        public DateTime? DataRejestracji { get; set; }
        public int LiczbaStudentow { get; set; }
    }
}