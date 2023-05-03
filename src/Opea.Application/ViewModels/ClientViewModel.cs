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

        [Required(ErrorMessage = "O Porte da Empresa é obrigatório")]
        [DisplayName("Porte da Empresa")]
        public int CompanySizeId { get; set; }
    }
}
