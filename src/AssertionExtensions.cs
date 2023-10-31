using XSwift.Base;
using FluentAssertions.Specialized;
using MassTransit.Initializers;

namespace FluentAssertions.XSwift
{
    public static class AssertionExtensions
    {
        public static async Task BeSatisfiedWith<TIssue>(
            this NonGenericAsyncFunctionAssertions nonGenericAsyncFunctionAssertions) where TIssue : IIssue
        {
            (await nonGenericAsyncFunctionAssertions.
                ThrowExactlyAsync<ErrorException>().
                Select(x => x.Which.Error.Issues.OfType<TIssue>()
                .Count())).Should().BeGreaterThan(0);
        }
    }
}
