using System;
interface IMessageSender
{
    void Send(string message);
}

class EmailSender : IMessageSender
{
    public void Send(string message)
    {
        Console.WriteLine($"Send Email: {message}");
    }
}

class LoggingSenderDecorator : IMessageSender
{
    private readonly IMessageSender _inner;

    public LoggingSenderDecorator(IMessageSender inner)
    {
        _inner = inner;
    }

    public void Send(string message)
    {
        Console.WriteLine($"[LOG] Sending: {message}");
        _inner.Send(message);
    }
}

