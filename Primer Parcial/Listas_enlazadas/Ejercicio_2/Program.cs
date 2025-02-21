// Definición de la clase Nodo genérica que puede contener cualquier tipo de dato T
public class Nodo<T>{
    // Propiedad para almacenar el dato del nodo
    public T Data { get; set; }
    // Propiedad para apuntar al siguiente nodo en la lista
    public Nodo<T> proximo { get; set; }   
    // Constructor que inicializa el nodo con un dato y establece el siguiente nodo como null
    public Nodo(T data){
        Data = data; // Asigna el dato al nodo
        proximo = null; // Inicializa el siguiente nodo como null
    }
}
// Definición de la clase ListaEnlazada genérica
public class ListaEnlazada<T>{
    // Propiedad privada que apunta al primer nodo de la lista
    private Nodo<T> cabeza;
    // Constructor que inicializa la lista como vacía
    public ListaEnlazada(){
        cabeza = null; // Inicializa la cabeza como null
    }
    // Método para agregar un nuevo dato a la lista
    public void Agregar(T data){
        // Crea un nuevo nodo con el dato proporcionado
        Nodo<T> nuevoNodo = new Nodo<T>(data);        
        // Si la lista está vacía, el nuevo nodo se convierte en la cabeza
        if (cabeza == null){
            cabeza = nuevoNodo; // Asigna el nuevo nodo a la cabeza
        }else{
            // Si la lista no está vacía, se busca el último nodo
            Nodo<T> temp = cabeza; // Comienza desde la cabeza
            while (temp.proximo != null){ // Recorre hasta el último nodo
                temp = temp.proximo; // Avanza al siguiente nodo
            }
            // Asigna el nuevo nodo al final de la lista
            temp.proximo = nuevoNodo; // Establece el siguiente del último nodo como el nuevo nodo
        }
    }
    // Método para invertir la lista enlazada
    public void lista_invertida(){
        Nodo<T> previo = null; // Nodo previo inicializado como null
        Nodo<T> actual = cabeza; // Nodo actual comienza en la cabeza
        Nodo<T> proximo = null; // Nodo siguiente inicializado como null   
        // Recorre la lista hasta que no haya más nodos
        while (actual != null){
            proximo = actual.proximo; // Guarda el siguiente nodo
            actual.proximo = previo;   // Invertir el enlace del nodo actual
            previo = actual;           // Mueve el nodo previo un paso adelante
            actual = proximo;          // Mueve el nodo actual un paso adelante
        }
        cabeza = previo; // Actualiza la cabeza de la lista al último nodo procesado
    }   
    // Método para imprimir los elementos de la lista
    public void Imprimir(){
        Nodo<T> temp = cabeza; // Comienza desde la cabeza
        // Recorre la lista hasta que no haya más nodos
        while (temp != null){
            Console.Write(temp.Data + " "); // Imprime el dato del nodo actual
            temp = temp.proximo; // Avanza al siguiente nodo
        }
        Console.WriteLine(); // Imprime una nueva línea al final
    }
}
// Clase principal que contiene el método Main
class Program{
    // Método principal que se ejecuta al iniciar el programa
    static void Main(string[] args){
        // Crea una nueva lista enlazada de enteros
        ListaEnlazada<int> lista = new ListaEnlazada<int>();
        
        // Solicita al usuario que ingrese números para agregar a la lista
        Console.WriteLine("Ingrese los números para agregar a la lista (escriba 'fin' para terminar):");
        
        // Bucle infinito para recibir entradas del usuario
        while (true){
            string entrada = Console.ReadLine(); // Lee la entrada del usuario
            // Si el usuario escribe 'fin', se sale del bucle
            if (entrada.ToLower() == "fin"){
                break;
            }
            // Intenta convertir la entrada a un número entero
            if (int.TryParse(entrada, out int numero))
            {
                lista.Agregar(numero); // Agrega el número a la lista
            }else{
                // Si la entrada no es un número válido, se muestra un mensaje de error
                Console.WriteLine("Por favor, ingrese un número válido o 'fin' para terminar.");
            }
        }
        // Imprime la lista original
        Console.WriteLine("Lista original:");
        lista.Imprimir();
        // Invierte la lista
        lista.lista_invertida();       
        // Imprime la lista invertida
        Console.WriteLine("Lista invertida:");
        lista.Imprimir();
    }
}