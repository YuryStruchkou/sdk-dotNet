﻿using System.Collections.Generic;
using EncoreTickets.SDK.Api;
using EncoreTickets.SDK.Api.Context;
using EncoreTickets.SDK.Api.Helpers;
using EncoreTickets.SDK.Content.Models;

namespace EncoreTickets.SDK.Content
{
    /// <summary>
    /// Wrapper class for the inventory service API
    /// </summary>
    public class ContentServiceApi : BaseApi
    {
        /// <summary>
        /// Default constructor for the Inventory service
        /// </summary>
        /// <param name="context"></param>
        public ContentServiceApi(ApiContext context) : base(context, "content-service.{0}tixuk.io/api/")
        {
        }

        public ContentServiceApi(ApiContext context, string baseUrl) : base(context, baseUrl)
        {
        }

        /// <summary>
        /// Search for a product
        /// </summary>
        /// <returns></returns>
        public IList<Location> GetLocations()
        {
            var results = Executor.ExecuteApiWithWrappedResponse<List<Location>>(
                "v1/locations",
                RequestMethod.Get);
            return results.DataOrException;
        }

        /// <summary>
        /// Get the available products
        /// </summary>
        /// <returns></returns>
        public IList<Product> GetProducts()
        {
            var result = Executor.ExecuteApiWithWrappedResponse<List<Product>>(
                "v1/products?page=1&limit=1000",
                RequestMethod.Get);
            return result.DataOrException;
        }

        /// <summary>
        /// Get the product by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Product GetProductById(string id)
        {
            var result = Executor.ExecuteApiWithWrappedResponse<Product>(
                $"v1/products/{id}",
                RequestMethod.Get);
            return result.DataOrException;
        }

        /// <summary>
        /// Get the product by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Product GetProductById(int id)
        {
            return GetProductById(id.ToString());
        }
    }
}