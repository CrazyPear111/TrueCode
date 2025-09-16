using System.Collections;

namespace TrueCode.CurrencyService.Currencies;

public class UserFavorites : IList<ICurrency>
{
    private readonly List<ICurrency> _favoriteCurrencies;

    public ICurrency this[int index] 
    {
        get => _favoriteCurrencies[index];
        set 
        { 
            ArgumentNullException.ThrowIfNull(value);
            _favoriteCurrencies[index] = value;
        }
    }

    public long UserId { get; private init; }

    public int Count => _favoriteCurrencies.Count;

    public bool IsReadOnly => false;

    public void Add(ICurrency item)
    {
        ArgumentNullException.ThrowIfNull(item);
        _favoriteCurrencies.Add(item);
    }

    public void Clear()
    {
        _favoriteCurrencies.Clear();
    }

    public bool Contains(ICurrency item)
    {
        return _favoriteCurrencies.Contains(item);
    }

    public void CopyTo(ICurrency[] array, int arrayIndex)
    {
        _favoriteCurrencies.CopyTo(array, arrayIndex);
    }

    public IEnumerator<ICurrency> GetEnumerator()
    {
        return _favoriteCurrencies.GetEnumerator();
    }

    public int IndexOf(ICurrency item)
    {
        return _favoriteCurrencies.IndexOf(item);
    }

    public void Insert(int index, ICurrency item)
    {
        ArgumentNullException.ThrowIfNull(item);
        _favoriteCurrencies.Insert(index, item);
    }

    public bool Remove(ICurrency item)
    {
        return _favoriteCurrencies.Remove(item);
    }

    public void RemoveAt(int index)
    {
        _favoriteCurrencies.RemoveAt(index);
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}
