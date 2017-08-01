using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RejestrSzkolen.DAL
{
    public class RejestrRepository
    {
        public ViewModels.IndexVM GetStudentsIndexVM(string sortOrder, string currentFilter, string searchString, int? page)
        {
            using (var db = new RejestrContext())
            {
                db.Database.Log = Console.Write;
                var students = db.Studenci.AsQueryable();
                if (!String.IsNullOrEmpty(searchString))
                {
                    students = students.Where(s =>
                                       (s.Imie + " " + s.Nazwisko).ToUpper().Contains(searchString.ToUpper())
                                       ||
                                       (s.Nazwisko + " " + s.Imie).ToUpper().Contains(searchString.ToUpper())
                                );
                }
                switch (sortOrder)
                {
                    case "name_desc":
                        students = students.OrderByDescending(s => s.Nazwisko);
                        break;
                    case "Date":
                        students = students.OrderBy(s => s.DataRejestracji);
                        break;
                    case "date_desc":
                        students = students.OrderByDescending(s => s.DataRejestracji);
                        break;
                    default:
                        students = students.OrderBy(s => s.Nazwisko);
                        break;
                }

                if (searchString != null)
                {
                    page = 1;
                }
                else
                {
                    searchString = currentFilter;
                }
              
                int pageSize = 3;
                int pageNumber = (page ?? 1);
                var list = students.ToPagedList(pageNumber, pageSize);
                
                var vm = new ViewModels.IndexVM()
                {
                    NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "",
                    DateSortParm = sortOrder == "Date" ? "date_desc" : "Date",
                    CurrentFilter = searchString,
                    CurrentSort = sortOrder,
                    Lista = students.ToPagedList(pageNumber, pageSize)
                };

                return vm;
            }
        }
    }
}