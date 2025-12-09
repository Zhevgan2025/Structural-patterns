using System;

namespace ProxyForTheIbook
{
    public class BookProxy : Ibook
    {
        private readonly User _user;
        private RealBook _realBook;

        public string Title { get; }

        public BookProxy(User user, string title)
        {
            _user = user;
            Title = title;
        }

        public string GetContent()
        {
            Console.WriteLine($"[Proxy] User '{_user}' requests access to '{Title}'");

            if (!_user.IsRegistered)
            {
                return "[Proxy] Access denied: user is not registered.";
            }

            if (!_user.HasBookAccess)
            {
                return "[Proxy] Access denied: user has no permission for this book.";
            }

            if (_realBook == null)
            {
                Console.WriteLine("[Proxy] All checks passed. Creating RealBook...");
                _realBook = new RealBook(Title);
            }

            return _realBook.GetContent();
        }
    }
}

