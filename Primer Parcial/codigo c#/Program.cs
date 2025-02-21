//Nombre: Ariel Paz
//Fecha: 03/12/2024
//--------------------------codigo-------------------------\\
// Definición de la clase Estrella
public class Estrella
{
    // Declaración de una variable privada para almacenar la longitud del lado de la estrella
    private double lado;
    // Constructor de la clase Estrella que inicializa el lado
    public Estrella(double lado)
    {
        // Asigna el valor del lado pasado como parámetro a la variable de instancia lado
        this.lado = lado;
    }
    // Método para calcular el área de la estrella
    public double CalcularArea()
    {
        // Fórmula para el área de una estrella regular de 5 puntas
        return (5 * lado * lado) / (4 * Math.Tan(Math.PI / 5)); // Retorna el área calculada
    }
    // Método para calcular el perímetro de la estrella
    public double CalcularPerimetro()
    {
        // El perímetro de la estrella es 5 veces la longitud de un lado
        return 5 * lado; // Retorna el perímetro calculado
    }
}

// Definición de la clase Hexagono
public class Hexagono
{
    // Declaración de una variable privada para almacenar la longitud del lado del hexágono
    private double lado;
    // Constructor de la clase Hexagono que inicializa el lado
    public Hexagono(double lado)
    {
        // Asigna el valor del lado pasado como parámetro a la variable de instancia lado
        this.lado = lado;
    }
    // Método para calcular el área del hexágono
    public double CalcularArea()
    {
        // Fórmula para el área de un hexágono regular
        return (3 * Math.Sqrt(3) * lado * lado) / 2; // Retorna el área calculada
    }
    // Método para calcular el perímetro del hexágono
    public double CalcularPerimetro()
    {
        // El perímetro del hexágono es 6 veces la longitud de un lado
        return 6 * lado; // Retorna el perímetro calculado
    }
}

// Clase principal donde se ejecuta el programa
class Program
{
    // Método principal que se ejecuta al iniciar el programa
    static void Main(string[] args)
    {
        // Crea una instancia de la clase Estrella con un lado de 8
        Estrella estrellita = new Estrella(8);
        // Crea una instancia de la clase Hexagono con un lado de 5
        Hexagono hexagui = new Hexagono(5);
        // Imprime el área de la estrella en la consola
        Console.WriteLine("Área de la estrella: " + estrellita.CalcularArea());
        // Imprime el perímetro de la estrella en la consola
        Console.WriteLine("Perímetro de la estrella: " + estrellita.CalcularPerimetro());
        // Imprime el área del hexágono en la consola
        Console.WriteLine("Área del hexágono: " + hexagui.CalcularArea());
        // Imprime el perímetro del hexágono en la consola
        Console.WriteLine("Perímetro del hexágono: " + hexagui.CalcularPerimetro());
    }
}