﻿using System.Runtime.Serialization.Formatters.Binary;

namespace Memento
{
    public class MementoPattern
    {

    }

    public class Memento
    {

        MemoryStream memoryStream = new MemoryStream();
        BinaryFormatter binaryFormatter = new BinaryFormatter();
        public Memento Serialize(object o)
        {
            memoryStream.Seek(0, SeekOrigin.Begin);
            binaryFormatter.Serialize(memoryStream, o);
            return this;
        }

        public object Deserialize()
        {
            memoryStream.Seek(0, SeekOrigin.Begin);
            object o = binaryFormatter.Deserialize(memoryStream);
            memoryStream.Close();
            return o;
        }


    }

    public interface IRestorable
    {
        Memento Save();
        void Restore(Memento memento);
    }

    public class Memoriable<T> where T : IRestorable, new()
    {
        private T restorable = new T();

        public Memento Save()
        {
            return restorable.Save();
        }

        public void Restore(Memento memento)
        {
            restorable.Restore(memento);
        }
    }
    [Serializable]
    public class FormSettings : IRestorable
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public Point Position { get; set; }
        public void Restore(Memento memento)
        {
            var formSettings = (FormSettings)memento.Deserialize();
            Width = formSettings.Width;
            Height = formSettings.Height;
            Position = formSettings.Position;
        }

        public Memento Save()
        {
            Memento memento = new Memento();
            return memento.Serialize(this);
        }
    }
}
