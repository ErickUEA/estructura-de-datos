using System; // Importa el espacio de nombres System, que contiene clases fundamentales
// Definición de la clase Vehiculo que representa un vehículo
public class Vehiculo{
    // Propiedades para almacenar la información del vehículo
    public string Placa { get; set; }
    public string Marca { get; set; }
    public string Modelo { get; set; }
    public int Año { get; set; }
    public decimal Precio { get; set; }
    public Vehiculo Siguiente { get; set; } // Propiedad para apuntar al siguiente vehículo en la lista   
    // Constructor que inicializa un nuevo vehículo con los datos proporcionados
    public Vehiculo(string placa, string marca, string modelo, int año, decimal precio){
        Placa = placa; // Asigna la placa
        Marca = marca; // Asigna la marca
        Modelo = modelo; // Asigna el modelo
        Año = año; // Asigna el año
        Precio = precio; // Asigna el precio
        Siguiente = null; // Inicializa el siguiente vehículo como null
    }
}
// Definición de la clase ListaVehiculos que representa una lista de vehículos
public class ListaVehiculos{
    private Vehiculo cabeza; // Propiedad privada que apunta al primer vehículo de la lista
    // Constructor que inicializa la lista como vacía
    public ListaVehiculos(){
        cabeza = null; // Inicializa la cabeza como null
    }
    // Método para agregar un nuevo vehículo a la lista
    public void AgregarVehiculo(string placa, string marca, string modelo, int año, decimal precio){
        // Crea un nuevo vehículo con los datos proporcionados
        Vehiculo nuevoVehiculo = new Vehiculo(placa, marca, modelo, año, precio);
        nuevoVehiculo.Siguiente = cabeza; // El siguiente del nuevo vehículo apunta a la cabeza actual
        cabeza = nuevoVehiculo; // La cabeza ahora es el nuevo vehículo
    }
    // Método para buscar un vehículo por su placa
    public Vehiculo BuscarVehiculo(string placa){
        Vehiculo actual = cabeza; // Comienza desde la cabeza de la lista
        while (actual != null){ // Recorre la lista
            // Compara la placa del vehículo actual con la placa buscada (ignorando mayúsculas y minúsculas)
            if (actual.Placa.Equals(placa, StringComparison.OrdinalIgnoreCase))
                return actual; // Devuelve el vehículo encontrado
            actual = actual.Siguiente; // Avanza al siguiente vehículo
        }
        return null; // Si no se encuentra, devuelve null
    }
    // Método para ver vehículos de un año específico
    public void VerVehiculosPorAño(int año){
        Vehiculo actual = cabeza; // Comienza desde la cabeza de la lista
        bool encontrado = false; // Bandera para verificar si se encontraron vehículos
        Console.WriteLine($"Vehículos del año {año}:");
        while (actual != null){ // Recorre la lista
            if (actual.Año == año){ // Si el año del vehículo coincide con el año buscado
                // Muestra la información del vehículo
                Console.WriteLine($"Placa: {actual.Placa}, Marca: {actual.Marca}, Modelo: {actual.Modelo}, Precio: {actual.Precio}");
                encontrado = true; // Marca que se encontró al menos un vehículo
            }
            actual = actual.Siguiente; // Avanza al siguiente vehículo
        }
        if (!encontrado){ // Si no se encontraron vehículos
            Console.WriteLine("No se encontraron vehículos de ese año."); // Mensaje de no encontrado
        }
    }
    // Método para ver todos los vehículos registrados
    public void VerTodosLosVehiculos(){
        Vehiculo actual = cabeza; // Comienza desde la cabeza de la lista
        if (actual == null){ // Si la lista está vacía
            Console.WriteLine("No hay vehículos registrados."); // Mensaje de lista vacía
            return; // Sale del método
        }
        Console.WriteLine("Vehículos registrados:"); // Mensaje de encabezado
        while (actual != null){ // Recorre la lista
            // Muestra la información del vehículo
            Console.WriteLine($"Placa: {actual.Placa}, Marca: {actual.Marca}, Modelo: {actual.Modelo}, Año: {actual.Año}, Precio: {actual.Precio}");
            actual = actual.Siguiente; // Avanza al siguiente vehículo
        }
    }   
    // Método para eliminar un vehículo por su placa
    public void EliminarVehiculo(string placa){
        // Si la cabeza es el vehículo a eliminar
        if (cabeza != null && cabeza.Placa.Equals(placa, StringComparison.OrdinalIgnoreCase )){
            cabeza = cabeza.Siguiente; // La cabeza ahora apunta al siguiente vehículo
            Console.WriteLine("Vehículo eliminado."); // Mensaje de confirmación
            return; // Sale del método
        }
        Vehiculo actual = cabeza; // Comienza desde la cabeza de la lista
        Vehiculo anterior = null; // Inicializa el nodo anterior como null
        while (actual != null && !actual.Placa.Equals(placa, StringComparison.OrdinalIgnoreCase)){ // Busca el vehículo a eliminar
            anterior = actual; // Actualiza el nodo anterior
            actual = actual.Siguiente; // Avanza al siguiente vehículo
        }
        if (actual != null){ // Si se encontró el vehículo
            anterior.Siguiente = actual.Siguiente; // Elimina el vehículo de la lista
            Console.WriteLine("Vehículo eliminado."); // Mensaje de confirmación
        }else{
            Console.WriteLine("Vehículo no encontrado."); // Mensaje de error si no se encuentra
        }
    }
}
// Clase principal que contiene el método Main
class Program{
    // Método principal que se ejecuta al iniciar el programa
    static void Main(string[] args){
        ListaVehiculos listaVehiculos = new ListaVehiculos(); // Crea una nueva lista de vehículos
        string opcion; // Variable para almacenar la opción del usuario
        do{
            // Muestra el menú de opciones
            Console.WriteLine("Seleccione una opción:");
            Console.WriteLine("1. Agregar vehículo");
            Console.WriteLine("2. Buscar vehículo por placa");
            Console.WriteLine("3. Ver vehículos por año");
            Console.WriteLine("4. Ver todos los vehículos registrados");
            Console.WriteLine("5. Eliminar vehículo registrado");
            Console.WriteLine("0. Salir");
            opcion = Console.ReadLine(); // Lee la opción del usuario
            switch (opcion){
                case "1":
                    AgregarVehiculo(listaVehiculos); // Llama al método para agregar un vehículo
                    break;
                case "2":
                    BuscarVehiculo(listaVehiculos); // Llama al método para buscar un vehículo
                    break;
                case "3":
                    VerVehiculosPorAño(listaVehiculos); // Llama al método para ver vehículos por año
                    break;
                case "4":
                    listaVehiculos.VerTodosLosVehiculos(); // Muestra todos los vehículos registrados
                    break;
                case "5":
                    EliminarVehiculo(listaVehiculos); // Llama al método para eliminar un vehículo
                    break;
                case "0":
                    Console.WriteLine("Saliendo..."); // Mensaje de salida
                    break;
                default:
                    Console.WriteLine("Opción no válida. Intente nuevamente."); // Mensaje de error para opción no válida
                    break;
            }
        } while (opcion != "0"); // Continúa hasta que el usuario elija salir
    }
    // Método para agregar un vehículo a la lista
    static void AgregarVehiculo(ListaVehiculos lista){
        Console.WriteLine("Ingrese la placa:"); // Solicita la placa
        string placa = Console.ReadLine(); // Lee la placa
        Console.WriteLine("Ingrese la marca:"); // Solicita la marca
        string marca = Console.ReadLine(); // Lee la marca
        Console.WriteLine("Ingrese el modelo:"); // Solicita el modelo
        string modelo = Console.ReadLine(); // Lee el modelo
        Console.WriteLine("Ingrese el año:"); // Solicita el año
        int año = int.Parse(Console.ReadLine()); // Lee y convierte el año a entero
        Console.WriteLine("Ingrese el precio:"); // Solicita el precio
        decimal precio = decimal.Parse(Console.ReadLine()); // Lee y convierte el precio a decimal
        lista.AgregarVehiculo(placa, marca, modelo, año, precio); // Agrega el vehículo a la lista
        Console.WriteLine("Vehículo agregado."); // Mensaje de confirmación
    }
    // Método para buscar un vehículo en la lista
    static void BuscarVehiculo(ListaVehiculos lista){
        Console.WriteLine("Ingrese la placa del vehículo a buscar:"); // Solicita la placa
        string placa = Console.ReadLine(); // Lee la placa
        Vehiculo vehiculo = lista.BuscarVehiculo(placa); // Busca el vehículo en la lista
        if (vehiculo != null){ // Si se encuentra el vehículo
            // Muestra la información del vehículo encontrado
            Console.WriteLine($"Vehículo encontrado: Placa: {vehiculo.Placa}, Marca: {vehiculo.Marca}, Modelo: {vehiculo.Modelo}, Año: {vehiculo.Año}, Precio: {vehiculo.Precio}");
        }else{ // Si no se encuentra el vehículo
            Console.WriteLine("Vehículo no encontrado."); // Mensaje de error
        }
    }
    // Método para ver vehículos de un año específico
    static void VerVehiculosPorAño(ListaVehiculos lista){
        Console.WriteLine("Ingrese el año de los vehículos a ver:"); // Solicita el año
        int año = int.Parse(Console.ReadLine()); // Lee y convierte el año a entero
        lista.VerVehiculosPorAño(año); // Llama al método para ver vehículos de ese año
    }   
    // Método para eliminar un vehículo de la lista
    static void EliminarVehiculo(ListaVehiculos lista){
        Console.WriteLine("Ingrese la placa del vehículo a eliminar:"); // Solicita la placa
        string placa = Console.ReadLine(); // Lee la placa
        lista.EliminarVehiculo(placa); // Elimina el vehículo de la lista
    }
}