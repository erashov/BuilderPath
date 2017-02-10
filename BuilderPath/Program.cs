using System;
using System.Text;

namespace BuilderPath
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            new BuildPath();//Сложность O(n^2)
            Console.ReadLine();
        }
    }
}
