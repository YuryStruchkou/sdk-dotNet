﻿using System.Collections.Generic;
using EncoreTickets.SDK.Api;
using EncoreTickets.SDK.Api.Context;
using EncoreTickets.SDK.Api.Helpers;
using EncoreTickets.SDK.Api.Helpers.RestClientWrapper;
using Moq;
using NUnit.Framework;

namespace EncoreTickets.SDK.Tests.Tests.Api
{
    internal class ApiClientWrapperBuilderTests
    {
        private const string SdkVersion = "1.1.0";

        private static object[] sourceForCreateClientWrapperTests =
        {
            new ApiContext(),
            null,
        };

        private static object[] sourceForCreateClientWrapperParametersTests =
        {
            new object[]
            {
                new ApiContext(),
                RequestMethod.Get,
                new {test1 = "test", Test2 = 4, test3 = (string) null},
                new Dictionary<string, string>
                {
                    {"x-SDK", $"EncoreTickets.SDK.NET {SdkVersion}"},
                },
                new Dictionary<string, string>
                {
                    {"test1", "test"},
                    {"test2", "4"},
                }
            },
            new object[]
            {
                new ApiContext
                {
                    Affiliate = "test"
                },
                RequestMethod.Get,
                null,
                new Dictionary<string, string>
                {
                    {"x-SDK", $"EncoreTickets.SDK.NET {SdkVersion}"},
                    {"affiliateId", "test"},
                },
                null
            },
        };

        [TestCaseSource(nameof(sourceForCreateClientWrapperTests))]
        public void Api_ApiClientWrapperBuilder_CreateClientWrapper_ReturnsClientWrapper(ApiContext context)
        {
            var wrapper = ApiClientWrapperBuilder.CreateClientWrapper(context);
            Assert.IsTrue(wrapper != null);
        }

        [TestCaseSource(nameof(sourceForCreateClientWrapperParametersTests))]
        public void Api_ApiClientWrapperBuilder_CreateClientWrapperParameters_ReturnsCorrectedParameters(
            ApiContext context, RequestMethod method, object queryObject,
            Dictionary<string, string> expectedHeaders, Dictionary<string, string> expectedQuery)
        {
            var baseUrl = It.IsAny<string>();
            var endpoint = It.IsAny<string>();
            var body = It.IsAny<object>();
            var dateFormat = It.IsAny<string>();
            var expectedParameters = new RestClientParameters
            {
                BaseUrl = baseUrl,
                RequestUrl = endpoint,
                RequestBody = body,
                RequestFormat = RequestFormat.Json,
                RequestMethod = method,
                RequestUrlSegments = null,
                RequestDateFormat = dateFormat
            };
            var result = ApiClientWrapperBuilder.CreateClientWrapperParameters(context, baseUrl, endpoint, method, body,
                queryObject, dateFormat);
            AssertExtension.SimplePropertyValuesAreEquals(expectedParameters, result);
            AssertExtension.EnumerableAreEquals(expectedParameters.RequestUrlSegments, result.RequestUrlSegments);
            AssertExtension.EnumerableAreEquals(expectedParameters.RequestQueryParameters, expectedQuery);
            AssertExtension.EnumerableAreEquals(expectedParameters.RequestHeaders, expectedHeaders);
        }
    }
}
