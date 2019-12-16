using System;

using System.Collections.Generic;

namespace _50minutos_flyweight
{
    class Program
    {
        static void Main(string[] args)
        {
            Sanduiches lista = new Sanduiches();

            Console.WriteLine("Pedido: ", lista[1]);
            Console.WriteLine("Pedido: ", lista[3]);
            Console.WriteLine("Pedido: ", lista[3]);
            Console.WriteLine("Pedido: ", lista[2]);
            Console.WriteLine("Pedido: ", lista[1]);
            Console.WriteLine("Pedido: ", lista[4]);

            Console.ReadKey();
        }
    }

    //IFlyweight
    public interface ISanduiche
    {
        double Preco { get; }
    }

    public abstract class Sanduiche : ISanduiche
    {
        public abstract double Preco { get; }
        public override string ToString()
        {
            return String.Format(" - {1:c}", this.GetType().Name, this.Preco);
        }
    }

    //Flyweight
    public class Hamburger : Sanduiche
    {
        public override double Preco
        {
            get
            {
                return 4.5;
            }
        }
    }

    //Flyweight
    public class PaoComMortadela : Sanduiche
    {
        public override double Preco
        {
            get
            {
                return 1.8;
            }
        }
    }

    //Flyweight
    public class Misto : Sanduiche
    {
        public override double Preco
        {
            get
            {
                return 2.75;
            }
        }

        public Tipo Tipo { get; set; }
    }

    //FlyweightFactory
    public class Sanduiches
    {
        //flyweights
        Dictionary<int, ISanduiche> sanduiches =
            new Dictionary<int, ISanduiche>();
            
        public Sanduiches()
        {
            sanduiches.Clear();
            sanduiches.Add(1, new Hamburger());
            sanduiches.Add(2, new PaoComMortadela());
            sanduiches.Add(3, new Misto(){ Tipo = Tipo.frio});
            sanduiches.Add(4, new Misto(){ Tipo = Tipo.quente});
        }
        
        public ISanduiche this[int index]
        {
            get
            {
                return sanduiches[index];
            }
        }
    }

    public enum Tipo
    {
        quente, frio
    }
}
