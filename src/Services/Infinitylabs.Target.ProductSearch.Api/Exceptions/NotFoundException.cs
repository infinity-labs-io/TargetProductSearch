using System;

namespace InfinityLabs.Target.ProductSearch.Api.Exceptions
{
    public class NotFoundException : Exception
    {
        private string _message;

        public override string Message => _message;
        
        public NotFoundException(string resourceName, int id)
        {
            _message = $"Resource '{resourceName}' with id '{id}' was not found.";
        }
    }
}