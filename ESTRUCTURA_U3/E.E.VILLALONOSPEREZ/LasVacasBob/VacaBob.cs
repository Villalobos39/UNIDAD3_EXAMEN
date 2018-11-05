using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Threading.Tasks;

namespace LasVacasBob
{
    class VacaBob
    {
        int opcion, tiempoCruze;
        //LOS ATRIBUTOS Y PROBIEDADES SON LLAMDOS DESDE OTRA CLASE
        Vaca Mazie = new Vaca("MAZIE", 2);Vaca Daisy = new Vaca("DAISY", 4);
        Vaca Crazy = new Vaca("CRAZY", 10); Vaca Lazy = new Vaca("LAZY", 20);
        List<Vaca> ganado = new List<Vaca>();
        //LA CREACION DE LA LISTA DEPENDEL DEL TIPO QUE SE LE ASIGNA <> DENTRO
        public VacaBob()     
        {
            //ESTE CONSTRUCTOR INICIALIZA MIS VARIABLES Y LAS AÑADE A LA LISTA
            tiempoCruze = 0;
            ganado.Add(Mazie); ganado.Add(Daisy);
            ganado.Add(Crazy); ganado.Add(Lazy);
        }
        private void QuitarVaca(Vaca vacas)
        {
            ganado.Remove(vacas); //REMUEVE LAS VACAS SELECIONDAS POR EL USUSARIO
        }

        private void VacasPorCruzar() // DESPLEGA LOS DATOS RESTANTES DE LA LISTA
        {
            int conteo = 0;
            foreach (Vaca vacas in ganado)
            {
                
                //DESPUES DE QUITAR ELEMENTOS DE LA LISTA IMPRIME LOS ELEMENTOS RESTANTES 
                conteo++;
                Console.Write("\n\t{0} {1} TIEMPO DE CRUZE: {2} MIN", conteo, vacas.Nombre, vacas.Tiempo);
            }
        }
       
        private int CruzeUnaVaca(Vaca vacas)
        {
            //MARCA EL TIEMPO DE UNA VACA AL SER SELECCIONADA
            return vacas.Tiempo;
        }

        private int CruzeDosVacas(Vaca vacas, Vaca vacas2)
        {
            // SE TOMA EL VALOR DE LA VACA QUE TARDE MAS
            if (vacas.Tiempo > vacas2.Tiempo)
            {
                return vacas.Tiempo;
            }
            // ES POR ESO QUE SE LLEVA UNA COMPARACION 
            else
            {
                return vacas2.Tiempo;
            }
            //RESGRESANDO ASI SOLO UNO DE LOS TIEMPOS
        }

        public void CalcularTiempoCruze()
        {
           
            Console.Write("\n\n\t>>>BOB QUIERE CRUZAR SUS CUATRO VACAS EN 34 MINUTOS<<<");  
            Console.Write("\n\tVACAS EN CRUZAR");
            VacasPorCruzar();// MUESTRA LAS VACAS QUE TIENE BOB ANTES DE CRUZAR EL PUENTE
            Console.Write("\n\tVACAS CON EL YOGO SELECCIONA LAS VACAS QUE IRAN JUNTAS ");
            //PRIMERO DEBE SECCIONAR A LAS DOS PRIMERAS VACAS QUE TRENDAN QUE IR JUNTAS ATADAS DEL YOGO           
            Console.Write("\n\tVACA ATADA AL YOGO :");
            opcion = int.Parse(Console.ReadLine());
            
            if (opcion==1 || opcion==2 || opcion == 3 || opcion == 4)
            {
                //ESTO SIMPLIFICARA EL METODO, DE CLASE VACA SE MANDA A LLAMAR A LA LISTA, 
                Vaca LaVaca = ganado[opcion - 1];
                //ESTO CON EL FIN DE IR ELEIJIENDO LA VACA QUE CRUZARA JUNTO CON LA PRIMERA,
                ganado.Remove(ganado[opcion - 1]); VacasPorCruzar();
                Console.Write("\n\tJUNTO CON LA VACA  :"); opcion = int.Parse(Console.ReadLine());
                // AL SER SELECIONADA SE MANDRA A LLAMAR A LA COMPARACION DE TIEMPO,
         
                if (opcion > ganado.Count || opcion < 1)
                {
                    ganado.Add(LaVaca);
                    Console.Write("\n\t\aERRO");
                }
               // UNA VEZ QUE SE TOMARA EL TIEMPO DE LA VACA QUE DURE MAS, 
                tiempoCruze = tiempoCruze + CruzeDosVacas(LaVaca, ganado[opcion - 1]);
                Console.Write("\n\tLAS VACAS {0} Y {1} CRUZAN EN YODO EN : {2} MIN ", ganado[opcion - 1].Nombre, LaVaca.Nombre, tiempoCruze);
                //LO SIGUENTE ES SUMAR EL TIEMPO DE LAS DOS VACAS MAS, 
                ganado.Remove(ganado[opcion - 1]); VacasPorCruzar(); opcion = 1;
                tiempoCruze = tiempoCruze + CruzeUnaVaca(ganado[opcion - 1]);
                //QUE TIENE QUE CRUZAR UNA POR UNA, POR INDIVIDUAL.
                Console.Write("\n\tTIEMPO DE CRUZE DE 3 VACAS: {0} MIN ", tiempoCruze);
                ganado.Remove(ganado[opcion - 1]); opcion = 1;
                tiempoCruze = tiempoCruze + CruzeUnaVaca(ganado[opcion - 1]);
               //PARA PASAR A LAS CONDICIONES PRIMERO SE DEBE DE VER SI LOS ELEMNTOS EN LA LISTA ES IGUAL A 0
                Console.Write("\n\n\tTIEMPO DE CRUZE TOTAL DE LAS 4 VACAS : {0} MIN", tiempoCruze);
                ganado.Remove(ganado[opcion - 1]);   
            }
            //ASI, SI LA SUMA DE LOS TIEMPOS CUMPLE CON LAS CONSICIONES
            if (ganado.Count==0)
            {
                // SE IMPRIME SI SE LOGRO O NO. 
                if (tiempoCruze == 34)
                {
                    Console.Write("\n\n\t\aFELICIDADES SE LOGRO EL TIEMPO REQUERIDO\n\n\n");
                }
                else
                {
                    Console.Write("\n\n\t\aSUERTE PARA LA PROXIMA \n\n\n");
                }
            }         
        }
    }
}
