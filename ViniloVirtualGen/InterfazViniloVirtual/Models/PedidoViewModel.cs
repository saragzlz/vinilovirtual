using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using ViniloVirtualGen.ApplicationCore.EN.ViniloVirtual;
using ViniloVirtualGen.ApplicationCore.Enumerated.ViniloVirtual;


namespace InterfazViniloVirtual.Models
{
    public class PedidoViewModel
    {

        [ScaffoldColumn(false)]
        public int Id { get; set; }

        public List<int> LineasPedido { get; set; }

        public string Fecha { get; set; }

        public string Direccion { get; set; }

        public double Total { get; set; }

        public string MetodoPago { get; set; }

        public string Estado { get; set; }

        public string IdUsuario { get; set; }

        public string NumeroTarjeta { get; set; }

        public string MesExpiracionTarjeta { get; set; }

        public string AnyoExpiracionTarjeta { get; set; }

        public string CCCVTarjeta { get; set; }

        public bool SeleccionMetodo { get; set; }

    }
}