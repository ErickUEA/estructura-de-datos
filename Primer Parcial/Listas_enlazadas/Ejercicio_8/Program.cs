using System; // Importa el espacio de nombres System, que contiene clases fundamentales
using System.Collections.Generic; // Importa el espacio de nombres para usar listas genéricas

// Definición de la clase Nodo que representa un nodo en la lista enlazada
class Nodo{
    public double Valor; // Propiedad para almacenar el valor del nodo
    public Nodo Siguiente; // Propiedad para apuntar al siguiente nodo en la lista
    
    // Constructor que inicializa el nodo con un valor
    public Nodo(double valor){
        Valor = valor; // Asigna el valor al nodo
        Siguiente = null; // Inicializa el siguiente nodo como null
    }
}

// Definición de la clase Lista que representa una lista enlazada de nodos
class Lista{
    private Nodo cabeza; // Propiedad privada que apunta al primer nodo de la lista
    
    // Método para agregar un nuevo valor a la lista
    public void Agregar(double valor){
        Nodo nuevoNodo = new Nodo(valor); // Crea un nuevo nodo con el valor proporcionado
        if (cabeza == null){ // Si la lista está vacía
            cabeza = nuevoNodo; // Asigna el nuevo nodo como cabeza
        }else{
            Nodo temp = cabeza; // Comienza desde la cabeza
            // Recorre la lista hasta el último nodo
            while (temp.Siguiente != null){
                temp = temp.Siguiente; // Avanza al siguiente nodo
            }
            temp.Siguiente = nuevoNodo; // Asigna el nuevo nodo al final de la lista
        }
    }
    
    // Método para obtener todos los valores de la lista como una lista de doubles
    public List<double> ObtenerValores(){
        List<double> valores = new List<double>(); // Crea una nueva lista para almacenar los valores
        Nodo temp = cabeza; // Comienza desde la cabeza
        // Recorre la lista y agrega los valores a la lista de resultados
        while (temp != null){
            valores.Add(temp.Valor); // Agrega el valor del nodo actual
            temp = temp.Siguiente; // Avanza al siguiente nodo
        }
        return valores; // Devuelve la lista de valores
    }
    
    // Método para calcular el promedio de los valores en la lista
    public double CalcularPromedio(){
        double suma = 0; // Inicializa la suma en 0
        int contador = 0; // Inicializa el contador en 0
        Nodo temp = cabeza; // Comienza desde la cabeza
        // Recorre la lista y suma los valores
        while (temp != null){
            suma += temp.Valor; // Suma el valor del nodo actual
            contador++; // Incrementa el contador
            temp = temp.Siguiente; // Avanza al siguiente nodo
        }
        // Devuelve el promedio, o 0 si no hay elementos
        return contador > 0 ? suma / contador : 0; 
    }
}

// Clase principal que contiene el método Main
class Program{
    // Método principal que se ejecuta al iniciar el programa
    static void Main(string[] args){
        Lista listaPrincipal = new Lista(); // Crea una nueva lista principal
        List<double> menoresIguales = new List<double>(); // Lista para almacenar valores menores o iguales al promedio
        List<double> mayores = new List<double>(); // Lista para almacenar valores mayores al promedio

        // Solicita al usuario la cantidad de datos a cargar
        Console.WriteLine("Ingrese la cantidad de datos a cargar:");
        int cantidad = int.Parse(Console.ReadLine()); // Lee y convierte la entrada a un entero
        // Bucle para cargar los datos en la lista
        for (int i = 0; i < cantidad; i++){
            Console.WriteLine($"Ingrese el dato {i + 1}:"); // Solicita el dato
            double dato = double.Parse(Console.ReadLine()); // Lee y convierte la entrada a double
            listaPrincipal.Agregar(dato); // Agrega el dato a la lista principal
        }
        
        // Obtiene los valores cargados y calcula el promedio
        List<double> datosCargados = listaPrincipal.ObtenerValores(); // Obtiene los valores de la lista
        double promedio = listaPrincipal.CalcularPromedio(); // Calcula el promedio de los valores
        
        // Clasifica los datos en menores o iguales y mayores al promedio
        foreach (var dato in datosCargados){
            if (dato <= promedio){ // Si el dato es menor o igual al promedio
                menoresIguales.Add(dato); // Agrega a la lista de menores o iguales
            }else{ // Si el dato es mayor al promedio
                mayores.Add(dato); // Agrega a la lista de mayores
            }
        }
        
        // Mostrar resultados
        Console.WriteLine("\n Datos cargados en la lista principal:");
        foreach (var dato in datosCargados){
            Console.WriteLine(dato); // Muestra cada dato cargado
        }
        Console.WriteLine($"\nPromedio: {promedio}"); // Muestra el promedio calculado
        Console.WriteLine("\nDatos menores o iguales al promedio:");
        foreach (var dato in menoresIguales){
            Console.WriteLine(dato); // Muestra cada dato menor o igual al promedio
        }
        Console.WriteLine("\nDatos mayores al promedio:");
        foreach (var dato in mayores){
            Console.WriteLine(dato); // Muestra cada dato mayor al promedio
        }
    }
} 
