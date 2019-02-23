using FluentAssertions;
using MoriaClient.Common;
using MoriaClient.Common.Configuration;
using NUnit.Framework;
using System;
using System.Collections.Generic;

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
            Dictionary<EndpointType, string> endpoints = new Dictionary<EndpointType, string>
            {
                { EndpointType.TeacherList, "teacher_list" },
                { EndpointType.Teacher, "teacher" }
            };
            ClientConfiguration configuration = new ClientConfiguration("http://example.com", endpoints);
            HttpClientFactory factory = null;

            // When
            Action createFactory = () => factory = new HttpClientFactory(configuration.BaseApiUri);

            // Then
            createFactory.Should().NotThrow();
            factory.Should().NotBeNull();
        }
    }
}