using System; // Importa el espacio de nombres System, que contiene clases fundamentales y tipos de datos.
public class Nodo{
    public int Valor; // Valor del nodo, que almacenará un número entero.
    public Nodo continuo; // Referencia al siguiente nodo en la lista enlazada.

    public Nodo(int valor){ // Constructor de la clase Nodo que recibe un valor entero.
        Valor = valor; // Asigna el valor recibido al campo Valor del nodo.
        continuo = null; // Inicializa la referencia al siguiente nodo como null (no apunta a ningún nodo).
    }
}
public class ListaEnlazada{
    private Nodo cabeza; // Referencia al primer nodo de la lista enlazada.
    public ListaEnlazada(){ // Constructor de la clase ListaEnlazada.
        cabeza = null; // Inicializa la cabeza de la lista como null (la lista está vacía).
    }
    // Método para agregar un nuevo nodo al final de la lista.
    public void Agregar(int valor){
        Nodo nuevoNodo = new Nodo(valor); // Crea un nuevo nodo con el valor proporcionado.
        if (cabeza == null){ // Verifica si la lista está vacía.
            cabeza = nuevoNodo; // Si está vacía, el nuevo nodo se convierte en la cabeza de la lista.
        }else{
            Nodo actual = cabeza; // Inicializa un nodo actual que comienza en la cabeza.
            while (actual.continuo != null){ // Recorre la lista hasta llegar al último nodo.
                actual = actual.continuo; // Avanza al siguiente nodo.
            }
            actual.continuo = nuevoNodo; // Asigna el nuevo nodo al final de la lista.
        }
    }
    // Método para contar el número de elementos en la lista.
    public int ContarElementos(){
        int contador = 0; // Inicializa un contador en 0.
        Nodo actual = cabeza; // Comienza desde la cabeza de la lista.
        while (actual != null){ // Mientras haya nodos en la lista.
            contador++; // Incrementa el contador por cada nodo encontrado.
            actual = actual.continuo; // Avanza al siguiente nodo.
        }
        return contador; // Devuelve el total de elementos contados.
    }
}
class Program{
    static void Main(string[] args){ // Método principal que se ejecuta al iniciar el programa.
        ListaEnlazada lista = new ListaEnlazada(); // Crea una nueva instancia de ListaEnlazada.
        for (int i = 0; i < 50; i++){
            int numeroAleatorio = random.Next(1, 1000); // Genera un número entre 1 y 999
            lista.Agregar(numeroAleatorio);
        }
        // Contamos los elementos
        int totalElementos = lista.ContarElementos(); // Llama al método para contar los elementos en la lista.
        Console.WriteLine("Número de elementos en la lista: " + totalElementos); // Muestra el total de elementos en la lista.
    }
}