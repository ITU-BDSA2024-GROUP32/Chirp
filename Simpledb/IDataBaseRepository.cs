namespace Simpledb;

public interface IDataBaseepository<T>
{
    public IEnumerable<T> read(int? limit = null);
    public void store(T record);
}
