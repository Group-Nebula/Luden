namespace Luden.Application.Models.Responses
{
    public class NameIdRes
    {
        public NameIdRes(Guid id, string name)
        {
            Id = id;
            Name = name;
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
