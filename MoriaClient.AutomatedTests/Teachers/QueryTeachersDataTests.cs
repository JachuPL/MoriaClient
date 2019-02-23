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
                new ClientConfiguration("http://moria.umcs.lublin.pl/api/", "teacher_list", "teacher");
            IQueryTeachersData query = new QueryTeachersData(configuration);

            var result = await query.Get(1575);
            Console.WriteLine($"{result.Id}\t{result.Degree} {result.FirstName} {result.LastName}");
        }
    }
}