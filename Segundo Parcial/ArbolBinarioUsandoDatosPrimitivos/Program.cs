using System;

class Nodo
{
    public int Clave;
    public string Valor;
    public Nodo Izquierdo;
    public Nodo Derecho;

    public Nodo(int clave, string valor)
    {
        Clave = clave;
        Valor = valor;
        Izquierdo = null;
        Derecho = null;
    }
}

class ArbolBinario
{
    private Nodo raiz;

    public void Insertar(int clave, string valor)
    {
        raiz = InsertarRecursivo(raiz, clave, valor);
    }

    private Nodo InsertarRecursivo(Nodo nodo, int clave, string valor)
    {
        if (nodo == null)
        {
            return new Nodo(clave, valor);
        }

        if (clave < nodo.Clave)
        {
            nodo.Izquierdo = InsertarRecursivo(nodo.Izquierdo, clave, valor);
        }
        else if (clave > nodo.Clave)
        {
            nodo.Derecho = InsertarRecursivo(nodo.Derecho, clave, valor);
        }

        return nodo;
    }

    public void Eliminar(int clave)
    {
        if (Buscar(raiz, clave) == null)
        {
            Console.WriteLine($"El nodo con clave {clave} no existe.");
            return;
        }
        raiz = EliminarRecursivo(raiz, clave);
    }

    private Nodo EliminarRecursivo(Nodo nodo, int clave)
    {
        if (nodo == null) return nodo;

        if (clave < nodo.Clave)
        {
            nodo.Izquierdo = EliminarRecursivo(nodo.Izquierdo, clave);
        }
        else if (clave > nodo.Clave)
        {
            nodo.Derecho = EliminarRecursivo(nodo.Derecho, clave);
        }
        else
        {
            // Nodo encontrado
            if (nodo.Izquierdo == null) return nodo.Derecho;
            else if (nodo.Derecho == null) return nodo.Izquierdo;

            // Nodo con dos hijos: obtener el sucesor inorden (mínimo en el subárbol derecho)
            nodo.Clave = Minimo(nodo.Derecho).Clave;
            nodo.Valor = Minimo(nodo.Derecho).Valor;
            nodo.Derecho = EliminarRecursivo(nodo.Derecho, nodo.Clave);
        }

        return nodo;
    }

    private Nodo Minimo(Nodo nodo)
    {
        while (nodo.Izquierdo != null)
        {
            nodo = nodo.Izquierdo;
        }
        return nodo;
    }

    public void Mostrar()
    {
        if (raiz == null)
        {
            Console.WriteLine("No existen datos en el árbol.");
        }
        else
        {
            MostrarRecursivo(raiz);
        }
    }

    private void MostrarRecursivo(Nodo nodo)
    {
        if (nodo != null)
        {
            MostrarRecursivo(nodo.Izquierdo);
            Console.WriteLine($"Clave: {nodo.Clave}, Valor: {nodo.Valor}");
            MostrarRecursivo(nodo.Derecho);
        }
    }

    private Nodo Buscar(Nodo nodo, int clave)
    {
        if (nodo == null || nodo.Clave == clave)
        {
            return nodo;
        }

        if (clave < nodo.Clave)
        {
            return Buscar(nodo.Izquierdo, clave);
        }
        else
        {
            return Buscar(nodo.Derecho, clave);
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        ArbolBinario arbol = new ArbolBinario();
        int opcion;

        do
        {
            Console.WriteLine("Menú:");
            Console.WriteLine("1. Insertar nodo");
            Console.WriteLine("2. Eliminar nodo");
            Console.WriteLine("3. Mostrar árbol");
            Console.WriteLine("4. Salir");
            Console.Write("Seleccione una opción: ");
            opcion = int.Parse(Console.ReadLine());

            switch (opcion)
            {
                case 1:
                    Console.Write("Ingrese la clave (entero): ");
                    int clave = int.Parse(Console.ReadLine());
                    Console.Write("Ingrese el valor (cadena): ");
                    string valor = Console.ReadLine();
                    arbol.Insertar(clave, valor);
                    break;

                case 2:
                    Console.Write("Ingrese la clave del nodo a eliminar (entero): ");
                    int claveEliminar = int.Parse(Console.ReadLine());
                    arbol.Eliminar(claveEliminar);
                    break;

                case 3:
                    Console.WriteLine("Contenido del árbol:");
                    arbol.Mostrar();
                    break;

                case 4:
                    Console.WriteLine("Saliendo...");
                    break;

                default:
                    Console.WriteLine("Opción no válida. Intente de nuevo.");
                    break;
            }

            Console.WriteLine();
        } while (opcion != 4);
    }
}