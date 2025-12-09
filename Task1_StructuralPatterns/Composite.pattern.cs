using System;
using System.Linq;

abstract class FileSystemItem
{
    public string Name { get; }
    protected FileSystemItem(string name) => Name = name;
    public abstract int GetSize();
}

class FileItem : FileSystemItem
{
    private int _size;
    public FileItem(string name, int size) : base(name)
    {
        _size = size;
    }
    public override int GetSize() => _size;
}

class Folder : FileSystemItem
{
    private LinkedList<FileSystemItem> _children = new();

    public Folder(string name) : base(name) { }

    public void Add(FileSystemItem item) => _children.AddLast(item);

    public override int GetSize() => _children.Sum(c => c.GetSize());
}

