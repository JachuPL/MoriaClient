using MoriaClient.Common;
using MoriaClient.Configuration;
using MoriaClient.Teachers.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Runtime.Serialization.Json;
using System.Threading.Tasks;

namespace MoriaClient.Teachers
{
    internal class QueryTeachersData : IQueryTeachersData
    {
        private readonly ClientConfiguration _configuration;

        internal QueryTeachersData(ClientConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<IEnumerable<Teacher>> GetAll()
        {
            using (HttpClient client = HttpClientFactory.CreateClient(_configuration))
            {
                Uri teacherListUri = new Uri(_configuration.ApiUri, _configuration.TeacherListEndpoint);
                using (Stream stream = await client.GetStreamAsync(teacherListUri))
                {
                    // TODO: use proper classes implementing response format
                    DataContractJsonSerializer jsonSerializer = new DataContractJsonSerializer(typeof(ICollection<Teacher>));
                    return (ICollection<Teacher>)jsonSerializer.ReadObject(stream);
                }
            }
        }

        public async Task<IEnumerable<Teacher>> GetWithId(params int[] idList)
        {
            throw new NotImplementedException();
        }

        public async Task<Teacher> Get(int id)
        {
            throw new NotImplementedException();
        }
    }
}