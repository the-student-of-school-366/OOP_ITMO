namespace Itmo.ObjectOrientedProgramming.Lab2.Repositories;

public class Repository<T> where T : class
{
    private readonly Dictionary<Guid, T> _items = new();

    public void Add(Guid id, T item)
    {
        if (_items[id] == null)
        {
            _items[id] = item;
        }
    }

    public T GetById(Guid id)
    {
        return _items[id];
    }

    public IEnumerable<T> GetAll() => _items.Values;
}