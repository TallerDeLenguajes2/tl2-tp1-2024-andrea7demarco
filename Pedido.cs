using System;
using System.IO;
using System.Collections;
using System.Linq;

namespace EspacioPrograma 
{
    public enum EstadoPedido{
        aceptado,
        pendiente,
        rechazado
    }
    public class Pedido
    {
        private int nro;
        private string nombre;
        private Cliente nombreCliente;
        private EstadoPedido estado;
        private Cadete cadeteAsignado;

        public int Nro { get => nro; set => nro = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public Cliente NombreCliente { get => nombreCliente; set => nombreCliente = value; }
        public EstadoPedido Estado { get => estado; set => estado = value; }
        public Cadete CadeteAsignado { get => cadeteAsignado; set => cadeteAsignado = value; }

        public Pedido(int nro, string nombre, Cliente cliente)
        {
            this.nro=nro;
            this.nombre=nombre;
            this.nombreCliente=cliente;
            this.estado=EstadoPedido.pendiente;
            this.CadeteAsignado=null;
        }

        public Pedido()
        {
            this.nro=0;
            this.nombre="";
            this.nombreCliente=new Cliente();
            this.estado=EstadoPedido.pendiente;
            this.cadeteAsignado=null;
        }

public string Mostrar()
{
    var cadena = @$"Nro: {this.nro}
    Nombre: {this.nombre}
    ---------------Datos del cliente----------------";

    if (this.nombreCliente != null) // Verifica que nombreCliente no sea null
    {
        cadena += @$"
        Dirección: {this.nombreCliente.Direccion}
        Teléfono: {this.nombreCliente.Telefono}";
    }
    else
    {
        cadena += "\nCliente no asignado.";
    }

    cadena += $@"
    Estado: {this.estado}
    DATOS CADETE";

    if (this.cadeteAsignado != null) // Verifica que cadeteAsignado no sea null
    {
        cadena += this.cadeteAsignado.Mostrar();
    }
    else
    {
        cadena += "\nCadete no asignado.";
    }

    return cadena;
}


        public void AsignarCadeteAPedido(Cadete cadete)
        {
            this.CadeteAsignado=cadete;
        }

        public void AceptarPedido()
        {
            if(this.estado==EstadoPedido.pendiente)
            {
                this.estado=EstadoPedido.aceptado;
            }
            
        }

        public void RechazarPedido()
        {
            if(this.estado==EstadoPedido.pendiente)
            {
                this.estado=EstadoPedido.rechazado;
                this.cadeteAsignado=null;
            }
    
        }
    }
}