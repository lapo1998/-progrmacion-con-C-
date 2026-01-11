// ejercicio01 
using System;
using System.Collections.Generic;

namespace ProgramaNumerosInversos
{
    class Program
    {
        static void MainDesactivado(string[] args)
        {
            // 1. Lista y almacenamiento de números del 1 al 10
            List<int> numeros = new List<int>();
            for (int i = 1; i <= 10; i++)
            {
                numeros.Add(i);
            }

            // 2. Creación de una lista auxiliar para el orden inverso
            List<string> resultado = new List<string>();

            for (int i = numeros.Count - 1; i >= 0; i--)
            {
                resultado.Add(numeros[i].ToString());
            }

            // 3. Visualización en pantalla de los elementos separados por comas
            string salida = string.Join(", ", resultado);
            Console.WriteLine(salida);

        }
    }
}