//persona en mi caso me e puesto yo mismo 
// Define los atributos comunes de una persona
public class Persona
{
    // Atributos como: (Nombre, Apellido, Dirección)
    public string Nombre { get; set; }
    public string Apellido { get; set; }
    public string Direccion { get; set; }

    // Constructor de la clase Persona
    public Persona(string nombre, string apellido, string direccion)
    {
        this.Nombre = nombre;
        this.Apellido = apellido;
        this.Direccion = direccion;
    }
}