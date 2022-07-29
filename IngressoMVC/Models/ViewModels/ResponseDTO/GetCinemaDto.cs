using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IngressoMVC.Models.ViewModels.ResponseDTO
{
    public class GetCinemaDto
    {
        public int Id { get; set; }
        [Display(Name = "Nome")]
        public string Nome { get; set; }

        [Display(Name = "Descrição")]
        public string Descricao { get; set; }
        
        [Display(Name = "Imagem De Capa")]
        public string LogoURL { get; set; }


        public List<string> FotoFilme { get; set; }
    }
}
