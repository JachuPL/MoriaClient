using FluentAssertions;
using MoriaClient.Common.Configuration;
using MoriaClient.Teachers;
using MoriaClient.Teachers.Factories;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace MoriaClient.AutomatedTests.Teachers.Factories
{
    [TestFixture]
    public class TeacherQueryFactoryTests
    {
        [TestCase(TestName = "TeacherQueryFactory should throw ArgumentNullException if supplied configuration is null")]
        public void ShouldThrowExceptionIfConfigurationIsNull()
        {
            // Given
            IQueryTeachersData queryTeachers = null;

            // When
            Action createQuery = () => queryTeachers = TeacherQueryFactory.CreateQuery(null);

            // Then
            createQuery.Should().Throw<ArgumentNullException>();

            queryTeachers.Should().BeNull();
        }

        [TestCase(TestName = "TeacherQueryFactory should create query object if supplied configuration is not null")]
        public void ShouldCreateQueryIfConfigurationWasSupplied()
        {
            // Given
            Dictionary<EndpointType, string> endpoints = new Dictionary<EndpointType, string>
            {
                { EndpointType.TeacherList, "teacher_list" },
                { EndpointType.Teacher, "teacher" }
            };
            IQueryTeachersData queryTeachers = null;

            // When
            Action createQuery = () =>
                queryTeachers =
                    TeacherQueryFactory.CreateQuery(new ClientConfiguration("http://example.com", endpoints));

            // Then
            createQuery.Should().NotThrow();
            queryTeachers.Should().NotBeNull();
        }
    }
}