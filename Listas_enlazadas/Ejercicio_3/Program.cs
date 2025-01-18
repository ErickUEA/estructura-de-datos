using System; // Importa el espacio de nombres System, que contiene clases fundamentales
// Definición de la clase Nodo que representa un nodo en la lista enlazada
public class Nodo{
    // Propiedad para almacenar el valor del nodo
    public int Valor { get; set; }
    // Propiedad para apuntar al siguiente nodo en la lista
    public Nodo Siguiente { get; set; }   
    // Constructor que inicializa el nodo con un valor y establece el siguiente nodo como null
    public Nodo(int valor){
        Valor = valor; // Asigna el valor al nodo
        Siguiente = null; // Inicializa el siguiente nodo como null
    }
}
// Definición de la clase Lista que representa una lista enlazada
public class Lista{
    // Propiedad privada que apunta al primer nodo de la lista
    private Nodo cabeza;
    // Constructor que inicializa la lista como vacía
    public Lista(){
        cabeza = null; // Inicializa la cabeza como null
    }
    // Método para agregar un nuevo valor a la lista
    public void Agregar(int valor){
        // Crea un nuevo nodo con el valor proporcionado
        Nodo nuevoNodo = new Nodo(valor);   
        // Si la lista está vacía, el nuevo nodo se convierte en la cabeza
        if (cabeza == null){
            cabeza = nuevoNodo; // Asigna el nuevo nodo a la cabeza
        }else{
            // Si la lista no está vacía, se busca el último nodo
            Nodo actual = cabeza; // Comienza desde la cabeza
            while (actual.Siguiente != null){ // Recorre hasta el último nodo
                actual = actual.Siguiente; // Avanza al siguiente nodo
            }
            // Asigna el nuevo nodo al final de la lista
            actual.Siguiente = nuevoNodo; // Establece el siguiente del último nodo como el nuevo nodo
        }
    }
    // Método para buscar un valor en la lista
    public void Buscar(int valor){
        int contador = 0; // Inicializa un contador para contar las ocurrencias del valor
        Nodo actual = cabeza; // Comienza desde la cabeza
        // Recorre la lista hasta que no haya más nodos
        while (actual != null){
            // Si el valor del nodo actual coincide con el valor buscado, incrementa el contador
            if (actual.Valor == valor){
                contador++;
            }
            actual = actual.Siguiente; // Avanza al siguiente nodo
        }       
        // Muestra el resultado de la búsqueda
        if (contador > 0){
            // Si se encontró el valor, muestra cuántas veces se encontró
            Console.WriteLine($"El valor {valor} se encontró {contador} veces en la lista.");
        }else{
            // Si no se encontró el valor, muestra un mensaje indicando que no fue encontrado
            Console.WriteLine($"El valor {valor} no fue encontrado en la lista.");
        }
    }
}
// Clase principal que contiene el método Main
class Program{
    // Método principal que se ejecuta al iniciar el programa
    static void Main(string[] args){
        // Crea una nueva lista
        Lista lista = new Lista();
        // Solicita al usuario que ingrese la cantidad de elementos que desea agregar a la lista
        Console.WriteLine("Ingrese la cantidad de elementos que desea agregar a la lista:");
        int cantidad = int.Parse(Console.ReadLine()); // Lee y convierte la entrada a un entero
        // Bucle para agregar la cantidad de elementos especificada por el usuario
        for (int i = 0; i < cantidad; i++){
            // Solicita al usuario que ingrese el valor para cada elemento
            Console.WriteLine($"Ingrese el valor para el elemento {i + 1}:");
            int valor = int.Parse(Console.ReadLine()); // Lee y convierte la entrada a un entero
            lista.Agregar(valor); // Agrega el valor a la lista
        }
        // Solicita al usuario que ingrese el valor que desea buscar en la lista
        Console.WriteLine("Ingrese el valor que desea buscar en la lista:");
        int valorABuscar = int.Parse(Console.ReadLine()); // Lee y convierte la entrada a un entero
        lista.Buscar(valorABuscar); // Llama al método Buscar para buscar el valor en la lista
    }
}