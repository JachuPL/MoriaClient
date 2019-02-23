using MoriaClient.Common;
using MoriaClient.Common.Configuration;
using MoriaClient.Common.Models.Request;
using MoriaClient.Common.Models.Response;
using MoriaClient.Courses.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace MoriaClient.Courses
{
    internal sealed class QueryCoursesData : IQueryCoursesData
    {
        private readonly ClientConfiguration _configuration;

        public QueryCoursesData(ClientConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<IEnumerable<Course>> GetAll()
        {
            EntityArrayApiResponse<Course> apiResponse = await QueryCourseArray();
            return apiResponse.Result.Elements;
        }

        private async Task<EntityArrayApiResponse<Course>> QueryCourseArray(params int[] ids)
        {
            Uri courseListUri = new Uri(_configuration.BaseApiUri, _configuration.Endpoints[EndpointType.CourseList]);

            string jsonBody = string.Empty;

            if (ids.Length > 0)
            {
                jsonBody = JsonProcessor.GetStringFromObject(new IntArrayRequest(ids));
            }

            HttpResponseMessage responseMessage = await RequestMaker.GetResource(courseListUri, jsonBody);
            EntityArrayApiResponse<Course> apiResponse =
                JsonProcessor.GetObjectFromStream<EntityArrayApiResponse<Course>>(
                    await responseMessage.Content.ReadAsStreamAsync());

            ValidateArrayResponse(apiResponse);

            return apiResponse;
        }

        private static void ValidateArrayResponse(EntityArrayApiResponse<Course> apiResponse)
        {
            if (apiResponse?.Status.ToLower() != "ok")
            {
                throw new InvalidOperationException(apiResponse?.Error);
            }

            if (apiResponse.Result is null)
            {
                throw new InvalidCastException(
                    "Something wrong happened, server sent response that does not match predefined structure. Notify me about this bug by creating an issue at project page on GitHub.");
            }
        }

        public async Task<IEnumerable<Course>> GetWithId(params int[] idList)
        {
            EntityArrayApiResponse<Course> apiResponse = await QueryCourseArray(idList);
            return apiResponse.Result.Elements;
        }

        public async Task<Course> Get(int id)
        {
            Uri courseUri = new Uri(_configuration.BaseApiUri, _configuration.Endpoints[EndpointType.Course]);

            string jsonBody = JsonProcessor.GetStringFromObject(new IntRequest(id));

            HttpResponseMessage responseMessage = await RequestMaker.GetResource(courseUri, jsonBody);
            EntityApiResponse<Course> apiResponse =
                JsonProcessor.GetObjectFromStream<EntityApiResponse<Course>>(await responseMessage.Content
                    .ReadAsStreamAsync());

            ValidateResponse(apiResponse);

            return apiResponse.Result;
        }

        private static void ValidateResponse(EntityApiResponse<Course> apiResponse)
        {
            if (apiResponse?.Status.ToLower() != "ok")
            {
                throw new InvalidOperationException(apiResponse?.Error);
            }

            if (apiResponse.Result is null)
            {
                throw new InvalidCastException(
                    "Something wrong happened, server sent response that does not match predefined structure. Notify me about this bug by creating an issue at project page on GitHub.");
            }
        }
    }
}