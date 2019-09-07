using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;
using Entity;

namespace Business
{
    public class BDetallePedido
    {
        private DDetallePedido DDetallePedido = null;
        public List<DetallePedido> GetDetallePedidosPorId(int IdPedido)
        {
            List<DetallePedido> DetallesPedidos = null;
            try
            {
                DDetallePedido = new DDetallePedido();
                DetallesPedidos = DDetallePedido.GetDetallePedidos(new DetallePedido { Pedido = new Pedido { IdPedido = IdPedido } });
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return DetallesPedidos;
        }
        public decimal GetDetalleTotalPorId(int IdPedido)
        {
            List<DetallePedido> DetallesPedidos = null;
            decimal total = 0;
            try
            {
                DDetallePedido = new DDetallePedido();
                DetallesPedidos = DDetallePedido.GetDetallePedidos(new DetallePedido { Pedido = new Pedido { IdPedido = IdPedido } });

                foreach (var item in DetallesPedidos)
                {
                    total =total + item.Cantidad * item.PrecioUnidad - item.Descuento;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                DDetallePedido = null;
            }
            return total;
        }
    }
}
