using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;
using System.Threading;


namespace ProxyForTheIbook
{
    public class RealBook : Ibook
    {
        public string Title { get; }
        private string _Content;
        private bool _isLoaded;



        public RealBook(string title)
        {
            Title = title;
            Console.WriteLine($"[RealBook] create new book {Title}");
        }

        private void Load()
        {
            if (_isLoaded) return;
            Console.WriteLine($"[RealBook] Downloading the book content {Title}");
            Thread.Sleep(2000);
            _Content = $"Full text of the book {Title}. Your novel could be here.";
            _isLoaded = true;

            Console.WriteLine($"[RealBook] Book '{Title}' fully loaded.");


        }
        public string GetContent()
        {
            Load();
            return _Content;
        }
    }
}