﻿using MoriaClient.Common;
using MoriaClient.Common.Configuration;
using MoriaClient.Common.Models.Request;
using MoriaClient.Common.Models.Response;
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

        internal QueryTeachersData(ClientConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<IEnumerable<Teacher>> GetAll()
        {
            EntityArrayApiResponse<Teacher> apiResponse = await QueryTeacherArray();
            return apiResponse.Result.Elements;
        }

        private async Task<EntityArrayApiResponse<Teacher>> QueryTeacherArray(params int[] ids)
        {
            Uri teacherListUri = new Uri(_configuration.BaseApiUri, _configuration.Endpoints[EndpointType.TeacherList]);

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

        private static void ValidateArrayResponse(EntityArrayApiResponse<Teacher> apiResponse)
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

        public async Task<IEnumerable<Teacher>> GetWithId(params int[] idList)
        {
            EntityArrayApiResponse<Teacher> apiResponse = await QueryTeacherArray(idList);
            return apiResponse.Result.Elements;
        }

        public async Task<Teacher> Get(int id)
        {
            Uri teacherUri = new Uri(_configuration.BaseApiUri, _configuration.Endpoints[EndpointType.Teacher]);

            string jsonBody = JsonProcessor.GetStringFromObject(new IntRequest(id));

            HttpResponseMessage responseMessage = await RequestMaker.GetResource(teacherUri, jsonBody);
            EntityApiResponse<Teacher> apiResponse =
                JsonProcessor.GetObjectFromStream<EntityApiResponse<Teacher>>(await responseMessage.Content
                    .ReadAsStreamAsync());

            ValidateResponse(apiResponse);

            return apiResponse.Result;
        }

        private static void ValidateResponse(EntityApiResponse<Teacher> apiResponse)
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