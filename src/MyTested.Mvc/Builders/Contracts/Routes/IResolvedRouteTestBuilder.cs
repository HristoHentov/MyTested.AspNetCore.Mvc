﻿namespace MyTested.Mvc.Builders.Contracts.Routes
{
    using System.Collections.Generic;

    /// <summary>
    /// Used for adding additional test cases to a route.
    /// </summary>
    public interface IResolvedRouteTestBuilder
    {
        IAndResolvedRouteTestBuilder ToRouteValue(string key);

        IAndResolvedRouteTestBuilder ToRouteValue(string key, object value);

        IAndResolvedRouteTestBuilder ToRouteValues(object routeValues);

        IAndResolvedRouteTestBuilder ToRouteValues(IDictionary<string, object> routeValues);

        IAndResolvedRouteTestBuilder ToDataToken(string key);

        IAndResolvedRouteTestBuilder ToDataToken(string key, object value);

        IAndResolvedRouteTestBuilder ToDataTokens(object dataTokens);

        IAndResolvedRouteTestBuilder ToDataTokens(IDictionary<string, object> dataTokens);

        /// <summary>
        /// Tests whether the resolved route will have valid model state.
        /// </summary>
        /// <returns>The same route test builder.</returns>
        IAndResolvedRouteTestBuilder ToValidModelState();
    }
}
