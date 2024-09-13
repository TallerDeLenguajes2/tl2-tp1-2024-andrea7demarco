using EspacioPrograma;
class SistemaCadeteria
{
    public void Ejecutar()
    {
        var listaCadeterias = new List<Cadeteria>();
        var listaCadetes = new List<Cadete>();
        listaCadetes = ManejoPedidos.CargarCadetes("Nombres.csv");
        listaCadeterias = ManejoPedidos.CargarCadeterias("Cadeterias.csv", listaCadetes);

        Console.WriteLine("Ingrese el nombre de la cadeteria con la que desea trabajar");
        var nombreCadeteria = Console.ReadLine();
        Cadeteria cadeteriaSeleccionada = listaCadeterias.FirstOrDefault(l => l.Nombre == nombreCadeteria);

        if (cadeteriaSeleccionada != null)
        {
            var ingresar = "a";
            var nroDePedido = 0;
            Pedido pedidotomado = null;
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
                        pedidotomado = ManejoPedidos.DarDeAlta(nroDePedido);
                        nroDePedido += 1;
                        pedidotomado.Mostrar();
                        break;

                    case "b":
                        if (pedidotomado != null)
                        {
                            cadeteAsignado = ManejoPedidos.AsignarCadete(listaCadetes, pedidotomado);
                        }
                        break;

                    case "c":
                        if (pedidotomado != null)
                        {
                            ManejoPedidos.CambiarDeEstado(pedidotomado, cadeteAsignado);
                        }
                        break;

                    case "d":
                        if (pedidotomado != null)
                        {
                            cadeteAsignado.RechazarPedido(pedidotomado);
                            cadeteAsignado = ManejoPedidos.AsignarCadete(listaCadetes, pedidotomado);
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
}
