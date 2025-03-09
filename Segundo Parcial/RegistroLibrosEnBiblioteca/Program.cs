using System;
using System.Collections.Generic;

class Biblioteca{
    private Dictionary<string, Dictionary<string, string>> libros = new Dictionary<string, Dictionary<string, string>>();
    private Dictionary<string, Dictionary<string, object>> usuarios = new Dictionary<string, Dictionary<string, object>>();
    public void AñadirLibro(string titulo, string autor, string categoria, string isbn){
        if (!libros.ContainsKey(isbn)){
            libros[isbn] = new Dictionary<string, string>{
                { "titulo", titulo },
                { "autor", autor },
                { "categoria", categoria }
            };
            Console.WriteLine($"Se ha añadido el libro {titulo}");
        }else{
            Console.WriteLine("El libro ya existe");
        }
    }
    public void QuitarLibro(string isbn){
        if (libros.ContainsKey(isbn)){
            libros.Remove(isbn);
            Console.WriteLine($"Libro con ISBN -{isbn}- eliminado");
        }else{
            Console.WriteLine("El libro no existe");
        }
    }
    public void RegistraUsuario(string nombre, string idUsuario){
        if (!usuarios.ContainsKey(idUsuario)){
            usuarios[idUsuario] = new Dictionary<string, object>{
                { "nombre", nombre },
                { "libros_prestados", new List<Dictionary<string, string>>() }
            };
            Console.WriteLine("Usuario añadido");
        }else{
            Console.WriteLine("Ya existe el usuario");
        }
    }
    public void DarDeBajaUsuario(string idUsuario){
        if (usuarios.ContainsKey(idUsuario)){
            usuarios.Remove(idUsuario);
            Console.WriteLine($"Usuario con id -{idUsuario}- eliminado");
        }else{
            Console.WriteLine("El usuario no se ha encontrado");
        }
    }
    public void PrestaLibro(string idUsuario, string isbn){
    if (usuarios.ContainsKey(idUsuario) && libros.ContainsKey(isbn)){
        var libro = new Dictionary<string, string>(libros[isbn]);
        libro["isbn"] = isbn;
        ((List<Dictionary<string, string>>)usuarios[idUsuario]["libros_prestados"]).Add(libro);
        libros.Remove(isbn);
        Console.WriteLine($"Libro {libro["titulo"]} prestado a {usuarios[idUsuario]["nombre"]}");
    }else{
        Console.WriteLine("Libro o usuario no existen");
        }
    }
    public void DevolverLibro(string idUsuario, string isbn){
    if (usuarios.ContainsKey(idUsuario)){
        var librosPrestados = (List<Dictionary<string, string>>)usuarios[idUsuario]["libros_prestados"];
        Dictionary<string, string> libroARemover = null;
        foreach (var libro in librosPrestados){
            if (libro["isbn"] == isbn){
                libroARemover = libro;
                break;
            }
        }
        if (libroARemover != null){
            librosPrestados.Remove(libroARemover);
            libros[isbn] = libroARemover;
            Console.WriteLine($"Libro {libroARemover["titulo"]} devuelto por el usuario {usuarios[idUsuario]["nombre"]}");
        }else{
            Console.WriteLine("El libro no estaba prestado a este usuario.");
        }
    }else{
        Console.WriteLine("El usuario no existe.");
        }
    }
    public List<Dictionary<string, string>> BuscarLibro(string titulo = null, string autor = null, string categoria = null){
        var resultados = new List<Dictionary<string, string>>();
        foreach (var libro in libros.Values){
            if ((titulo != null && libro["titulo"].Contains(titulo)) ||
                (autor != null && libro["autor"].Contains(autor)) ||
                (categoria != null && libro["categoria"] == categoria)){
                resultados.Add(libro);
            }
        }
        return resultados;
    }
    public List<Dictionary<string, string>> ListarLibrosPrestados(string idUsuario){
        if (usuarios.ContainsKey(idUsuario)){
            return (List<Dictionary<string, string>>)usuarios[idUsuario]["libros_prestados"];
        }
        return new List<Dictionary<string, string>>();
    }
}

class Program{
    static void Main(){
        Biblioteca biblioteca = new Biblioteca();
        while (true){
            Console.WriteLine("\nBienvenido al menu");
            Console.WriteLine("1. Añadir un libro\t\t2. Eliminar un libro\n3. Registrar a un usuario\t4. Dar de baja a un usuario\n5. Prestar un libro\t\t6. Regresar un libro\n7. Buscar libros\t\t8. Mostrar libros prestados\n9. Salir");
            int opciones = int.Parse(Console.ReadLine());
            switch (opciones){
                case 1:
                    Console.Write("Ingrese el titulo del libro: ");
                    string titulo = Console.ReadLine();
                    Console.Write("Ingrese el autor del libro: ");
                    string autor = Console.ReadLine();
                    Console.Write("Ingrese la categoria del libro: ");
                    string categoria = Console.ReadLine();
                    Console.Write("Ingrese el ISBN del libro: ");
                    string isbn = Console.ReadLine();
                    biblioteca.AñadirLibro(titulo, autor, categoria, isbn);
                    break;
                case 2:
                    Console.Write("Ingrese el ISBN para eliminar el libro: ");
                    isbn = Console.ReadLine();
                    biblioteca.QuitarLibro(isbn);
                    break;
                case 3:
                    Console.Write("Ingrese el nombre del usuario: ");
                    string nombre = Console.ReadLine();
                    Console.Write("Ingrese la ID del usuario: ");
                    string idUsuario = Console.ReadLine();
                    biblioteca.RegistraUsuario(nombre, idUsuario);
                    break;
                case 4:
                    Console.Write("Ingrese la ID del usuario para eliminarlo: ");
                    idUsuario = Console.ReadLine();
                    biblioteca.DarDeBajaUsuario(idUsuario);
                    break;
                case 5:
                    Console.Write("Ingrese la ID del usuario: ");
                    idUsuario = Console.ReadLine();
                    Console.Write("Ingrese el ISBN del libro a prestar: ");
                    isbn = Console.ReadLine();
                    biblioteca.PrestaLibro(idUsuario, isbn);
                    break;
                case 6:
                    Console.Write("Ingrese el ISBN del libro a devolver: ");
                    isbn = Console.ReadLine();
                    Console.Write("Ingrese la ID del usuario que devuelve el libro: ");
                    idUsuario = Console.ReadLine();
                    biblioteca.DevolverLibro(idUsuario, isbn);
                    break;
                case 7:
                    Console.Write("Ingrese el título del libro a buscar: ");
                    titulo = Console.ReadLine();
                    var resultados = biblioteca.BuscarLibro(titulo);
                    if (resultados.Count > 0){
                        foreach (var libro in resultados){
                            Console.WriteLine($"Título: {libro["titulo"]}, Autor: {libro["autor"]}, Categoría: {libro["categoria"]}");
                        }
                    }else{
                        Console.WriteLine("No se encontraron libros.");
                    }
                    break;
                case 8:
                    Console.Write("Ingrese la ID del usuario para ver los libros prestados: ");
                    idUsuario = Console.ReadLine();
                    var librosPrestados = biblioteca.ListarLibrosPrestados(idUsuario);
                    if (librosPrestados.Count > 0){
                        foreach (var libro in librosPrestados){
                            Console.WriteLine($"Título: {libro["titulo"]}");
                        }
                    }else{
                        Console.WriteLine("No hay libros prestados.");
                    }
                    break;
                case 9:
                    Console.Write("Saliendo adios");
                    return;
                    break;
            }
        }
    }
}