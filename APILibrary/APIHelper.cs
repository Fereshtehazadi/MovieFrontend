using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace APILibrary
{
    public static class APIHelper
    {
        public static HttpClient ApiClient  { get; set; }

        public static void InitializeClient()
        {
            ApiClient = new HttpClient();
            ApiClient.BaseAddress = new Uri("https://localhost:44378/api/"); // Address till backend
            ApiClient.DefaultRequestHeaders.Accept.Clear();
            ApiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

    }
}
