using System;
using System.Collections.Generic;

public class PalabrasExistentes {
    public Dictionary<string, string> palabras { get; set; } // Propiedad que almacena un diccionario de palabras en inglés y sus traducciones en español.
    public PalabrasExistentes() { // Constructor de la clase PalabrasExistentes.
        palabras = new Dictionary<string, string>(); // Inicializa el diccionario de palabras.
        // Agrega pares de palabras en inglés y sus traducciones en español al diccionario.
        palabras.Add("time", "tiempo");
        palabras.Add("person", "persona");
        palabras.Add("year", "año");
        palabras.Add("way", "camino/forma");
        palabras.Add("day", "día");
        palabras.Add("man", "hombre");
        palabras.Add("world", "mundo");
        palabras.Add("life", "vida");
        palabras.Add("hand", "mano");
        palabras.Add("part", "parte");
        palabras.Add("woman", "mujer");
        palabras.Add("place", "lugar");
        palabras.Add("work", "trabajo");
        palabras.Add("case", "caso");
        palabras.Add("point", "punto/tema");
        palabras.Add("government", "gobierno");
        palabras.Add("company", "empresa/compañía");
    }
}

class Program {
    static void Main(string[] args) {
        while (true) {
            PalabrasExistentes palabra_existente = new PalabrasExistentes(); // Crea una nueva instancia de PalabrasExistentes.
            Console.WriteLine("Bienvenido a el menu, ¿que desea hacer?\n1. Traducir una frase\n2. Agregar palabras al diccionario\n0. Salir");
            int opcion = int.Parse(Console.ReadLine()); // Lee la opción del usuario y la convierte a un entero.

            if (opcion == 1) {
                Console.WriteLine("Ingrese la frase en ingles a traducir: ");
                string frase = Console.ReadLine();
                string[] palabrasFrase = frase.Split(' '); // Divide la frase en palabras usando el espacio como delimitador.
                List<string> traducciones = new List<string>(); // Crea una lista para almacenar las traducciones de las palabras.
                foreach (string palabra in palabrasFrase) { // Itera sobre cada palabra en la frase.
                    string palabraLimpia = palabra.Trim(new char[] { '.', ',', '!', '?' }); // Elimina signos de puntuación de la palabra.
                    // Intenta obtener la traducción de la palabra limpia del diccionario.
                    if (palabra_existente.palabras.TryGetValue(palabraLimpia, out string traduccion)) {
                        // Si se encuentra la traducción, se agrega a la lista de traducciones.
                        traducciones.Add(traduccion);
                    } else {
                        // Si no se encuentra la traducción, se agrega la palabra original a la lista.
                        traducciones.Add(palabra);
                    }
                }
                // Muestra la traducción completa de la frase.
                Console.WriteLine($"La traducción es: " + string.Join(" ", traducciones));
            } else if (opcion == 2) {
                Console.WriteLine("Ingrese la palabra en inglés: ");
                string palabraIngles = Console.ReadLine();
                Console.WriteLine("Ingrese la traducción en español: ");
                string traduccionEspanol = Console.ReadLine();
                // Verifica si la palabra en inglés ya existe en el diccionario.
                if (!palabra_existente.palabras.ContainsKey(palabraIngles)) {
                    palabra_existente.palabras.Add(palabraIngles, traduccionEspanol);
                    Console.WriteLine("Palabra agregada exitosamente.");
                } else {
                    Console.WriteLine("La palabra ya existe en el diccionario.");
                }
            } else if (opcion == 0) {
                Console.WriteLine("Cerrado programa, adios.");
                break; // Sale del bucle y termina el programa.
            } else { // Si el usuario ingresa una opción no válida.
                Console.WriteLine("No existe la opcion, intente denuevo");
            }
        }
    }
}