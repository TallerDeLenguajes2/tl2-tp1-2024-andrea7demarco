using System;
using System.Collections.Generic;
using System.IO;
using EspacioPrograma;
using System.Linq;


class Program
{
    static void Main(string[] args)
    {
        var listaCadeterias = new List<Cadeteria>();
        var listaCadetes = new List<Cadete>();
        listaCadetes = CargarCadetes("Nombres.csv");
        listaCadeterias = CargarCadeterias("Cadeterias.csv", listaCadetes);

        Console.WriteLine("Ingrese el nombre de la cadeteria con la que desea trabajar");
        var nombreCadeteria = Console.ReadLine();
        Cadeteria cadeteriaSeleccionada = listaCadeterias.FirstOrDefault(l => l.Nombre == nombreCadeteria);

        if (cadeteriaSeleccionada != null)
        {
            var ingresar = "a";
            var nroDePedido = 0;
            Pedido pedidotomado = null;  // Inicializado en null
            var cadeteAsignado = new Cadete();
            cadeteriaSeleccionada.Mostrar();

            while (ingresar != "e")
            {
                Console.WriteLine("Seleccione una opcion:");
                Console.WriteLine("a) Dar de alta el pedido");
                Console.WriteLine("b) Asignarlo a un cadete");
                Console.WriteLine("c) Cambiarlo de estado");
                Console.WriteLine("d) Reasignar el pedido a otro cadete");
                Console.WriteLine("e) Salir");
                ingresar = Console.ReadLine();

                switch (ingresar)
                {
                    case "a":
                        pedidotomado = DarDeAlta(nroDePedido);
                        nroDePedido += 1;
                        pedidotomado.Mostrar();
                        break;

                    case "b":
                        if (pedidotomado != null)
                        {
                            cadeteAsignado = AsignarCadete(listaCadetes, pedidotomado);
                        }
                        break;

                    case "c":
                        if (pedidotomado != null)
                        {
                            CambiarDeEstado(pedidotomado, cadeteAsignado);
                        }
                        break;

                    case "d":
                        if (pedidotomado != null)
                        {
                            cadeteAsignado.RechazarPedido(pedidotomado);
                            cadeteAsignado = AsignarCadete(listaCadetes, pedidotomado);
                        }
                        break;
                }
            }

            cadeteriaSeleccionada.MostrarInforme();
        }
        else
        {
            Console.WriteLine("No se encontró la cadeteria");
        }
    }

    private static void CambiarDeEstado(Pedido pedidotomado, Cadete cadeteAsignado)
    {
        Console.WriteLine("Seleccione el estado en que desea colocar el pedido");
        Console.WriteLine("1. Rechazado");
        Console.WriteLine("2. Pendiente");
        var ingresarEstado = Console.ReadLine();

        if (ingresarEstado == "1")
        {
            pedidotomado.RechazarPedido();
            cadeteAsignado.RechazarPedido(pedidotomado);
        }
        else if (ingresarEstado == "2")
        {
            pedidotomado.Estado = Pedido.EstadoPedido.pendiente;
            cadeteAsignado.RechazarPedido(pedidotomado); // Corregido a aceptar
        }
    }

    private static Cadete AsignarCadete(List<Cadete> listaCadetes, Pedido pedidotomado)
    {
        Console.WriteLine("Elige el cadete que desea asignar");
        foreach (var item in listaCadetes)
        {
            Console.WriteLine($"{item.Nombre}");
        }

        var cadeteAsignar = Console.ReadLine();
        var cadeteselecionado = listaCadetes.FirstOrDefault(l => l.Nombre == cadeteAsignar);

        if (cadeteselecionado != null)
        {
            cadeteselecionado.AsignarPedido(pedidotomado);
            pedidotomado.AceptarPedido();
            cadeteselecionado.Mostrar();
            return cadeteselecionado;
        }
        else
        {
            Console.WriteLine("No se encontró el cadete");
            return null;
        }
    }

    public static List<Cadeteria> CargarCadeterias(string ruta, List<Cadete> listaCad)
    {
        var ListaCadeterias = new List<Cadeteria>();
        var HelperDeArchivo = new HelperDeArchivo();

        try
        {
            var datos = HelperDeArchivo.LeerCsv(ruta);
            if (datos != null && datos.Any())
            {
                foreach (var Cadeteria in datos)
                {
                    if (Cadeteria == null)
                    {
                        break;
                    }

                    var nuevacadeteria = new Cadeteria(Cadeteria[0], Cadeteria[1], listaCad);
                    ListaCadeterias.Add(nuevacadeteria);
                }
            }
        }
        catch (FileNotFoundException e)
        {
            Console.WriteLine($"Error: El archivo {ruta} no fue encontrado.");
        }

        return ListaCadeterias;
    }

    public static List<Cadete> CargarCadetes(string ruta)
    {
        var HelperDeArchivo = new HelperDeArchivo();
        Cadete nuevoCadete;
        var nuevaLista = new List<Cadete>();

        try
        {
            var listaCsv = HelperDeArchivo.LeerCsv(ruta);

            if (listaCsv != null && listaCsv.Any())
            {
                int id = 0;
                foreach (var cadete in listaCsv)
                {
                    if (cadete == null)
                        break;

                    nuevoCadete = new Cadete(id, cadete[0], cadete[1], cadete[2]);
                    nuevaLista.Add(nuevoCadete);
                    id += 1;
                }
            }
            else
            {
                Console.WriteLine("\n(No se encontraron cadetes para cargar)");
            }
        }
        catch (FileNotFoundException e)
        {
            Console.WriteLine($"Error: El archivo {ruta} no fue encontrado.");
        }

        return nuevaLista;
    }

    public static Pedido DarDeAlta(int nroDePedido)
    {
        Console.WriteLine("Ingrese el nombre del cliente");
        var nombreCliente = Console.ReadLine();

        Console.WriteLine("Ingrese la dirección donde vive");
        var direccionCliente = Console.ReadLine();

        Console.WriteLine("Ingrese el teléfono del cliente");
        var telefonoCliente = Console.ReadLine();

        Console.WriteLine("Ingrese los datos de referencia");
        var datosReferencia = Console.ReadLine();

        var datosCliente = new Cliente(nombreCliente, direccionCliente, telefonoCliente, datosReferencia);

        Console.WriteLine("Ingrese las observaciones que tenga del pedido");
        var observaciones = Console.ReadLine();

        var PedidoTomado = new Pedido(nroDePedido, observaciones, datosCliente);
        return PedidoTomado;
    }
}
