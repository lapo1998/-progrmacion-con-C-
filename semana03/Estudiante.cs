using System;

// Estudiante Nombre, Apellido y Dirección
public class Estudiante : Persona
{
    // Atributos específicos del estudiante
    public int Id { get; set; }

    // Array (string[]) para almacenar los números de teléfono
    public string[] lTelefono { get; set; }

    // Constructor de Estudiante
    public Estudiante(int id, string nombre, string apellido, string direccion, string[] lTelefono)
        : base(nombre, apellido, direccion) 
    {
        this.Id = id;
        this.lTelefono = lTelefono;
    }

    // Método para mostrar la información del estudiante
    public void MostrarInformacion()
    {
        Console.WriteLine("\n--- Ficha de Registro de Estudiante ---");
        Console.WriteLine($"ID: {this.Id}");
        
        // Atributos heredados de Persona
        Console.WriteLine($"Nombre Completo: {this.Nombre} {this.Apellido}");
        Console.WriteLine($"Dirección: {this.Direccion}");
        Console.WriteLine("--------------------------------------");
        Console.WriteLine("Teléfonos Registrados:"); 
        
        int contador = 1;
        foreach (var telefono in this.lTelefono)
        {
            Console.WriteLine($"- Teléfono #{contador}: {telefono}");
            contador++;
        }
        Console.WriteLine("--------------------------------------\n");
    }
}