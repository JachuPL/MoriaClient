using FluentAssertions;
using MoriaClient.Configuration;
using MoriaClient.Teachers;
using MoriaClient.Teachers.Factories;
using NUnit.Framework;
using System;

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
            IQueryTeachersData queryTeachers = null;

            // When
            Action createQuery = () =>
                queryTeachers =
                    TeacherQueryFactory.CreateQuery(new ClientConfiguration("http://example.com", "teachers_list", string.Empty));

            // Then
            createQuery.Should().NotThrow();
            queryTeachers.Should().NotBeNull();
        }
    }
}