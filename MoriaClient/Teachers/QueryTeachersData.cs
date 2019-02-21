using MoriaClient.Teachers.Models;
using System;
using System.Collections.Generic;
using System.Net;

namespace MoriaClient.Teachers
{
    internal class QueryTeachersData : IQueryTeachersData
    {
        private readonly WebClient _client;

        internal QueryTeachersData(WebClient client)
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