using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Common
{
    public interface IHttpHandler : IDisposable
    {
        Uri BaseAddress { get; set; }
        void AddHeader(string key, string value);
        Task<HttpResponseMessage> GetAsync(Uri uri);
        Task<HttpResponseMessage> PostAsync(Uri uri, HttpContent content);
    }
}