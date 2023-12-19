using ViniloVirtualGen.ApplicationCore.EN.ViniloVirtual;
using InterfazViniloVirtual.Models;

namespace InterfazViniloVirtual.Assemblers
{
    public class PedidoAssembler
    {
        public PedidoViewModel ConvertirENToViewModel(PedidoEN pediEn)
        {
            PedidoViewModel pedidoViewModel = new PedidoViewModel();
            pedidoViewModel.IdUsuario = pediEn.Usuario.Email;
            pedidoViewModel.Direccion = pediEn.Direccion;
            pedidoViewModel.Id = pediEn.Id;
            pedidoViewModel.Fecha = pediEn.Fecha.Value.ToShortDateString();
            if (pediEn.MetodoPago == ViniloVirtualGen.ApplicationCore.Enumerated.ViniloVirtual.MetodosPagoEnum.mastercard)
            {
                pedidoViewModel.MetodoPago = "M";
            }
            else if (pediEn.MetodoPago == ViniloVirtualGen.ApplicationCore.Enumerated.ViniloVirtual.MetodosPagoEnum.paypal)
            {
                pedidoViewModel.MetodoPago = "P";
            }
            else
            {
                pedidoViewModel.MetodoPago = "V";
            }

            pedidoViewModel.LineasPedido = new List<int>();

            pedidoViewModel.Total = pediEn.Total;

            return pedidoViewModel;
        }

         public IList<PedidoViewModel> ConvertirListENToViewModel(System.Collections.Generic.IList<ViniloVirtualGen.ApplicationCore.EN.ViniloVirtual.PedidoEN> ens)
        {

            IList<PedidoViewModel> pedidos = new List<PedidoViewModel>();
            foreach (PedidoEN en in ens)
            {
                pedidos.Add(ConvertirENToViewModel(en));
            }

            return pedidos;

        }
    }
}