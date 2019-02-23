using FluentAssertions;
using MoriaClient.Common;
using MoriaClient.Common.Models.Request;
using MoriaClient.Common.Models.Response;
using MoriaClient.Rooms.Models;
using MoriaClient.Teachers.Models;
using NUnit.Framework;
using System.IO;
using System.Text;

namespace MoriaClient.AutomatedTests.Common
{
    [TestFixture]
    public class JsonProcessorTests
    {
        [TestCase(TestName = "JsonProcessor should deserialize teacher array correctly")]
        public void ShouldDeserializeTeacherArrayCorrectly()
        {
            // Given
            string teacherArrayJsonResult =
                "{\"result\":{\"array\":[{\"degree\":\"A\",\"department_id\":1,\"first_name\":\"A\",\"id\":1,\"last_name\":\"A\"},{\"degree\":\"B\",\"department_id\":2,\"first_name\":\"B\",\"id\":2,\"last_name\":\"B\"},{\"degree\":\"C\",\"department_id\":3,\"first_name\":\"C\",\"id\":3,\"last_name\":\"C\"},{\"degree\":\"D\",\"department_id\":4,\"first_name\":\"D\",\"id\":4,\"last_name\":\"D\"}],\"count\":4},\"status\":\"ok\"}";
            // When
            EntityArrayApiResponse<Teacher> parsedEntities =
                JsonProcessor.GetObjectFromStream<EntityArrayApiResponse<Teacher>>(
                    new MemoryStream(Encoding.UTF8.GetBytes(teacherArrayJsonResult)));

            // Then
            parsedEntities.Should().NotBeNull();
            parsedEntities.Result.Should().NotBeNull();
            parsedEntities.Result.Elements.Should().NotBeNullOrEmpty();
            parsedEntities.Result.Elements.Should().HaveCount(4);
            parsedEntities.Result.Elements.Should().Contain(x => x.Id == 1 && x.Degree == "A" && x.DepartmentId == 1 && x.FirstName == "A" && x.LastName == "A");
            parsedEntities.Result.Elements.Should().Contain(x => x.Id == 2 && x.Degree == "B" && x.DepartmentId == 2 && x.FirstName == "B" && x.LastName == "B");
            parsedEntities.Result.Elements.Should().Contain(x => x.Id == 3 && x.Degree == "C" && x.DepartmentId == 3 && x.FirstName == "C" && x.LastName == "C");
            parsedEntities.Result.Elements.Should().Contain(x => x.Id == 4 && x.Degree == "D" && x.DepartmentId == 4 && x.FirstName == "D" && x.LastName == "D");
        }

        [TestCase(TestName = "JsonProcessor should deserialize teacher correctly")]
        public void ShouldDeserializeTeacherCorrectly()
        {
            // Given
            string teacherArrayJsonResult =
                "{\"result\":{\"degree\":\"A\",\"department_id\":1,\"first_name\":\"A\",\"id\":1,\"last_name\":\"A\"},\"status\":\"ok\"}";
            // When
            EntityApiResponse<Teacher> parsedEntities =
                JsonProcessor.GetObjectFromStream<EntityApiResponse<Teacher>>(
                    new MemoryStream(Encoding.UTF8.GetBytes(teacherArrayJsonResult)));

            // Then
            parsedEntities.Should().NotBeNull();
            parsedEntities.Result.Should().NotBeNull();
            parsedEntities.Result.Id.Should().Be(1);
            parsedEntities.Result.Degree.Should().Be("A");
            parsedEntities.Result.DepartmentId.Should().Be(1);
            parsedEntities.Result.FirstName.Should().Be("A");
            parsedEntities.Result.LastName.Should().Be("A");
        }

        [TestCase(TestName = "JsonProcessor should serialize int array request correctly")]
        public void ShouldSerializeIntArrayProperly()
        {
            // Given
            int[] ids = { 1, 2, 3, 4, 5 };

            // When
            string result = JsonProcessor.GetStringFromObject(new IntArrayRequest(ids));

            // Then
            result.Should().NotBeNullOrWhiteSpace();
        }

        [TestCase(TestName = "JsonProcessor should serialize int request correctly")]
        public void ShouldSerializeIntProperly()
        {
            // Given
            int id = 1;

            // When
            string result = JsonProcessor.GetStringFromObject(new IntRequest(id));

            // Then
            result.Should().NotBeNullOrWhiteSpace();
        }

        [TestCase(TestName = "JsonProcessor should deserialize room array correctly")]
        public void ShouldDeserializeRoomArrayCorrectly()
        {
            // Given
            string roomArrayJsonResult =
                "{\"result\":{\"array\":[{\"department_id\":1,\"id\":1,\"name\":\"A\",\"quanitiy\":1},{\"department_id\":2,\"id\":2,\"name\":\"B\",\"quanitiy\":2},{\"department_id\":3,\"id\":3,\"name\":\"C\",\"quanitiy\":3}],\"count\":3},\"status\":\"ok\"}";
            // When
            EntityArrayApiResponse<Room> parsedEntities =
                JsonProcessor.GetObjectFromStream<EntityArrayApiResponse<Room>>(
                    new MemoryStream(Encoding.UTF8.GetBytes(roomArrayJsonResult)));

            // Then
            parsedEntities.Should().NotBeNull();
            parsedEntities.Result.Should().NotBeNull();
            parsedEntities.Result.Elements.Should().NotBeNullOrEmpty();
            parsedEntities.Result.Elements.Should().HaveCount(3);
            parsedEntities.Result.Elements.Should().Contain(x => x.Id == 1 && x.Name == "A" && x.Capacity == 1 && x.DepartmentId == 1);
            parsedEntities.Result.Elements.Should().Contain(x => x.Id == 2 && x.Name == "B" && x.Capacity == 2 && x.DepartmentId == 2);
            parsedEntities.Result.Elements.Should().Contain(x => x.Id == 3 && x.Name == "C" && x.Capacity == 3 && x.DepartmentId == 3);
        }

        [TestCase(TestName = "JsonProcessor should deserialize room correctly")]
        public void ShouldDeserializeRoomCorrectly()
        {
            // Given
            string teacherArrayJsonResult =
                "{\"result\":{\"department_id\":1,\"id\":1,\"name\":\"A\",\"quanitiy\":1},\"status\":\"ok\"}";
            // When
            EntityApiResponse<Room> parsedEntities =
                JsonProcessor.GetObjectFromStream<EntityApiResponse<Room>>(
                    new MemoryStream(Encoding.UTF8.GetBytes(teacherArrayJsonResult)));

            // Then
            parsedEntities.Should().NotBeNull();
            parsedEntities.Result.Should().NotBeNull();
            parsedEntities.Result.Id.Should().Be(1);
            parsedEntities.Result.Name.Should().Be("A");
            parsedEntities.Result.DepartmentId.Should().Be(1);
            parsedEntities.Result.Capacity.Should().Be(1);
        }

        // TODO: test against error jsons
    }
}