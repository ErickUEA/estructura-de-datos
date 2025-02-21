using System;
using System.Collections.Generic;
using System.Linq;

class Ciudadano
{
    public string Nombre { get; set; }
    public bool VacunadoConPfizer { get; set; }
    public bool VacunadoConAstrazeneca { get; set; }

    public Ciudadano(string nombre)
    {
        Nombre = nombre;
        VacunadoConPfizer = false;
        VacunadoConAstrazeneca = false;
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Crear un conjunto ficticio de 500 ciudadanos
        HashSet<Ciudadano> ciudadanos = new HashSet<Ciudadano>();
        for (int i = 1; i <= 500; i++)
        {
            ciudadanos.Add(new Ciudadano($"Ciudadano {i}"));
        }

        // Crear un conjunto de 75 ciudadanos vacunados con Pfizer
        HashSet<Ciudadano> vacunadosPfizer = new HashSet<Ciudadano>();
        Random random = new Random();
        while (vacunadosPfizer.Count < 75)
        {
            int index = random.Next(1, 501);
            var ciudadano = ciudadanos.First(c => c.Nombre == $"Ciudadano {index}");
            if (!vacunadosPfizer.Contains(ciudadano))
            {
                ciudadano.VacunadoConPfizer = true;
                vacunadosPfizer.Add(ciudadano);
            }
        }

        // Crear un conjunto de 75 ciudadanos vacunados con AstraZeneca
        HashSet<Ciudadano> vacunadosAstrazeneca = new HashSet<Ciudadano>();
        while (vacunadosAstrazeneca.Count < 75)
        {
            int index = random.Next(1, 501);
            var ciudadano = ciudadanos.First(c => c.Nombre == $"Ciudadano {index}");
            if (!vacunadosAstrazeneca.Contains(ciudadano) && !vacunadosPfizer.Contains(ciudadano))
            {
                ciudadano.VacunadoConAstrazeneca = true;
                vacunadosAstrazeneca.Add(ciudadano);
            }
        }

        // Listado de ciudadanos que no se han vacunado
        var noVacunados = ciudadanos.Where(c => !c.VacunadoConPfizer && !c.VacunadoConAstrazeneca).ToList();
        Console.WriteLine("Ciudadanos no vacunados: \n" + string.Join(", ", noVacunados.Select(c => c.Nombre)));
        // Listado de ciudadanos que solamente han recibido la vacuna de Pfizer
        var soloPfizer = ciudadanos.Where(c => c.VacunadoConPfizer && !c.VacunadoConAstrazeneca).ToList();
        Console.WriteLine("\nCiudadanos vacunados solamente con Pfizer: \n" + string.Join(", ", soloPfizer.Select(c => c.Nombre)));
        // Listado de ciudadanos que solamente han recibido la vacuna de AstraZeneca
        var soloAstrazeneca = ciudadanos.Where(c => c.VacunadoConAstrazeneca && !c.VacunadoConPfizer).ToList();
        Console.WriteLine("\nCiudadanos vacunados solamente con AstraZeneca: \n" + string.Join(", ", soloAstrazeneca.Select(c => c.Nombre)));
        var vacunadosAmbas = ciudadanos.Where(c => c.VacunadoConPfizer && c.VacunadoConAstrazeneca).ToList();
        if (vacunadosAmbas.Count == 0)
        {
            Console.WriteLine("No hay ciudadanos con 2 vacunas");
        }
        else
        {
            Console.WriteLine(string.Join(", ", vacunadosAmbas.Select(c => c.Nombre)));
        }
    }
}
