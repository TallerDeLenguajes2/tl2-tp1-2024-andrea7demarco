using System;
using System.IO;
using System.Collections;
namespace EspacioPrograma
{
    public class Pedido
    {
        public enum EstadoPedido
        {
            aceptado,
            pendiente,
            rechazado

        }
        private int nro;
        private string nombre;
        private Cliente nombreCliente; //composicion
        private EstadoPedido estado;

        public int Nro { get => nro; set => nro = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public Cliente NombreCliente { get => nombreCliente; set => nombreCliente = value; }
        public EstadoPedido Estado { get => estado; set => estado = value; }

        public Pedido(int nro, string nombre, Cliente cliente)
        {
            this.nro = nro;
            this.nombre = nombre;
            this.nombreCliente = new Cliente();
            this.estado = EstadoPedido.pendiente;

        }

        public Pedido()
        {
            this.nro = 0;
            this.nombre = "";
            this.nombreCliente = new Cliente();
            this.estado = EstadoPedido.pendiente;
        }

        public void Mostrar()
        {
            Console.WriteLine($"nro : {this.nro}");
            Console.WriteLine($"Nombre:{this.nombre}");
            Console.WriteLine("----Datos del cliente----\n");
            this.NombreCliente.Mostrar();
            Console.WriteLine($"Estado: {this.estado}");
        }

        public void AceptarPedido()
        {
            this.estado = EstadoPedido.aceptado;
        }

        public void RechazarPedido()
        {
            this.estado = EstadoPedido.rechazado;
        }
    }
}