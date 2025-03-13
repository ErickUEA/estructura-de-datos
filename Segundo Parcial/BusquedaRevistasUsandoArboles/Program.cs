using System;
class Nodo{
    public string Titulo;
    public Nodo Izquierda;
    public Nodo Derecha;

    public Nodo(string titulo){
        Titulo = titulo;
        Izquierda = null;
        Derecha = null;
    }
}
class ArbolBinario{
    private Nodo raiz;
    public ArbolBinario(){
        raiz = null;
    }
    public void Insertar(string titulo){
        raiz = InsertarRecursivo(raiz, titulo);
    }
    private Nodo InsertarRecursivo(Nodo nodo, string titulo){
        if (nodo == null){
            return new Nodo(titulo);
        }
        if (string.Compare(titulo, nodo.Titulo) < 0){
            nodo.Izquierda = InsertarRecursivo(nodo.Izquierda, titulo);
        }else if (string.Compare(titulo, nodo.Titulo) > 0){
            nodo.Derecha = InsertarRecursivo(nodo.Derecha, titulo);
        }
        return nodo;
    }
    public bool Buscar(string titulo){
        return BuscarIterativo(raiz, titulo);
    }
    private bool BuscarIterativo(Nodo nodo, string titulo){
        while (nodo != null){
            int comparacion = string.Compare(titulo, nodo.Titulo);
            if (comparacion == 0){
                return true;
            }else if (comparacion < 0){
                nodo = nodo.Izquierda;
            }else{
                nodo = nodo.Derecha;
            }
        }
        return false; // No encontrado
    }
}
class Program{
    static void Main(string[] args){
        ArbolBinario catalogo = new ArbolBinario();
        string[] titulos = new string[10];
        Console.WriteLine("Ingresar 10 títulos de revistas: ");
        for (int i = 0; i < 10; i++)
        {
            Console.Write($"Título {i + 1}: ");
            titulos[i] = Console.ReadLine();
            catalogo.Insertar(titulos[i]);
        }
        while (true){
            Console.WriteLine("\nMenú:");
            Console.WriteLine("1. Buscar un título");
            Console.WriteLine("2. Salir");
            Console.Write("Seleccione una opción: ");
            string opcion = Console.ReadLine();
            if (opcion == "1"){
                Console.Write("Ingrese el título a buscar: ");
                string tituloABuscar = Console.ReadLine();
                bool encontrado = catalogo.Buscar(tituloABuscar);
                if (encontrado){
                    Console.WriteLine("Título encontrado.");
                }else{
                    Console.WriteLine("Título no encontrado.");
                }
            }else if (opcion == "2"){
                break;
            }else{
                Console.WriteLine("Opción no válida. Intente de nuevo.");
            }
        }
    }
}