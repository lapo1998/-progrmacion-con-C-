using System;
using System.Collections.Generic;
using System.IO;

namespace PracticaUEA
{
    /// Clase Grafo: Implementa una estructura de datos no dirigida 
    /// utilizando listas de adyacencia para optimizar la memoria.
    class Grafo
    {
        // Diccionario que actúa como lista de adyacencia:
        // TKey (string): El nombre del nodo (ejemplo. ciudad o persona).
        // TValue (List<string>): Lista de nodos con los que tiene conexión directa.
        private Dictionary<string, List<string>> listaAdyacencia;

        // Constructor para inicializar la estructura de datos
        public Grafo()
        {
            listaAdyacencia = new Dictionary<string, List<string>>();
        }

        /// Agrega una arista (conexión) entre dos nodos. 
        /// Al ser un grafo no dirigido, la relación es recíproca.

        public void AgregarArista(string origen, string destino)
        {
            // Si el nodo de origen no existe en el diccionario, lo creamos
            if (!listaAdyacencia.ContainsKey(origen))
                listaAdyacencia[origen] = new List<string>();

            // Si el nodo de destino no existe, lo creamos para asegurar la bidireccionalidad
            if (!listaAdyacencia.ContainsKey(destino))
                listaAdyacencia[destino] = new List<string>();

            // Agregamos la conexión de origen a destino (evitando duplicados)
            if (!listaAdyacencia[origen].Contains(destino))
                listaAdyacencia[origen].Add(destino);

            // Agregamos la conexión de destino a origen (propiedad de grafo no dirigido)
            if (!listaAdyacencia[destino].Contains(origen))
                listaAdyacencia[destino].Add(origen);
        }

        /// Genera la reportería solicitada en la guía para visualizar 
        /// y consultar los elementos que conforman la estructura.
        public void MostrarReporteria()
        {
            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine("          REPORTE DE ESTRUCTURA DE DATOS          ");
            Console.WriteLine("--------------------------------------------------");
            
            foreach (var nodo in listaAdyacencia)
            {
                // Imprime el nodo principal y une sus vecinos con comas para facilitar la lectura
                Console.WriteLine($"Elemento: [{nodo.Key}] | Conectado con: {string.Join(", ", nodo.Value)}");
            }
            Console.WriteLine("--------------------------------------------------\n");
        }
    }

    class Program
    {
        /// <summary>
        /// Método para cargar datos externos desde un bloque de notas (.txt).
        /// Cumple con el requerimiento de procesar información de fuentes secundarias.
        /// </summary>
        static Grafo CargarDesdeArchivo(string nombreArchivo)
        {
            Grafo nuevoGrafo = new Grafo();
            
            // Intenta localizar el archivo en diferentes niveles de carpetas para evitar errores de ruta
            string rutaBase = AppDomain.CurrentDomain.BaseDirectory;
            string rutaFinal = Path.Combine(rutaBase, "..", "..", "..", nombreArchivo);

            // Verificamos si el archivo existe antes de intentar leerlo
            if (!File.Exists(rutaFinal)) rutaFinal = nombreArchivo;

            try
            {
                if (File.Exists(rutaFinal))
                {
                    // Leemos todas las líneas del bloc de notas
                    string[] lineas = File.ReadAllLines(rutaFinal);
                    foreach (string linea in lineas)
                    {
                        // Dividimos la línea por el espacio para obtener origen y destino
                        string[] nodos = linea.Trim().Split(' ');
                        if (nodos.Length == 2)
                        {
                            nuevoGrafo.AgregarArista(nodos[0], nodos[1]);
                        }
                    }
                }
                else
                {
                    Console.WriteLine($"[Error]: No se encontró el archivo {nombreArchivo} en la ruta especificada.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[Excepción]: Error al procesar el archivo de texto: {ex.Message}");
            }

            return nuevoGrafo;
        }

        static void Main(string[] args)
        {
            // Inicialización del cronómetro para el análisis de tiempo de ejecución solicitado en la guía 
            var stopwatch = System.Diagnostics.Stopwatch.StartNew();


            // EJEMPLO 1: Procesamiento de Red Social (Basado en datos de bloc de notas)
            Console.WriteLine(">>> EJECUTANDO EJEMPLO 1: RED SOCIAL");
            Grafo ejemplo1 = CargarDesdeArchivo("grafo1.txt");
            ejemplo1.MostrarReporteria();

            // EJEMPLO 2: Procesamiento de Conexiones Aéreas en Ecuador
            Console.WriteLine(">>> EJECUTANDO EJEMPLO 2: RUTAS ECUADOR");
            Grafo ejemplo2 = CargarDesdeArchivo("grafo2.txt");
            ejemplo2.MostrarReporteria();

            // Finalización del análisis de rendimiento
            stopwatch.Stop();
            Console.WriteLine($"ANÁLISIS DE RENDIMIENTO: Tiempo total de procesamiento: {stopwatch.ElapsedMilliseconds} ms.");
            
            Console.WriteLine("\nOperación completada con éxito. Presione cualquier tecla para cerrar...");
            Console.ReadKey();
        }
    }
}