using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;
using Nest;

namespace Learning.Model
{
    public class Person
    {
        [JsonPropertyName("age")] public int Age { get; set; }

        [JsonPropertyName("eyeColor")] public string EyeColor { get; set; }

        [JsonPropertyName("name")] public string Name { get; set; }

        [JsonPropertyName("gender")] public string Gender { get; set; }

        [JsonPropertyName("company")] public string Company { get; set; }

        [JsonPropertyName("email")] public string Email { get; set; }

        [JsonPropertyName("phone")] public string Phone { get; set; }

        [JsonPropertyName("address")] public string Address { get; set; }

        [JsonPropertyName("about")] public string About { get; set; }

        [JsonPropertyName("registeration_date")]
        [JsonConverter(typeof(CustomDateFormat))]
        public DateTime RegistrationDate { get; set; }

        [Ignore]
        [JsonPropertyName("latitude")]
        public double Latitude { get; set; }

        [Ignore]
        [JsonPropertyName("longitude")]
        public double Longitude { get; set; }

        private string location = null;

        public string Location
        {
            get => location ?? $"{Latitude},{Longitude}"; //?? is null-coalescing operator
            set => location = value;
        }
    }
}