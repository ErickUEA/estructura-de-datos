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
    // Método para agregar un nuevo valor al final de la lista
    public void AgregarAlFinal(int valor){
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
    // Método para agregar un nuevo valor al inicio de la lista
    public void AgregarAlInicio(int valor){
        // Crea un nuevo nodo con el valor proporcionado
        Nodo nuevoNodo = new Nodo(valor);
        nuevoNodo.Siguiente = cabeza; // El siguiente del nuevo nodo apunta a la cabeza actual
        cabeza = nuevoNodo; // La cabeza ahora es el nuevo nodo
    }
    // Método para contar el número de elementos en la lista
    public int ContarElementos(){
        int contador = 0; // Inicializa un contador en 0
        Nodo actual = cabeza; // Comienza desde la cabeza   
        // Recorre la lista hasta que no haya más nodos
        while (actual != null){
            contador++; // Incrementa el contador por cada nodo
            actual = actual.Siguiente; // Avanza al siguiente nodo
        }
        return contador; // Devuelve el total de elementos contados
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
        // Crea dos listas: una para números primos y otra para números Armstrong
        Lista listaPrimos = new Lista();
        Lista listaArmstrong = new Lista();       
        // Solicita al usuario la cantidad de números a agregar
        Console.WriteLine("Ingrese la cantidad de números a agregar: ");
        int cantidad = int.Parse(Console.ReadLine()); // Lee y convierte la entrada a un entero
        // Bucle para agregar la cantidad de elementos especificada por el usuario
        for (int i = 0; i < cantidad; i++){
            Console.WriteLine($"Ingrese el número {i+1}:"); // Solicita el número al usuario
            int numero = int.Parse(Console.ReadLine()); // Lee y convierte la entrada a un entero
            // Verifica si el número es primo y lo agrega a la lista de primos
            if (EsPrimo(numero)){
                listaPrimos.AgregarAlFinal(numero); // Agrega el número primo al final de la lista
            }
            // Verifica si el número es Armstrong y lo agrega a la lista de Armstrong
            if (EsArmstrong(numero)){
                listaArmstrong.AgregarAlInicio(numero); // Agrega el número Armstrong al inicio de la lista
            }
        }
 // Contar elementos en cada lista
        int cantidadPrimos = listaPrimos.ContarElementos(); // Cuenta los números primos
        int cantidadArmstrong = listaArmstrong.ContarElementos(); // Cuenta los números Armstrong
        // Mostrar resultados
        Console.WriteLine($"Cantidad de números primos: {cantidadPrimos}"); // Muestra la cantidad de primos
        Console.WriteLine($"Cantidad de números Armstrong: {cantidadArmstrong}"); // Muestra la cantidad de Armstrong
        // Compara las cantidades y muestra cuál lista tiene más elementos
        if (cantidadPrimos > cantidadArmstrong){
            Console.WriteLine("La lista de números primos contiene más elementos."); // Mensaje si primos son más
        }else if (cantidadArmstrong > cantidadPrimos){
            Console.WriteLine("La lista de números Armstrong contiene más elementos."); // Mensaje si Armstrong son más
        }else{
            Console.WriteLine("Ambas listas contienen la misma cantidad de elementos."); // Mensaje si son iguales
        }
        // Muestra los números primos
        Console.WriteLine("Números primos:");
        listaPrimos.MostrarLista(); // Muestra la lista de números primos
        // Muestra los números Armstrong
        Console.WriteLine("Números Armstrong:");
        listaArmstrong.MostrarLista(); // Muestra la lista de números Armstrong
    }
    // Método para verificar si un número es primo
    static bool EsPrimo(int numero){
        if (numero <= 1) return false; // Los números menores o iguales a 1 no son primos
        for (int i = 2; i <= Math.Sqrt(numero); i++){ // Verifica divisibilidad hasta la raíz cuadrada del número
            if (numero % i == 0) return false; // Si es divisible, no es primo
        }
        return true; // Si no es divisible por ningún número, es primo
    }
    // Método para verificar si un número es Armstrong
    static bool EsArmstrong(int numero){
        int suma = 0; // Inicializa la suma en 0
        int temp = numero; // Almacena el número original
        int digitos = temp.ToString().Length; // Cuenta la cantidad de dígitos   
        // Calcula la suma de los dígitos elevados a la potencia de la cantidad de dígitos
        while (temp > 0){
            int digito = temp % 10; // Obtiene el último dígito
            suma += (int)Math.Pow(digito, digitos); // Suma el dígito elevado a la potencia
            temp /= 10; // Elimina el último dígito
        }
        return suma == numero; // Devuelve verdadero si la suma es igual al número original
    }
}