using System.ComponentModel.DataAnnotations;

namespace Opea.Application.ViewModels
{
    public class CompanySizeViewModel
    {
        [Range(0, int.MaxValue, ErrorMessage = "O Porte da Empresa é obrigatório")]
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
