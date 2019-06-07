using System;

namespace ConfigureAppIo.ServiceResolution
{
    public interface IServiceResolutionResult
    {
        Type ServiceType { get; }
        object InstanceResolved { get; }
        Exception ResolutionException { get; }
        string ServiceTypeName { get; }
        bool IsOpenGeneric { get; }
        string ResolutionWarning { get; }

    }
}