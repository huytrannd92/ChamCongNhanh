using System.Reflection;
using NetArchTest.Rules;
using Xunit;

namespace Schedule.UnitTests
{
    public class DomainLayerTest
    {
        private static Assembly DomainAssembly => typeof(Schedule.Domain.Common.ValueObject).Assembly;

        [Fact]
        public void ValueObjects_Should_Be_Immutable()
        {
            var result = Types.InAssembly(DomainAssembly)
                .That()
                .Inherit(typeof(Schedule.Domain.Common.ValueObject))
                .Should()
                .BeImmutable()
                .GetResult();

            Assert.True(result.IsSuccessful, GetFailingTypes(result));
        }

        private string GetFailingTypes(TestResult result)
        {
            return result.FailingTypeNames != null ?
                string.Join(", ", result.FailingTypeNames) :
                string.Empty;
        }

    }
}
