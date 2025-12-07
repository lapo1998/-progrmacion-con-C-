using System;

namespace FigurasGeometricas
{

    public class Circulo
    {
        private double radio; 

        // Propiedad pública que encapsula y valida el acceso al campo 'radio'.
        public double Radio
        {
            get { return radio; }
            set 
            {
                // Validación: El radio debe ser mayor que cero
                if (value > 0)
                {
                    radio = value;
                }
                else
                {
                    throw new ArgumentException("El radio debe ser mayor que cero.");
                }
            }
        }

        // Constructor para inicializar el objeto Círculo
        public Circulo(double radioInicial)
        {
            Radio = radioInicial; // Asigna usando la propiedad 
        }
        public double CalcularArea()
        {
            return Math.PI * Radio * Radio;
        }

        // Método para calcular el perímetro 
        public double CalcularPerimetro()
        {
            return 2 * Math.PI * Radio;
        }
    }

    public class Cuadrado
    {
   
        private double lado;

        public double Lado
        {
            get { return lado; }
            set
            {
                // Validación para asegurar que el lado sea positivo
                if (value > 0)
                {
                    lado = value;
                }
                else
                {
                    throw new ArgumentException("El lado debe ser mayor que cero.");
                }
            }
        }

        public Cuadrado(double ladoInicial)
        {
            Lado = ladoInicial; // Asigna usando la propiedad
        }

        public double CalcularArea()
        {
            return Lado * Lado;
        }
        public double CalcularPerimetro()
        {
            return 4 * Lado;
        }
    }
    public class Programa
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("=== FIGURAS GEOMÉTRICAS ===");
            Console.WriteLine();

            // Crear una instancia de Circulo con radio 5
            Circulo circulo = new Circulo(5);
            Console.WriteLine($"Círculo (radio = {circulo.Radio})");
            Console.WriteLine($"Área: {circulo.CalcularArea()}");
            Console.WriteLine($"Perímetro: {circulo.CalcularPerimetro()}");
            Console.WriteLine();

            // Crear una instancia de Cuadrado 
            Cuadrado cuadrado = new Cuadrado(7); 
            
            Console.WriteLine($"Cuadrado (lado = {cuadrado.Lado})");
            Console.WriteLine($"Área: {cuadrado.CalcularArea()}"); // Resultado: 7 * 7 = 49
            Console.WriteLine($"Perímetro: {cuadrado.CalcularPerimetro()}"); // Resultado: 4 * 7 = 28
            Console.WriteLine();
            
           
        }
    } 
}