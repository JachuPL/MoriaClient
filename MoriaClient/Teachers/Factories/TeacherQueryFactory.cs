using MoriaClient.Common;

namespace MoriaClient.Teachers.Factories
{
    public static class TeacherQueryFactory
    {
        public static IQueryTeachersData CreateQuery() => new QueryTeachersData(WebClientFactory.CreateClient());
    }
}