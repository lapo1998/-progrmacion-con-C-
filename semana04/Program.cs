using System; 
using System.Collections.Generic;

namespace AgendaUEA // Definición del espacio de nombres para organizar el proyecto.
{
    class Contacto
    {
        // string para almacenar y recuperar el nombre del contacto.
        public string Nombre { get; set; } 
        //string para gestionar el dato del número telefónico.
        public string Telefono { get; set; } 

        // Inicializa los atributos al instanciar un nuevo objeto.
        public Contacto(string nombre, string telefono)
        {
            Nombre = nombre; // Asignación del parámetro nombre
            Telefono = telefono; // Asignación del parámetro teléfono 
        }

        // Esta codigo despliega en la terminal los estados actuales del objeto.
        public void Mostrar()
        {
            // Cadenas para presentar el reporte individual del contacto.
            Console.WriteLine("Nombre: " + Nombre + " | Tel: " + Telefono);
        }
    }

    class Program 
    {
        static void Main(string[] args) 
        {
            List<Contacto> agenda = new List<Contacto>(); 
            // Variable entera para almacenar la selección del usuario en el menú interactivo.
            int opcion = 0; 

            do
            {
                // Bloque de instrucciones para visualizar las opciones del sistema
                Console.WriteLine("\n--- AGENDA TELEFONICA UEA ---");
                Console.WriteLine("1. Agregar Contacto");
                Console.WriteLine("2. Ver Todos (Reporteria)");
                Console.WriteLine("3. Buscar por Nombre");
                Console.WriteLine("4. Salir");
                Console.Write("Seleccione una opcion: ");
                
                // Lectura de la entrada del usuario desde el flujo de entrada estándar.
                string entrada = Console.ReadLine(); 
                // Validación y conversión de la entrada de texto a un tipo de dato entero (int).
                if (int.TryParse(entrada, out opcion))
                {
                    // Evaluación de la opción seleccionada para ejecutar el registro de datos.
                    if (opcion == 1)
                    {
                        Console.Write("Nombre: ");
                        string nom = Console.ReadLine(); 
                        Console.Write("Telefono: ");
                        string tel = Console.ReadLine();
                        
                        // Instanciación y adición de un nuevo objeto Contacto a la lista dinámica.
                        agenda.Add(new Contacto(nom, tel)); 
                        Console.WriteLine("Contacto guardado."); // Confirmación visual de la persistencia.
                    }
                    // Evaluación de la opción para visualizar la totalidad de los registros.
                    else if (opcion == 2)
                    {
                        Console.WriteLine("\n--- LISTA DE CONTACTOS ---");
                        // Bucle de iteración para recorrer cada objeto almacenado en la estructura List.
                        foreach (var c in agenda) { c.Mostrar(); } 
                    }
                    // Evaluación de la opción para ejecutar el módulo de consulta por filtrado.
                    else if (opcion == 3)
                    {
                        Console.Write("Nombre a buscar: ");
                        string buscar = Console.ReadLine();
                        bool encontrado = false; // Variable de bandera para controlar el estado de la búsqueda.
                        
                        // Recorrido de la lista para localizar coincidencia mediante búsqueda lineal.
                        foreach (var c in agenda)
                        {
                            // Comparación de cadenas ignorando diferencias entre mayúsculas y minúsculas.
                            if (c.Nombre.ToLower() == buscar.ToLower())
                            {
                                c.Mostrar(); // Invocación del método mostrar si hay coincidencia.
                                encontrado = true; // Cambio de estado al localizar el nodo específico.
                            }
                        }
                        // Condicional para notificar al usuario en caso de no hallar el registro.
                        if (!encontrado) Console.WriteLine("No se encontro el contacto.");
                    }
                }
            // Condición de salida del bucle: El programa finaliza si el usuario selecciona la opción 4.
            } while (opcion != 4); 
        }
    }
}