//ejercicio02
using System;
using System.Collections.Generic;

namespace ProgramaAsignaturasPersonalizadas
{
    class Program
    {
      static void MainDesactivado(string[] args)
        {
            // 1. Almacenamiento de las asignaturas de la materia de TIC  en la UEA 3 ciclo
            List<string> asignaturas = new List<string> 
            { 
                "Administracion de sistemas operativos", 
                "Estructura de datos", 
                "Fundamentos de sistemas digitales", 
                "Instalaciones electricas y de cableado", 
                "Metodologia de la Investigacion" 
            };

            // 2. Visualización de la lista en la terminal
            Console.WriteLine("Lista de asignaturas del ciclo:");
            Console.WriteLine("----------------------------------");
            
            foreach (string materia in asignaturas)
            {
                Console.WriteLine("- " + materia);
            }
        }
    }
}