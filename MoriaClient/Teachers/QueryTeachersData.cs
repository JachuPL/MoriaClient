using MoriaClient.Common;
using MoriaClient.Common.Models.Request;
using MoriaClient.Common.Models.Response;
using MoriaClient.Configuration;
using MoriaClient.Teachers.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
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
            EntityArrayApiResponse<Teacher> apiResponse = await QueryTeacherArray();
            return apiResponse.Result.Elements;
        }

        private async Task<EntityArrayApiResponse<Teacher>> QueryTeacherArray(params int[] ids)
        {
            Uri teacherListUri = new Uri(_configuration.BaseApiUri, _configuration.TeacherListEndpoint);

            string jsonBody = string.Empty;

            if (ids.Length > 0)
            {
                jsonBody = JsonProcessor.GetStringFromObject(new IntArrayRequest(ids));
            }

            HttpResponseMessage responseMessage = await RequestMaker.GetResource(teacherListUri, jsonBody);
            EntityArrayApiResponse<Teacher> apiResponse =
                JsonProcessor.GetObjectFromStream<EntityArrayApiResponse<Teacher>>(
                    await responseMessage.Content.ReadAsStreamAsync());

            ValidateArrayResponse(apiResponse);

            return apiResponse;
        }

        private void ValidateArrayResponse(EntityArrayApiResponse<Teacher> apiResponse)
        {
            if (apiResponse?.Result is null)
            {
                throw new Exception(
                    "Something wrong happened, server sent response that does not match predefined structure. Notify me about this bug by creating an issue at project page on GitHub.");
            }

            if (apiResponse.Status.ToLower() != "ok")
            {
                throw new InvalidOperationException(apiResponse.Error);
            }
        }

        public async Task<IEnumerable<Teacher>> GetWithId(params int[] idList)
        {
            var apiResponse = await QueryTeacherArray(idList);
            return apiResponse.Result.Elements;
        }

        public async Task<Teacher> Get(int id)
        {
            throw new NotImplementedException();
        }
    }
}