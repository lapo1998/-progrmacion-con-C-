namespace TraductorBasico
{
    class Program 
    {
        // Crea un diccionario para traducir de inglés a español ignorando mayúsculas o minúsculas.
        static Dictionary<string, string> inglesAEspanol = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
        // Crea un diccionario inverso para permitir la traducción de español a inglés.
        static Dictionary<string, string> espanolAIngles = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);

        static void Main(string[] args) 
        {
            InicializarDiccionario(); 
            MenuPrincipal(); 
        }

        static void InicializarDiccionario() 
        {
            // Pabaras sugeridas
            var palabrasIniciales = new Dictionary<string, string>
            {
                {"Time", "tiempo"}, {"Person", "persona"}, {"Year", "año"},
                {"Way", "camino"}, {"Day", "día"}, {"Thing", "cosa"},
                {"Man", "hombre"}, {"World", "mundo"}, {"Life", "vida"},
                {"Hand", "mano"}, {"Part", "parte"}, {"Child", "niño"},
                {"Eye", "ojo"}, {"Woman", "mujer"}, {"Place", "lugar"},
                {"Work", "trabajo"}, {"Week", "semana"}, {"Case", "caso"},
                {"Point", "punto"}, {"Government", "gobierno"}, {"Company", "empresa"}
            };

            foreach (var item in palabrasIniciales)
            // Guardamos la palabra en inglés y su traducción al español
            {
                inglesAEspanol[item.Key] = item.Value; 
                espanolAIngles[item.Value] = item.Key; 
            }
        }

        static void MenuPrincipal()
        {
            int opcion; 
            do
            {
                // Menú en la consola.
                Console.WriteLine("\n==================== MENÚ ====================");
                Console.WriteLine("1. Traducir una frase");
                Console.WriteLine("2. Agregar palabras al diccionario");
                Console.WriteLine("0. Salir");
                Console.Write("\nSeleccione una opción: ");

                // Valida que la entrada sea un número entero para evitar errores de ejecución.
                if (int.TryParse(Console.ReadLine(), out opcion))
                {
                    switch (opcion) 
                    {
                        case 1: TraducirFrase(); break; // Ejecuta el proceso de traducción.
                        case 2: AgregarPalabras(); break; // opcion que permitea agregar mas palabras al diccionario.
                        case 0: Console.WriteLine("Cierre del sistema."); break; 
                        default: Console.WriteLine("Opción no válida."); break; 
                    }
                }
            } while (opcion != 0); // Repite el menú hasta que el usuario decida salir.
        }

        static void TraducirFrase() 
        {
            Console.WriteLine("\nIngrese la frase a procesar:");
            // Captura la oración ingresada por el usuario.
            string entrada = Console.ReadLine();
            string[] palabras = entrada.Split(' '); 
            List<string> resultado = new List<string>(); 

            foreach (string palabra in palabras) 
            {
                // Remueve signos de puntuación para que la búsqueda en el diccionario sea exacta.
                string limpia = palabra.Trim(new char[] { '.', ',', '!', '?' });
                string traduccion = limpia; // mantiene la palabra original si no hay match.

                // Verifica si el término existe en cualquiera de los dos diccionarios.
                if (inglesAEspanol.ContainsKey(limpia))
                    traduccion = inglesAEspanol[limpia]; // Sustituye por su par en español.
                else if (espanolAIngles.ContainsKey(limpia))
                    traduccion = espanolAIngles[limpia]; // Sustituye por su par en inglés.

                // Agrega la palabra (traducida o no) respetando los signos de puntuación originales.
                resultado.Add(palabra.Replace(limpia, traduccion));
            }

            Console.WriteLine("\nResultado:");
            Console.WriteLine(string.Join(" ", resultado)); 
        }

        static void AgregarPalabras() 
        {
            Console.Write("Ingrese palabra en Inglés: ");
            string ing = Console.ReadLine().Trim(); 
            Console.Write("Ingrese su equivalente en Español: ");
            string esp = Console.ReadLine().Trim(); 

            // Asegura que el usuario no ingrese campos nulos.
            if (!string.IsNullOrEmpty(ing) && !string.IsNullOrEmpty(esp))
            {
                inglesAEspanol[ing] = esp; 
                espanolAIngles[esp] = ing; 
                Console.WriteLine("Registro almacenado exitosamente.");
            }
            else
            {
                Console.WriteLine("Error: Los campos no pueden estar vacíos.");
            }
        }
    }
}