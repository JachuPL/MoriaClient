using FluentAssertions;
using MoriaClient.Common;
using MoriaClient.Configuration;
using NUnit.Framework;
using System;

namespace MoriaClient.AutomatedTests.Common
{
    [TestFixture]
    public class HttpClientFactoryTests
    {
        [TestCase(TestName = "HttpClientFactory throws ArgumentNullException if supplied configuration is null")]
        public void ShouldThrowExceptionWhenConfigurationIsNull()
        {
            // Given
            HttpClientFactory factory = null;

            // When
            Action createFactory = () => factory = new HttpClientFactory(null);

            // Then
            createFactory.Should().Throw<ArgumentNullException>();
            factory.Should().BeNull();
        }

        [TestCase(TestName = "HttpClientFactory creates HttpClient if supplied configuration is not null")]
        public void ShouldCreateClientWhenConfigurationIsNotNull()
        {
            // Given
            ClientConfiguration configuration = new ClientConfiguration("http://example.com", "teacher_list");
            HttpClientFactory factory = null;

            // When
            Action createFactory = () => factory = new HttpClientFactory(configuration.BaseApiUri);

            // Then
            createFactory.Should().NotThrow();
            factory.Should().NotBeNull();
        }
    }
}