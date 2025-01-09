// Definición de la clase Producto
public class Producto
{
    // Propiedades de la clase Producto
    public int id { get; set; } // ID del producto
    public string nombre { get; set; } // Nombre del producto
    public int cantidad { get; set; } // Cantidad disponible del producto
    public decimal precio_compra { get; set; } // Precio de compra del producto
    public float precio_mayorista { get; set; } // Precio mayorista del producto
    public float precio_publico { get; set; } // Precio público del producto

    // Constructor de la clase Producto
    public Producto(int Id, string Nombre, int Cantidad, decimal Precio_compra, float Precio_mayorista, float Precio_publico)
    {
        // Inicialización de las propiedades con los parámetros del constructor
        id = Id;
        nombre = Nombre;
        cantidad = Cantidad;
        precio_compra = Precio_compra;
        precio_mayorista = Precio_mayorista;
        precio_publico = Precio_publico;
    }
}

// Definición de la clase Program que contiene el método Main
class Program
{
    // Método principal que se ejecuta al iniciar el programa
    static void Main()
    {
        // Definición de una constante que representa el número máximo de productos
        const int productos_maximos = 200;
        // Creación de un arreglo bidimensional para almacenar los productos
        object[,] productos = new object[productos_maximos, 6];
        // Contador para llevar el registro de cuántos productos se han agregado
        int contador = 0;

        // Bucle infinito para mostrar el menú y permitir la interacción del usuario
        while (true)
        {
            // Mostrar el menú de opciones
            Console.WriteLine("Menu de acceso\n1. Agregar producto\n2. Ver lista de productos\n3. Salir");
            // Leer la opción elegida por el usuario
            int opcion = int.Parse(Console.ReadLine());

            // Opción para agregar un producto
            if (opcion == 1)
            {
                // Verificar si se ha alcanzado el límite de productos
                if (contador >= productos_maximos)
                {
                    Console.WriteLine("La base de productos se ha llenado");
                    continue; // Volver al inicio del bucle
                }

                // Solicitar los datos del nuevo producto
                Console.WriteLine("Ingrese los datos del producto");
                Console.Write("ID: ");
                int id = int.Parse(Console.ReadLine()); // Leer el ID del producto
                bool id_existe = false; // Variable para verificar si el ID ya existe

                // Comprobar si el ID ya existe en la lista de productos
                for (int i = 0; i < contador; i++)
                {
                    if ((int)productos[i, 0] == id) // Comparar el ID ingresado con los existentes
                    {
                        id_existe = true; // Marcar que el ID ya existe
                        break; // Salir del bucle
                    }
                    continue; // Continuar con la siguiente iteración (no necesario aquí)
                }

                // Si el ID ya existe, solicitar otro ID
                if (id_existe)
                {
                    Console.WriteLine("El ID ya existe, ingrese otro");
                    continue; // Volver al inicio del bucle
                }

                // Leer los demás datos del producto
                Console.Write("Nombre: ");
                string nombre = Console.ReadLine(); // Leer el nombre del producto
                Console.Write("Cantidad: ");
                int cantidad = int.Parse(Console.ReadLine()); // Leer la cantidad del producto
                Console.Write("Precio Compra: ");
                decimal precio_compra = decimal.Parse(Console.ReadLine()); // Leer el precio de compra
                Console.Write("Precio Mayorista: ");
                float precio_mayorista = float.Parse(Console.ReadLine()); // Leer el precio mayorista
                Console.Write("Precio Publico: ");
                float precio_publico = float.Parse(Console.ReadLine()); // Leer el precio público

                // Almacenar los datos del producto en el arreglo
                productos[contador, 0] = id;
                productos[contador, 1] = nombre;
                productos[contador, 2] = cantidad;
                productos[contador, 3] = precio_compra;
                productos[contador, 4] = precio_mayorista;
                productos[contador, 5] = precio_publico;

                // Incrementar el contador de productos
                contador++;
                Console.WriteLine("Se ha agregado el producto"); // Mensaje de confirmación
            }
            else // Opción para ver la lista de productos
            {
                if (opcion == 2)
                {
                    Console .WriteLine("Lista de productos"); // Mensaje para indicar que se mostrará la lista de productos
                    // Bucle para mostrar cada producto en la lista
                    for (int i = 0; i < contador; i++)
                    {
                        // Mostrar los detalles de cada producto
                        Console.WriteLine($"ID: {productos[i, 0]}\nNombre: {productos[i, 1]}\nCantidad: {productos[i, 2]}\nPrecio Compra: {productos[i, 3]}\nPrecio Mayorista: {productos[i, 4]}\nPrecio Público: {productos[i, 5]}\n");
                    }
                }
                else if (opcion == 3) // Opción para salir del programa
                {
                    Console.WriteLine("Saliendo del programa"); // Mensaje de despedida
                    break; // Salir del bucle y terminar el programa
                }
                else // Opción no válida
                {
                    Console.WriteLine("opcion incorrecta. Regresando al menu"); // Mensaje de error
                }
            }
        }
    }
}