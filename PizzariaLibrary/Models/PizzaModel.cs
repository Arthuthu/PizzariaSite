using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzariaLibrary.Models
{
    public class PizzaModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "É necessário preencher o campo do nome")]
        public string Nome { get; set; }
        [DisplayName("Descrição")]
        [Required(ErrorMessage = "É necessário preencher o campo da descrição")]

        public string Descricao { get; set; }
        [Required(ErrorMessage = "É necessário preencher o campo do tipo da pizza")]

        public string Tipo { get; set; }
        [Required(ErrorMessage = "É necessário preencher o campo do valor")]

        public decimal Valor { get; set; }

    }
}
