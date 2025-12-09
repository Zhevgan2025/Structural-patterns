using System;

interface IImage
{
    void Display();
}

class RealImage : IImage
{
    private string _fileName;

    public RealImage(string fileName)
    {
        _fileName = fileName;
        LoadFromDisk(); 
    }

    private void LoadFromDisk()
    {
        Console.WriteLine($"Loading {_fileName} from disk...");
    }

    public void Display()
    {
        Console.WriteLine($"Show picture {_fileName}");
    }
}


class ImageProxy : IImage
{
    private string _fileName;
    private RealImage _realImage;

    public ImageProxy(string fileName)
    {
        _fileName = fileName;
    }

    public void Display()
    {
        if (_realImage == null)
            _realImage = new RealImage(_fileName);

        _realImage.Display();
    }
}

