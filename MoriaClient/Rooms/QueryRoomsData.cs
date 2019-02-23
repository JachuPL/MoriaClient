using MoriaClient.Common;
using MoriaClient.Common.Configuration;
using MoriaClient.Common.Models.Request;
using MoriaClient.Common.Models.Response;
using MoriaClient.Rooms.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace MoriaClient.Rooms
{
    internal sealed class QueryRoomsData : IQueryRoomsData
    {
        private readonly ClientConfiguration _configuration;

        public QueryRoomsData(ClientConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<IEnumerable<Room>> GetAll()
        {
            EntityArrayApiResponse<Room> apiResponse = await QueryRoomArray();
            return apiResponse.Result.Elements;
        }

        private async Task<EntityArrayApiResponse<Room>> QueryRoomArray(params int[] ids)
        {
            Uri roomListUri = new Uri(_configuration.BaseApiUri, _configuration.Endpoints[EndpointType.RoomList]);

            string jsonBody = string.Empty;

            if (ids.Length > 0)
            {
                jsonBody = JsonProcessor.GetStringFromObject(new IntArrayRequest(ids));
            }

            HttpResponseMessage responseMessage = await RequestMaker.GetResource(roomListUri, jsonBody);
            EntityArrayApiResponse<Room> apiResponse =
                JsonProcessor.GetObjectFromStream<EntityArrayApiResponse<Room>>(
                    await responseMessage.Content.ReadAsStreamAsync());

            ValidateArrayResponse(apiResponse);

            return apiResponse;
        }

        private static void ValidateArrayResponse(EntityArrayApiResponse<Room> apiResponse)
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

        public async Task<IEnumerable<Room>> GetWithId(params int[] idList)
        {
            EntityArrayApiResponse<Room> apiResponse = await QueryRoomArray(idList);
            return apiResponse.Result.Elements;
        }

        public async Task<Room> Get(int id)
        {
            Uri roomUri = new Uri(_configuration.BaseApiUri, _configuration.Endpoints[EndpointType.Room]);

            string jsonBody = JsonProcessor.GetStringFromObject(new IntRequest(id));

            HttpResponseMessage responseMessage = await RequestMaker.GetResource(roomUri, jsonBody);
            EntityApiResponse<Room> apiResponse =
                JsonProcessor.GetObjectFromStream<EntityApiResponse<Room>>(await responseMessage.Content
                    .ReadAsStreamAsync());

            ValidateResponse(apiResponse);

            return apiResponse.Result;
        }

        private static void ValidateResponse(EntityApiResponse<Room> apiResponse)
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