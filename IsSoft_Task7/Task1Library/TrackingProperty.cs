using System;

namespace Task1Library
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
    public class TrackingProperty : Attribute
    {
        public string PropertyName { get; }

        public TrackingProperty(string propertyName) => PropertyName = propertyName;
    }
}