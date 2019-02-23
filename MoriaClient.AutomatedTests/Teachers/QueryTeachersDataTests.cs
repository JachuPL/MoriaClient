using MoriaClient.Configuration;
using MoriaClient.Teachers;
using NUnit.Framework;
using System;
using System.Threading.Tasks;

namespace MoriaClient.AutomatedTests.Teachers
{
    [TestFixture]
    public class QueryTeachersDataTests
    {
        [Test]
        public async Task Test()
        {
            ClientConfiguration configuration =
                new ClientConfiguration("http://moria.umcs.lublin.pl/api/", "teacher_list");
            IQueryTeachersData query = new QueryTeachersData(configuration);

            var result = await query.GetWithId(1575, 1488);
            foreach (var entity in result)
                Console.WriteLine($"{entity.Id}\t{entity.Degree} {entity.FirstName} {entity.LastName}");
        }
    }
}