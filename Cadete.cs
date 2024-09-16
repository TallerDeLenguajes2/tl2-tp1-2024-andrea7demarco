namespace EspacioPrograma
{
    public class Cadete
    {
        private int id;
        private string nombre;
        private string direccion;
        private string telefono;
       // private List<Pedido> listadoPedidos;
        public int CantidadEnvios;
        public float CantidadGanado;


        public string Telefono { get => telefono; set => telefono = value; }
        public string Direccion { get => direccion; set => direccion = value; }
        public string Nombre { get => nombre; set => nombre = value; }

        public Cadete(int id, string nombre, string telefono, string direccion)
        {
            this.id = id;
            this.nombre = nombre;
            this.direccion = direccion;
            this.telefono = telefono;
           // this.listadoPedidos = new List<Pedido>();
            this.CantidadEnvios = 0;
            this.CantidadGanado = 0;
        }

        public Cadete()
        {
            this.id = 0;
            this.nombre = "";
            this.direccion = "";
            this.telefono = "";
        //    this.listadoPedidos = new List<Pedido>();
            this.CantidadEnvios = 0;
            this.CantidadGanado = 0;

        }

/*        public void TomarPedido(Pedido pedido)
        {
            this.listadoPedidos.Add(pedido);
        }
*/
      public void Mostrar()
        {
            int contador = 0;
            Console.WriteLine($"ID : {this.id}");
            Console.WriteLine($"Nombre: {this.nombre}");
            Console.WriteLine($"Direccion: {this.direccion}");
            Console.WriteLine($"Telefono: {this.telefono}");
            Console.WriteLine("----Listado de pedidos----\n");
        /*    foreach (var item in this.listadoPedidos)
            {
                Console.WriteLine($"////pedido nro {contador}////");
                item.Mostrar();
                contador += 1;
            }
    */
        }
     

/*       public void AsignarPedido(Pedido pedido)
        {
            this.listadoPedidos.Add(pedido);
            this.CantidadEnvios += 1;
            this.CalcularGanancia();
        }

       public void RechazarPedido(Pedido pedido)
        {
            if (this.listadoPedidos.Contains(pedido))
            {
                this.listadoPedidos.Remove(pedido);
                this.CantidadEnvios -= 1;
                this.CalcularGanancia();
            }
        }
*/
        private void CalcularGanancia()
        {
            this.CantidadGanado = this.CantidadEnvios * 500;
        }
    }
}