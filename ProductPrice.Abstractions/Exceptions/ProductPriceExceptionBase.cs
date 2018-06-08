using System;
using System.Net;
using System.Resources;
using ProductPrice.Abstractions.Attributes;

namespace ProductPrice.Abstractions.Exceptions
{
    [StatusCode(HttpStatusCode.BadRequest)]
    public class ProductPriceExceptionBase : ApplicationException
    {
        protected virtual ResourceManager CodesManager => Codes.ResourceManager;
        protected virtual ResourceManager MessagesManager => Messages.ResourceManager;

        private string TypeName => GetType().Name;

        public override string Message => MessagesManager.GetString(TypeName) ?? string.Empty;

        public virtual string Code => CodesManager.GetString(TypeName);
    }
}