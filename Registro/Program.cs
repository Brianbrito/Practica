using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Registro
{
    public class Persona
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public List<Direccion> Direcciones { get; set; }
    }
    public class Direccion
    {
        
        public int Id{ get; set; }
        public string Calle { get; set; }
        public Persona Persona { get; set; }
        
    }
    public class BlogDbContext : DbContext
    {
        public DbSet<Persona> Personas { get; set; }
        public DbSet<Direccion> Direccions { get; set; }
    }


    class Program
    {
      
        static void Main(string[] args)
        {
            var context = new BlogDbContext();

            Console.Write("Ingrese su Nombre:");
            var Nombre = Convert.ToString(Console.ReadLine());

            Console.WriteLine();
            Console.Write("Ingrese su primer Apellido:");
            var Apellido = Convert.ToString(Console.ReadLine());

            Console.WriteLine();
            Console.Write("Ingrese el nombre de su calle:");
            var Calle = Convert.ToString(Console.ReadLine());

            var persona = new Persona()
            {
                Nombre = Nombre,
                Apellido = Apellido,
                 
            };

            var direccion = new Direccion()
            {
                Calle = Calle
            };


            context.Personas.Add(persona);
            context.Direccions.Add(direccion);
            context.SaveChanges();

        }
    }
}
