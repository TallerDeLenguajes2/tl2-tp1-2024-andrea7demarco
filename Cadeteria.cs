namespace EspacioPrograma
{


    public class Cadeteria
    {
        private string nombre;
        private string telefono;
        private List<Cadete> listadoCadetes;
        private int totalEnvios;
        private float totalGanado;
        private double cantPromEnvios;

        public string Nombre { get => nombre; set => nombre = value; }
        public string Telefono { get => telefono; set => telefono = value; }
        public int TotalEnvios { get => totalEnvios; set => totalEnvios = value; }
        public float TotalGanado { get => totalGanado; set => totalGanado = value; }
        public double CantPromEnvios { get => cantPromEnvios; set => cantPromEnvios = value; }

        public Cadeteria(string name, string phone, List<Cadete> lista)
        {
            this.nombre = name;
            this.telefono = phone;
            this.listadoCadetes = new List<Cadete>();
            this.listadoCadetes.AddRange(lista);
        }
        public void Mostrar()
        {
            int contador = 1;
            Console.WriteLine($"Nombre: {this.nombre}");
            Console.WriteLine($"Telefono: {this.telefono}");
            foreach (var item in listadoCadetes)
            {
                Console.WriteLine($"||||||||||CLIENTE {contador}|||||||||||||||");
                item.Mostrar();
                contador += 1;
            }
        }

        public void CalcularTotal()
        {
            if (listadoCadetes != null && listadoCadetes.Any())
            {
                this.TotalEnvios = listadoCadetes.Sum(l => l.CantidadEnvios);
                this.TotalGanado = listadoCadetes.Sum(l => l.CantidadGanado);
                this.CantPromEnvios = (double)listadoCadetes.Average(l => l.CantidadEnvios);
            }
            else
            {
                Console.WriteLine("La lista esta vacia");
            }

        }

        public void MostrarInforme()
        {
            this.CalcularTotal();
            Console.WriteLine("/////////MOSTRAR INFORME///////////");
            Console.WriteLine("             Datos Cadetes       ");
            foreach (var item in this.listadoCadetes)
            {
                Console.WriteLine($"{item.Nombre}: {item.CantidadEnvios}   {item.CantidadGanado}");
            }
            Console.WriteLine("=================DATOS CADETERIA===============");
            Console.WriteLine($"TOTAL GANADO: {this.TotalGanado}");
            Console.WriteLine($"TOTAL ENVIOS: {this.TotalEnvios}");
            Console.WriteLine($"PROMEDIO DE ENVIOS: {this.CantPromEnvios}");
        }
    }
}