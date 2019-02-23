using FakeItEasy;
using FluentAssertions;
using MoriaClient.Common;
using MoriaClient.Configuration;
using MoriaClient.Teachers;
using MoriaClient.Teachers.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MoriaClient.AutomatedTests.Teachers
{
    [TestFixture]
    public class QueryTeachersDataTests
    {
        [TestCase]
        public async Task ShouldReturnTeachersForCorrectResponse()
        {
            // Given
            string mockResult =
                "{\"result\":{\"array\":[{\"degree\":\"A\",\"department_id\":1,\"first_name\":\"A\",\"id\":1,\"last_name\":\"A\"},{\"degree\":\"B\",\"department_id\":2,\"first_name\":\"B\",\"id\":2,\"last_name\":\"B\"},{\"degree\":\"C\",\"department_id\":3,\"first_name\":\"C\",\"id\":3,\"last_name\":\"C\"},{\"degree\":\"D\",\"department_id\":4,\"first_name\":\"D\",\"id\":4,\"last_name\":\"D\"}],\"count\":4},\"status\":\"ok\"}";
            ClientConfiguration mockConfiguration = new ClientConfiguration("http://example.com", "teacher_list");
            HttpClient mockClient = A.Fake<HttpClient>();
            A.CallTo(() => mockClient.GetStreamAsync(A<Uri>.Ignored))
                .Returns(new MemoryStream(Encoding.UTF8.GetBytes(mockResult)));
            IQueryTeachersData queryTeachers = new QueryTeachersData(mockConfiguration);

            // When
            IEnumerable<Teacher> teachers = await queryTeachers.GetAll();

            // Then
            teachers.Should().NotBeNullOrEmpty();
            teachers.Should().HaveCount(4);
            teachers.Should().Contain(x => x.Id == 1 && x.Degree == "A" && x.DepartmentId == 1 && x.FirstName == "A" && x.LastName == "A");
            teachers.Should().Contain(x => x.Id == 2 && x.Degree == "B" && x.DepartmentId == 2 && x.FirstName == "B" && x.LastName == "B");
            teachers.Should().Contain(x => x.Id == 3 && x.Degree == "C" && x.DepartmentId == 3 && x.FirstName == "C" && x.LastName == "C");
            teachers.Should().Contain(x => x.Id == 4 && x.Degree == "D" && x.DepartmentId == 4 && x.FirstName == "D" && x.LastName == "D");
        }
    }
}