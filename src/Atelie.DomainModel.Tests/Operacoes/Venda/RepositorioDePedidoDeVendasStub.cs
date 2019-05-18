using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Atelie.Operacoes.Venda
{
    public class RepositorioDePedidoDeVendasStub : IRepositorioDePedidoDeVendas
    {
        public async Task<PedidoDeVenda> ObtemPedidoDeVenda(int id)
        {
            //if (id == 0)
            //{
            //    throw new InvalidOperationException();
            //}

            return new PedidoDeVenda();
        }

        public Task Update(PedidoDeVenda pedidoDeVenda)
        {
            throw new NotImplementedException();
        }
    }
}
