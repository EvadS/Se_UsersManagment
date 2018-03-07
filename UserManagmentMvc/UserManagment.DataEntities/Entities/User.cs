using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserManagment.DataEntities.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string phoneNumber { get; set; }
        public string Patronymic { get; set; }
        public bool Employed { get; set; }
        public string OrganisationName { get; set; }
        public DateTime StartOnUTc { get; set; }
    }
}
