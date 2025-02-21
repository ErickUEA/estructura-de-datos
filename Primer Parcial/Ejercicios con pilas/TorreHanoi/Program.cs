using System;
using System.Collections.Generic; // Importa el espacio de nombres que contiene clases para colecciones genéricas, como Stack.

class TorreDeHanoiConPilas{
    static void Main(string[] args){
        Console.WriteLine("Ingrese el número de discos:"); // Solicita al usuario que ingrese el número de discos.
        int numDiscos; // Declara una variable para almacenar el número de discos.
        // Bucle que se ejecuta hasta que el usuario ingresa un número válido mayor a 0.
        while (!int.TryParse(Console.ReadLine(), out numDiscos) || numDiscos <= 0){
            Console.WriteLine("Por favor, ingrese un número válido mayor a 0:"); // Mensaje de error si la entrada no es válida.
        }
        // Crear las pilas para representar los postes de la Torre de Hanoi.
        Stack<int> origen = new Stack<int>(); // Pila que representa el poste de origen.
        Stack<int> auxiliar = new Stack<int>(); // Pila que representa el poste auxiliar.
        Stack<int> destino = new Stack<int>(); // Pila que representa el poste de destino.
        // Inicializar la pila de origen con los discos, apilando de mayor a menor.
        for (int i = numDiscos; i >= 1; i--){
            origen.Push(i); // Agrega discos a la pila de origen.
        }
        Console.WriteLine("\nEstado inicial:"); // Muestra el estado inicial de las pilas.
        MostrarEstado(origen, auxiliar, destino); // Llama a la función para mostrar el estado de las pilas.
        // Resolver la Torre de Hanoi usando pilas.
        ResolverTorreDeHanoi(numDiscos, origen, destino, auxiliar); // Llama a la función que resuelve el problema.
        Console.WriteLine("\nEstado final:"); // Muestra el estado final de las pilas.
        MostrarEstado(origen, auxiliar, destino); // Llama a la función para mostrar el estado final de las pilas.
    }
    static void ResolverTorreDeHanoi(int n, Stack<int> origen, Stack<int> destino, Stack<int> auxiliar){
        if (n == 1){ // Caso base: si hay un solo disco.
            // Mover un único disco directamente del origen al destino.
            destino.Push(origen.Pop()); // Saca el disco de la pila de origen y lo agrega a la pila de destino.
            Console.WriteLine("\nMovimiento realizado:"); // Indica que se ha realizado un movimiento.
            MostrarEstado(origen, auxiliar, destino); // Muestra el estado actual de las pilas.
            return; // Sale de la función.
        }
        // Mover n-1 discos del origen al auxiliar usando el destino como soporte.
        ResolverTorreDeHanoi(n - 1, origen, auxiliar, destino); // Llama recursivamente para mover n-1 discos.
        // Mover el disco más grande del origen al destino.
        destino.Push(origen.Pop()); // Saca el disco más grande de la pila de origen y lo agrega a la pila de destino.
        Console.WriteLine("\nMovimiento realizado:"); // Indica que se ha realizado un movimiento.
        MostrarEstado(origen, auxiliar, destino); // Muestra el estado actual de las pilas.
        // Mover los n-1 discos del auxiliar al destino usando el origen como soporte.
        ResolverTorreDeHanoi(n - 1, auxiliar, destino, origen); // Llama recursivamente para mover n-1 discos.
    }
    static void MostrarEstado(Stack<int> origen, Stack<int> auxiliar, Stack<int> destino){
        // Muestra el contenido de cada pila en la consola.
        Console.WriteLine("Pilar 1: -" + string.Join("-", origen) + "-|"); // Muestra el contenido de la pila de origen.
        Console.WriteLine("Pilar 2: -" + string.Join("-", auxiliar) + "-|"); // Muestra el contenido de la pila auxiliar.
        Console.WriteLine("Pilar 3: -" + string.Join("-", destino) + "-|"); // Muestra el contenido de la pila de destino.
    }
}