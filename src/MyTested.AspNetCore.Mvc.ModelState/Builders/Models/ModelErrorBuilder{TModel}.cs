namespace MyTested.AspNetCore.Mvc.Builders.Models
{
    using System;
    using System.Linq.Expressions;
    using Contracts.Models;
    using Internal.TestContexts;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.ModelBinding;

    public class ModelErrorBuilder<TModel> : IAndModelStateBuilder<TModel>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ModelErrorBuilder{TModel}"/> class.
        /// </summary>
        /// <param name="testContext"><see cref="ActionTestContext"/> containing data about the currently executed assertion chain.</param>
        /// <param name="modelState">Optional <see cref="ModelStateDictionary"/> to use the class with. Default is <see cref="ControllerBase"/>'s <see cref="ModelStateDictionary"/>.</param>
        public ModelErrorBuilder(
            ActionTestContext testContext,
            ModelStateDictionary modelState = null)
            => this.ModelState = modelState ?? testContext.ModelState;

        public ModelStateDictionary ModelState { get; private set; }

        /// <inheritdoc />
        public IAndModelStateBuilder<TModel> WithErrorFor<TProperty>(
            Expression<Func<TModel, TProperty>> propertySelector,
            string errorMessage)
        {
            var body = propertySelector.Body;

            if(body is MemberExpression memberBody)
            {
                this.ModelState.AddModelError(memberBody.Member.Name, errorMessage);
                return this;
            }

            throw new InvalidOperationException($"Cannot extract error key from the provided {nameof(propertySelector)}");
        }

        public IModelErrorBuilder<TModel> AndAlso() => this;
    }
}
