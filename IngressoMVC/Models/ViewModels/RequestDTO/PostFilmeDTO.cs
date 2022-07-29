using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IngressoMVC.Models.ViewModels.RequestDTO
{
    public class PostFilmeDTO
    {
        [Required(ErrorMessage = "O Titulo é Obrigatório!")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "O Filme deve ter no máximo 50 caracters, e no mínimo 3")]
        public string Titulo { get; set; }
        [StringLength(50, MinimumLength = 3, ErrorMessage = "A Descrição deve ter no máximo 50 caracters, e no mínimo 15")]
        public string Descricao { get; set; }
        [Required(ErrorMessage = "Preço obrigatória")]
        [Range(0, 500,ErrorMessage = "O Preço deve ter no máximo 5 digitos, e no mínimo 4")]
        public decimal Preco { get; set; }
        [Required(ErrorMessage = "Imagem obrigatória")]
        public string ImageURL { get; set; }

        #region relacionamentos
        public string NomeCinema { get; set; }

        public int ProdutorId { get; set; }

        public List<int> AtoresId { get; set; }
        public List<int> CategoriasId { get; set; } //Por Id
        #endregion
    }
}
