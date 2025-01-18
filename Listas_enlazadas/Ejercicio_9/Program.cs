using System; // Importa el espacio de nombres System, que contiene clases fundamentales

// Definición de la clase Nodo que representa un nodo en la lista enlazada
class Nodo{
    public int Valor; // Propiedad para almacenar el valor del nodo
    public Nodo Siguiente; // Propiedad para apuntar al siguiente nodo en la lista
    
    // Constructor que inicializa el nodo con un valor
    public Nodo(int valor){
        Valor = valor; // Asigna el valor al nodo
        Siguiente = null; // Inicializa el siguiente nodo como null
    }
}

// Definición de la clase Lista que representa una lista enlazada de nodos
class Lista{
    private Nodo cabeza; // Propiedad privada que apunta al primer nodo de la lista
    
    // Método para agregar un nuevo valor a la lista
    public void Agregar(int valor){
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
    
    // Método para contar el número de nodos en la lista
    public int Contar(){
        int contador = 0; // Inicializa el contador en 0
        Nodo temp = cabeza; // Comienza desde la cabeza
        // Recorre la lista y cuenta los nodos
        while (temp != null){
            contador++; // Incrementa el contador por cada nodo
            temp = temp.Siguiente; // Avanza al siguiente nodo
        }
        return contador; // Devuelve el total de nodos contados
    }   
    // Método para comparar esta lista con otra lista
    public bool Comparar(Lista otraLista){
        Nodo temp1 = cabeza; // Comienza desde la cabeza de la lista actual
        Nodo temp2 = otraLista.cabeza; // Comienza desde la cabeza de la otra lista
        // Recorre ambas listas simultáneamente
        while (temp1 != null && temp2 != null){
            if (temp1.Valor != temp2.Valor) // Si los valores son diferentes
            {
                return false; // No son iguales en contenido
            }
            temp1 = temp1.Siguiente; // Avanza al siguiente nodo en la lista actual
            temp2 = temp2.Siguiente; // Avanza al siguiente nodo en la otra lista
        }
        // Ambas listas deben terminar al mismo tiempo para ser iguales
        return temp1 == null && temp2 == null; // Devuelve true si ambas listas son nulas
    }
}
// Clase principal que contiene el método Main
class Program
{
    // Método principal que se ejecuta al iniciar el programa
    static void Main(string[] args){
        Lista lista1 = new Lista(); // Crea una nueva lista para la primera entrada
        Lista lista2 = new Lista(); // Crea una nueva lista para la segunda entrada
        
        // Solicita al usuario la cantidad de datos para la primera lista
        Console.WriteLine("Ingrese la cantidad de datos para la primera lista:");
        int cantidad1 = int.Parse(Console.ReadLine()); // Lee y convierte la entrada a un entero
        // Bucle para cargar los datos en la primera lista
        for (int i = 0; i < cantidad1; i++){
            Console.WriteLine($"Ingrese el dato {i + 1} para la primera lista:"); // Solicita el dato
            int dato = int.Parse(Console.ReadLine()); // Lee y convierte la entrada a un entero
            lista1.Agregar(dato); // Agrega el dato a la primera lista
        }
        // Solicita al usuario la cantidad de datos para la segunda lista
        Console.WriteLine("Ingrese la cantidad de datos para la segunda lista:");
        int cantidad2 = int.Parse(Console.ReadLine()); // Lee y convierte la entrada a un entero
        // Bucle para cargar los datos en la segunda lista
        for (int i = 0; i < cantidad2; i++){
            Console.WriteLine($"Ingrese el dato {i + 1} para la segunda lista:"); // Solicita el dato
            int dato = int.Parse(Console.ReadLine()); // Lee y convierte la entrada a un entero
            lista2.Agregar(dato); // Agrega el dato a la segunda lista
        }
        
        // Cuenta el número de elementos en ambas listas
        int tamaño 1 = lista1.Contar(); // Cuenta los nodos en la primera lista
        int tamaño2 = lista2.Contar(); // Cuenta los nodos en la segunda lista
        
        // Comparar listas
        if (tamaño1 == tamaño2){ // Si ambas listas tienen el mismo tamaño
            if (lista1.Comparar(lista2)){ // Compara el contenido de ambas listas
                Console.WriteLine("Las listas son iguales en tamaño y en contenido."); // Mensaje de igualdad
            }else{
                Console.WriteLine("Las listas son iguales en tamaño pero no en contenido."); // Mensaje de tamaño igual pero contenido diferente
            }
        }else{
            Console.WriteLine("Las listas no tienen el mismo tamaño ni contenido."); // Mensaje de desigualdad
        }
    }
}