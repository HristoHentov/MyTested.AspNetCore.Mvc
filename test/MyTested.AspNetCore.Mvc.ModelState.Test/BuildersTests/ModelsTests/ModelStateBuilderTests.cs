namespace MyTested.AspNetCore.Mvc.Test.BuildersTests.ModelsTests
{
    using System;
    using Setups;
    using Setups.Controllers;
    using Xunit;
    using System.Collections.Generic;
    using Setups.Models;

    public class ModelStateBuilderTests
    {
        [Fact]
        public void WithModelStateWithErrorShouldWorkCorrectly()
        {
            var requestBody = TestObjectFactory.GetValidRequestModel();

            MyController<MvcController>
                .Instance()
                .WithModelState(modelState => modelState
                    .WithError("TestError", "Invalid value"))
                .Calling(c => c.BadRequestWithModelState(requestBody))
                .ShouldReturn()
                .BadRequest();
        }

        [Fact]
        public void WithModelStateWithErrorsDictionaryShouldWorkCorrectly()
        {
            var requestBody = TestObjectFactory.GetValidRequestModel();
            var errorsDictionary = new Dictionary<string, string>()
            {
                ["First"] = "SomeError",
                ["Second"] = "AnotherError",
            };

            MyController<MvcController>
                .Instance()
                .WithModelState(modelState => modelState
                    .WithErrors(errorsDictionary))
                .Calling(c => c.BadRequestWithModelState(requestBody))
                .ShouldReturn()
                .BadRequest();
        }

        [Fact]
        public void WithModelStateWithErrorsObjectShouldWorkCorrectly()
        {
            var requestBody = TestObjectFactory.GetValidRequestModel();
            var errorsObject = new
            {
                First = "SomeError",
                Second = "AnotherError",
            };

            MyController<MvcController>
                .Instance()
                .WithModelState(modelState => modelState
                    .WithErrors(errorsObject))
                .Calling(c => c.BadRequestWithModelState(requestBody))
                .ShouldReturn()
                .BadRequest();
        }

        [Fact]
        public void WithModelStateForModelShouldWorkCorrectly()
        {
            var requestBody = TestObjectFactory.GetValidRequestModel();

            MyController<MvcController>
                .Instance()
                .WithModelState(modelState => modelState
                    .For<RequestModel>()
                    .WithErrorFor(m => m.RequiredString, "")
                    .WithErrorFor(m => m.Integer, "bad int")
                    .WithErrorFor(m => m.NotValidateInteger, "error message")
                    .AndAlso()
                    .For<RequestModel>()
                    .WithErrorFor(m => m.Integer, "some other errror")
                )
                .Calling(c => c.BadRequestWithModelState(requestBody))
                .ShouldReturn()
                .BadRequest();
        }

        //[Fact]
        //public void WithModelStateForModelWithPropertySelectorShouldWorkCorrectly()
        //{
        //    var requestBody = TestObjectFactory.GetValidRequestModel();

        //    MyController<MvcController>
        //        .Instance()
        //        .WithModelState(modelState => modelState
        //            .For((RequestModel m) => m.RequiredString, "")
        //            .For((DateTime dt) => dt.Date, "failed date"))
        //        .Calling(c => c.BadRequestWithModelState(requestBody))
        //        .ShouldReturn()
        //        .BadRequest();
        //}
    }
}
