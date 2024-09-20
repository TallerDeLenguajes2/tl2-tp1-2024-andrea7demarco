using System.Runtime.CompilerServices;

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

        public string Nombre { get => nombre; set => nombre = value; }
        public string Telefono { get => telefono; set => telefono = value; }
        public List<Pedido> ListadoPedidos { get => listadoPedidos; set => listadoPedidos = value; }
        public List<Cadete> ListadoCadetes { get => listadoCadetes; set => listadoCadetes = value; }
        public Cadeteria(string name, string phone)
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
            var direccionCliente = Console.ReadLine();
            Console.WriteLine("Telefono:\n");
            var telefonoCliente = Console.ReadLine();
            Console.WriteLine("Ingrese datos de referencia\n");
            var datosRef = Console.ReadLine();
            var datosCliente = new Cliente(nombreCliente, telefonoCliente, direccionCliente, datosRef);
            Console.WriteLine("Ingrese el nombre del pedido");
            var nombrePedido = Console.ReadLine();
            var PedidoTomado = new Pedido(nroPedido, nombrePedido, datosCliente);


        }

        public void TomarPedido(int id)
        {
            var pedido = new Pedido();
            foreach (var item in this.listadoPedidos)
            {
                if (item.Nro == id)
                {
                    this.listadoPedidos.Add(pedido);
                }
            }
        }

        public double JornalACobrar(int idCadete)
        {
            var cad = this.listadoCadetes.FirstOrDefault(l => l.Id == idCadete);

            if (cad == null)
            {
                Console.WriteLine("No se encuentra dicho cadete");
                return 0;
            }

            int totalPedidos = this.ListadoPedidos
                                .Count(p => p.CadeteAsignado == cad && p.Estado == Pedido.EstadoPedido.aceptado);

            return totalPedidos * 500;
        }

        public void AsignarCadeteAPedidoPorID(int idCadete, int idPedido)
        {
            var CadeteAAsignar = this.listadoCadetes.FirstOrDefault(l => l.Id == idCadete);
            var pedido = this.listadoPedidos.FirstOrDefault(l => l.Nro == idPedido);
            if (pedido != null && CadeteAAsignar != null)
            {
                pedido.AsignarCadeteAPedido(CadeteAAsignar);
            }
            else
            {
                Console.WriteLine("No se encuentra el pedido/cadete");
            }
        }

        public void AceptarPedido(int idPedido)
        {
            var ValidacionPed = this.listadoPedidos.FirstOrDefault(l => l.Nro == idPedido);
            if (ValidacionPed != null)
            {
                ValidacionPed.AceptarPedido();
            }
        }
        public void Mostrar()
        {
            int contador = 0;
            Console.WriteLine($"Nombre: {this.nombre}");
            Console.WriteLine($"Telefono: {this.telefono}");
            foreach (var item in listadoCadetes)
            {
                Console.WriteLine($"||||||||||CLIENTE {contador}|||||||||||||||");
                item.Mostrar();
                contador += 1;
            }
        }

        public void MostrarPedidosPendientes()
        {
            Console.WriteLine("==PEDIDOS PENDIENTES===\n");
            foreach (var item in this.listadoPedidos)
            {
                if (item.Estado == Pedido.EstadoPedido.pendiente)
                {
                    item.Mostrar();
                }
            }
        }
    }

  }
