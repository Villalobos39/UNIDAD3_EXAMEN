using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LasVacasBob
{
    class Vaca
    {
        //ATRUBUTOS CON PROPIEDADES 
        public string Nombre { get; set; } // ESTE ATRIBUTO RERESENTA EL NOMBRE DE LAS VACAS O ID
        public int Tiempo { get; set; } //EL TIEMPO QUE TARDA CADA UNA EN CRUZAR 

        public Vaca(string nombre, int tiempo) 
        //ESTE COSTRUCTOR SOBRE CARGADO NOS AYUDA A PODER COMPAPARTIR LOS PARAMETROS 
        {
            Nombre = nombre;
            Tiempo = tiempo;
            //CON OTRAS CLASES DE FORMA PUBLICA
        }
    }
}
