//ejercicio05
using System;
using System.Collections.Generic;

namespace ConteoVocales
{
    class Program
    {
        static void Main(string[] args)
        {
            // 1. Solicitud de datos al usuario
            Console.Write("Por favor, ingrese una palabra: ");
            string palabra = Console.ReadLine().ToLower();

            // 2. Definición de las vocales a contabilizar
            char[] vocales = { 'a', 'e', 'i', 'o', 'u' };

            Console.WriteLine("\nResultado del conteo:");

            // 3. Lógica de búsqueda y conteo
            foreach (char vocal in vocales)
            {
                int contador = 0;
                foreach (char letra in palabra)
                {
                    if (letra == vocal)
                    {
                        contador++;
                    }
                }
                
                // 4. Visualización de resultados individuales
                Console.WriteLine($"La vocal '{vocal}' aparece: {contador} veces.");
            }
        }
    }
}