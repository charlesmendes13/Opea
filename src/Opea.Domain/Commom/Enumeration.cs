namespace Opea.Domain.Commom
{
    public abstract class Enumeration : IComparable
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        protected Enumeration(int id, string name) => (Id, Name) = (id, name);
        public int CompareTo(object other) => Id.CompareTo(((Enumeration)other).Id);
    }
}
