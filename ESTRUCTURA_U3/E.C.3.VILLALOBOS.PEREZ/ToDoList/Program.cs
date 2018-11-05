using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList
{
    class Program
    {
        static void Main(string[] args)
        {
            Tarea Imprimir = new Tarea();
            //MANDO A LLAMAR EL METODO MENU
            Imprimir.Menu();
            Console.Write("\n");
            Console.ReadKey();

        }
    }
}
