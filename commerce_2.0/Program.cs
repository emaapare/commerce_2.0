using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace commerce_2._0
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var ctx = new ordersEntities();
            
            Console.WriteLine($"creato contesto: {ctx}\n");
            char scelta1;

            do
            {
                Console.Clear();
                Console.WriteLine("Inizio Esercizio");
                Console.WriteLine("1) login");
                Console.WriteLine("2) lista ordini");
                Console.WriteLine("3) dettaglio ordini");
                Console.WriteLine("4) inserimento ordine");

                string scelta = Console.ReadLine();

                switch (scelta)
                {
                    case "1":
                        Console.Clear();
                        Console.WriteLine("inserisci username: ");
                        string username = Console.ReadLine();
                        Console.WriteLine("inserisci password: ");
                        string password = Console.ReadLine();
                        var newU = new utenti() { login = username, password = password };
                        ctx.utenti.Add(newU);
                        ctx.SaveChanges();
                        break;
                    case "2":
                        Console.WriteLine("Lista degli ordini");
                        foreach (orders c in ctx.orders)
                        {
                            Console.WriteLine(c.orderid + " " + c.customer + " " + c.orderdate);
                        }
                        break;
                    case "3":
                        Console.WriteLine("Dettaglio degli ordini");
                        foreach (orderitems c in ctx.orderitems)
                        {
                            Console.WriteLine(c.orderid + " " + c.item + " " + c.qty + " " + c.price);
                        }
                        break;
                    case "4":
                        Console.WriteLine("Insert di un ordine");
                        var newO = new orderitems() { orderid = 2, item = "IT", qty = 22, price = 33 };
                        ctx.orderitems.Add(newO);
                        ctx.SaveChanges();
                        break;
                    default:
                        Console.WriteLine("Inserimento errato");
                        break;
                }
                Console.WriteLine("premere 's' per continuare, altro per terminare: ");
                scelta1 = char.Parse(Console.ReadLine());
            } while (scelta1 == 's');
        }
    }
}
