using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiendaElectronica_Entidades
{
    public class Producto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Marca { get; set; }
        public string Categoria { get; set; }
        public decimal Precio { get; set; }
        public int Stock { get; set; }
    }
    public class Usuario
    {
        public string Nombre { get; set; }
        public string DireccionEnvio { get; set; }
       
        public List<Producto> CarritoCompras { get; set; } = new List<Producto>(); //Inicializo la propiedad
    }
}
