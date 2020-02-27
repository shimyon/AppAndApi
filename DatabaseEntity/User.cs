using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseEntity
{
    public class User : _BaseEntity
    {
        [StringLength(50)]
        public string UserName { get; set; }

        [StringLength(50)]
        public string Email { get; set; }

        [StringLength(50)]
        public string FirstName { get; set; }


        [StringLength(50)]
        public string SurName { get; set; }

        [StringLength(100)]
        public string Password { get; set; }

        public string Address { get; set; }

    }
}
