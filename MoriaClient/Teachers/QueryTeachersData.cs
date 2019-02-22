using MoriaClient.Teachers.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;

namespace MoriaClient.Teachers
{
    internal class QueryTeachersData : IQueryTeachersData
    {
        private readonly HttpClient _client;

        internal QueryTeachersData(HttpClient client)
        {
            _client = client;
        }

        public IEnumerable<Teacher> GetAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Teacher> GetWithId(params int[] idList)
        {
            throw new NotImplementedException();
        }

        public Teacher Get(int id)
        {
            throw new NotImplementedException();
        }
    }
}