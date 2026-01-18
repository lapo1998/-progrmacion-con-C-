using System;

namespace ProyectoListas
{
   
    // CLASE NODO:
    // Almacena los datos del vehículo y la referencia al siguiente nodo.

    class Vehiculo
    {
        // Atributos que representan los datos del vehículo según la guía
        public string Placa, Marca, Modelo;
        public int Anio;
        public double Precio;

        // Constructor para inicializar un nuevo objeto Vehiculo
        public Vehiculo(string placa, string marca, string modelo, int anio, double precio)
        {
            Placa = placa; 
            Marca = marca; 
            Modelo = modelo; 
            Anio = anio;
            Precio = precio;
        }
    }

    class Nodo
    {
        public Vehiculo Datos;    // Información del vehículo almacenada en el nodo
        public Nodo Siguiente;    // Puntero o referencia al siguiente nodo en la secuencia

        public Nodo(Vehiculo vehiculo) 
        { 
            Datos = vehiculo; 
            Siguiente = null; // Al crear el nodo, inicialmente no apunta a nadie
        }
    }

    
    // CLASE LISTA ENLAZADA: Gestiona la colección dinámica de nodos.
    // Implementa las operaciones de inserción, búsqueda y eliminación.
    class ListaEstacionamiento
    {
        private Nodo cabeza; // Referencia al primer elemento de la lista

        public ListaEstacionamiento() { cabeza = null; }

        // Operación A: Agregar vehículo al final de la lista
        public void AgregarVehiculo(Vehiculo v)
        {
            Nodo nuevo = new Nodo(v);
            if (cabeza == null) 
            {
                cabeza = nuevo; // Si la lista está vacía, el nuevo nodo es la cabeza
            }
            else
            {
                Nodo temp = cabeza;
                // Recorremos hasta el último nodo 
                while (temp.Siguiente != null) temp = temp.Siguiente;
                temp.Siguiente = nuevo; // Enlazamos el nuevo nodo al final
            }
        }

        // Operación B: Buscar vehículo por placa
        public void BuscarPorPlaca(string placa)
        {
            Nodo actual = cabeza;
            while (actual != null)
            {
                // Buscamos ignorando mayúsculas/minúsculas para evitar errores del usuario
                if (actual.Datos.Placa.Equals(placa, StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine($"\nVEHÍCULO LOCALIZADO: {actual.Datos.Marca} {actual.Datos.Modelo}");
                    Console.WriteLine($"Año: {actual.Datos.Anio} | Precio: ${actual.Datos.Precio:N2}");
                    return;
                }
                actual = actual.Siguiente;
            }
            Console.WriteLine("\nError: El vehículo no se encuentra en el registro de Ingeniería de Sistemas.");
        }

        // Operación C: Ver vehículos por año
        public void VerPorAnio(int anio)
        {
            Nodo actual = cabeza;
            bool encontrado = false;
            Console.WriteLine($"\nVehículos del año {anio} en el Área de Ingeniería:");
            while (actual != null)
            {
                if (actual.Datos.Anio == anio)
                {
                    Console.WriteLine($"- [{actual.Datos.Placa}] {actual.Datos.Marca} {actual.Datos.Modelo} - Precio: ${actual.Datos.Precio:N2}");
                    encontrado = true;
                }
                actual = actual.Siguiente;
            }
            if (!encontrado) Console.WriteLine("No existen registros para ese año.");
        }

        // Operación D: Ver todos los vehículos
        public void VerTodos()
        {
            if (cabeza == null) { Console.WriteLine("\nNo hay vehículos registrados en el estacionamiento."); return; }
            Nodo actual = cabeza;
            Console.WriteLine("\n--- REGISTRO DE VEHÍCULOS: ÁREA DE INGENIERÍA DE SISTEMAS - UEA ---");
            while (actual != null)
            {
                Console.WriteLine($"Placa: {actual.Datos.Placa.ToUpper()} | {actual.Datos.Marca} {actual.Datos.Modelo} | Año: {actual.Datos.Anio} | Precio: ${actual.Datos.Precio:N2}");
                actual = actual.Siguiente;
            }
        }

        // Operación E: Eliminar carro
        public void EliminarVehiculo(string placa)
        {
            if (cabeza == null) return;

            if (cabeza.Datos.Placa.Equals(placa, StringComparison.OrdinalIgnoreCase))
            {
                cabeza = cabeza.Siguiente; // La cabeza ahora apunta al segundo elemento
                Console.WriteLine("\nVehículo eliminado del registro satisfactoriamente.");
                return;
            }

            Nodo actual = cabeza;
            // Buscamos el nodo anterior al que queremos eliminar
            while (actual.Siguiente != null && !actual.Siguiente.Datos.Placa.Equals(placa, StringComparison.OrdinalIgnoreCase))
            {
                actual = actual.Siguiente;
            }

            // Si lo encontramos, "saltamos" el nodo objetivo enlazando el actual con el subsiguiente
            if (actual.Siguiente != null)
            {
                actual.Siguiente = actual.Siguiente.Siguiente;
                Console.WriteLine("\nVehículo eliminado del registro satisfactoriamente.");
            }
            else Console.WriteLine("\nError: No se encontró el vehículo para eliminar.");
        }
    }
    // CLASE PROGRAM: Interfaz de usuario y control del flujo principal.
   
    class Program
    {
        static void Main(string[] args)
        {
            ListaEstacionamiento parkUEA = new ListaEstacionamiento();
            int opcion;

            do
            {
                // Limpiamos pantalla y mostramos el encabezado institucional
                Console.Clear();
                Console.WriteLine("  REGISTRO DE LOS VEHÍCULOS DEL ESTACIONAMIENTO");
                Console.WriteLine("  ÁREA DE INGENIERÍA DE SISTEMAS DE LA UNIVERSIDAD UEA");
                Console.WriteLine("1. Agregar vehículo");
                Console.WriteLine("2. Buscar vehículo por placa");
                Console.WriteLine("3. Ver vehículos por año");
                Console.WriteLine("4. Ver todos los vehículos registrados");
                Console.WriteLine("5. Eliminar carro registrado");
                Console.WriteLine("6. Salir del sistema");
                Console.Write("\nSeleccione una operación: ");
                
                // Validación para evitar que el programa se cierre por entradas no numéricas
                if (!int.TryParse(Console.ReadLine(), out opcion)) continue;

                switch (opcion)
                {
                    case 1:
                        Console.WriteLine("\n--- Ingrese Datos del Vehículo ---");
                        Console.Write("Placa: "); string p = Console.ReadLine();
                        Console.Write("Marca: "); string m = Console.ReadLine();
                        Console.Write("Modelo: "); string mo = Console.ReadLine();
                        Console.Write("Año: "); int a = int.Parse(Console.ReadLine());
                        Console.Write("Precio: "); double pr = double.Parse(Console.ReadLine());
                        parkUEA.AgregarVehiculo(new Vehiculo(p, m, mo, a, pr));
                        break;
                    case 2:
                        Console.Write("\nIngrese placa a buscar: ");
                        parkUEA.BuscarPorPlaca(Console.ReadLine());
                        break;
                    case 3:
                        Console.Write("\nIngrese el año: ");
                        if(int.TryParse(Console.ReadLine(), out int anioFiltro))
                            parkUEA.VerPorAnio(anioFiltro);
                        break;
                    case 4:
                        parkUEA.VerTodos();
                        break;
                    case 5:
                        Console.Write("\nIngrese placa del vehículo a eliminar: ");
                        parkUEA.EliminarVehiculo(Console.ReadLine());
                        break;
                }
                if (opcion != 6) { Console.WriteLine("\nPresione cualquier tecla para volver al menú..."); Console.ReadKey(); }

            } while (opcion != 6);
        }
    }
}