using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Threading.Tasks;

namespace E3_EstDatos
{
    public class Operacion
    {
        
        public void Principal()
        {
            Stack Lista = new Stack();
            Queue Cola = new Queue();

            Console.Write("\n\nVALOR  DE LA PILA : ");
            Ejercicio1(Lista);
            Console.Write("\n\nPALABRAS");
            Ejercicio2();
            Console.Write("\n\n>>>CALIDFICACIONES DE PROMEDIO<<<\n");
            Ejercicio4();
            Console.WriteLine("\n>>>ESPERE CALCULANDO TIEMPO <<<");

            Ejercicio3(); 

        }

        public void Ejercicio1(Stack lista)
        {
            //¿Qué valores se devuelven durante la siguiente serie de operaciones de pila,
            //si se ejecutan en una pila inicialmente vacía ? 
            //push(5), push(3), pop(), push(2), push(8),
            //pop(), pop(), push(9), push(1), pop(), push(7), push(6), pop(), pop(), push(4),
            //pop(), pop()
                   
            lista.Push(5); lista.Push(3); lista.Pop(); lista.Push(2); lista.Push(8);
            lista.Pop(); lista.Pop(); lista.Push(9); lista.Push(1);  lista.Pop();
            lista.Push(7); lista.Push(6); lista.Pop(); lista.Pop(); lista.Push(4);
            lista.Pop(); lista.Pop();
            foreach (var item in lista)
            {
                Console.WriteLine(item);
            }

        }

        public void Ejercicio2()
        {
            //Escriba en este metodo un modulo que pueda leer  y almacenar palabras reservadas en una lista enlazada 
            //e identificadores y literales en Otra lista enlazada.
            //Cuando el programa haya terminado de leer la entrada, mostrar
            //Los contenidos de cada lista enlazada.
            //Revise que es un Identificador y que es un literal

            Console.Write("\nPALABRAS RESERVADAS");
        }
        public void Ejercicio3()
        {
            //mida el tiempo entre Un lista ligada y una lista normal en el tiempo de ejecucion de 9876 elementos agregados.
            const int total = 999;
            List<string> Lista = new List<string>();
            LinkedList<string> Listaligada = new LinkedList<string>();
            for (int i = 0; i < 979; i++)
            {
                Lista.Add("jasmin");
                Listaligada.AddLast("dulce");
            }
            var t1 = Stopwatch.StartNew();
            for (int i = 0; i < total; i++)
            {
                foreach (string item in Lista)
                {
                    if (item.Length != 6)
                    {
                        throw new Exception();
                    }
                }
            }
            t1.Stop();
            var t2 = Stopwatch.StartNew();
            for (int i = 0; i < total; i++)
            {
                foreach (string item in Listaligada)
                {
                    if (item.Length != 5)
                    {
                        throw new Exception();
                    }
                }
            }
            t2.Stop();
            Console.WriteLine("LISTA: " + ((double)(t1.Elapsed.TotalMilliseconds * 1000000) / total).ToString("0.00 NS"));
            Console.WriteLine("LISTAS LIGADA: " + ((double)(t2.Elapsed.TotalMilliseconds * 1000000) / total).ToString("0.00 NS"));
        }

        public void Ejercicio4()
        {
            // Diseñar e implementar una clase que le permita a un maestro hacer un seguimiento de las calificaciones
            // en un solo curso.Incluir métodos que calculen la nota media, la
            //calificacion más alto, y el calificacion más bajo. Escribe un programa para poner a prueba tu clase.
            //implementación. Minimo 30 Calificaciones, de 30 alumnos.
            Clase curso = new Clase();        
            Stack Alumnos = new Stack();
            Stack<int> Calificaciones = new Stack<int>();
            Console.Write("\nNOMBRE DE LA CLASE :");
            curso.NombreClase = Console.ReadLine();
            Console.Write("\nMAESTRO:", curso.Maestro);
            curso.Maestro = Console.ReadLine();
            Console.Write("\nALUMNOS DE LA CLASE: ");
            int num = int.Parse(Console.ReadLine());
            for (int i = 0; i < num; i++)
            {
                Console.Write("EL ALUMNO {0}: ", i + 1);
                Alumnos.Push(Console.ReadLine());

                Console.Write(" CALIFICACION GRENERAL: ", i + 1);
                Calificaciones.Push(int.Parse(Console.ReadLine()));
            }
            Console.WriteLine(" EL PROMEDIO ES: {0}", curso.Promedio(Calificaciones));
            Console.WriteLine(" EL PROMEDIO MAYOR : {0}", Calificaciones.Max());
            Console.WriteLine(" EL PROMEDIO MENOR : {0}", Calificaciones.Min());
        }
    }
}

