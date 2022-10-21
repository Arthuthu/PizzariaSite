using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzariaLibrary.Models
{
    public class Pizza
    {
        public int Id { get; set; }
        [DisplayName("Tipo")]
        public string Nome { get; set; }
        [DisplayName("Descrição")]
        public string Descricao { get; set; }
        public string Tipo { get; set; }
        public decimal Valor { get; set; }

    }
}
