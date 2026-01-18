using System;

namespace ProyectoListas
{
    //  NODO

    class Nodo

    {

        public int Dato;

        public Nodo Siguiente;



        public Nodo(int dato)

        {

            Dato = dato;

            Siguiente = null;

        }

    }
    //  LISTA ENLAZADA

    class Lista
    {
        private Nodo cabeza;
        public Lista()
        {
            cabeza = null;
        }
        // Método para insertar elementos al final

        public void InsertarFinal(int dato)
        {
            Nodo nuevoNodo = new Nodo(dato);
            if (cabeza == null)
            {
                cabeza = nuevoNodo;
            }
            else
            {
                Nodo temporal = cabeza;
                while (temporal.Siguiente != null)
                {
                    temporal = temporal.Siguiente;
                }
                temporal.Siguiente = nuevoNodo;
            }
        }
        // Función que cuenta el número de SALTOS ---
        public int CalcularNumeroDeSaltos()
        {
            // Si la lista está vacía o solo tiene un elemento, no hay saltos que realizar
            if (cabeza == null || cabeza.Siguiente == null)
            {
                return 0;
            }
            int saltos = 0;
            Nodo actual = cabeza;
            // Recorremos la lista hasta que no haya un "Siguiente" a donde saltar

            while (actual.Siguiente != null)
            {
                saltos++; // Incrementamos el contador de saltos
                actual = actual.Siguiente; // Realizamos el salto al siguiente nodo
            }
            return saltos;
        }
        // Método para visualizar la lista en consola
        public void Mostrar()
        {
            Nodo actual = cabeza;

            while (actual != null)
            {
                Console.Write($"[{actual.Dato}] -> ");
                actual = actual.Siguiente;
            }
            Console.WriteLine("null");

        }

    }
    // PROGRAMA PRINCIPAL

    class Program
    {
        static void Main(string[] args)
        {

            Lista miLista = new Lista();
            // Insertamos 5 elementos esto generará 4 saltos

            miLista.InsertarFinal(10);

            miLista.InsertarFinal(20);

            miLista.InsertarFinal(30);

            miLista.InsertarFinal(40);

            miLista.InsertarFinal(50);
            Console.WriteLine("Visualización de la Lista Enlazada:");

            miLista.Mostrar();
            // Ejecución del algoritmo para cañcular el numero de saltos

            int saltosRealizados = miLista.CalcularNumeroDeSaltos();
            Console.WriteLine("\n-------------------------------------------------");

            Console.WriteLine($"RESULTADO: Se realizaron {saltosRealizados} saltos para recorrer la lista.");

            Console.WriteLine("-------------------------------------------------");



        }

    }

}

