using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactManagement.Core.Entity
{
    public class Contact:BaseEntity
    {
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Company { get; set; }
        public string Title { get; set; }
        public string House { get; set; }
        public string Street { get; set; }
        public string PObox { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }
    }
}
