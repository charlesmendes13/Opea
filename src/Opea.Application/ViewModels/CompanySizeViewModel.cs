using System.ComponentModel.DataAnnotations;

namespace Opea.Application.ViewModels
{
    public class CompanySizeViewModel
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
