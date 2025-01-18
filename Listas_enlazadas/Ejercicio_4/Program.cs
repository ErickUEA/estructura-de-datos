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
    // Método para eliminar nodos cuyo valor está fuera de un rango especificado
    public void EliminarFueraDeRango(int min, int max){
        Nodo actual = cabeza; // Comienza desde la cabeza
        Nodo anterior = null; // Inicializa el nodo anterior como null   
        // Recorre la lista hasta que no haya más nodos
        while (actual != null){
            // Verifica si el valor del nodo actual está fuera del rango
            if (actual.Valor < min || actual.Valor > max){
                // Si estamos en el primer nodo
                if (anterior == null){ 
                    cabeza = actual.Siguiente; // Mueve la cabeza al siguiente nodo
                }else{
                    anterior.Siguiente = actual.Siguiente; // Elimina el nodo actual
                }
            }else{
                anterior = actual; // Solo avanzamos si no eliminamos el nodo
            }
            actual = actual.Siguiente; // Avanza al siguiente nodo
        }
    }   
    // Método para mostrar los valores de la lista
    public void MostrarLista(){
        Nodo actual = cabeza; // Comienza desde la cabeza
        // Recorre la lista hasta que no haya más nodos
        while (actual != null){
            Console.Write(actual.Valor + " "); // Imprime el valor del nodo actual
            actual = actual.Siguiente; // Avanza al siguiente nodo
        }
        Console.WriteLine(); // Imprime una nueva línea al final
    }
}
// Clase principal que contiene el método Main
class Program{
    // Método principal que se ejecuta al iniciar el programa
    static void Main(string[] args){
        Random random = new Random(); // Crea una instancia de la clase Random para generar números aleatorios
        Lista lista = new Lista(); // Crea una nueva lista
        // Generar 50 números aleatorios entre 1 y 999
        for (int i = 0; i < 50; i++){
            int numeroAleatorio = random.Next(1, 1000); // Genera un número entre 1 y 999
            lista.Agregar(numeroAleatorio); // Agrega el número aleatorio a la lista
        }
        // Muestra la lista original
        Console.WriteLine("Lista original:");
        lista.MostrarLista();
        // Leer el rango de valores desde el teclado
        Console.WriteLine("Ingrese el valor mínimo del rango:");
        int min = int.Parse(Console.ReadLine()); // Lee y convierte la entrada a un entero
        Console.WriteLine("Ingrese el valor máximo del rango:");
        int max = int.Parse(Console.ReadLine()); // Lee y convierte la entrada a un entero
        // Eliminar nodos fuera del rango especificado
        lista.EliminarFueraDeRango(min, max);
        // Muestra la lista después de eliminar nodos fuera del rango
        Console.WriteLine("Lista después de eliminar nodos fuera del rango:");
        lista.MostrarLista(); // Muestra la lista actualizada después de la eliminación
    }
}