namespace InterfaceSegregation
{
    internal class Program
    {
        //İşlevler; tek bir interface'e zorlanmamalı! Belirli işlevler belirli interface'lere ayrılmalı.
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }



    }


    public interface IMessage
    {
        public string From { get; set; }
        public string To { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }





    }

    public interface IVideoMessage : IMessage
    {
        public string VideoFormat { get; set; }
        public int VideoDuration { get; set; }
    }

    public interface IAudioMessage : IMessage
    {
        public string AudioFormat { get; set; }
        public int AudioDuration { get; set; }
    }

    public class TextMessage : IMessage
    {
        public string From { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string To { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Subject { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Body { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

    }

    public class VideoMessage : IVideoMessage
    {
        public string VideoFormat { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int VideoDuration { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string From { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string To { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Subject { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Body { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }


    public class AudioMessage : IAudioMessage
    {
        public string AudioFormat { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int AudioDuration { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string From { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string To { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Subject { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Body { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}