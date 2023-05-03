using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Opea.Application.ViewModels
{
    public class ClientViewModel
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "O Nome da Empresa é obrigatório")]
        [DisplayName("Nome da Empresa")]
        public string CompanyName { get; set; }


        [Range(0, int.MaxValue, ErrorMessage = "O Porte da Empresa é obrigatório")]
        public int CompanySizeId { get; set; }

        [DisplayName("Porte da Empresa")]
        public string CompanySizeName { get; set; }
    }
}
