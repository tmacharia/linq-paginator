using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Common
{
    public class HttpHandler : IBaseInterface, IHttpHandler
    {
        private HttpClient _client;
        public HttpHandler()
        {
            _client = new HttpClient();
        }
        public HttpHandler(HttpClientHandler clientHandler)
        {
            if (clientHandler.IsNull())
                throw new ArgumentNullException(nameof(clientHandler));

            _client = new HttpClient(clientHandler);
        }

        public Uri BaseAddress
        {
            get
            {
                return _client.BaseAddress;
            }
            set
            {
                _client.BaseAddress = value;
            }
        }

        public void AddHeader(string key, string value)
        {
            _client.DefaultRequestHeaders.Add(key, value);
        }
        public Task<HttpResponseMessage> GetAsync(Uri uri)
        {
            return _client.GetAsync(uri);
        }

        public Task<HttpResponseMessage> PostAsync(Uri uri, HttpContent content)
        {
            return _client.PostAsync(uri, content);
        }

        protected override void Dispose(bool isDisposing)
        {
            if (isDisposing)
            {
                base.DisposeItem(ref _client);
            }
        }
    }
}
