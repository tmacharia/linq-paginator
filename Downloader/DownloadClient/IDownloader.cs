using System;
using System.Threading.Tasks;

namespace DownloadClient
{
    public delegate void DownloadEventHandler(DownloadMetric e);
    public delegate void DownloadCompletedEventHandler(DownloadMetric d);
    public delegate void DownloadErrorEventHandler(Exception ex);

    public interface IDownloader
    {
        /// <summary>
        /// Event handler or function/method to call passing along a <see cref="DownloadMetric"/>
        /// for every time progress occurs during a download operation.
        /// </summary>
        event DownloadEventHandler OnDownloading;
        /// <summary>
        /// Event handler to call after a download operation successfully completes!
        /// </summary>
        event DownloadCompletedEventHandler DownloadCompleted;
        /// <summary>
        /// Event handler to call when an error occurs while processing a download 
        /// operation. This event passes along an <see cref="HeliumException"/>
        /// </summary>
        event DownloadErrorEventHandler OnError;

        /// <summary>
        /// Returns all the bytes read from a HTTP resource.
        /// </summary>
        /// <param name="uri">Path to the resource to download.</param>
        /// <returns>
        ///     A byte array of the contents read from the specified <paramref name="uri"/>
        /// </returns>
        byte[] Download(Uri uri);
        /// <summary>
        /// Returns all the bytes read from a HTTP resource.
        /// </summary>
        /// <param name="url">Path to the resource to download.</param>
        /// <returns>
        ///     A byte array of the contents read from the specified <paramref name="uri"/>
        /// </returns>
        byte[] Download(string url);
        /// <summary>
        /// Asynchronously reads and returns all the bytes read from a HTTP resource.
        /// </summary>
        /// <param name="uri">Path to the resource to download.</param>
        /// <returns>
        ///     An awaitable <see cref="Task"/> that finally returns the resource's content
        ///     as a byte array once the <see cref="Task"/> completes.
        /// </returns>
        Task<byte[]> DownloadAsync(Uri uri);
        /// <summary>
        /// Asynchronously reads and returns all the bytes read from a HTTP resource.
        /// </summary>
        /// <param name="url">Path to the resource to download.</param>
        /// <returns>
        ///     An awaitable <see cref="Task"/> that finally returns the resource's content
        ///     as a byte array once the <see cref="Task"/> completes.
        /// </returns>
        Task<byte[]> DownloadAsync(string url);


        /// <summary>
        /// Asynchronously downloads the contents of a remote resource/file and saves it 
        /// to a local file in the local Helium <see cref="Globals.TempFolder"/> with the name
        /// of the file found in the <paramref name="url"/>.
        /// 
        /// </summary>
        /// <param name="url">Path to the resource to download.</param>
        void DownloadToFile(string url);
        /// <summary>
        /// Asynchronously downloads the contents of a remote resource/file and saves it
        /// to a local file in the local Helium <see cref="Globals.TempFolder"/> using the 
        /// <paramref name="filename"/> specified.
        /// 
        /// </summary>
        /// <param name="url">Path to the resource to download.</param>
        /// <param name="filename">
        ///     Name to use in saving the file or basically a path of where to save the file.
        /// </param>
        void DownloadToFile(string url, string filename);
        /// <summary>
        /// Asynchronously downloads the contents of a remote resource/file and saves it 
        /// to a local file in the local Helium <see cref="Globals.TempFolder"/> with the name
        /// of the file found in the <paramref name="uri"/>.
        /// 
        /// </summary>
        /// <param name="url">Path to the resource to download.</param>
        void DownloadToFile(Uri uri);
        /// <summary>
        /// Asynchronously downloads the contents of a remote resource/file and saves it
        /// to a local file in the local Helium <see cref="Globals.TempFolder"/> using the 
        /// <paramref name="filename"/> specified.
        /// 
        /// </summary>
        /// <param name="uri">Path to the resource to download.</param>
        /// <param name="filename">
        ///     Name to use in saving the file or basically a path of where to save the file.
        /// </param>
        void DownloadToFile(Uri uri, string filename);
    }
}
