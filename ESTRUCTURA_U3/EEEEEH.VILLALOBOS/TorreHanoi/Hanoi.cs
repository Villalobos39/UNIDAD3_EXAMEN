using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TorreHanoi
{
    class Hanoi
    {
        int totalDiscos; // variable local que determina el numero de discos
        Stack<int> torre1; Stack<int> torre2; Stack<int> torre3;
        // estas pilas nos ayudan almacenar los numero (discos) que tendra cada torre
        public Hanoi(int discos)
        {
            totalDiscos = discos; torre1 = new Stack<int>();
            torre2 = new Stack<int>(); torre3 = new Stack<int>();
        }

        public void TorresDeHanoi()
        {//SE PUEDEN CREAR 100 DISICOS COMO MAXIMO Y ES LA CAPACIDASD DE CADA TORRE 
            torre1.Push(100); torre2.Push(100); torre3.Push(100);
            for (int i = totalDiscos; i > 0; i--)
            {
                torre1.Push(i);
            }
        }

        public void PosicionDisco(int position, int pieza)
        {
            //ESTE CURSOR SELECCIONA EL NUMERO QUE MOVEREMOS ENTRE LAS TORRES           
            Console.SetCursorPosition(position, 7);
            Console.WriteLine("[{0}]", pieza);
        }

        public bool TorreCompletada()
        { // esta CONDICION DETERMINA EL FIN DEL JUEGO SI LOS DISCOS SE ENCUENTRAN EN LA TORRE 3
            //ESTEN DE MANERA ORDENADA Y SEAN TODOS 
            if (torre3.Count == totalDiscos + 1)
            { return false; } else { return true; }
        }

        public void TorresHanoi()
        { // se coloca sobre cada torre el numero de discos 
            int columna = 8;

            foreach (int numero in torre1)
            {
                Console.SetCursorPosition(9, columna);
                if (numero == 100) { Console.WriteLine("_"); }
                else {Console.Write(numero); columna = columna + 1; }
            }
            // es importante marcar la posicion en donde se pondran para eso _
            columna = 8;
            foreach (int valor in torre2)
            {
                Console.SetCursorPosition(18, columna);
                if (valor == 100)
                { Console.WriteLine("_"); }
                else {Console.Write(valor); columna = columna + 1; }
            }

            columna = 8;
            foreach (int i in torre3)
            {// en estas coordenadas vemos que estarea en la fila 27 horizontal 
                // columna 8
                Console.SetCursorPosition(27, columna);
                if (i == 100) { Console.WriteLine("_"); }
                else {Console.Write(i); columna = columna + 1; }
            }
            //el valor de la columna representa la posocion vertical de las torres
        }

        public int DejarDisco(int position, int valor)
        { // CUANDO EL CURSOS SELECIIONA EL NUMERO DE LA PILA 
            if (valor == 0)
            {
                return 0;
            }

            else if (position == 9)
            {// ESTE DEPENDE DE LA POSICION EN QUE SE ENCUENTRA 
                if (torre1.Peek() > valor)
                {
                    torre1.Push(valor); return 0;
                }
                else { return valor; }
            }
            // AL MISMO TIEMPO QUE SE SELECCIONA USAMOS EL PEEK PARA RETIRARLO DE LA PILA 
           else if (position == 18)
           {
                if (torre2.Peek() > valor)
                {
                    torre2.Push(valor); return 0;
                }
                else { return valor; }
            }
            // ANTERIOR Y PUSH PARA AÑADIRLO A LA PILA CONSIGUENTE
            else if (position==27)
            {
                if (torre3.Peek() > valor)
                {
                    torre3.Push(valor); return 0;
                }
                else { return valor; }
            }
            return 0;
            // SI LA POSICION ES 9 DE LA PRIMERA PILA SE CUMPLE LA CONDICION AL IGUAL CON LAS OTRAS DOS 
        }

        public int MoverDisco(int posicion)
        {
            // AHORA SI SE DESEA DESPLAZAR EL DISCO ENTRE TORRES 

            if (posicion == 9)
            {
                if (torre1.Peek() > 0)
                {
                    return torre1.Pop();
                }
                else{ return 0; }
            }
            // COMO SABESMOS EL SEMEJANTE EL PROCEDIMIENTO AL ANTERIOR 
            else if (posicion == 18)
            {
                if (torre2.Peek() > 0)
                {
                    return torre2.Pop();
                }
                else { return 0; }
            }
            //SOLO QUE AQUI QUITAMOS EL ELEMENTO DE LA PILA CON POO 
            else if (posicion == 27)
            {
                if (torre3.Peek() > 0)
                {
                    return torre3.Pop();
                }
                else { return 0; }
            }
            // ESTO NOS PERMITE HACER EL INTERCAMBION DE DISCOS SI QUE ESTE PERMANESCA DONDE MISMO 
            return 0;
        }
    }
}
