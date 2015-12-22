namespace Functional.Application.Interfaces.Common
{
    using Functional.Domain.Interfaces.Validation;
    using Functional.Domain.Validation;

    /// <summary>
    /// Espõe as operações básicas de escrita de dados.
    /// <para>Para fins de validação do resultado, o objeto <see cref="ValidationResult"/> receberá o resultado das operações,
    /// bem como eventuais erros.</para>
    /// </summary>
    /// <typeparam name="TEntity">O tipo principal que o serviço atende</typeparam>
    public interface IWriteOnlyAppService<in TEntity>
    where TEntity : class, ISelfValidation
    {
        /// <summary>
        /// Cria um <see cref="TEntity"/>.
        /// </summary>
        /// <param name="entity">A entidade</param>
        /// <returns>Um <see cref="ValidationResult"/></returns>
        ValidationResult Create(TEntity entity);

        /// <summary>
        /// Atualiza um <see cref="TEntity"/>.
        /// </summary>
        /// <param name="entity">A entidade</param>
        /// <returns>Um <see cref="ValidationResult"/></returns>
        ValidationResult Update(TEntity entity);

        /// <summary>
        /// Remove um <see cref="TEntity"/>.
        /// </summary>
        /// <param name="entity">A entidade</param>
        /// <returns>Um <see cref="ValidationResult"/></returns>
        ValidationResult Remove(TEntity entity);
    }

}
