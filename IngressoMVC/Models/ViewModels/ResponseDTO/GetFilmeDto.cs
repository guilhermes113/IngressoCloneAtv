using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IngressoMVC.Models.ViewModels.ResponseDTO
{
    public class GetFilmeDto
    {
        public int Id { get; set; }
        [Display(Name = "Título")]
        public string Titulo { get; set; }

        [Display(Name = "Descrição")]
        public string Descricao { get; set; }

        [Display(Name = "Preço")]
        public Decimal Preco { get; set; }

        [Display(Name = "Imagem De Capa")]
        public string ImageURL { get; set; }


        public List<string> NomeCinemas { get; set; }
        public string FotoURLCinema { get; set; }
    }
}
