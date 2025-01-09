using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace schoollib_wpf.Models
{
    public class Reader
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? Patronymic { get; set; }
        public int Step { get; set; }
        public string? Parallel { get; set; }
        public ICollection<AttachedBook> Books { get; set; }

        public Reader()
        {
            Books = new List<AttachedBook>();
        }
    }
}
