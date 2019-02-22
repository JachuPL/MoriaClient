using FluentAssertions;
using MoriaClient.Configuration;
using MoriaClient.Teachers;
using MoriaClient.Teachers.Factories;
using MoriaClient.Teachers.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MoriaClient.AutomatedTests.Teachers
{
    [TestFixture]
    public class QueryTeachersDataTests
    {
        [TestCase]
        public async Task BLA()
        {
            // Given
            ClientConfiguration configuration = new ConfigurationBuilder()
                .WithApiUrl("http://moria.umcs.lublin.pl/api/")
                .WithTeacherListEndpoint("teacher_list")
                .Build();
            IQueryTeachersData queryTeachers = TeacherQueryFactory.CreateQuery(configuration);

            // When
            IEnumerable<Teacher> teachers = await queryTeachers.GetAll();

            // Then
            teachers.Should().NotBeNull();
            foreach (var teacher in teachers)
                Console.WriteLine($"{teacher.Degree} {teacher.FirstName} {teacher.LastName}");
        }
    }
}