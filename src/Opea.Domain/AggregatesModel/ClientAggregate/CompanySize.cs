using Opea.Domain.Commom;

namespace Opea.Domain.AggregatesModel.ClientAggregate
{
    public class CompanySize : Enumeration
    {
        public static CompanySize Pequena = new (1, nameof(Pequena));
        public static CompanySize Media = new (2, nameof(Media));
        public static CompanySize Grande = new (3, nameof(Grande));

        public CompanySize(int id, string name)
            : base(id, name)
        {
        }
    }
}
