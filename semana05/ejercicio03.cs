//ejercicio03
using System;
using System.Collections.Generic;
using System.Linq;

namespace ProgramaLoteria
{
    class Program
    {
         static void MainDesactivado(string[] args)
        {
            // 1.lista para los números
            List<int> numerosGanadores = new List<int>();

            Console.WriteLine("--- Registro de Lotería Primitiva ---");

            // 2. Bucle para solicitar 6 números al usuario
            for (int i = 1; i <= 6; i++)
            {
                Console.Write($"Ingrese el número ganador {i}: ");
                int numero = int.Parse(Console.ReadLine());
                numerosGanadores.Add(numero);
            }

            // 3. Ordenamiento de la lista de menor a mayor
            numerosGanadores.Sort();

            // 4. Visualización de los resultados
            Console.WriteLine("\nLos números ganadores ordenados son:");
            Console.WriteLine(string.Join(", ", numerosGanadores));
        }
    }
}