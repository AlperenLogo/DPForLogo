using System;
using System.Collections.Generic;

namespace Interpreter
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = "MMXXII";
            Interpreter interpreter = new Interpreter(input);
            List<Basamak> basamaklar = new List<Basamak>();
            basamaklar.Add(new BinlerBasamak());
            basamaklar.Add(new YuzlerBasamak());
            basamaklar.Add(new OnlarBasamak());
            basamaklar.Add(new BirlerBasamak());

            foreach (var item in basamaklar)
            {
                item.Cevir(interpreter);
            }

            Console.WriteLine(interpreter.Output.ToString());
            Console.ReadLine();




        }
    }

    public class Interpreter
    {

        public string Input { get; set; }
        public int Output { get; set; }
        public Interpreter(string input)
        {
            Input = input;
        }
    }

    //I      X     C     M
    //IV     XL    CD
    //V      L     D
    //IX     XC    CM
    public abstract class Basamak
    {
        public abstract string Bir();
        public abstract string Dort();
        public abstract string Bes();
        public abstract string Dokuz();

        public abstract int Carpan();
        public void Cevir(Interpreter interpreter)
        {
            if (interpreter.Input.Length == 0)
            {
                return;
            }

            if (interpreter.Input.StartsWith(Dokuz()))
            {
                interpreter.Output += 9 * Carpan();
                interpreter.Input = interpreter.Input.Substring(2);
            }

            if (interpreter.Input.StartsWith(Dort()))
            {
                interpreter.Output += 4 * Carpan();
                interpreter.Input = interpreter.Input.Substring(2);
            }

            if (interpreter.Input.StartsWith(Bes()))
            {
                interpreter.Output += 5 * Carpan();
                interpreter.Input = interpreter.Input.Substring(1);
            }

            while (interpreter.Input.StartsWith(Bir()))
            {
                interpreter.Output += 1 * Carpan();
                interpreter.Input = interpreter.Input.Substring(1);
            }
        }


        //I      X     C     M
        //IV     XL    CD
        //V      L     D
        //IX     XC    CM


    }

    public class BirlerBasamak : Basamak
    {
        public override string Bes()
        {
            return "V";
        }

        public override string Bir()
        {
            return "I";
        }

        public override int Carpan()
        {
            return 1;
        }

        public override string Dokuz()
        {
            return "IX";
        }

        public override string Dort()
        {
            return "IV";
        }
    }

    public class OnlarBasamak : Basamak
    {
        public override string Bes()
        {
            return "L";
        }

        public override string Bir()
        {
            return "X";
        }

        public override int Carpan()
        {
            return 10;
        }

        public override string Dokuz()
        {
            return "XC";
        }

        public override string Dort()
        {
            return "XL";
        }
    }

    public class YuzlerBasamak : Basamak
    {
        public override string Bes()
        {
            return "D";
        }

        public override string Bir()
        {
            return "C";
        }

        public override int Carpan()
        {
            return 100;
        }

        public override string Dokuz()
        {
            return "CM";
        }

        public override string Dort()
        {
            return "CD";
        }
    }
    public class BinlerBasamak : Basamak
    {
        public override string Bes()
        {
            return " ";
        }

        public override string Bir()
        {
            return "M";
        }

        public override int Carpan()
        {
            return 1000;
        }

        public override string Dokuz()
        {
            return " ";
        }

        public override string Dort()
        {
            return " ";
        }
    }
}
