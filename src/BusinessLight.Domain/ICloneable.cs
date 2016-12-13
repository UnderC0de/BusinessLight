namespace BusinessLight.Domain
{
    public interface ICloneable<out T>
    {
        T Clone();
    }
}