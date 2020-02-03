using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiWithDI.Models
{
    public class TodoItem
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public bool IsComplete { get; set; }

    }
}
