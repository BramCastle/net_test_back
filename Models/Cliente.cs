using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace net_test.Models
{
    public class Cliente
    {
        [Key]
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string RFC { get; set; }
        public DateTime CreatedFecha { get; set; }
        public string CreatedFechaNatural => this.CreatedFecha.ToString("dd/MM/yyyy hh:mm");
        public DateTime UpdatedFecha { get; set; }
        public string UpdatedFechaNatural => this.UpdatedFecha.ToString("dd/MM/yyyy hh:mm");
        public bool Deleted { get; set; } = false;
    }
}