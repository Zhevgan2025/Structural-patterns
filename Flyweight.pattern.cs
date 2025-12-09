using System;
class CharFlyweight
{
    public char Symbol { get; }
    public string Font { get; }

    public CharFlyweight(char symbol, string font)
    {
        Symbol = symbol;
        Font = font;
    }

    public void Draw(int x, int y)
    {
        Console.WriteLine($"Draw '{Symbol}' with {Font} at ({x},{y})");
    }
}

class CharFlyweightFactory
{
    private Dictionary<string, CharFlyweight> _cache = new();

    public CharFlyweight Get(char symbol, string font)
    {
        string key = symbol + font;
        if (!_cache.ContainsKey(key))
            _cache[key] = new CharFlyweight(symbol, font);
        return _cache[key];
    }
}

