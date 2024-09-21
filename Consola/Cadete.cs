namespace EspacioPrograma
{
    public class Cadete
    {
        private int id;
        private string nombre;
        private string direccion;
        private string telefono;
        // private List<Pedido> listadoPedidos;

        public string Telefono { get => telefono; set => telefono = value; }
        public string Direccion { get => direccion; set => direccion = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public int Id { get => id; set => id = value; }
        public Cadete(int id, string nombre, string telefono, string direccion)
        {
            this.id = id;
            this.nombre = nombre;
            this.direccion = direccion;
            this.telefono = telefono;
            // this.listadoPedidos = new List<Pedido>();

        }

        public Cadete()
        {
            this.id = 0;
            this.nombre = "";
            this.direccion = "";
            this.telefono = "";
            //    this.listadoPedidos = new List<Pedido>();
        }

        public string Mostrar()
        {
            var cadena = (@$"id: {this.Id}
            nombre: {this.nombre}
            Direccion: {this.direccion}");
            return (cadena);
        }

    }
}