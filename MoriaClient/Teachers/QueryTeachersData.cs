using MoriaClient.Common;
using MoriaClient.Common.Models;
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
        private readonly HttpClientFactory _clientFactory;

        internal QueryTeachersData(ClientConfiguration configuration)
        {
            _configuration = configuration;
            _clientFactory = new HttpClientFactory(configuration.BaseApiUri);
        }

        public async Task<IEnumerable<Teacher>> GetAll()
        {
            using (HttpClient client = _clientFactory.CreateClient())
            {
                Uri teacherListUri = new Uri(_configuration.BaseApiUri,
                    _configuration.TeacherListEndpoint);
                using (Stream responseStream = await client.GetStreamAsync(teacherListUri))
                {
                    DataContractJsonSerializer jsonSerializer =
                        new DataContractJsonSerializer(typeof(EntityArrayApiResponse<Teacher>));
                    EntityArrayApiResponse<Teacher> apiResponse =
                        jsonSerializer.ReadObject(responseStream) as EntityArrayApiResponse<Teacher>;
                    if (apiResponse?.Result is null)
                    {
                        throw new Exception(
                            "Something wrong happened, server sent response that does not match predefined structure. Notify me about this bug by creating an issue at project page on GitHub.");
                    }

                    if (apiResponse.Status.ToLower() != "ok")
                    {
                        throw new InvalidOperationException(apiResponse.Error);
                    }

                    return apiResponse.Result.Elements;
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