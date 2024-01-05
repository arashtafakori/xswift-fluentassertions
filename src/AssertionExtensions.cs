using XSwift.Base;
using FluentAssertions.Specialized;
using FluentAssertions;

namespace XSwift.FluentAssertions
{
    /// <summary>
    /// Provides extension methods for assertions related to asynchronous functions.
    /// </summary>
    public static class AssertionExtensions
    {
        /// <summary>
        /// Asserts that the asynchronous function throws an ErrorException containing an issue of the specified type.
        /// </summary>
        /// <typeparam name="TIssue">The type of the issue to check for in the ErrorException.</typeparam>
        /// <param name="nonGenericAsyncFunctionAssertions">The NonGenericAsyncFunctionAssertions instance.</param>
        /// <returns>A Task representing the asynchronous operation.</returns>
        /// <remarks>
        /// This method is used in conjunction with FluentAssertions for asserting that an asynchronous function
        /// throws an ErrorException containing an issue of the specified type.
        /// </remarks>
        public static async Task BeSatisfiedWith<TIssue>(
            this NonGenericAsyncFunctionAssertions nonGenericAsyncFunctionAssertions) where TIssue : IIssue
        {
            var exception = await nonGenericAsyncFunctionAssertions.ThrowExactlyAsync<ErrorException>();

            exception.Which.Error.Issues
                .OfType<TIssue>()
                .Should().NotBeEmpty($"because there should be at least one {typeof(TIssue).Name} issue");
        }
    }
}
