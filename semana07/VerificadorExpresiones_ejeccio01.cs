using System; 
using System.Collections.Generic;

class ProgramaValidacion
{
    static void MainDesactivado(string[] args)
    {
        // expresión matemática a evaluar
        string nuevaExpresion = "[5 * (4 + 2) / {10 - 3}]";

        Console.WriteLine("Evaluando la expresión: " + nuevaExpresion);

        //invoca la función de validación y muestra el resultado final
        if (ValidarBalanceo(nuevaExpresion))
        {
            Console.WriteLine("Resultado: Fórmula balanceada.");
        }
        else
        {
            Console.WriteLine("Resultado: Fórmula no balanceada.");
        }
    }


    /// utilizamos una pila para verificar la simetría de los signos de agrupación.
    static bool ValidarBalanceo(string texto)
    {
        // Se instancia una nueva pila de caracteres
        Stack<char> pilaSimbólica = new Stack<char>();

        // Ciclo foreach para recorrer cada uno de los caracteres presentes en la expresión
        foreach (char c in texto)
        {

            if (c == '(' || c == '[' || c == '{')
            {
                // Se inserta el símbolo en la cima de la pila
                pilaSimbólica.Push(c);
            }
            // Paso 2: Si el carácter detectado es un símbolo de CIERRE, se valida la pila
            else if (c == ')' || c == ']' || c == '}')
            {
                // Si encontramos un cierre pero la pila está vacía, la expresión no está balanceada
                if (pilaSimbólica.Count == 0) return false;

                // Se extrae el último símbolo de apertura ingresado para comparar
                char apertura = pilaSimbólica.Pop();

                if (!SonParejaCompatible(apertura, c))
                {
                    return false;
                }
            }
        }

        //  Al terminar el recorrido, si la pila está vacía (Count == 0), todo se cerró correctamente
        return pilaSimbólica.Count == 0;
    }

    /// Método auxiliar para validar la correspondencia entre los pares de símbolos.

    static bool SonParejaCompatible(char op, char cl)
    {
        // Verificación lógica de pares: paréntesis, corchetes y llaves
        if (op == '(' && cl == ')') return true;
        if (op == '[' && cl == ']') return true;
        if (op == '{' && cl == '}') return true;
        
        // Si no coincide ninguno de los pares anteriores, retorna falso
        return false;
    }
}