using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace ConfigureAppIo.ServiceResolution
{
    public class ServiceResolutionResults : IReadOnlyList<IServiceResolutionResult>
    {
        private readonly IList<IServiceResolutionResult> _results;
        public ServiceResolutionResults(IEnumerable<IServiceResolutionResult> results)
        {
            _results = (results ?? Enumerable.Empty<IServiceResolutionResult>()).ToList();
        }

        public IEnumerator<IServiceResolutionResult> GetEnumerator()
        {
            return _results.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _results.GetEnumerator();
        }

        public int Count => _results.Count;

        public IServiceResolutionResult this[int index] => _results[index];

        public IEnumerable<T> Get<T>() => _results.Where(s => s.ServiceType == typeof(T)).Select(t => t.InstanceResolved).Cast<T>();

        public IEnumerable<IServiceResolutionResult> GetResolvedTypeResults() => _results.Where(s => s.InstanceResolved != null);

        public IEnumerable<IServiceResolutionResult> GetFailedResolutionTypeResults() => _results.Where(s => s.ResolutionException != null);

        public IEnumerable<IServiceResolutionResult> GetWarningResolutionTypeResults() => _results.Where(s => s.ResolutionException == null && s.ResolutionWarning != null);

    }
}