using RejestrSzkolen.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PagedList;

namespace RejestrSzkolen.ViewModels
{
    public class IndexVM
    {
        public IPagedList<Student> Lista { get; set; }
        public string NameSortParm { get; set; }
        public string DateSortParm { get; set; }
        public string CurrentSort { get; set; }
        public string CurrentFilter { get; set; }
    }
}