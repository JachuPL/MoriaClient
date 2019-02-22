using FluentAssertions;
using MoriaClient.Common;
using NUnit.Framework;
using System;
using System.Net.Http;

namespace MoriaClient.AutomatedTests
{
    [TestFixture]
    public class HttpClientFactoryTests
    {
        [TestCase(TestName = "HttpClientFactory throws ArgumentNullException if supplied configuration is null")]
        public void ShouldThrowExceptionWhenConfigurationIsNull()
        {
            // Given
            HttpClient client = null;

            // When
            Action createClient = () => client = HttpClientFactory.CreateClient(null);

            // Then
            createClient.Should().Throw<ArgumentNullException>();
        }
    }
}