﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using static DeliveryRoomWatcher.Models.PaymongoModel;

namespace DeliveryRoomWatcher.Hooks
{
    public class UsePaymongoApi
    {
        public static async Task<PaymongoSourceResourceResponse> PaymongoFetch(string url, string key, dynamic payload)
        {
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Add("Authorization", $"Basic {key}");
            var content = new StringContent(JsonConvert.SerializeObject(payload), Encoding.UTF8, "application/json");
            var authenticationBytes = Encoding.ASCII.GetBytes($"{key}:");
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(authenticationBytes));
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var result = await httpClient.PostAsync(url, content);
            var result_string = result.Content.ReadAsStringAsync().Result;
            PaymongoSourceResourceResponse payment_resource_response = JsonConvert.DeserializeObject<PaymongoSourceResourceResponse>(result_string);
            return payment_resource_response;
        }
        public static async Task<PaymongoSourceResourceResponse> RetrieveSource(string url, string key,string source)
        {
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Add("Authorization", $"Basic {key}");

            var authenticationBytes = Encoding.ASCII.GetBytes($"{key}:");
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(authenticationBytes));
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var result = await httpClient.GetAsync($@"{url}/{source}");
            var result_string = result.Content.ReadAsStringAsync().Result;
            PaymongoSourceResourceResponse payment_resource_response = JsonConvert.DeserializeObject<PaymongoSourceResourceResponse>(result_string);
            //PaymongoSourceResourceResponse payment_resource_response = JsonConvert.DeserializeObject<PaymongoSourceResourceResponse>(JsonConvert.SerializeObject(result_string));
            return payment_resource_response;
        }
    }
}
