namespace MyTested.AspNetCore.Mvc.Builders.Contracts.Models
{
    using System;
    using System.Linq.Expressions;
    using Base;

    public interface IModelErrorBuilder<TModel> : IBaseBuilderWithModelError
    {
        /// <summary>
        /// Adds an error for the selected <typeparamref name="TProperty"/>
        /// to the <see cref="Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateDictionary"/>
        /// </summary>
        /// <typeparam name="TProperty">The property to add an error for.</typeparam>
        /// <param name="propertySelector">An expression, to select the property.</param>
        /// <param name="errorMessage">The message for the error.</param>
        /// <returns></returns>
        IAndModelStateBuilder<TModel> WithErrorFor<TProperty>(
            Expression<Func<TModel, TProperty>> propertySelector,
            string errorMessage);
    }
}
