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

        private Cadete cadeteAsignado;

        public int Nro { get => nro; set => nro = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public Cliente NombreCliente { get => nombreCliente; set => nombreCliente = value; }
        public EstadoPedido Estado { get => estado; set => estado = value; }
        public Cadete CadeteAsignado {get => cadeteAsignado; set => cadeteAsignado = value;}
        public Pedido(int nro, string nombre, Cliente cliente)
        {
            this.nro = nro;
            this.nombre = nombre;
            this.nombreCliente = new Cliente();
            this.estado = EstadoPedido.pendiente;
            this.CadeteAsignado = null;

        }

        public Pedido()
        {
            this.nro = 0;
            this.nombre = "";
            this.nombreCliente = new Cliente();
            this.estado = EstadoPedido.pendiente;
            this.cadeteAsignado = null;
        }

        public void Mostrar()
        {
            Console.WriteLine($"nro : {this.nro}");
            Console.WriteLine($"Nombre:{this.nombre}");
            Console.WriteLine("----Datos del cliente----\n");
            this.NombreCliente.Mostrar();
            Console.WriteLine($"Estado: {this.estado}");
            Console.WriteLine($"Cadete Asignado: {this.cadeteAsignado}");

        }
        
        public void AsignarCadeteAPedido(Cadete cadete)
        {
            this.CadeteAsignado = cadete;
        }

        public void AceptarPedido()
        {
            if(this.estado == EstadoPedido.pendiente)
            {
                this.estado = EstadoPedido.aceptado;
            }
        }

        public void RechazarPedido()
        {
            if(this.estado == EstadoPedido.pendiente)
            {
                this.estado = EstadoPedido.rechazado;
                this.cadeteAsignado = null;
            }
        }
    }
}