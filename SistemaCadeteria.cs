namespace EspacioPrograma
{
    class SistemaCadeteria
    {
        public void ManejarPedidos()
        {
            var listaCadeterias = new List<Cadeteria>();
            var listaCadetes = new List<Cadete>();
            var CargarJSON = new AccesoADatosJSON();
            var CargarCSV = new AccesoADatosCSV();
            Console.WriteLine(" Ingrese 1- leer json, 2 - leer en csv");
            var leer = Console.ReadLine();
            int opcion;
            bool control = int.TryParse(leer, out opcion);
            if (opcion == 1)
            {
                listaCadeterias = CargarJSON.LeerArchivoCadeteriaYCargarCadetes(@"C:\taller\taller2\tp1\Cadeterias.json", @"C:\taller\taller2\tp1\Cadetes.json");
            }
            else
            {
                if (opcion == 2)
                {
                    listaCadeterias = CargarCSV.LeerArchivoCadeteriaYCargarCadetes("Cadeterias.csv", @"C:\taller\taller2\tp1\Nombres.csv");
                }
                else
                {
                    Console.WriteLine("Opción no válida");
                }
            }

            Console.WriteLine("Ingrese el nombre de la cadeteria con la que trabajara\n");
            var nombreCadeteria = Console.ReadLine();
            Cadeteria cadeteriaSeleccionada = listaCadeterias.Find(cadeteria => cadeteria.Nombre == nombreCadeteria);
            if (cadeteriaSeleccionada != null)
            {
                var ingresar = 0;
                var nroDePedido = 0;
                var cad1 = cadeteriaSeleccionada.Mostrar();
                Console.WriteLine(cad1);

                while (ingresar != 6)
                {
                    ingresar = Interfaz(cadeteriaSeleccionada, ref nroDePedido);
                }

                var inf = new Informe(cadeteriaSeleccionada.ListadoPedidos, cadeteriaSeleccionada.ListadoCadetes);
                var cadena = inf.MostrarInforme(cadeteriaSeleccionada.ListadoCadetes);
                Console.WriteLine(cadena);
            }
            else
            {
                Console.WriteLine("No se encontró la cadetería");
            }

        }

        private static int Interfaz(Cadeteria cadeteriaSeleccionada, ref int nroDePedido)
        {
            int opciones;
            Console.WriteLine("Elija una opcion:");
            Console.WriteLine("1) Dar de alta un pedido");
            Console.WriteLine("2)Asignar pedido al cadete");
            Console.WriteLine("3)Cambiar estado del pedido");
            Console.WriteLine("4)Reasignar el pedido a otro cadete");
            Console.WriteLine("5)Ver cobro del cadete (Ingreso ID)");
            Console.WriteLine("6)Salir del menu");
            var leer1 = Console.ReadLine();
            bool control = int.TryParse(leer1, out opciones);

            switch (opciones)
            {
                case 1:
                    cadeteriaSeleccionada.DarDeAlta(nroDePedido);
                    nroDePedido += 1;
                    cadeteriaSeleccionada.MostrarPedidosPendientes();
                    break;
                case 2:
                    AsignarPedidoACadete(cadeteriaSeleccionada);
                    break;
                case 3:
                    CambiarDeEstado(cadeteriaSeleccionada);
                    break;
                case 4:
                    ReasignarPedido(cadeteriaSeleccionada);
                    break;
                case 5:
                    JornalACobrarPorID(cadeteriaSeleccionada);
                    break;

            }

            return opciones;

        }

        private static void AsignarPedidoACadete(Cadeteria cadeteriaSeleccionada)
        {
            cadeteriaSeleccionada.MostrarPedidosPendientes();
            Console.WriteLine("Seleccione el numero de pedido que desea utilizar");
            var a = Console.ReadLine();
            int nro;
            bool control = int.TryParse(a, out nro);
            if (control) //true
            {
                AsignarCadete(cadeteriaSeleccionada, nro);
                Console.WriteLine("Asignado correctamente");
            }
        }

        private static void JornalACobrarPorID(Cadeteria cadeteriaSeleccionada)
        {
            Console.WriteLine("Ingrese el ID del cadete que desea ver el jornal a cobrar");
            var a = Console.ReadLine();
            int id;
            bool control = int.TryParse(a, out id);
            if (control)
            {
                var totalACobrar = cadeteriaSeleccionada.JornalACobrar(id);
                Console.WriteLine($"El cadete debe cobrar {totalACobrar}");

            }
        }

        private static void ReasignarPedido(Cadeteria cadeteriaSeleccionada)
        {
            Console.WriteLine("Ingrese el nro del pedido que desea reasignar");
            cadeteriaSeleccionada.MostrarPedidosPendientes();
            var a = Console.ReadLine();
            int nro;
            bool control = int.TryParse(a, out nro);
            if (control)
            {
                Console.WriteLine("Ingrese el id del cadete al que le dara el pedido");
                var b = Console.ReadLine();
                int id;
                bool control2 = int.TryParse(b, out id);
                if (control2)
                {
                    cadeteriaSeleccionada.AsignarCadeteAPedidoPorID(id, nro);


                }
                else
                {
                    Console.WriteLine("No se encuentra el cadete");
                }
            }
        }

        private static void AsignarCadete(Cadeteria cadeteriaSeleccionada, int nro)
        {
            var pedidoTomado = cadeteriaSeleccionada.ListadoPedidos.Find(l => l.Nro == nro);
            if (pedidoTomado != null)
            {
                Console.WriteLine("Ingrese el id del cadete que desea buscar");
                var a = Console.ReadLine();
                int id;
                bool control = int.TryParse(a, out id);
                if (control)
                {
                    cadeteriaSeleccionada.AsignarCadeteAPedidoPorID(id, pedidoTomado.Nro);
                    Console.WriteLine("Cadete asignado correctamente");
                }
            }
        }

        private static void CambiarDeEstado(Cadeteria cadeteriaSeleccionada)
        {
            cadeteriaSeleccionada.MostrarPedidosPendientes();
            Console.WriteLine("Seleccione el pedido que desea cambiar de estado");
            var a = Console.ReadLine();
            int nro;
            bool control = int.TryParse(a, out nro);
            if (control)
            {
                var pedidoTomado = cadeteriaSeleccionada.ListadoPedidos.Find(l => l.Nro == nro);
                if (pedidoTomado != null && pedidoTomado.Estado == EstadoPedido.pendiente)
                {
                    Console.WriteLine("Seleccione el estado en que desea el pedido");
                    Console.WriteLine("1. Rechazado");
                    Console.WriteLine("2. Acpetado");
                    var ingresarEstado = Console.ReadLine();
                    if (ingresarEstado == "1")
                    {
                        cadeteriaSeleccionada.ListadoPedidos.Remove(pedidoTomado);
                        pedidoTomado.RechazarPedido();
                        pedidoTomado = null;
                    }
                    else
                    {
                        if (pedidoTomado.CadeteAsignado != null)
                        {
                            cadeteriaSeleccionada.AceptarPedido(pedidoTomado.Nro);
                        }
                        else
                        {
                            Console.WriteLine("un pedido para ser entregado debe ser asignado a un cadete");
                        }
                    }
                }
                else
                {
                    Console.WriteLine("El pedido ya fue entregado o rechazado o no existe");
                }
            }

        }

        public static List<Cadete> CargarCadetes(string ruta)
        {
            var HelperDeArchivo = new HelperDeArchivo();
            Cadete nuevoCadete;
            var nuevaLista = new List<Cadete>();
            var listaCSV = HelperDeArchivo.LeerCsv(ruta);
            if (listaCSV != null && listaCSV.Any())
            {
                int id = 0;
                foreach (var cadete in listaCSV)
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
                Console.WriteLine("NO se encontraron cadete para cargar");
            }
            return nuevaLista;

        }
    }
}

