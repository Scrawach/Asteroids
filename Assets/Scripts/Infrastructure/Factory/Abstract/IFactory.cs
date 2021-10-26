namespace Infrastructure.Factory.Abstract
{
    public interface IFactory<out TProduct>
    {
        TProduct Create();
    }
}