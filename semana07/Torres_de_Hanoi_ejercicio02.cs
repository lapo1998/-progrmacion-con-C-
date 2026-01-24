using System;
using System.Collections.Generic;

class ProgramaHanoiDinamico
{
    // Declaración de tres pilas para representar los postes, almacenando números enteros "discos"
    static Stack<int> torreOrigen = new Stack<int>();
    static Stack<int> torreAuxiliar = new Stack<int>();
    static Stack<int> torreDestino = new Stack<int>();

    static void Main()
    {
        Console.WriteLine("  RESOLUCIÓN DE LAS TORRES DE HANOI CON PILAS");
        
        // solicita al usuario la cantidad de discos para la base de la torre
        Console.Write("Ingrese el número de discos para jugar: ");
        int nDiscos;
        
        // Se valida que la entrada sea un número entero y positivo
        if (!int.TryParse(Console.ReadLine(), out nDiscos) || nDiscos <= 0)
        {
            Console.WriteLine("Error: Por favor, ingrese un número entero positivo.");
            return; // Finaliza la ejecución si la entrada es inválida
        }

        // Se inicializa la torre de origen utilizando un ciclo for descendente
        for (int i = nDiscos; i >= 1; i--)
        {
            torreOrigen.Push(i);
        }

        Console.WriteLine($"\nIniciando juego con {nDiscos} discos...");
        Console.WriteLine("Movimientos a realizar:\n");

        // Inicio del algoritmo recursivo que gestiona los movimientos
        ResolverHanoi(nDiscos, torreOrigen, torreDestino, torreAuxiliar, "A", "C", "B");

        // Mensaje de finalización exitosa
        Console.WriteLine("¡Felicidades! Se ha completado el desplazamiento.");

        
        // Se mantiene la consola abierta para visualizar los resultados
        Console.WriteLine("Presione cualquier tecla para salir...");
        Console.ReadKey();
    }


    /// Método recursivo que descompone el problema de Hanoi
    static void ResolverHanoi(int n, Stack<int> origen, Stack<int> destino, Stack<int> auxiliar, 
                              string nombreOrigen, string nombreDestino, string nombreAuxiliar)
    {
        // Si solo queda un disco, se realiza el movimiento directo
        if (n == 1)
        {
            MoverDisco(origen, destino, nombreOrigen, nombreDestino);
            return;
        }

        ResolverHanoi(n - 1, origen, auxiliar, destino, nombreOrigen, nombreAuxiliar, nombreDestino);
        MoverDisco(origen, destino, nombreOrigen, nombreDestino);
        ResolverHanoi(n - 1, auxiliar, destino, origen, nombreAuxiliar, nombreDestino, nombreOrigen);
    }

    /// Ejecuta físicamente el cambio de un disco entre pilas

    static void MoverDisco(Stack<int> origen, Stack<int> destino, string desde, string hacia)
    {
        //Operación Pop se extrae el elemento de la cima de la pila origen
        int disco = origen.Pop();
        
        // Operación Push se coloca el elemento extraído en la cima de la pila destino
        destino.Push(disco);
        
        // Impresión en pantalla para documentar el rastro de la ejecución
        Console.WriteLine($"[Paso] Mover disco {disco} de Torre {desde} a Torre {hacia}");
    }
}