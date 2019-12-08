namespace MyTested.AspNetCore.Mvc.Builders.Models
{
    using System;
    using System.Linq.Expressions;
    using Contracts.Models;
    using Internal.TestContexts;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.ModelBinding;
    using Utilities.Extensions;

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
            var mem = body as MemberExpression;
            var name = mem.Member.Name;
            this.ModelState.AddModelError(name, errorMessage);

            return this;
        }

        public IAndModelStateBuilder AndAlso()
        {
            return new ModelStateBuilder(null);
        }
    }
}
