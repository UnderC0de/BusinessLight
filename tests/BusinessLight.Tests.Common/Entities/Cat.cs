namespace BusinessLight.Tests.Common.Entities
{
    public class Cat : Animal
    {
        public override string Name
        {
            get; 
            set;
        }
        public override string Go()
        {
            return "I walk!";
        }
    }
}