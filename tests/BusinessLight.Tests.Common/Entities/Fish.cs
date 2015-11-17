namespace BusinessLight.Tests.Common.Entities
{
    public class Fish : Animal
    {
        public override string Name { get; set; }
        public override string Go()
        {
            return "I swim!";
        }
    }
}