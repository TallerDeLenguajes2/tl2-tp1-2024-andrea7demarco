namespace EspacioPrograma
{

    public class Informe
    {
        private double montoGanado;
        private double montoPromedioXCadete;
        private int totalEnvios;

        private string MostrarMontoGanadoyEnviosPorCadete(List<Cadete> listadoCadetes)
        {
            string cadena = "";
            foreach (var cadete in listadoCadetes)
            {
                cadena += @$"CADETE {cadete.Nombre}:";

            }

            return (cadena);
        }

        private void CalcularGananciaYTotalEnvios(List<Pedido> listadoPedidos)
        {
            int envios = 0;
            foreach (var pedido in listadoPedidos)
            {
                if (pedido.Estado == EstadoPedido.aceptado)
                {
                    envios++;
                }
            }
            this.montoGanado = (double)envios * 500;
            this.totalEnvios = envios;

        }

        private void CalcularMontoPromedioPorCadete(List<Cadete> listadoCadetes)
        {
            this.montoPromedioXCadete = this.montoGanado / listadoCadetes.Count();
        }

        public string MostrarInforme(List<Cadete> listadoCadetes)
        {
            var cadena = (@$"           INFORME
            CANT ENVIOS: {this.totalEnvios}
            MONTO GANADO: {this.montoGanado}
            CANTIDAD PROMEDIO GANADA POR CADETE: {this.montoPromedioXCadete}
            ====================================================");
            return (cadena);
        }

        public Informe(List<Pedido> listadoPedidos, List<Cadete> listadoCadetes)
        {
            CalcularGananciaYTotalEnvios(listadoPedidos);
            CalcularMontoPromedioPorCadete(listadoCadetes);
            
        }


    }

}