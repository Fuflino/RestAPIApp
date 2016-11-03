using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL.Entities
{
    public class Status : AbstractEntity
    {
        public string Statuses { get; set; }
        public List<User> Users { get; set; }
    }
}
