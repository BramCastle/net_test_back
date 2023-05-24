using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace net_test.Models
{
    public class Menu
    {
        [Key]
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Icon { get; set; }
        public string Ruta { get; set; }
        public bool Deleted { get; set; } = false;
    }

}