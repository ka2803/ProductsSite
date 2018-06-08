using System;
using ProductPrice.Domain.Redis.Enums;

namespace ProductPrice.Domain.Redis.Attributes
{
    [AttributeUsage(AttributeTargets.Class)]
    public class IndexAttribute : Attribute
    {
        public RedisIndex Index { get; }

        public IndexAttribute(RedisIndex index)
        {
            Index = index;
        }
    }
}