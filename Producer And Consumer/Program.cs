using System;
using System.Threading;

namespace Producer_And_Consumer
{
    class Program
    {

        static object[] products = new object[3];

        static void Main(string[] args)
        {

            Thread t1 = new Thread(Produce);
            Thread t2 = new Thread(Consume);

            t1.Name = "Producer";
            t2.Name = "Consumer";

            t1.Start();
            t2.Start();

            Thread.Sleep(1000);

            t1.Join();
            t2.Join();
        }

        static void Produce()
        {
            while (true)
            {

                while (true)
                {
                    bool isAllNull = true;
                    for(int i = 0; i < products.Length; i++)
                    {
                        if(products[i] != null)
                        {
                            isAllNull = false;
                        }

                    }
                    if(isAllNull == true)
                    {
                        break;
                    }
                    Console.WriteLine("Couldnt produce item");

                    Thread.Sleep(100 / 15);

                }

                for (int i = 0; i < products.Length; i++)
                {
                    Object obj = new object();
                    products[i] = obj;
                    Console.WriteLine("Item Added");
                }

                Thread.Sleep(100 / 15);
            }
        }
        static void Consume()
        {
            while (true)
            {
                while (true)
                {
                    bool isOneNull = false;
                    for (int i = 0; i < products.Length; i++)
                    {
                        if (products[i] == null)
                        {
                            isOneNull = true;
                        }

                    }
                    if (isOneNull == false)
                    {
                        break;
                    }
                    Console.WriteLine("Couldnt consume item");

                    Thread.Sleep(100 / 15);
                }

                for (int i = 0; i < products.Length; i++)
                {
                    products[i] = null;
                    Console.WriteLine("Item removed");
                }

                Thread.Sleep(100 / 15);

            }
        }
    }
}
