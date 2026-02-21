using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Console.WriteLine("=== Campaña de Vacunación COVID-19 ===");

        // 1. Creamos el conjunto ficticio de 500 ciudadanos usando HashSet
        HashSet<string> conjuntoU = new HashSet<string>();
        for (int i = 1; i <= 500; i++)
        {
            conjuntoU.Add("Ciudadano " + i);
        }

        // 2. Crear conjuntos de 75 ciudadanos para Pfizer y AstraZeneca
        HashSet<string> conjuntoA = GenerarVacunados(); // Pfizer
        HashSet<string> conjuntoB = GenerarVacunados(); // AstraZeneca
        
        // Listado de ciudadanos que han recibido ambas vacunas (A ∩ B)
        var ambasDosis = new HashSet<string>(conjuntoA);
        ambasDosis.IntersectWith(conjuntoB);

        // Listado de ciudadanos que solo tienen la vacuna de Pfizer (A - B)
        var soloPfizer = new HashSet<string>(conjuntoA);
        soloPfizer.ExceptWith(conjuntoB);

        // Listado de ciudadanos que solo tienen la vacuna de AstraZeneca (B - A)
        var soloAstra = new HashSet<string>(conjuntoB);
        soloAstra.ExceptWith(conjuntoA);

        // Ciudadanos no vacunados (U - (A U B))
        var vacunadosTotales = new HashSet<string>(conjuntoA);
        vacunadosTotales.UnionWith(conjuntoB);
        var noVacunados = new HashSet<string>(conjuntoU);
        noVacunados.ExceptWith(vacunadosTotales);

        // Salida de datos
        Console.WriteLine($"Total ciudadanos: {conjuntoU.Count}");
        Console.WriteLine($"Vacunados con Pfizer: {conjuntoA.Count}");
        Console.WriteLine($"Vacunados con AstraZeneca: {conjuntoB.Count}");
        Console.WriteLine($"Ciudadanos no vacunados: {noVacunados.Count}");
        Console.WriteLine($"Ciudadanos con ambas vacunas: {ambasDosis.Count}");
        Console.WriteLine($"Ciudadanos solo con Pfizer: {soloPfizer.Count}");
        Console.WriteLine($"Ciudadanos solo con AstraZeneca: {soloAstra.Count}");
    }
     //Método para generar ciudadanos vacunados de manera aleatoria.

    static HashSet<string> GenerarVacunados()
    {
        HashSet<string> conjunto = new HashSet<string>();
        Random random = new Random();
        
        // El bucle garantiza exactamente 75 elementos únicos
        while (conjunto.Count < 75)
        // Genera un número entre 1 y 500
        {
            int num = random.Next(1, 500);
            conjunto.Add("Ciudadano " + num);
        }
        
        return conjunto;
    }
}