using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace Task2_StructuralPatterns_Client
{
    public class HttpOperatorApi : IOperatorApi
    {
        private readonly HttpClient _http;

        public HttpOperatorApi(string baseAddress)
        {
            _http = new HttpClient
            {
                BaseAddress = new Uri(baseAddress)
            };
        }

        public async Task<IEnumerable<SomeEntity>> GetManyAsync()
        {
            var result =
                await _http.GetFromJsonAsync<IEnumerable<SomeEntity>>("Operator/GetMany");

            return result ?? new List<SomeEntity>();
        }

        public async Task<SomeEntity> CreateAsync(SomeEntity entity)
        {
            var response = await _http.PostAsJsonAsync("Operator/Create", entity);
            response.EnsureSuccessStatusCode();

            var created = await response.Content.ReadFromJsonAsync<SomeEntity>();
            return created!;
        }
        public async Task<SomeEntity?> GetOneAsync(Guid id)
        {
            return await _http.GetFromJsonAsync<SomeEntity>($"Operator/GetOne/{id}");
        }
    }
}

