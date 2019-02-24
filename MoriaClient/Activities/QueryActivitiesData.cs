using MoriaClient.Activities.Models;
using MoriaClient.Common;
using MoriaClient.Common.Configuration;
using MoriaClient.Common.Models.Request;
using MoriaClient.Common.Models.Response;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace MoriaClient.Activities
{
    internal sealed class QueryActivitiesData : IQueryActivitiesData
    {
        private readonly ClientConfiguration _configuration;

        public QueryActivitiesData(ClientConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<Activity> Get(int id)
        {
            Uri activityUri = new Uri(_configuration.BaseApiUri, _configuration.Endpoints[EndpointType.Activity]);

            string jsonBody = JsonProcessor.GetStringFromObject(new IntRequest(id));

            HttpResponseMessage responseMessage = await RequestMaker.GetResource(activityUri, jsonBody);
            EntityApiResponse<Activity> apiResponse =
                JsonProcessor.GetObjectFromStream<EntityApiResponse<Activity>>(
                    await responseMessage.Content.ReadAsStreamAsync());

            ValidateResponse(apiResponse);

            return apiResponse.Result;
        }

        private void ValidateResponse(EntityApiResponse<Activity> apiResponse)
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

        public async Task<IEnumerable<Activity>> GetByRoom(int roomId)
        {
            EntityArrayApiResponse<Activity> apiResponse = await QueryActivityArray(EndpointType.ActivitiesByRoom, roomId);
            return apiResponse.Result.Elements;
        }

        private async Task<EntityArrayApiResponse<Activity>> QueryActivityArray(EndpointType type, int id)
        {
            Uri activityListUri = new Uri(_configuration.BaseApiUri, _configuration.Endpoints[type]);

            string jsonBody = JsonProcessor.GetStringFromObject(new IntRequest(id));

            HttpResponseMessage responseMessage = await RequestMaker.GetResource(activityListUri, jsonBody);
            EntityArrayApiResponse<Activity> apiResponse =
                JsonProcessor.GetObjectFromStream<EntityArrayApiResponse<Activity>>(
                    await responseMessage.Content.ReadAsStreamAsync());

            ValidateArrayResponse(apiResponse);

            return apiResponse;
        }

        private static void ValidateArrayResponse(EntityArrayApiResponse<Activity> apiResponse)
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

        public async Task<IEnumerable<Activity>> GetByCourse(int courseId)
        {
            EntityArrayApiResponse<Activity> apiResponse = await QueryActivityArray(EndpointType.ActivitiesByCourse, courseId);
            return apiResponse.Result.Elements;
        }

        public async Task<IEnumerable<Activity>> GetByTeacher(int teacherId)
        {
            EntityArrayApiResponse<Activity> apiResponse = await QueryActivityArray(EndpointType.ActivitiesByTeacher, teacherId);
            return apiResponse.Result.Elements;
        }
    }
}