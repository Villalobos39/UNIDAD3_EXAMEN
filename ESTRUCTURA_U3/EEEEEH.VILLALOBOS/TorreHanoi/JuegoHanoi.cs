using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TorreHanoi
{
    class JuegoHanoi
    {
        Hanoi hanoi; // SE CREA UN OBJETO PARA MANDAR A LLAMAR A LA CLASE HANOI
        int movimientos; int NoDisco;
        int posicion; int disco; bool True;
        // ESTAS VARIABLES SON LOCALES 
    
        public JuegoHanoi()
        {
            disco = 0; movimientos = 0;
            True = true; posicion = 9;
        }
        // INICIALIZACION DE LAS VARIABLES 
  
        public void Comerzar()
        {   // EL ENCABEZADO INICIA EL JUEGO , PREGUNTANDO EL NUMERO DE DISCOS        
            Console.Write("\n\tNUMERO DE DISCO : "); NoDisco = int.Parse(Console.ReadLine());
            hanoi= new Hanoi(NoDisco); hanoi.TorresDeHanoi(); 
            while (True == true)
            {
                // ESTE CICLO SE LLEVARA EN EJECUCION HASTA QUE 
                //TODOS LOS ELEMENTOS DEL LA TORRE 1 PASEN A LA TORRE 3
                Console.Write("\n\t\tTORRES DE HANOI");
                Console.SetCursorPosition(40, 1);
                Console.Write("\n\t\tINSTRUCCIONES : \n\tPARA SIELECIONAR DISCO PRESIONAR S" +
                              "\n\tUTILIZA [ A || D ] PARA PASAR DE LA TORRE 1 A 2 O 3 ");
                Console.Write("\n\tMOVIMIENTO TOTALES {0}", movimientos);
                //PARA COMEZAR EL JUEGOS MANDE A LLAMAR A LOS METODOS POSICION DE DIDSCO 
                hanoi.PosicionDisco(posicion, disco); hanoi.TorresHanoi();
                //Y EL DE LAS TORRES QUE POSSICIONA LOS DISCOS EN LA PRIMERA TORRE POR DEFECTO
                ConsoleKeyInfo Control = Console.ReadKey(true);
                switch (Control.Key)
                {
                    // PARA QUE ME PERMITIERA MOVER LOS ELEMENTOS DE UNA TORRE A OTRA 
                    case  ConsoleKey.A:
                        if (posicion > 9)
                        {
                            posicion = posicion - 9; Console.Clear();
                        } break;
                        // USE EL CONSOLEKEY CON UNA TECLA POR DEFECTO EN ESTE CASO 
                    case ConsoleKey.D:
                        if (posicion < 27)
                        {
                            posicion = posicion + 9; Console.Clear();
                        }  break;
                        // FUERON LAS LETRAS A S D
                    case ConsoleKey.S: movimientos++;
                        if (disco == 0)
                        {
                            disco = hanoi.MoverDisco(posicion);
                            Console.Clear();
                        }
                        //PARA QUE CUANDO AGARRADA EL NUMERO DE LA TOORE ESTA NO HICIERA UNA COPIA COMO TAL 
                        else
                        {
                            int numero = disco;
                            disco = hanoi.DejarDisco(posicion, numero);
                            Console.Clear();
                        } break;
                        // ESTUVE BORRANDO , PODRIA BORRALO COMO CICLO COMPLETO PERO NO QUISE 
                    default:
                        Console.Write("\n\n\n\tERROR"); break;
                }
                True = hanoi.TorreCompletada();  
            }        
        }
        public void FinJuego ()
        {
            // MENSAJE DE TERMINADO CON UN CONTEO TOTAL DE MOVIEMTOS 
            Console.Write("\n\a\tMOVIMIENTO TOTALES {0}", movimientos);
            Console.WriteLine("\n\tFIN DEL JUEGO LO HAS LOGRADO ");
        }
    }
}
  