using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Opea.Application.ViewModels
{
    public class ClientViewModel
    {
        [Key]
        public int Id { get; set; }

        [DisplayName("Nome da Empresa")]
        [Required(ErrorMessage = "O Nome da Empresa é obrigatório")]        
        public string CompanyName { get; set; }
                       
        public CompanySizeViewModel CompanySize { get; set; }
    }
}

