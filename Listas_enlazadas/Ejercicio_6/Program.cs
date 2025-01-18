using System; // Importa el espacio de nombres System, que contiene clases fundamentales
// Definición de la clase Estudiante que representa a un estudiante
public class Estudiante{
    // Propiedades para almacenar la información del estudiante
    public string Cedula { get; set; }
    public string Nombre { get; set; }
    public string Apellido { get; set; }
    public string Correo { get; set; }
    public double NotaDefinitiva { get; set; }
    public Estudiante Siguiente { get; set; } // Propiedad para apuntar al siguiente estudiante en la lista
    // Constructor que inicializa un nuevo estudiante con los datos proporcionados
    public Estudiante(string cedula, string nombre, string apellido, string correo, double notaDefinitiva){
        Cedula = cedula; // Asigna la cédula
        Nombre = nombre; // Asigna el nombre
        Apellido = apellido; // Asigna el apellido
        Correo = correo; // Asigna el correo
        NotaDefinitiva = notaDefinitiva; // Asigna la nota definitiva
        Siguiente = null; // Inicializa el siguiente estudiante como null
    }
}
// Definición de la clase ListaEstudiantes que representa una lista de estudiantes
public class ListaEstudiantes{
    // Propiedades privadas que apuntan a la cabeza de las listas de aprobados y reprobados
    private Estudiante cabezaAprobados;
    private Estudiante cabezaReprobados;    
    // Constructor que inicializa las listas como vacías
    public ListaEstudiantes(){
        cabezaAprobados = null; // Inicializa la cabeza de aprobados como null
        cabezaReprobados = null; // Inicializa la cabeza de reprobados como null
    }
    // Método para agregar un nuevo estudiante a la lista
    public void AgregarEstudiante(string cedula, string nombre, string apellido, string correo, double notaDefinitiva){
        // Crea un nuevo estudiante con los datos proporcionados
        Estudiante nuevoEstudiante = new Estudiante(cedula, nombre, apellido, correo, notaDefinitiva);   
        // Si la nota es mayor o igual a 6, se agrega a la lista de aprobados
        if (notaDefinitiva >= 6){
            // Agregar al inicio de la lista de aprobados
            nuevoEstudiante.Siguiente = cabezaAprobados; // El siguiente del nuevo estudiante apunta a la cabeza actual
            cabezaAprobados = nuevoEstudiante; // La cabeza ahora es el nuevo estudiante
        }else{
            // Agregar al final de la lista de reprobados
            if (cabezaReprobados == null){ // Si la lista de reprobados está vacía
                cabezaReprobados = nuevoEstudiante; // Asigna el nuevo estudiante como cabeza
            }else{
                // Si la lista no está vacía, busca el último estudiante
                Estudiante actual = cabezaReprobados; // Comienza desde la cabeza de reprobados
                while (actual.Siguiente != null){ // Recorre hasta el último estudiante
                    actual = actual.Siguiente; // Avanza al siguiente estudiante
                }
                actual.Siguiente = nuevoEstudiante; // Asigna el nuevo estudiante al final de la lista
            }
        }
    }
    // Método para buscar un estudiante por su cédula
    public Estudiante BuscarEstudiante(string cedula){
        Estudiante actual = cabezaAprobados; // Comienza desde la cabeza de aprobados
        while (actual != null){ // Recorre la lista de aprobados
            if (actual.Cedula == cedula) // Si encuentra la cédula
                return actual; // Devuelve el estudiante encontrado
            actual = actual.Siguiente; // Avanza al siguiente estudiante
        }   
        // Si no se encuentra en aprobados, busca en reprobados
        actual = cabezaReprobados; // Comienza desde la cabeza de reprobados
        while (actual != null){ // Recorre la lista de reprobados
            if (actual.Cedula == cedula) // Si encuentra la cédula
                return actual; // Devuelve el estudiante encontrado
            actual = actual.Siguiente; // Avanza al siguiente estudiante
        }
        return null; // Si no se encuentra, devuelve null
    }
    // Método para eliminar un estudiante por su cédula
    public void EliminarEstudiante(string cedula){
        // Eliminar de la lista de aprobados
        if (cabezaAprobados != null && cabezaAprobados.Cedula == cedula){ // Si la cabeza es el estudiante a eliminar
            cabezaAprobados = cabezaAprobados.Siguiente ; // La cabeza ahora apunta al siguiente estudiante
            return; // Sale del método
        }
        Estudiante actual = cabezaAprobados; // Comienza desde la cabeza de aprobados
        Estudiante anterior = null; // Inicializa el nodo anterior como null
        while (actual != null && actual.Cedula != cedula){ // Busca el estudiante a eliminar
            anterior = actual; // Actualiza el nodo anterior
            actual = actual.Siguiente; // Avanza al siguiente estudiante
        }
        if (actual != null){ // Si se encontró el estudiante
            anterior.Siguiente = actual.Siguiente; // Elimina el estudiante de la lista
            return; // Sale del método
        }
        // Eliminar de la lista de reprobados
        if (cabezaReprobados != null && cabezaReprobados.Cedula == cedula){ // Si la cabeza es el estudiante a eliminar
            cabezaReprobados = cabezaReprobados.Siguiente; // La cabeza ahora apunta al siguiente estudiante
            return; // Sale del método
        }
        actual = cabezaReprobados; // Comienza desde la cabeza de reprobados
        anterior = null; // Reinicia el nodo anterior
        while (actual != null && actual.Cedula != cedula){ // Busca el estudiante a eliminar
            anterior = actual; // Actualiza el nodo anterior
            actual = actual.Siguiente; // Avanza al siguiente estudiante
        }
        if (actual != null){ // Si se encontró el estudiante
            anterior.Siguiente = actual.Siguiente; // Elimina el estudiante de la lista
        }
    }
    // Método para contar el total de estudiantes aprobados
    public int TotalAprobados(){
        int contador = 0; // Inicializa el contador en 0
        Estudiante actual = cabezaAprobados; // Comienza desde la cabeza de aprobados
        while (actual != null){ // Recorre la lista de aprobados
            contador++; // Incrementa el contador por cada estudiante
            actual = actual.Siguiente; // Avanza al siguiente estudiante
        }
        return contador; // Devuelve el total de estudiantes aprobados
    }
    // Método para contar el total de estudiantes reprobados
    public int TotalReprobados(){
        int contador = 0; // Inicializa el contador en 0
        Estudiante actual = cabezaReprobados; // Comienza desde la cabeza de reprobados
        while (actual != null){ // Recorre la lista de reprobados
            contador++; // Incrementa el contador por cada estudiante
            actual = actual.Siguiente; // Avanza al siguiente estudiante
        }
        return contador; // Devuelve el total de estudiantes reprobados
    }
    // Método para mostrar la información de todos los estudiantes
    public void MostrarEstudiantes(){
        Console.WriteLine("Estudiantes Aprobados:"); // Mensaje de encabezado
        Estudiante actual = cabezaAprobados; // Comienza desde la cabeza de aprobados
        while (actual != null){ // Recorre la lista de aprobados
            // Muestra la información del estudiante
            Console.WriteLine($"{actual.Cedula} - {actual.Nombre} {actual.Apellido} - {actual.Correo} - Nota: {actual.NotaDefinitiva}");
            actual = actual.Siguiente; // Avanza al siguiente estudiante
        }
        Console.WriteLine("Estudiantes Reprobados:"); // Mensaje de encabezado
        actual = cabezaReprobados; // Comienza desde la cabeza de reprobados
        while (actual != null){ // Recorre la lista de reprobados
            // Muestra la información del estudiante
            Console.WriteLine($"{actual.Cedula} - {actual.Nombre} {actual.Apellido} - {actual.Correo} - Nota: {actual.NotaDefinitiva}");
            actual = actual.Siguiente; // Avanza al siguiente estudiante
        }
    }
}
// Clase principal que contiene el método Main
class Program{
    // Método principal que se ejecuta al iniciar el programa
    static void Main(string[] args){
        ListaEstudiantes listaEstudiantes = new ListaEstudiantes(); // Crea una nueva lista de estudiantes
        string opcion; // Variable para almacenar la opción del usuario
        do{
            // Muestra el menú de opciones
            Console.WriteLine("Seleccione una opción:");
            Console.WriteLine("1. Agregar estudiante");
            Console.WriteLine("2. Buscar estudiante por cédula");
            Console.WriteLine("3. Eliminar estudiante");
            Console.WriteLine("4. Total estudiantes aprobados");
            Console.WriteLine("5. Total estudiantes reprobados");
            Console.WriteLine("6. Mostrar estudiantes");
            Console.WriteLine("0. Salir");
            opcion = Console.ReadLine(); // Lee la opción del usuario
            switch (opcion){
                case "1":
                    AgregarEstudiante(listaEstudiantes); // Llama al método para agregar un estudiante
                    break;
                case "2":
                    BuscarEstudiante(listaEstudiantes); // Llama al método para buscar un estudiante
                    break;
                case "3":
                    EliminarEstudiante(listaEstudiantes); // Llama al método para eliminar un estudiante
                    break;
                case "4":
                    Console.WriteLine($"Total estudiantes aprobados: {listaEstudiantes.TotalAprobados()}"); // Muestra el total de aprobados
                    break;
                case "5":
                    Console.WriteLine($"Total estudiantes reprobados: {listaEstudiantes.TotalReprobados()}"); // Muestra el total de reprobados
                    break;
                case "6":
                    listaEstudiantes.MostrarEstudiantes(); // Muestra la lista de estudiantes
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
    // Método para agregar un estudiante a la lista
    static void AgregarEstudiante(ListaEstudiantes lista){
        Console.WriteLine("Ingrese la cédula:"); // Solicita la cédula
        string cedula = VerificarCedula(); // Verifica la cédula
        Console.WriteLine("Ingrese el nombre:"); // Solicita el nombre
        string nombre = Console.ReadLine(); // Lee el nombre
        Console.WriteLine("Ingrese el apellido:"); // Solicita el apellido
        string apellido = Console.ReadLine(); // Lee el apellido
        Console.WriteLine("Ingrese el correo:"); // Solicita el correo
        string correo = Console.ReadLine(); // Lee el correo
        Console.WriteLine("Ingrese la nota definitiva (1-10):"); // Solicita la nota
        double notaDefinitiva = double.Parse(Console.ReadLine()); // Lee y convierte la nota a double
        lista.AgregarEstudiante(cedula, nombre, apellido, correo, notaDefinitiva); // Agrega el estudiante a la lista
    }
    // Método para verificar la validez de la cédula
    static string VerificarCedula(){
        string cedula; // Variable para almacenar la cédula
        while (true){ // Bucle infinito hasta que se ingrese una cédula válida
            cedula = Console.ReadLine(); // Lee la cédula
            if (cedula.Length != 10){ // Verifica que la cédula tenga 10 dígitos
                Console.WriteLine("La cédula debe tener 10 dígitos. Intente nuevamente."); // Mensaje de error
                continue; // Continúa el bucle
            }
            int s2 = 0, s3 = 0; // Inicializa sumas para dígitos impares y pares
            for (int i = 0; i < 10; i++){ // Recorre cada dígito de la cédula
                int digito = int.Parse(cedula[i].ToString()); // Convierte el dígito a entero
                if (i % 2 == 0){ // Si el índice es par (dígitos impares)
                    int impar = digito * 2; // Multiplica el dígito por 2
                    if (impar > 9) impar -= 9; // Si el resultado es mayor que 9, resta 9
                    s2 += impar; // Suma a la suma de dígitos impares
                }else{ // Si el índice es impar (dígitos pares)
                    s3 += digito; // Suma a la suma de dígitos pares
                }
            }
            int s1 = s2 + s3; // Suma total de las dos sumas
            int div = s1 / 10; // División entera de la suma total por 10
            int aumento = (div + 1) * 10; // Aumenta a la siguiente decena
            int comprobador = aumento - s1; // Calcula el dígito de comprobación
            int d = int.Parse(cedula[9].ToString()); // Obtiene el último dígito de la cédula
            if (comprobador == d || comprobador == 10){ // Verifica si el dígito de comprobación es correcto
                Console.WriteLine("Cédula correcta"); // Mensaje de éxito
                return cedula; // Devuelve la cédula válida
            }else{
                Console.WriteLine("Cédula incorrecta. Intente nuevamente."); // Mensaje de error si la cédula es incorrecta
            }
        }
    }
    // Método para buscar un estudiante en la lista
    static void BuscarEstudiante(ListaEstudiantes lista)
    {
        Console.WriteLine("Ingrese la cédula del estudiante a buscar:"); // Solicita la cédula
        string cedula = Console.ReadLine(); // Lee la cédula
        Estudiante estudiante = lista.BuscarEstudiante(cedula); // Busca el estudiante en la lista
        if (estudiante != null) // Si se encuentra el estudiante
        {
            // Muestra la información del estudiante encontrado
            Console.WriteLine($"Estudiante encontrado: {estudiante.Cedula} - {estudiante.Nombre} {estudiante.Apellido} - {estudiante.Correo} - Nota: {estudiante.NotaDefinitiva}");
        }
        else // Si no se encuentra el estudiante
        {
            Console.WriteLine("Estudiante no encontrado."); // Mensaje de error
        }
    }
    // Método para eliminar un estudiante de la lista
    static void EliminarEstudiante(ListaEstudiantes lista){
        Console.WriteLine("Ingrese la cédula del estudiante a eliminar:"); // Solicita la cédula
        string cedula = Console.ReadLine(); // Lee la cédula
        lista.EliminarEstudiante(cedula); // Elimina el estudiante de la lista
        Console.WriteLine("Estudiante eliminado (si existía)."); // Mensaje de confirmación
    }
}