using System;
using System.Collections.Generic;

namespace ParqueDiversiones
{
    // Esta clase representa a los visitantes. 
    // Guardamos su nombre y el turno asignado para que todo sea justo.
    class Persona
    {
        public string Nombre { get; set; }
        public int Turno { get; set; }

        public Persona(string nombre, int turno)
        {
            Nombre = nombre;
            Turno = turno;
        }

        // Este método nos ayuda a imprimir los datos de la persona de forma clara.
        public override string ToString()
        {
            return $"Turno {Turno} - {Nombre}";
        }
    }

    class Atraccion
    {
        // La "Cola" nos asegura que el primero que llegue sea el primero en subir.
        private Queue<Persona> cola = new Queue<Persona>();
        
        private int capacidad = 30; 
        private int contadorTurnos = 1;

        // SECCIÓN DE REPORTERÍA 
        
        // Este método cumple con el requisito de visualizar y consultar los elementos.
        public void GenerarReporte()
        {
            Console.WriteLine("\nREPORTE DE VISITANTES EN ESPERA ");
            if (cola.Count == 0)
            {
                Console.WriteLine("La fila se encuentra vacía en este momento.");
            }
            else
            {
                // Consultamos y recorremos cada elemento de la estructura de datos.
                foreach (Persona p in cola)
                {
                    Console.WriteLine($"- {p.ToString()}");
                }
            }
            Console.WriteLine("=====================================================");
            MostrarEstadoAsientos();
        }

        // MÉTODOS DE OPERACIÓN

        public void AgregarPersona(string nombre)
        {
            if (cola.Count < capacidad)
            {
                Persona p = new Persona(nombre, contadorTurnos++);
                cola.Enqueue(p); 
                Console.WriteLine("Persona agregada: " + p);
                MostrarEstadoAsientos();
            }
            else
            {
                Console.WriteLine("Lo sentimos, la Rueda Moscovita está llena.");
            }
        }

        public void MostrarEstadoAsientos()
        {
            int ocupados = cola.Count;
            int disponibles = capacidad - ocupados;
            Console.WriteLine($"Asientos ocupados: {ocupados}");
            Console.WriteLine($"Asientos disponibles: {disponibles}\n");
        }

        public void SubirAtraccion()
        {
            Console.WriteLine("\n--- Iniciando el recorrido en la Rueda Moscovita ---");
            while (cola.Count > 0)
            {
                Persona p = cola.Dequeue(); 
                Console.WriteLine("Subiendo a la cabina: " + p);
            }
            Console.WriteLine("Todos los asientos han sido procesados. ¡La atracción está en movimiento!");
        }

        public bool EstaLlena()
        {
            return cola.Count == capacidad;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("     ATRACCIÓN RUEDA MOSCOVITA"); 
            Console.ResetColor();
            
            Atraccion rueda = new Atraccion();
            bool salir = false;

            // Menú interactivo para gestionar la reportería y el ingreso manual
            while (!salir)
            {
                Console.WriteLine("\n--- MENÚ DE CONTROL ---");
                Console.WriteLine("1. Registrar nuevo visitante");
                Console.WriteLine("2. Ver reporte de la fila");
                Console.WriteLine("3. Iniciar atracción");
                Console.WriteLine("4. Cerrar sistema");
                Console.Write("Seleccione una opción: ");
                
                string opcion = Console.ReadLine() ?? "";

                switch (opcion)
                {
                    case "1":
                        if (!rueda.EstaLlena())
                        {
                            Console.Write("Ingrese nombre de la persona: ");
                            rueda.AgregarPersona(Console.ReadLine() ?? "Anónimo");
                        }
                        else { Console.WriteLine("Atracción llena."); }
                        break;
                    case "2":
                        rueda.GenerarReporte();
                        break;
                    case "3":
                        rueda.SubirAtraccion();
                        break;
                    case "4":
                        salir = true;
                        break;
                    default:
                        Console.WriteLine("Opción no válida.");
                        break;
                }
            }
        }
    }
}