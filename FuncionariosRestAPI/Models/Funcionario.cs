using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FuncionariosRestAPI.Models
{
    public class Funcionario
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Campo obrigatório")]
        public string Funcao { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        public string Departamento { get; set; }

        public decimal Salario { get; set; }
    }
}
