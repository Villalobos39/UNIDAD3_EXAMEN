using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TorreHanoi
{
    class Program
    {
        static void Main(string[] args)
        {
            JuegoHanoi no = new JuegoHanoi();

            no.Comerzar();
            no.FinJuego();

            Console.ReadKey();

        }
    }
}
