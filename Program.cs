using System;
using System.IO;

namespace lab6_2
{
    class Program
    {
        static void Main(string[] args)
        {
            foreach (string s in Directory.EnumerateFiles(@"Media/"))
            {
                //Console.WriteLine(Path.GetFileName(s));
                PlayerItem.DefineMedia(s);
            }
            Console.Read();
        }
    }
    interface IMedia
    {
        void Pause();
        void Stop();
    }

    interface IPlayable : IMedia
    {
        void Play();
    }

    interface IRecordable : IMedia
    {
        void Record();
    }

    class PlayerItem
    {
        IMedia FileRef { get; set; }

        public static PlayerItem DefineMedia(string path)
        {
            if (!File.Exists(path))
                return null;
            switch (Path.GetExtension(path).ToLower())
            {
                case (".mkv"):
                    Console.Write(Path.GetFileName(path) + "\t");
                    return new MkvVideo();
                case (".mp3"):
                    Console.Write(Path.GetFileName(path) + "\t");
                    return new MP3Audio();
                case (".wav"):
                    Console.Write(Path.GetFileName(path) + "\t");
                    return new WavAudio();
                default:
                    Console.Write(Path.GetFileName(path) + "\t(N/A)\n");
                    return null;
            }
        }
    }
    class MP3Audio : PlayerItem, IRecordable
    {
        public void Record() { }
        public void Pause() { }
        public void Stop() { }

        public MP3Audio()
        {
            Console.WriteLine("Записывать, пауза, стоп");
        }
    }

    class MkvVideo : PlayerItem, IPlayable
    {
        public void Play() { }
        public void Pause() { }
        public void Stop() { }

        public MkvVideo()
        {
            Console.WriteLine("Играть, пауза, стоп");
        }
    }

    class WavAudio : PlayerItem, IPlayable, IRecordable
    {
        public void Play() { }
        public void Pause() { }
        public void Stop() { }
        public void Record() { }

        public WavAudio()
        {
            Console.WriteLine("Играть, пауза, стоп, записывать");
        }
    }
}
