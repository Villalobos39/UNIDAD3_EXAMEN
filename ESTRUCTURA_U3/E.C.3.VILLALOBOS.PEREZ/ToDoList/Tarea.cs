using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList
{
    class Tarea
    {
        General Tareas = new General();
      // usando TO DO LIST la listas llaman a los atributos localizados un una clase
        List<General> HOMEWORK = new List<General>();
        List<General> PendienteList = new List<General>();
        List<General> ProcesoList = new List<General>();
        List<General> TerminadaList = new List<General>();

        private void Capturar() // esta es la captura general las tareas se crearan aqui
        {
            Console.Write("NO. TAREA : "); Tareas.NoTarea = int.Parse(Console.ReadLine());
            Console.Write("NOMBRE TAREA : "); Tareas.NombreTarea = Console.ReadLine();
            Console.Write("DESCRIPCION  : "); Tareas.Descripcion = Console.ReadLine();
            Console.Write("FECHA DE ENTREGA  : "); Tareas.FechaEntrega = Console.ReadLine();       
            Console.Write("\n");
        }
        // este metodo imprime una general DE LAS TAREAS
        private void TareaMostrar()
        {
            Console.Write("ESTATUS 1: PENDIENTE "); Pendiente();
            Console.Write("ESTATUS 2: PROCESO "); Proceso();
            Console.Write("ESTATUS 3: TERMINADO "); Terminado();
        }

        private void Pendiente()
        { // TODAS LAS TAREEAS INICIAN AQUI 
            foreach (General Tarea in PendienteList)
            {
                Console.Write("\n");
                Console.Write("\nNO. TAREA : " + Tarea.NoTarea);
                Console.Write("\nNOMBRE TAREA : " + Tarea.NombreTarea);
                Console.Write("\nDESCRIPCION  : " + Tarea.Descripcion);
                Console.Write("\nFECHA DE ENTREGA  : " +Tarea.FechaEntrega );
            }
        }

        private void Proceso()
        { // LAS TAREAS DE PENDIENTE SOLO PUEDEN PASAR A EN PROCESO
            foreach (General Tarea in ProcesoList)
            {
                Console.Write("\n");
                Console.Write("\nNO. TAREA : " + Tarea.NoTarea);
                Console.Write("\nNOMBRE TAREA : " + Tarea.NombreTarea);
                Console.Write("\nDESCRIPCION  : " + Tarea.Descripcion);
                Console.Write("\nFECHA DE ENTREGA  : " + Tarea.FechaEntrega);
            }     
        }

        private void Terminado()
        {// LAS TAREAS EN PROCESO SOLO PUEDEN SER TERMINADAS POR QUE YA ESTAN INICIADAS
            foreach (General Tarea in TerminadaList)
            {
                Console.Write("\n");
                Console.Write("\nNO. TAREA : " + Tarea.NoTarea);
                Console.Write("\nNOMBRE TAREA : " + Tarea.NombreTarea);
                Console.Write("\nDESCRIPCION  : " + Tarea.Descripcion);
                Console.Write("\nFECHA DE ENTREGA  : " + Tarea.FechaEntrega);    
            }          
        }
        private void QuitarTarea(General homework)
        {
            PendienteList.Remove(homework); //REMUEVE LAS TAREAS SELECIONDAS POR EL USUSARIO
            ProcesoList.Remove(homework);
        }
        
        public void Menu()
        {
            // INGRESASMOS EL TOTAL DE TAREAS QUE DEJARON 
            Console.Write("\n NUMERO DE TAREAS : ");
            int numero = int.Parse(Console.ReadLine());
            //UTILIZO ESTE CICLO PARA CAPTURAR ESAS TAREAS 
            for (int contador = 1; contador <= numero; contador++)
            {
                Capturar();
                PendienteList.Add(Tareas);
            }
            //PendienteList.Add(Tareas);
            Console.Clear();
            // UNA VEZ CAPUTADAS EL UNICA LISTA QUE DISPONE DE TAREA SERIA LA PENDIENTE
            Console.Write("\nVER TAREAS :  1)PENSIENTES \n2)PROCESO 3)TERMINADAS 4)MOSTRAR TAREAS: ");
            int opcion = int.Parse(Console.ReadLine());

            if (opcion == 1)
            {
                Console.Write("ESTATUS 1: PENDIENTE "); 
                Pendiente(); 
                // AQUI SE MUESTRAN LAS TAREAS  PENDIENTES 
                Console.Write("\nDESEA CAMBIAR ESTADO : 1) SI 2) NO  :  ");
                opcion = int.Parse(Console.ReadLine());
                // TIENES LA OPORTUNIDAD DE CAMBIAR SU ESTADO 
                if (opcion == 1)
                {
                    Console.Write("\nTAREA QUE CAMBIA DE ESTADO :  ");
                    opcion = int.Parse(Console.ReadLine());
                    General Latarea = PendienteList[opcion - 1];
                        PendienteList.Remove(PendienteList[opcion - 1]);
                        ProcesoList.Add(PendienteList[opcion - 1]);
                    // CUANDO PASA ESTO SE REMUEVEN LOS ELEMENTOS DE LA PRIMERA LISTA 
                    // PARA AÑADIRSE EN LA QUE SIGUE 
                }
                Pendiente();
                Menu();
            }
            if (opcion == 2)
            {
              // LOS ESTADOS ESTAN MARCADOS COMO ESTATUS YA QUE CADA LISTA LO DETERMINA 
                Console.Write("ESTATUS 2: PROCESO ");
                Proceso();
                Console.Write("\nDESEA CAMBIAR ESTADO : 1) SI 2) NO  :  ");
                opcion = int.Parse(Console.ReadLine());
                if (opcion == 1)
                {
                    Console.Write("\nTAREA QUE CAMBIA DE ESTADO :  ");
                    opcion = int.Parse(Console.ReadLine());
                    General Latarea = ProcesoList[opcion - 1];
                    ProcesoList.Remove(ProcesoList[opcion - 1]);
                    TerminadaList.Add(ProcesoList[opcion - 1]);
                }
                Proceso();
                Menu();
                //DEPENDIENDO DE LA REPUESTA DEL USUSARIO SE REALIZA LA EJECUCION DE METODOS
            }
            if (opcion == 3)
            { Console.Write("ESTATUS 3: TERMINADO ");
                Terminado();  Menu(); }
            if (opcion == 4)
            { TareaMostrar(); }
            else Menu();
        }

    }
}
