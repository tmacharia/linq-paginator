using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Caching
{
    public interface ICommonService
    {
        /// <summary>
        /// Checks whether Application folders exist in the machine in use and further
        /// goes to create them if they dont exists. Generates the default path to use
        /// through the application.
        /// </summary>
        /// <returns>
        /// A boolean showing whether initialization was successful or not.
        /// </returns>
        bool Initialize();
        /// <summary>
        /// Reads data in a file with the name <paramref name="filename"/> using default
        /// application storage path and serializes the results to an instance of
        /// <typeparamref name="TEntity"/>
        /// </summary>
        /// <typeparam name="TEntity">Object Type</typeparam>
        /// <param name="filename">Name of file in default application storage folder.</param>
        /// <returns>An instance of type <typeparamref name="TEntity"/></returns>
        TEntity Read<TEntity>(string filename);
        /// <summary>
        /// Reads data from a file with the name <paramref name="filename"/> using default
        /// application storage path.
        /// </summary>
        /// <param name="filename">Name of file in default application storage folder.
        /// N.B All files are .json files
        /// </param>
        /// <returns>Contents of the file as a string.</returns>
        string Read(string filename);
        /// <summary>
        /// Reads data from a file with the name <paramref name="filename"/> using default
        /// application storage path.
        /// </summary>
        /// <param name="filename"></param>
        /// <returns>Stream with file contents</returns>
        Stream ReadAsStream(string filename);
        /// <summary>
        /// Writes a json string or plaintext to a file
        /// </summary>
        /// <param name="filename">Name to use in creating the file.</param>
        /// <param name="content">Data to write in the file.</param>
        /// <returns>A boolean showing whether the operation was successful
        /// or not.
        /// </returns>
        bool Write(string filename, string contents);
        /// <summary>
        /// Writes data in an object of type <typeparamref name="TEntity"/> to a file within
        /// the application default storage location with the <paramref name="filename"/>
        /// specified.
        /// </summary>
        /// <typeparam name="TEntity">Object Type.</typeparam>
        /// <param name="entity">Object containing data to save in file.</param>
        /// <param name="filename">Name to use in creating the file. 
        /// Do not include file extensions since all files are saved as json and thus
        /// have a default extension of .json
        /// </param>
        /// <returns>A boolean showing whether the operation was successful or not.</returns>
        bool Write<TEntity>(TEntity entity, string filename);

        /// <summary>
        /// Converts a string representation to a stream
        /// </summary>
        /// <param name="s">String to convert</param>
        /// <returns>A Stream</returns>
        Stream StringToStream(string s);
        /// <summary>
        /// Converts a stream to raw bytes and then creates a string representation of that
        /// byte[] in base64.
        /// </summary>
        /// <param name="stream">Stream to convert or any child elements that inherit
        /// from the base <see cref="System.IO.MemoryStream"/>
        /// </param>
        /// <returns>A string in base64</returns>
        string StreamToString(Stream stream);
        /// <summary>
        /// Clears the contents of a file.
        /// </summary>
        /// <param name="filename">Name of file to clear contents from application storage folder.
        /// N.B Only use the filename with no extension & not the path to the file.
        /// </param>
        /// <returns>A boolean indicating whether the operation was successful.</returns>
        bool Clear(string filename);
    }
}
