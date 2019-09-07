using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Entity;

namespace Data
{
    public class DDetallePedido
    {
        public List<DetallePedido> GetDetallePedidos(DetallePedido detallePedido)
        {
            SqlParameter[] parameters = null;
            string commandText = string.Empty;
            List<DetallePedido> DetallesPedidos = null;
            //código mediante el cual traemos los detalle del pedido

            try
            {
                commandText = "Usp_detalle";
                parameters = new SqlParameter[1];
                parameters[0] = new SqlParameter("@IdPedido", SqlDbType.Int);
                parameters[0].Value = detallePedido.Pedido.IdPedido;
                DetallesPedidos = new List<DetallePedido>();

                using (SqlDataReader reader = SQLHelper.ExecuteReader(SQLHelper.Connection, "Usp_detalle", CommandType.StoredProcedure, parameters))
                {
                    while (reader.Read())
                    {
                        DetallesPedidos.Add(new DetallePedido
                        {
                            Pedido = new Pedido { IdPedido = reader["IdPedido"] != null ? Convert.ToInt32(reader["IdPedido"]) : 0}, 
                            IdProducto = reader["IdProducto"] != null ? Convert.ToInt32(reader["IdProducto"]) : 0,
                            Cantidad = reader["Cantidad"] != null ? Convert.ToInt32(reader["Cantidad"]) : 0,
                            PrecioUnidad = reader["PrecioUnidad"] != null ? Convert.ToDecimal(reader["PrecioUnidad"]) : 0,
                            Descuento = reader["Descuento"] != null ? Convert.ToDecimal(reader["Descuento"]) : 0
                        });
                    }
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return DetallesPedidos;
        }
    }
}