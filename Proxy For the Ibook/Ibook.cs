using System;

namespace ProxyForTheIbook
{

    interface Ibook
    {
        string Title { get; }
        string GetContent();
    }
}