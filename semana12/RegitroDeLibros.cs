using System;                     
using System.Collections.Generic; 

class Biblioteca  // Se declara la clase principal del programa
{
    static void Main() 
    {
        // Se crea un conjunto (HashSet) para almacenar los ISBN y evitar duplicados
        HashSet<string> isbnRegistrados = new HashSet<string>();

        // Se crea un mapa (Dictionary) para relacionar el ISBN con el nombre del libro
        Dictionary<string, string> libros = new Dictionary<string, string>();

        int opcion; 

        do 
        {
            // Se muestran las opciones del sistema en pantalla
            Console.WriteLine("\n--- SISTEMA DE BIBLIOTECA ---");
            Console.WriteLine("1. Registrar libro");
            Console.WriteLine("2. Mostrar libros");
            Console.WriteLine("3. Buscar libro");
            Console.WriteLine("4. Salir");

            // opción ingresada por el usuario y se convierte a número entero
            opcion = int.Parse(Console.ReadLine());

            switch (opcion)
            {

                case 1: // Opción para registrar un nuevo libro

                    Console.Write("Ingrese ISBN: "); // Se solicita al usuario el código ISBN
                    string isbn = Console.ReadLine(); // Se guarda el ISBN ingresado

                    // Se verifica si el ISBN ya existe dentro del conjunto
                    if (isbnRegistrados.Contains(isbn))
                    {
                        // Si el ISBN ya está registrado, se muestra un mensaje
                        Console.WriteLine("El libro ya está registrado.");
                    }
                    else
                    {
                        // Si el ISBN no existe, se solicita el nombre del libro
                        Console.Write("Ingrese nombre del libro: ");
                        string nombre = Console.ReadLine(); // Se guarda el nombre del libro

                        // Se agrega el ISBN al conjunto para evitar duplicados
                        isbnRegistrados.Add(isbn);

                        // Se agrega el ISBN y el nombre del libro al Dictionary
                        libros.Add(isbn, nombre);

                        // Se muestra un mensaje confirmando el registro del libro
                        Console.WriteLine("Libro registrado correctamente.");
                    }

                    break; 

                case 2: // Opción para mostrar todos los libros registrados

                    Console.WriteLine("\nLista de libros:"); 

                    // Se utiliza un ciclo foreach para recorrer todos los elementos del Dictionary
                    foreach (var libro in libros)
                    {
                       
                        Console.WriteLine("ISBN: " + libro.Key + " - Libro: " + libro.Value);
                    }

                    break; 

                case 3: // Opción para buscar un libro por su ISBN

                    Console.Write("Ingrese ISBN a buscar: "); 
                    string buscar = Console.ReadLine(); 

                    // Se verifica si el ISBN existe dentro del Dictionary
                    if (libros.ContainsKey(buscar))
                    {
                        // Si el ISBN existe, se muestra el nombre del libro
                        Console.WriteLine("Libro encontrado: " + libros[buscar]);
                    }
                    else
                    {
                        // Si el ISBN no existe, se informa al usuario
                        Console.WriteLine("Libro no encontrado.");
                    }

                    break; 

            }

        } while (opcion != 4); // El ciclo se repite mientras la opción sea diferente de 4 (salir)

    }
}