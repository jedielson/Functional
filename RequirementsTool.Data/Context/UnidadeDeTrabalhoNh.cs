using System;
using Functional.Domain.Interfaces.Context.Common;
using NHibernate;

namespace Functional.Data.Nhibernate.SqlServer.Context
{
    /// <summary>
    /// Unidade de trabalho do NH
    /// </summary>
    public class UnidadeDeTrabalhoNh : IUnidadeDeTrabalho
    {
        /// <summary>
        /// Construtor padrão
        /// </summary>
        public UnidadeDeTrabalhoNh()
        {
            this.Sessao = NHibernateSession.OpenSession();
        }

        /// <summary>
        /// Sessão de conexão
        /// </summary>
        public ISession Sessao { get; set; }

        /// <summary>
        /// Inicia a transação
        /// </summary>
        public void IniciarTransacao()
        {
            this.Sessao.BeginTransaction();
        }

        /// <summary>
        /// Confirma a transação
        /// </summary>
        public void ConfirmarTransacao()
        {
            this.Sessao.Transaction.Commit();
        }

        /// <summary>
        /// Desfaz a transação
        /// </summary>
        public void DesfazerTransacao()
        {
            try
            {
                this.Sessao.Transaction.Rollback();
            }
            catch (Exception)
            {
                return;
            }
        }

        /// <summary>
        /// Verifica se está em trasacão
        /// </summary>
        /// <returns>Se está em trasacão</returns>
        public bool EmTransacao()
        {
            return this.Sessao.Transaction != null && this.Sessao.Transaction.IsActive;
        }

        /// <summary>
        /// Dispose de unidade de trabalho
        /// </summary>
        public void Dispose()
        {
            if (this.Sessao.Transaction.IsActive)
            {
                this.Sessao.Transaction.Rollback();
            }

            if (this.Sessao.IsOpen)
            {
                this.Sessao.Close();
                this.Sessao.Dispose();
            }
        }
    }
}
