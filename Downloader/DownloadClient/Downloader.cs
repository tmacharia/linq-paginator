using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Common;
using static System.Environment;

namespace DownloadClient
{
    public class Downloader : IDownloader
    {
        private readonly HttpClient _client;
        public Downloader()
        {
            _client = new HttpClient();
        }

        public event DownloadEventHandler OnDownloading;
        public event DownloadCompletedEventHandler DownloadCompleted;
        public event DownloadErrorEventHandler OnError;

        public byte[] Download(Uri uri)
        {
            return _downloadAsync(uri).Result;
        }

        public byte[] Download(string url)
        {
            return _downloadAsync(new Uri(url)).Result;
        }

        public Task<byte[]> DownloadAsync(Uri uri)
        {
            return _downloadAsync(uri);
        }

        public Task<byte[]> DownloadAsync(string url)
        {
            return _downloadAsync(new Uri(url));
        }
        public async void DownloadToFile(string url)
        {
            var a = await _downloadAsync(new Uri(url), true);
        }

        public async void DownloadToFile(string url, string filename)
        {
            var a = await _downloadAsync(new Uri(url), true, filename);
        }

        public async void DownloadToFile(Uri uri)
        {
            var a = await _downloadAsync(uri,true);
        }

        public async void DownloadToFile(Uri uri, string filename)
        {
            var a = await _downloadAsync(uri, true, filename);
        }


        internal async Task<byte[]> _downloadAsync(Uri uri, bool saveToDisk=false, string filename=null)
        {
            byte[] vs = new byte[0];
            try
            {
                HttpResponseMessage httpResponse = await _client.GetAsync(uri, HttpCompletionOption.ResponseHeadersRead);

                if (httpResponse.IsSuccessStatusCode)
                {
                    long length = httpResponse.Content.Headers.ContentLength.Value;
                    /*__________________________________________________________________________________
                      |                                                                                |
                      |  .NET runtime has a 2GB size limit for objects.                                |
                      |  ----------------------------------------------                                |
                      |  To adhere to this restriction, this module ONLY allows downloading files      |
                      |  less than 1GB. If the file is greater than 1GB, call DownloadToFile method    |
                      |  instead which downloads the file directly to disk or allow this application   |
                      |  to automatically save the file to disk for you.                               |
                      |  ----------------------------------------------                                |
                      |  1 GB = 1,000,000,000 (1 Billion Bytes).                                       |
                      |                                                                                |
                     *|________________________________________________________________________________|*/
                      
                    long GB_bytes_size = 1000000000;

                    vs = (length >= GB_bytes_size || saveToDisk) ?
                        await _readHttpResponseStreamAsync(httpResponse, length, true, filename) :
                        await _readHttpResponseStreamAsync(httpResponse, length, saveToDisk);
                }
                else
                {
                    OnError(new Exception("An error occured. Http request responded with a non 200-OK StatusCode.",
                        new HttpRequestException(httpResponse.ReasonPhrase)));
                }
            }
            catch (Exception ex)
            {
                OnError(new Exception("Download operation failed & threw an exception. " +
                    "See inner exception for further details.", ex));
            }
            return vs;
        }

        internal async Task<byte[]> _readHttpResponseStreamAsync(HttpResponseMessage httpResponse, long length, bool saveToFile=false, string filename=null)
        {
            return await Task.Run(async () =>
            {
                using (StreamReader sr = new StreamReader(await httpResponse.Content.ReadAsStreamAsync().ConfigureAwait(false)))
                {
                    DownloadMetric metric = new DownloadMetric(length);
                    Stopwatch stopwatch = new Stopwatch();
                    stopwatch.Start();

                    if(!saveToFile)
                        return _fromReaderToStream(sr, new MemoryStream((int)length), ref metric, ref stopwatch, ref length);
                    else
                    {
                        filename = _toRelativeFilePath(httpResponse.RequestMessage.RequestUri,filename);

                        return _fromReaderToStream(sr, File.Open(filename, FileMode.OpenOrCreate, FileAccess.ReadWrite), 
                            ref metric, ref stopwatch, ref length);
                    }
                }
            }).ConfigureAwait(false);
        }

        internal byte[] _fromReaderToStream(StreamReader sr, Stream stream,
            ref DownloadMetric metric, ref Stopwatch stopwatch, ref long length)
        {
            var buffer = new byte[1024];
            var bytesRead = default(int);
            while ((bytesRead = sr.BaseStream.Read(buffer, 0, buffer.Length)) > 0)
            {
                stream.Write(buffer, 0, bytesRead);
                metric.DownloadedBytes += bytesRead;
                metric.ElapsedTime = stopwatch.Elapsed;

                OnDownloading(metric);
            }
            stopwatch.Stop();
            stopwatch.Reset();
            DownloadCompleted(metric);
            
            if(stream is MemoryStream) {
                return ((MemoryStream)stream).ToArray();
            }else {
                stream.Flush();
                stream.Close();
                stream.Dispose();
                return null;
            }
        }

        internal string _toRelativeFilePath(Uri uri, string filename = null)
        {
            string folder = @"G:\cmb\Sicflics\part 14\";
            string path = string.Empty;

            if (filename.IsValid())
            {
                /* First, check if file extensions match. If they don't, replace
                 * the file extension supplied by the user with the extension from
                 * the uri.
                 * 
                 ***************************************/
                string uri_ext = uri.OriginalString.Split('.').Last();
                string file_ext = filename.Split('.').Last();

                if (!file_ext.Equals(uri_ext))
                    filename = filename.Replace(file_ext, uri_ext);

                if(new Uri(filename).IsAbsoluteUri)
                {
                    path = Path.Combine(folder, filename);
                }
                else
                {
                    path = filename;
                }
            }
            else
            {
                filename = uri.LocalPath.Split('/').Last();
                filename = FileExts.ToSafeFileName(filename);
                path = Path.Combine(folder, filename);
            }

            /* Creates all directories and sub-directories in the specified path
             * unless they already exist.
             * 
             *****************************************/
            if (!Directory.Exists(folder))
                Directory.CreateDirectory(folder);

            return path;
        }
    }
}
