using System;

namespace Task1Library
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct)]
    public class TrackingEntity : Attribute { }
}