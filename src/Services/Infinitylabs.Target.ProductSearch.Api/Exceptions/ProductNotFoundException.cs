using System;
using System.Runtime.Serialization;

namespace InfinityLabs.Target.ProductSearch.Api.Exceptions
{
    public class ProductNotFoundException : NotFoundException
    {
        public ProductNotFoundException(int id) : base("Product", id)
        {
        }
    }
}