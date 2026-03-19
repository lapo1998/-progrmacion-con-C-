using System;
namespace EstructuraDatos_BST
{
    // Clase que representa cada nodo del árbol
    public class Nodo
    {
        public int Valor;// Dato almacenado en el nodo
        public Nodo Izquierdo, Derecho; //Referencias a los hijos

        // Constructor: inicializa el nodo con un valor
        public Nodo(int item)
        {
            Valor = item;
            Izquierdo = Derecho = null; 
        }
    }

    // Clase que gestiona la lógica del Árbol Binario de Búsqueda (BST)
    public class ArbolBinario
    {
        public Nodo Raiz; //Nodo principal del árbol

        public ArbolBinario() => Raiz = null;

        // Se inserta un valor respetando la propiedad del BST
        public void Insertar(int valor) => Raiz = InsertarRecursivo(Raiz, valor);

        // Método recursivo de inserción
        private Nodo InsertarRecursivo(Nodo raiz, int valor)
        {
            // Si la posición está vacía, se crea un nuevo nodo
            if (raiz == null) return new Nodo(valor);

            // Se decide en qué subárbol insertar según el valor
            if (valor < raiz.Valor)
                raiz.Izquierdo = InsertarRecursivo(raiz.Izquierdo, valor);
            else if (valor > raiz.Valor)
                raiz.Derecho = InsertarRecursivo(raiz.Derecho, valor);

            // Se retorna el nodo actual para mantener la estructura
            return raiz;
        }

        // Busca un valor dentro del árbol
        public bool Buscar(int valor) => BuscarRecursivo(Raiz, valor);

        private bool BuscarRecursivo(Nodo raiz, int valor)
        {
            if (raiz == null) return false; // No encontrado si el valor no existe 
            if (raiz.Valor == valor) return true; // Encontrado si el valor existe 

            // Se continúa la búsqueda en el subárbol correspondiente
            return valor < raiz.Valor
                ? BuscarRecursivo(raiz.Izquierdo, valor)
                : BuscarRecursivo(raiz.Derecho, valor);
        }

        // Elimina un valor del árbol
        public bool Eliminar(int valor)
        {
            // Se valida si el valor existe antes de eliminar
            if (!Buscar(valor)) return false;

            Raiz = EliminarRecursivo(Raiz, valor);
            return true;
        }

        private Nodo EliminarRecursivo(Nodo raiz, int valor)
        {
            if (raiz == null) return raiz;

            // Se localiza el nodo a eliminar
            if (valor < raiz.Valor)
                raiz.Izquierdo = EliminarRecursivo(raiz.Izquierdo, valor);
            else if (valor > raiz.Valor)
                raiz.Derecho = EliminarRecursivo(raiz.Derecho, valor);
            else
            {
                // Caso 1: nodo sin hijo izquierdo
                if (raiz.Izquierdo == null) return raiz.Derecho;

                // Caso 2: nodo sin hijo derecho
                if (raiz.Derecho == null) return raiz.Izquierdo;

                // Caso 3: nodo con dos hijos
                // Se reemplaza con el valor mínimo del subárbol derecho
                raiz.Valor = ValorMinimo(raiz.Derecho);

                // Se elimina el nodo duplicado
                raiz.Derecho = EliminarRecursivo(raiz.Derecho, raiz.Valor);
            }

            return raiz;
        }

        // Obtiene el valor mínimo (nodo más a la izquierda)
        public int ValorMinimo(Nodo raiz)
        {
            Nodo actual = raiz;

            // Se recorre hacia la izquierda hasta el final
            while (actual.Izquierdo != null)
                actual = actual.Izquierdo;

            return actual.Valor;
        }

        // Obtiene el valor máximo (nodo más a la derecha)
        public int ValorMaximo(Nodo raiz)
        {
            Nodo actual = raiz;

            while (actual.Derecho != null)
                actual = actual.Derecho;

            return actual.Valor;
        }

        // Calcula la altura del árbol
        public int CalcularAltura(Nodo raiz)
        {
            if (raiz == null) return 0;

            // Se calcula la altura de ambos subárboles
            return 1 + Math.Max(
                CalcularAltura(raiz.Izquierdo),
                CalcularAltura(raiz.Derecho)
            );
        }

        // Recorrido Inorden (izquierda, raíz, derecha)
        public void Inorden(Nodo raiz)
        {
            if (raiz != null)
            {
                Inorden(raiz.Izquierdo);
                Console.Write($"{raiz.Valor} ");
                Inorden(raiz.Derecho);
            }
        }

        // Recorrido Preorden (raíz, izquierda, derecha)
        public void Preorden(Nodo raiz)
        {
            if (raiz != null)
            {
                Console.Write($"{raiz.Valor} ");
                Preorden(raiz.Izquierdo);
                Preorden(raiz.Derecho);
            }
        }

        // Recorrido Postorden (izquierda, derecha, raíz)
        public void Postorden(Nodo raiz)
        {
            if (raiz != null)
            {
                Postorden(raiz.Izquierdo);
                Postorden(raiz.Derecho);
                Console.Write($"{raiz.Valor} ");
            }
        }

        // Elimina todos los nodos del árbol
        public void LimpiarArbol() => Raiz = null;
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Instancia principal del árbol
            ArbolBinario bst = new ArbolBinario();
            int opcion;

            // Menú interactivo
            do
            {
                Console.WriteLine("\n========= ÁRBOL BST =========");
                Console.WriteLine("1. Insertar valor");
                Console.WriteLine("2. Buscar valor");
                Console.WriteLine("3. Eliminar valor");
                Console.WriteLine("4. Mostrar recorridos");
                Console.WriteLine("5. Ver métricas");
                Console.WriteLine("6. Limpiar árbol");
                Console.WriteLine("7. Salir");
                Console.Write("Seleccione: ");

                // Validación de entrada
                if (!int.TryParse(Console.ReadLine(), out opcion))
                {
                    Console.WriteLine("Entrada no válida.");
                    continue;
                }

                int valor;

                switch (opcion)
                {
                    case 1:
                        Console.Write("Ingrese valor: ");
                        if (int.TryParse(Console.ReadLine(), out valor))
                            bst.Insertar(valor);
                        break;

                    case 2:
                        Console.Write("Valor a buscar: ");
                        if (int.TryParse(Console.ReadLine(), out valor))
                            Console.WriteLine(bst.Buscar(valor) ? "Existe." : "No encontrado.");
                        break;

                    case 3:
                        Console.Write("Valor a eliminar: ");
                        if (int.TryParse(Console.ReadLine(), out valor))
                            Console.WriteLine(bst.Eliminar(valor) ? "Eliminado." : "No existe.");
                        break;

                    case 4:
                        Console.Write("Preorden: "); bst.Preorden(bst.Raiz);
                        Console.Write("\nInorden: "); bst.Inorden(bst.Raiz);
                        Console.Write("\nPostorden: "); bst.Postorden(bst.Raiz);
                        Console.WriteLine();
                        break;

                    case 5:
                        if (bst.Raiz != null)
                        {
                            Console.WriteLine($"Mínimo: {bst.ValorMinimo(bst.Raiz)}");
                            Console.WriteLine($"Máximo: {bst.ValorMaximo(bst.Raiz)}");
                            Console.WriteLine($"Altura: {bst.CalcularAltura(bst.Raiz)}");
                        }
                        else
                            Console.WriteLine("Árbol vacío.");
                        break;

                    case 6:
                        bst.LimpiarArbol();
                        Console.WriteLine("Árbol limpiado.");
                        break;
                }

            } while (opcion != 7);
        }
    }
}