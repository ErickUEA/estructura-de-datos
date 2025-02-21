using System; // Importa el espacio de nombres System, que contiene clases fundamentales y tipos de datos.
using System.Collections.Generic; // Importa el espacio de nombres que permite el uso de colecciones genéricas, como List.
using System.Linq; // Importa el espacio de nombres que proporciona funcionalidades para consultas sobre colecciones.

class Materias //ejercicio 1
{   //Programa que almacena las asignaturas de un curso  en una lista y lo muestra por pantalla.
    public void listas_materias(){ // Método que gestiona la entrada y salida de materias.
        List <string> materias = new List<string>(); // Crea una lista de cadenas para almacenar los nombres de las materias.
        Console.Write("Numero de asignaturas a ingresar: "); // Solicita al usuario el número de asignaturas.
        int numero_asignatura = int.Parse(Console.ReadLine()); // Lee la entrada del usuario y la convierte a un entero.
        for (int i = 0; i < numero_asignatura; i++){ // Bucle que itera según el número de asignaturas.
            Console.Write($"Ingrese el nombre de la asignatura {i + 1}: "); // Pide al usuario que ingrese el nombre de cada asignatura.
            string asignatura = Console.ReadLine(); // Lee el nombre de la asignatura ingresada por el usuario.
            materias.Add(asignatura); // Agrega la asignatura a la lista de materias.
        }
        Console.WriteLine("\nLas asignaturas del curso son:"); // Imprime un mensaje antes de mostrar las asignaturas.
        foreach (string asignatura in materias){ // Bucle que recorre cada asignatura en la lista.
            Console.WriteLine(asignatura); // Muestra cada asignatura en la consola.
        }
    }
}

class ListaNumeros //ejercicio 5
{   //Programa que almacena en una lista los números del 1 al 10 y los muestre por pantalla en orden inverso separados por comas.
    private List<int> listaNumeros; // Declara una lista privada de enteros para almacenar los números.

    public ListaNumeros(){ // Constructor de la clase.
        listaNumeros = new List<int>(); // Inicializa la lista de números.
        for (int i = 1; i <= 10; i++){ // Bucle que itera del 1 al 10.
            listaNumeros.Add(i); // Agrega cada número a la lista.
        }
    }

    public void MostrarInverso(){ // Método que muestra los números en orden inverso.
        for (int i = listaNumeros.Count - 1; i >= 0; i--){ // Bucle que itera desde el último índice hasta el primero.
            Console.Write(i + (i > 0 ? ", " : "")); // Muestra el número y agrega una coma si no es el último.
        }
        Console.WriteLine(); // Para agregar un salto de línea al final.
    }
}

class Palindromo //ejercicio 8
{ //Programa que pida al usuario una palabra y muestre por pantalla si es un palíndromo.
    private List<string> listita; // Declara una lista privada de cadenas (aunque no se utiliza en este contexto).
    public void demuestra_palindromo(){ // Método que verifica si una palabra es un palíndromo.
        listita = new List<string>(); // Inicializa la lista (no se utiliza en este método).
        Console.Write("Introducir una palabra: "); // Pide al usuario que ingrese una palabra.
        string palabra = Console.ReadLine(); // Lee la palabra ingresada por el usuario.
        palabra = palabra.ToLower().Replace(" ", ""); // Convierte la palabra a minúsculas y elimina espacios.
        // Invertimos la palabra
        char[] arrayPalabra = palabra.ToCharArray(); // Convierte la palabra en un arreglo de caracteres.
        Array.Reverse(arrayPalabra); // Invierte el arreglo de caracteres.
        string palabraInvertida = new string(arrayPalabra); // Crea una nueva cadena a partir del arreglo invertido.
        if (palabra == palabraInvertida){ // Compara la palabra original con la invertida.
            Console.WriteLine($"'{palabra}' es un palindromo"); // Si son iguales, es un palíndromo.
        }else{
            Console.WriteLine($"'{palabra}' no es un palindromo"); // Si no son iguales, no es un palíndromo.
        }
    }
}

class Vocales //ejercicio 9
{   //programa que pida al usuario una palabra y muestre por pantalla el número de veces que contiene cada vocal.
    public void contar_vocales(){ // Método que cuenta las vocales en una palabra.
        Console .Write("Ingrese una palabra: "); // Pide al usuario que ingrese una palabra.
        string palabra = Console.ReadLine(); // Lee la palabra ingresada por el usuario.
        List <char> vocales = new List<char> {'a', 'e', 'i', 'o', 'u'}; // Crea una lista de caracteres que contiene las vocales.
        foreach (char vocal in vocales){ // Bucle que itera sobre cada vocal en la lista.
            int veces = 0; // Inicializa un contador para las veces que aparece la vocal.
            foreach (char letra in palabra){ // Bucle que itera sobre cada letra de la palabra ingresada.
                if (letra == vocal){ // Compara la letra actual con la vocal.
                    veces ++; // Si son iguales, incrementa el contador.
                }
            }
            Console.WriteLine($"La vocal '{vocal}' aparece {veces} veces"); // Muestra cuántas veces aparece la vocal en la palabra.
        }
    }
}

class Estadisticas // Clase para manejar estadísticas de números.
{
    private List<double> numeros; // Declara una lista privada de números de tipo double.

    public Estadisticas(){ // Constructor de la clase.
        numeros = new List<double>(); // Inicializa la lista de números.
    }

    public void CargarNumeros(string entrada){ // Método que carga números desde una cadena de entrada.
        // Separar la entrada por comas y convertir a números
        string[] partes = entrada.Split(','); // Divide la cadena de entrada en partes usando la coma como delimitador.
        foreach (var parte in partes) // Bucle que itera sobre cada parte de la entrada.
        {
            if (double.TryParse(parte.Trim(), out double numero)){ // Intenta convertir la parte a un número double.
                numeros.Add(numero); // Si tiene éxito, agrega el número a la lista.
            }else{
                Console.WriteLine($"'{parte}' no es un número válido y será ignorado."); // Si falla, muestra un mensaje de error.
            }
        }
    }

    public double CalcularMedia(){ // Método que calcula la media de los números.
        if (numeros.Count == 0) // Verifica si la lista está vacía.
            throw new InvalidOperationException("No hay números para calcular la media."); // Lanza una excepción si no hay números.
        return numeros.Average(); // Devuelve la media de los números en la lista.
    }

    public double CalcularDesviacionTipica() // Método que calcula la desviación típica de los números.
    {
        if (numeros.Count == 0) // Verifica si la lista está vacía.
            throw new InvalidOperationException("No hay números para calcular la desviación típica."); // Lanza una excepción si no hay números.

        double media = CalcularMedia(); // Calcula la media de los números.
        double sumaCuadrados = numeros.Sum(num => Math.Pow(num - media, 2)); // Calcula la suma de los cuadrados de las diferencias respecto a la media.
        return Math.Sqrt(sumaCuadrados / numeros.Count); // Devuelve la raíz cuadrada de la varianza (desviación típica).
    }
}

class Program // Clase principal que contiene el método Main.
{
    static void Main() // Método principal que se ejecuta al iniciar el programa.
    {   
        while (true){ // Bucle infinito que permite al usuario elegir opciones hasta que decida salir.
            Console.Write("Elegir una opcion para ver cada ejercicio\n1. Asignamiento de materias en una lista e imresion de la misma\n2. Almacenamiento de los numeros 1 hasta 10 en una lista y mostrandolos en forma inversa\n3. Detectar si una palabra es un palindromo\n4. Mostrar las veces que una vocal aparece en una palabra\n5. Ingreso de numeros y calculo de la media y desviacion tipica\n6. Salir\n"); // Muestra las opciones disponibles.
            int opciones = int.Parse(Console.ReadLine()); // Lee la opción elegida por el usuario.
            if (opciones == 1){ // Si el usuario elige la opción 1.
                Materias lista = new Materias(); // Crea una instancia de la clase Materias.
                lista.listas_materias(); // Llama al método para listar materias.
            }else if (opciones == 2){ // Si el usuario elige la opción 2.
                ListaNumeros numeros = new ListaNumeros(); // Crea una instancia de la clase ListaNumeros.
                numeros.MostrarInverso(); // Llama al método para mostrar los números en orden inverso.
            }else if (opciones == 3){ // Si el usuario elige la opción 3.
                Palindromo palindromo = new Palindromo(); // Crea una instancia de la clase Palindromo.
                palindromo.demuestra_palindromo(); // Llama al método para verificar si una palabra es un palíndromo.
            }else if (opciones == 4){ // Si el usuario elige la opción 4.
                Vocales palabra = new Vocales(); // Crea una instancia de la clase Vocales.
                palabra.contar_vocales(); // Llama al método para contar las vocales en una palabra.
            }else if (opciones == 5){ // Si el usuario elige la opción 5.
                Estadisticas estadisticas = new Estadisticas(); // Crea una instancia de la clase Estadisticas.
                Console.WriteLine("Introduce una muestra de números separados por comas:"); // Pide al usuario que ingrese números.
                string entrada = Console.ReadLine(); // Lee la entrada del usuario.
                estadisticas.CargarNumeros(entrada); // Carga los números desde la entrada.
                try // Intenta ejecutar el siguiente bloque de código.
                {
                    double media = estadisticas.CalcularMedia(); // Calcula la media de los números.
                    double desviacionTipica = estadisticas.CalcularDesviacionTipica(); // Calcula la desviación típica de los números.

                    Console.WriteLine($"La media es: {media}"); // Muestra la media calculada.
                    Console.WriteLine($"La desviación típica es: {desviacionTipica}"); // Muestra la desviación típica calculada.
                }
                catch (InvalidOperationException ex) // Captura excepciones de tipo InvalidOperationException.
                {
                    Console.WriteLine(ex.Message); // Muestra el mensaje de error si ocurre una excepción.
                }
            }else if (opciones == 6){ // Si el usuario elige la opción 6.
                Console.WriteLine("Saliendo..."); // Muestra un mensaje de salida.
                break; // Sale del bucle y termina el programa.
            }else{ // Si el usuario elige una opción no válida.
                Console.WriteLine("Opcion no existe. Intente nuevamente"); // Muestra un mensaje de error.
            }
        }
    }
}