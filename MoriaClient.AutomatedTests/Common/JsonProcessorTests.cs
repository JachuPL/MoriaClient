using FluentAssertions;
using MoriaClient.Activities.Models;
using MoriaClient.Common;
using MoriaClient.Common.Models.Request;
using MoriaClient.Common.Models.Response;
using MoriaClient.Courses.Models;
using MoriaClient.Rooms.Models;
using MoriaClient.Teachers.Models;
using NUnit.Framework;
using System.IO;
using System.Linq;
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
            string teacherArrayResultJson =
                "{\"result\":{\"array\":[{\"degree\":\"A\",\"department_id\":1,\"first_name\":\"A\",\"id\":1,\"last_name\":\"A\"},{\"degree\":\"B\",\"department_id\":2,\"first_name\":\"B\",\"id\":2,\"last_name\":\"B\"},{\"degree\":\"C\",\"department_id\":3,\"first_name\":\"C\",\"id\":3,\"last_name\":\"C\"},{\"degree\":\"D\",\"department_id\":4,\"first_name\":\"D\",\"id\":4,\"last_name\":\"D\"}],\"count\":4},\"status\":\"ok\"}";
            // When
            EntityArrayApiResponse<Teacher> parsedEntities =
                JsonProcessor.GetObjectFromStream<EntityArrayApiResponse<Teacher>>(
                    new MemoryStream(Encoding.UTF8.GetBytes(teacherArrayResultJson)));

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
            string teacherResultJson =
                "{\"result\":{\"degree\":\"A\",\"department_id\":1,\"first_name\":\"A\",\"id\":1,\"last_name\":\"A\"},\"status\":\"ok\"}";
            // When
            EntityApiResponse<Teacher> parsedEntities =
                JsonProcessor.GetObjectFromStream<EntityApiResponse<Teacher>>(
                    new MemoryStream(Encoding.UTF8.GetBytes(teacherResultJson)));

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
            string romArrayResultJson =
                "{\"result\":{\"array\":[{\"department_id\":1,\"id\":1,\"name\":\"A\",\"quanitiy\":1},{\"department_id\":2,\"id\":2,\"name\":\"B\",\"quanitiy\":2},{\"department_id\":3,\"id\":3,\"name\":\"C\",\"quanitiy\":3}],\"count\":3},\"status\":\"ok\"}";
            // When
            EntityArrayApiResponse<Room> parsedEntities =
                JsonProcessor.GetObjectFromStream<EntityArrayApiResponse<Room>>(
                    new MemoryStream(Encoding.UTF8.GetBytes(romArrayResultJson)));

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
            string roomResultJson =
                "{\"result\":{\"department_id\":1,\"id\":1,\"name\":\"A\",\"quanitiy\":1},\"status\":\"ok\"}";
            // When
            EntityApiResponse<Room> parsedEntities =
                JsonProcessor.GetObjectFromStream<EntityApiResponse<Room>>(
                    new MemoryStream(Encoding.UTF8.GetBytes(roomResultJson)));

            // Then
            parsedEntities.Should().NotBeNull();
            parsedEntities.Result.Should().NotBeNull();
            parsedEntities.Result.Id.Should().Be(1);
            parsedEntities.Result.Name.Should().Be("A");
            parsedEntities.Result.DepartmentId.Should().Be(1);
            parsedEntities.Result.Capacity.Should().Be(1);
        }

        [TestCase(TestName = "JsonProcessor should deserialize course array correctly")]
        public void ShouldDeserializeCourseArrayCorrectly()
        {
            // Given
            string courseArrayResultJson =
                "{\"result\":{\"array\":[{\"id\":1,\"name\":\"A\"},{\"id\":2,\"name\":\"B\"},{\"id\":3,\"name\":\"C\"}],\"count\":3},\"status\":\"ok\"}";
            // When
            EntityArrayApiResponse<Course> parsedEntities =
                JsonProcessor.GetObjectFromStream<EntityArrayApiResponse<Course>>(
                    new MemoryStream(Encoding.UTF8.GetBytes(courseArrayResultJson)));

            // Then
            parsedEntities.Should().NotBeNull();
            parsedEntities.Result.Should().NotBeNull();
            parsedEntities.Result.Elements.Should().NotBeNullOrEmpty();
            parsedEntities.Result.Elements.Should().HaveCount(3);
            parsedEntities.Result.Elements.Should().Contain(x => x.Id == 1 && x.Name == "A");
            parsedEntities.Result.Elements.Should().Contain(x => x.Id == 2 && x.Name == "B");
            parsedEntities.Result.Elements.Should().Contain(x => x.Id == 3 && x.Name == "C");
        }

        [TestCase(TestName = "JsonProcessor should deserialize course correctly")]
        public void ShouldDeserializeCourseCorrectly()
        {
            // Given
            string courseResultJson =
                "{\"result\":{\"id\":1,\"name\":\"A\"},\"status\":\"ok\"}";
            // When
            EntityApiResponse<Course> parsedEntities =
                JsonProcessor.GetObjectFromStream<EntityApiResponse<Course>>(
                    new MemoryStream(Encoding.UTF8.GetBytes(courseResultJson)));

            // Then
            parsedEntities.Should().NotBeNull();
            parsedEntities.Result.Should().NotBeNull();
            parsedEntities.Result.Id.Should().Be(1);
            parsedEntities.Result.Name.Should().Be("A");
        }

        [TestCase(TestName = "JsonProcessor should deserialize activity array correctly")]
        public void ShouldDeserializeActivityArrayCorrectly()
        {
            // Given
            string activityArrayResultJson =
                "{\"result\":{\"array\":[{\"event_array\":[{\"break_length\":\"01:01\",\"end_time\":\"01:01\",\"id\":1,\"length\":\"01:01\",\"room\":\"A\",\"room_id\":1,\"start_time\":\"01:01\",\"weekday\":1}],\"event_count\":1,\"id\":1,\"students_array\":[{\"group\":\"1\",\"groups\":\"2\",\"id\":1,\"name\":\"A\"}],\"students_count\":1,\"subject\":\"A\",\"subject_id\":1,\"teacher_array\":[{\"id\":1,\"name\":\"A\"}],\"teacher_count\":1},{\"event_array\":[{\"break_length\":\"02:02\",\"end_time\":\"02:02\",\"id\":2,\"length\":\"02:02\",\"room\":\"B\",\"room_id\":2,\"start_time\":\"02:02\",\"weekday\":2}],\"event_count\":1,\"id\":2,\"students_array\":[{\"group\":\"1\",\"groups\":\"2\",\"id\":2,\"name\":\"B\"}],\"students_count\":1,\"subject\":\"B\",\"subject_id\":2,\"teacher_array\":[{\"id\":2,\"name\":\"B\"}],\"teacher_count\":1},{\"event_array\":[{\"break_length\":\"03:03\",\"end_time\":\"03:03\",\"id\":3,\"length\":\"03:03\",\"room\":\"C\",\"room_id\":3,\"start_time\":\"03:03\",\"weekday\":3}],\"event_count\":1,\"id\":3,\"students_array\":[{\"group\":\"1\",\"groups\":\"2\",\"id\":3,\"name\":\"C\"}],\"students_count\":1,\"subject\":\"C\",\"subject_id\":3,\"teacher_array\":[{\"id\":3,\"name\":\"C\"}],\"teacher_count\":1}],\"count\":3},\"status\":\"ok\"}";

            // When
            EntityArrayApiResponse<Activity> parsedEntities =
                JsonProcessor.GetObjectFromStream<EntityArrayApiResponse<Activity>>(
                    new MemoryStream(Encoding.UTF8.GetBytes(activityArrayResultJson)));

            // Then
            parsedEntities.Should().NotBeNull();
            parsedEntities.Result.Should().NotBeNull();
            parsedEntities.Result.Elements.Should().NotBeNullOrEmpty();
            parsedEntities.Result.Elements.Should().HaveCount(3);
            // First activity
            Activity activity = parsedEntities.Result.Elements.SingleOrDefault(x => x.Id == 1);
            activity.Should().NotBeNull();
            activity.Id.Should().Be(1);
            activity.Subject.Should().Be("A");
            activity.SubjectId.Should().Be(1);
            activity.Teachers.Should().Contain(z => z.Name == "A" && z.Id == 1);
            activity.CourseGroups.Should().Contain(z => z.GroupId == 1
                                                        && z.Id == 1
                                                        && z.Name == "A"
                                                        && z.TotalGroups == 2);
            activity.Events.Should().Contain(z => z.BreakLength == "01:01"
                                                  && z.Day == WeekDay.Monday
                                                  && z.Duration == "01:01"
                                                  && z.Ends == "01:01"
                                                  && z.Id == 1
                                                  && z.RoomId == 1 && z.RoomName == "A"
                                                  && z.Start == "01:01");
            // Second activity
            activity = parsedEntities.Result.Elements.SingleOrDefault(x => x.Id == 2);
            activity.Should().NotBeNull();
            activity.Id.Should().Be(2);
            activity.Subject.Should().Be("B");
            activity.SubjectId.Should().Be(2);
            activity.Teachers.Should().Contain(z => z.Name == "B" && z.Id == 2);
            activity.CourseGroups.Should().Contain(z => z.GroupId == 1
                                                        && z.Id == 2
                                                        && z.Name == "B"
                                                        && z.TotalGroups == 2);
            activity.Events.Should().Contain(z => z.BreakLength == "02:02"
                                                  && z.Day == WeekDay.Tuesday
                                                  && z.Duration == "02:02"
                                                  && z.Ends == "02:02"
                                                  && z.Id == 2
                                                  && z.RoomId == 2 && z.RoomName == "B"
                                                  && z.Start == "02:02");
            // Third activity
            activity = parsedEntities.Result.Elements.SingleOrDefault(x => x.Id == 3);
            activity.Should().NotBeNull();
            activity.Id.Should().Be(3);
            activity.Subject.Should().Be("C");
            activity.SubjectId.Should().Be(3);
            activity.Teachers.Should().Contain(z => z.Name == "C" && z.Id == 3);
            activity.CourseGroups.Should().Contain(z => z.GroupId == 1
                                                        && z.Id == 3
                                                        && z.Name == "C"
                                                        && z.TotalGroups == 2);
            activity.Events.Should().Contain(z => z.BreakLength == "03:03"
                                                  && z.Day == WeekDay.Wednesday
                                                  && z.Duration == "03:03"
                                                  && z.Ends == "03:03"
                                                  && z.Id == 3
                                                  && z.RoomId == 3 && z.RoomName == "C"
                                                  && z.Start == "03:03");
        }

        [TestCase(TestName = "JsonProcessor should deserialize activity correctly")]
        public void ShouldDeserializeActivityCorrectly()
        {
            // Given
            string courseResultJson =
                "{\"result\":{\"event_array\":[{\"break_length\":\"00:30\",\"end_time\":\"15:50\",\"id\":1,\"length\":\"01:30\",\"room\":\"A\",\"room_id\":1,\"start_time\":\"14:20\",\"weekday\":1}],\"event_count\":1,\"id\":1,\"students_array\":[{\"group\":\"1\",\"groups\":\"2\",\"id\":1,\"name\":\"A\"}],\"students_count\":1,\"subject\":\"A\",\"subject_id\":1,\"teacher_array\":[{\"id\":1,\"name\":\"A\"}],\"teacher_count\":1},\"status\":\"ok\"}";
            // When
            EntityApiResponse<Activity> parsedEntities =
                JsonProcessor.GetObjectFromStream<EntityApiResponse<Activity>>(
                    new MemoryStream(Encoding.UTF8.GetBytes(courseResultJson)));

            // Then
            parsedEntities.Should().NotBeNull();
            parsedEntities.Result.Should().NotBeNull();
            parsedEntities.Result.Id.Should().Be(1);
            parsedEntities.Result.Subject.Should().Be("A");
            parsedEntities.Result.SubjectId.Should().Be(1);
            parsedEntities.Result.Teachers.Should().Contain(z => z.Name == "A" && z.Id == 1);
            parsedEntities.Result.CourseGroups.Should().Contain(z => z.GroupId == 1
                                                        && z.Id == 1
                                                        && z.Name == "A"
                                                        && z.TotalGroups == 2);
            parsedEntities.Result.Events.Should().Contain(z => z.BreakLength == "00:30"
                                                  && z.Day == WeekDay.Monday
                                                  && z.Duration == "01:30"
                                                  && z.Ends == "15:50"
                                                  && z.Id == 1
                                                  && z.RoomId == 1 && z.RoomName == "A"
                                                  && z.Start == "14:20");
        }

        // TODO: test against error jsons
    }
}