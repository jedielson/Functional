namespace Functional.Application.Interfaces.Common
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;

    using Functional.Domain.Interfaces.Validation;

    /// <summary>
    /// Expõe as operações básicas de acesso à dados.
    /// <para>Um dado pode ser acessado no modo somente leitura, se os parâmetros de somente leitura forem
    /// true.</para>
    /// <para>Um objeto será do tipo somente leitura quando não estiver sendo gerenciado pela api de acesso
    /// a dados. Neste caso, o objeto é um objeto comum em memória, e para operações de escrita, 
    /// deve ser submetido ao proxy.</para>
    /// <para></para>
    /// <para>As consultas que retornam coleções são retornadas na forma de <see cref="IQueryable{T}"/> para que possam
    /// ser usadas apenas no momento em que forem necessárias</para>
    /// </summary>
    /// <typeparam name="TEntity">O tipo principal que o serviço atende</typeparam>
    /// <seealso cref="Functional.Application.Interfaces.Common.IWriteOnlyAppService{TEntity}" />
    /// <seealso cref="System.IDisposable" />
    public interface IAppService<TEntity> : IWriteOnlyAppService<TEntity>, IDisposable where TEntity : class, ISelfValidation
    {
        /// <summary>
        /// Retorna um <see cref="TEntity"/> pelo id
        /// </summary>
        /// <param name="id">Um <see cref="Guid"/> que é o id da entidade</param>
        /// <param name="readonly">objeto somente leitura, ou não</param>
        /// <returns>Retorna um <see cref="TEntity"/></returns>
        TEntity Get(Guid id, bool @readonly = false);

        /// <summary>
        /// Retorna todos os objetos do tipo <see cref="TEntity"/>
        /// <para>Esta rotina deve ser usada com cuidado, pois pode ocasionar sobrecarga de memória.</para>
        /// <para>Caso se verifique que há muitos dados a serem carregados, recomenda-se o método <see cref="Find"/></para>
        /// </summary>
        /// <param name="readonly">objeto somente leitura, ou não</param>
        /// <returns>Um <see cref="IQueryable{T}"/> contendo o acesso aos dados.</returns>
        IQueryable<TEntity> All(bool @readonly = false);

        /// <summary>
        /// Realiza uma consulta filtrada, usando o parametro <param name="predicate"></param>
        /// </summary>
        /// <param name="predicate">O filtro a ser aplicado na consulta</param>
        /// <param name="readonly">objeto somente leitura, ou não</param>
        /// <returns>Um <see cref="IQueryable{T}"/> contendo o acesso aos dados.</returns>
        IQueryable<TEntity> Find(Expression<Func<TEntity, bool>> predicate, bool @readonly = false);
    }
}
