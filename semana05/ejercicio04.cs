//ejercicios04
using System;
using System.Collections.Generic;

namespace ProgramaAbecedario
{
    class Program
    {
        static void MainDesactivado(string[] args)
        {
            // 1.lista y almacenamiento del abecedario
            List<char> abecedario = new List<char>();
            for (char letra = 'A'; letra <= 'Z'; letra++)
            {
                abecedario.Add(letra);
            }

            // 2. Eliminación de las letras en posiciones múltiplos de 3
            for (int i = abecedario.Count; i >= 1; i--)
            {
                if (i % 3 == 0)
                {
                    // Restamos 1 porque los índices en C# comienzan en 0
                    abecedario.RemoveAt(i - 1);
                }
            }

            // 3. Visualización del resultado
            Console.WriteLine("Abecedario resultante (sin múltiplos de 3):");
            Console.WriteLine(string.Join(", ", abecedario));

        }
    }
}