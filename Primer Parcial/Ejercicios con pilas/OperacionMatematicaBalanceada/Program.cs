using System; // Importa el espacio de nombres System, que contiene clases fundamentales y tipos de datos.
using System.Collections.Generic; // Importa el espacio de nombres que contiene clases para colecciones genéricas, como Stack.

class Program // Define una clase llamada Program.
{
    static void Main(string[] args) // Método principal que se ejecuta al iniciar el programa.
    {
        Console.WriteLine("Ingrese una ecuación matemática:"); // Solicita al usuario que ingrese una ecuación matemática.
        string ecuacion = Console.ReadLine(); // Lee la entrada del usuario y la almacena en la variable 'ecuacion'.
        
        // Llama a la función EsBalanceada para verificar si la ecuación está balanceada.
        if (EsBalanceada(ecuacion)) 
        {
            Console.WriteLine("La ecuación está balanceada."); // Mensaje si la ecuación está balanceada.
        }
        else
        {
            Console.WriteLine("La ecuación no está balanceada."); // Mensaje si la ecuación no está balanceada.
        }
    }

    // Método que verifica si la ecuación tiene paréntesis balanceados.
    static bool EsBalanceada(string ecuacion) 
    {
        Stack<char> pila = new Stack<char>(); // Crea una pila para almacenar los paréntesis abiertos.
        
        // Itera sobre cada carácter en la ecuación.
        foreach (char c in ecuacion) 
        {
            // Si el carácter es un paréntesis de apertura, lo agrega a la pila.
            if (c == '(' || c == '{' || c == '[') 
            {
                pila.Push(c); // Agrega el paréntesis abierto a la pila.
            }
            // Si el carácter es un paréntesis de cierre.
            else if (c == ')' || c == '}' || c == ']') 
            {
                // Verifica si la pila está vacía, lo que indica que no hay un paréntesis abierto correspondiente.
                if (pila.Count == 0) 
                {
                    return false; // Retorna false porque no hay un paréntesis abierto correspondiente.
                }
                
                char parAbierto = pila.Pop(); // Saca el último paréntesis abierto de la pila.
                
                // Verifica si el paréntesis de cierre corresponde al de apertura.
                if ((c == ')' && parAbierto != '(') || 
                    (c == '}' && parAbierto != '{') || 
                    (c == ']' && parAbierto != '[')) 
                {
                    return false; // Retorna false si los paréntesis no coinciden.
                }
            }
        }
        
        // Si la pila no está vacía, significa que hay paréntesis abiertos sin cerrar.
        return pila.Count == 0; // Retorna true si la pila está vacía (todos los paréntesis están balanceados).
    }
}