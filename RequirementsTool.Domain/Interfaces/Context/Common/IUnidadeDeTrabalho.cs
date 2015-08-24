using System;

namespace Functional.Domain.Interfaces.Context.Common
{
    /// <summary>
    /// Interface de unidade de trabalho
    /// </summary>
    public interface IUnidadeDeTrabalho : IDisposable
    {
        /// <summary>
        /// Inicia uma transação
        /// </summary>
        void IniciarTransacao();

        /// <summary>
        /// Confirma a transação
        /// </summary>
        void ConfirmarTransacao();

        /// <summary>
        /// Desfaz a transação
        /// </summary>
        void DesfazerTransacao();

        /// <summary>
        /// Verifica se está em transação
        /// </summary>
        /// <returns>Se está em transação</returns>
        bool EmTransacao();
    }
}
