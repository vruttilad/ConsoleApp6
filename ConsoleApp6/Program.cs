using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericEx
{
    class Program
    {
        static void Main(string[] args)
        {
            DataAdd<string> da = new DataAdd<string>();
            da.Data = "Hello World";
            Console.WriteLine(da.Data);

            da.Add(1, "Rachel");
            da.Add(2, "Monica");
            
            Console.WriteLine(da.GetData(2));
            




            KeyValuePair<int, string> k = new KeyValuePair<int, string>();
            k.key = 1;
            k.value = "Ross";
            Console.WriteLine(k.key + k.value);

            Printer printer = new Printer();
            printer.Print<string>("Chandler");
           


            numbchange<int> n1 = new numbchange<int>(TestDelegate.AddNum);
            numbchange<int> n2 = new numbchange<int>(TestDelegate.MulNum);

            n1(10);
            Console.WriteLine("Value of Num: {0}", TestDelegate.GetNum());

            n2(20);
            Console.WriteLine("Value of Num: {0}", TestDelegate.GetNum());
           


            ISeries<string> stringseries = new ISeries<string>();
            stringseries.Addseries("Shinchain");
            stringseries.getseries();
            Console.ReadKey();
        }

       
    }

    //Generic class
    class DataAdd<T>
    {
        public T Data { get; set; }

        //Generic Array
        public T[] data = new T[10];

        //Generic Methods
        public void Add(int index, T item)
        {
            if (index > 0 && index < 10)
            {
                data[index] = item;
            }
        }

       
        public T GetData(int index)
        {
            if (index > 0 && index < 10)

                return data[index];
            

            else
                return default(T);
        }
    }

    //KeyValue Pair Example
   class KeyValuePair<TKey, TValue>
    {

        public TKey key { get; set; }
        public TValue value { get; set; }
    }

    //Non-Generic Class using Generic Method
    class Printer
    {

        public void Print<T>(T Data)
        {
            Console.WriteLine(Data);
            Console.ReadKey();
        }
    }

    //Delegate
    delegate T numbchange<T>(T n);
    class TestDelegate
    {

        static int number = 10;

        public static int AddNum(int p)
        {

            number += p;
            return number;
        }

        public static int MulNum(int q)
        {

            number *= q;
            return number;
        }

        public static int GetNum()
        {

            return number;
        }

    }

    //interface
    interface AddSerialDetails<T>
    {

        void Addseries(T sreies);

        T getseries();
    
    
    }

    public class ISeries<T> : AddSerialDetails<T>
    {
        T sreies;

        public void Addseries(T sreies)
        {
            this.sreies = sreies;
            Console.WriteLine(sreies);
        }

        public T getseries()
        {
            return this.sreies;
        }


    }


}