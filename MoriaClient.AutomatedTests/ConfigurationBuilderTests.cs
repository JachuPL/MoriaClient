using FluentAssertions;
using MoriaClient.Configuration;
using NUnit.Framework;
using System;

namespace MoriaClient.AutomatedTests
{
    [TestFixture]
    public class ConfigurationBuilderTests
    {
        [TestCase("", typeof(ArgumentNullException), TestName = "ConfigurationBuilder should throw ArgumentNullException for empty string")]
        [TestCase(null, typeof(ArgumentNullException), TestName = "ConfigurationBuilder should throw ArgumentNullException for null string")]
        [TestCase("\r\n\t  ", typeof(ArgumentNullException), TestName = "ConfigurationBuilder should throw ArgumentNullException for null string")]
        [TestCase("http://", typeof(ArgumentException), TestName = "ConfigurationBuilder should throw ArgumentNullException for null string")]
        public void ShouldThrowExceptionWhenApiUrlIsIncorrect(string apiUrl, Type exceptionType)
        {
            // Given
            ClientConfiguration configuration = null;

            // When
            Action createInvalidConfiguration =
                () => configuration = new ConfigurationBuilder().WithApiUrl(apiUrl).Build();

            // Then
            createInvalidConfiguration.Should().Throw<Exception>()
                .Which.GetType().Should().Be(exceptionType);
        }

        [TestCase("http://example.com", TestName = "ConfigurationBuilder should not throw exception for valid domain name with suffix")]
        [TestCase("http://example", TestName = "ConfigurationBuilder should not throw exception for valid domain name without suffix")]
        [TestCase("https://example.com", TestName = "ConfigurationBuilder should not throw exception for valid domain name with suffix and SSL")]
        [TestCase("https://example", TestName = "ConfigurationBuilder should not throw exception for valid domain name without suffix and with SSL")]
        public void ShouldNotThrowExceptionWhenApiUrlIsCorrect(string apiUrl)
        {
            // Given
            ClientConfiguration configuration = null;

            // When
            Action createValidConfiguration =
                () => configuration = new ConfigurationBuilder().WithApiUrl(apiUrl).Build();

            // Then
            createValidConfiguration.Should().NotThrow();
            configuration.Should().NotBeNull();
            configuration.ApiUri.Should().Be(apiUrl);
        }
    }
}