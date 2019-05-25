using Atelie.Cadastro.Materiais;
using Atelie.Cadastro.Materiais.Fabricantes;
using Atelie.Comum;

namespace Atelie.Operacoes.Compra
{
    public class ItemDePedidoDeCompra
    {
        public virtual PedidoDeCompra Pedido { get; internal set; }

        public virtual Material Material { get; internal set; }

        //public virtual CorDeFabricante Cor { get; internal set; }

        public virtual Unidade Unidade { get; internal set; }

        public double Quantidade { get; internal set; }

        public decimal Valor { get; internal set; }
    }
}
