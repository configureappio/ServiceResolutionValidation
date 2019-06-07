using System;
using System.Collections;
using System.Collections.Generic;
using Xunit;

namespace ConfigureAppIo.ServiceResolution.GenericResolutionsTests
{
    public class VerifyServiceResolution
    {
        [Fact]
        public void DummyTestToEnsureBuildAndTestRunnerWork()
        {
            var sut = ServiceResolutionValidation.ServiceResolutionValidation.VerifyServiceResolution();
            Assert.Empty(sut);
            Assert.Empty(sut.GetFailedResolutionTypeResults());
            Assert.Empty(sut.GetResolvedTypeResults());
            Assert.Empty(sut.GetWarningResolutionTypeResults());
#pragma warning disable xUnit2013 
            Assert.Equal(0, sut.Count);
#pragma warning restore xUnit2013 
            Assert.Throws<ArgumentOutOfRangeException>(() => sut[0]);
            Assert.Empty(sut.Get<string>());
            Assert.True(IteratorCountEquals(sut, 0));
            Assert.True(IteratorCountEquals((IEnumerable)sut, 0));
        }

        private static bool IteratorCountEquals(IEnumerable collection, int expectedCount)
        {
            var iterator = collection.GetEnumerator();
            int count = 0;
            while (iterator.MoveNext())
            {
                count++;
            }

            return count == expectedCount;
        }

        private static bool IteratorCountEquals<T>(IEnumerable<T> collection, int expectedCount)
        {
            using (var iterator = collection.GetEnumerator())
            {
                int count = 0;
                while (iterator.MoveNext())
                {
                    count++;
                }

                return count == expectedCount;
            }
        }
    }
}
