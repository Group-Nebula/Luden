namespace Luden.Domain.Exceptions.RpgSystem
{
    public class RpgSystemNotFoundException : Exception
    {
        public RpgSystemNotFoundException() : base("Rpg system not found")
        {
        }
    }
}
