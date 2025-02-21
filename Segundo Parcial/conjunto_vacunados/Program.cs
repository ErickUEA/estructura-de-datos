using System; 
using System.Collections.Generic; // Importa el espacio de nombres que contiene interfaces y clases que definen colecciones genéricas.
using System.Linq; // Importa el espacio de nombres que proporciona clases y métodos para consultas sobre colecciones.

class Ciudadano{
    public string Nombre { get; set; } // Propiedad pública para almacenar el nombre del ciudadano.
    public bool VacunadoConPfizer { get; set; } // Propiedad pública que indica si el ciudadano está vacunado con Pfizer.
    public bool VacunadoConAstrazeneca { get; set; } // Propiedad pública que indica si el ciudadano está vacunado con AstraZeneca.

    // Constructor de la clase Ciudadano que inicializa el nombre y establece las propiedades de vacunación en falso.
    public Ciudadano(string nombre){
        Nombre = nombre; // Asigna el nombre proporcionado al ciudadano.
        VacunadoConPfizer = false; // Inicializa la propiedad de vacunación con Pfizer en falso.
        VacunadoConAstrazeneca = false; // Inicializa la propiedad de vacunación con AstraZeneca en falso.
    }
}

class Program{
    static void Main(string[] args){
        // Crear un conjunto ficticio de 500 ciudadanos
        HashSet<Ciudadano> ciudadanos = new HashSet<Ciudadano>(); // Inicializa un conjunto para almacenar ciudadanos.
        for (int i = 1; i <= 500; i++){ // Bucle que itera desde 1 hasta 500.
            ciudadanos.Add(new Ciudadano($"Ciudadano {i}")); // Agrega un nuevo ciudadano al conjunto con un nombre único.
        }
        HashSet<Ciudadano> vacunadosPfizer = new HashSet<Ciudadano>(); // Inicializa un conjunto para ciudadanos vacunados con Pfizer.
        Random random = new Random(); // Crea una instancia de la clase Random para generar números aleatorios.
        while (vacunadosPfizer.Count < 75){
            int index = random.Next(1, 501); // Genera un número aleatorio entre 1 y 500.
            var ciudadano = ciudadanos.First(c => c.Nombre == $"Ciudadano {index}"); // Busca el ciudadano correspondiente al número aleatorio.
            if (!vacunadosPfizer.Contains(ciudadano)){ // Si el ciudadano no está ya en el conjunto de vacunados con Pfizer.
                ciudadano.VacunadoConPfizer = true; // Marca al ciudadano como vacunado con Pfizer.
                vacunadosPfizer.Add(ciudadano); // Agrega el ciudadano al conjunto de vacunados con Pfizer.
            }
        }
        HashSet<Ciudadano> vacunadosAstrazeneca = new HashSet<Ciudadano>(); // Inicializa un conjunto para ciudadanos vacunados con AstraZeneca.
        while (vacunadosAstrazeneca.Count < 75){
            int index = random.Next(1, 501); // Genera un número aleatorio entre 1 y 500.
            var ciudadano = ciudadanos.First(c => c.Nombre == $"Ciudadano {index}"); // Busca el ciudadano correspondiente al número aleatorio.
            // Si el ciudadano no está en el conjunto de vacunados con AstraZeneca y tampoco en el de vacunados con Pfizer.
            if (!vacunadosAstrazeneca.Contains(ciudadano) && !vacunadosPfizer.Contains(ciudadano)){
                ciudadano.VacunadoConAstrazeneca = true; // Marca al ciudadano como vacunado con AstraZeneca.
                vacunadosAstrazeneca.Add(ciudadano); // Agrega el ciudadano al conjunto de vacunados con AstraZeneca.
            }
        }

        // Listado de ciudadanos que no se han vacunado
        var noVacunados = ciudadanos.Where(c => !c.VacunadoConPfizer && !c.VacunadoConAstrazeneca).ToList(); // Filtra los ciudadanos no vacunados.
        Console.WriteLine("Ciudadanos no vacunados: \n" + string.Join(", ", noVacunados.Select(c => c.Nombre))); // Imprime los nombres de los ciudadanos no vacunados.
        // Listado de ciudadanos que solamente han recibido la vacuna de Pfizer
        var soloPfizer = ciudadanos.Where(c => c.VacunadoConPfizer && !c.VacunadoConAstrazeneca).ToList(); // Filtra los ciudadanos vacunados solo con Pfizer.
        Console.WriteLine("\nCiudadanos vacunados solamente con Pfizer: \n " + string.Join(", ", soloPfizer.Select(c => c.Nombre))); // Imprime los nombres de los ciudadanos vacunados solo con Pfizer.
        // Listado de ciudadanos que solamente han recibido la vacuna de AstraZeneca
        var soloAstrazeneca = ciudadanos.Where(c => c.VacunadoConAstrazeneca && !c.VacunadoConPfizer).ToList(); // Filtra los ciudadanos vacunados solo con AstraZeneca.
        Console.WriteLine("\nCiudadanos vacunados solamente con AstraZeneca: \n" + string.Join(", ", soloAstrazeneca.Select(c => c.Nombre))); // Imprime los nombres de los ciudadanos vacunados solo con AstraZeneca.
        // Listado de ciudadanos que han recibido ambas vacunas
        var vacunadosAmbas = ciudadanos.Where(c => c.VacunadoConPfizer && c.VacunadoConAstrazeneca).ToList(); // Filtra los ciudadanos que han recibido ambas vacunas.
        if (vacunadosAmbas.Count == 0){ // Si no hay ciudadanos vacunados con ambas vacunas.
            Console.WriteLine("No hay ciudadanos con 2 vacunas"); // Imprime un mensaje indicando que no hay ciudadanos con ambas vacunas.
        }else{
            Console.WriteLine(string.Join(", ", vacunadosAmbas.Select(c => c.Nombre))); // Imprime los nombres de los ciudadanos vacunados con ambas vacunas.
        }
    }
}