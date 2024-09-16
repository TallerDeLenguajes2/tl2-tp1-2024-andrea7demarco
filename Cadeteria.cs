namespace EspacioPrograma
{
    public class Cadeteria
    {
        private string nombre;
        private string telefono;
        
        private int totalEnvios;
        private float totalGanado;
        private double cantPromEnvios;
        private List<Pedido> listadoPedidos;
        private List<Cadete> listadoCadetes;

        public string Nombre { get => nombre; set => nombre = value;}
        public string Telefono { get => telefono; set => telefono = value;}
        public List<Pedido> ListadoPedidos { get => listadoPedidos; set => listadoPedidos =value;}
        public List<Cadete> ListadoCadetes { get => listadoCadetes; set => listadoCadetes =value;}
        public Cadeteria(string name, string phone, List<Cadete> lista1, List<Pedido> lista2)
        {
            this.nombre = name;
            this.telefono = phone;
            this.listadoCadetes = new List<Cadete>();
            this.listadoPedidos = new List<Pedido>();
        }

        public Cadeteria()
        {
            this.nombre = "";
            this.telefono = "";
            this.listadoCadetes = new List<Cadete>();
            this.listadoPedidos = new List<Pedido>();
        }

        public void DarDeAlta(int nroPedido)
        {
            Console.WriteLine("Ingrese nombre del cliente\n");
            var nombreCliente = Console.ReadLine();
            Console.WriteLine("Direccion:\n");
            var direccion = Console.ReadLine();
            Console.WriteLine("Telefono:\n");
            var telefonoCliente = Console.ReadLine();
            Console.WriteLine("Ingrese el nombre del pedido\n");
            var DatosCliente = new Cliente(nombreCliente,telefonoCliente,direcccionCliente)
            var nombrePedido = Console.ReadLine();
            Console.WriteLine("Ingrese datos de referencia\n");
            var datosRef = Console.ReadLine();
        }
/*        public void Mostrar()
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

        public void AsignarPedido(Pedido pedido)
        {
            this.listadoPedidos.Add(pedido);
            this.CantidadEnvios += 1;
            this.CalcularGanancia();
        }
    }
    */
}