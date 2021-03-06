﻿using System.Runtime.Serialization;

namespace MoriaClient.Common.Models.Request
{
    [DataContract]
    internal class IntArrayRequest
    {
        [DataMember(Name = "id")]
        public int[] Ids { get; set; }

        public IntArrayRequest(int[] array)
        {
            Ids = array;
        }
    }
}