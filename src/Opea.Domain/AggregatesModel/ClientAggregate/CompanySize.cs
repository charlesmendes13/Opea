using Opea.Domain.Commom;

namespace Opea.Domain.AggregatesModel.ClientAggregate
{
    public class CompanySize : Enumeration
    {
        public static CompanySize Small = new (1, nameof(Small));
        public static CompanySize Medium = new (1, nameof(Medium));
        public static CompanySize Large = new (1, nameof(Large));

        public CompanySize(int id, string name)
            : base(id, name)
        {
        }
    }
}
