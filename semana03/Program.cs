//programa
Console.WriteLine("2526 - ESTRUCTURA DE DATOS - UEA / SEMANA 03");
Console.WriteLine("\n");

// 1. Declaración e inicialización del Array con los datos de Elvio
string[] lTelefono = new string[3] 
{ 
    "0999988180", // Teléfono #1
    "0985726294", // Teléfono #2
    "0979542106"  // Teléfono #3
};

// 2. Creación del objeto Estudiante con los datos de Elvio Manuel
Estudiante estudiante = new Estudiante(
    id: 1998, 
    nombre: "Elvio Manuel", 
    apellido: "Lapo Agreda", 
    direccion: "Loja-Calvas", 
    lTelefono: lTelefono 
);

// 3. Llamar al método para mostrar la información
estudiante.MostrarInformacion();
