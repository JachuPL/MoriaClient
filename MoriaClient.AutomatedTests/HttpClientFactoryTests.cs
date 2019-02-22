using FluentAssertions;
using MoriaClient.Common;
using MoriaClient.Configuration;
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

        [TestCase(TestName = "HttpClientFactory creates HttpClient if supplied configuration is not null")]
        public void ShouldCreateClientWhenConfigurationIsNotNull()
        {
            // Given
            HttpClient client = null;

            // When
            Action createClient = () => client = HttpClientFactory.CreateClient(new ClientConfiguration("http://example.com", "teacher_list"));

            // Then
            createClient.Should().NotThrow();
            client.Should().NotBeNull();
        }
    }
}