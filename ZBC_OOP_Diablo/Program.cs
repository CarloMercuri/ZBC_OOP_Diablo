using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZBC_OOP_Diablo
{
    class Program
    {
        static void Main(string[] args)
        {

            WeaponsFactory f = new WeaponsFactory();
            GUI gui = new GUI(f);
            Console.ReadLine();
        }
    }
}
