using System;


interface ITargetLogger
{
    void Log(string message);
}


class LegacyLogger
{
    public void WriteToFile(string text)
    {
        Console.WriteLine($"[Legacy] {text}");
    }
}


class LoggerAdapter : ITargetLogger
{
    private readonly LegacyLogger _legacy;

    public LoggerAdapter(LegacyLogger legacy)
    {
        _legacy = legacy;
    }

    public void Log(string message)
    {
        _legacy.WriteToFile(message);
    }
}


class Program
{
    static void Main()
    {
        LegacyLogger oldLogger = new LegacyLogger();
        ITargetLogger logger = new LoggerAdapter(oldLogger);

        logger.Log("Hello from Adapter!");

        Console.ReadLine();
    }
}
