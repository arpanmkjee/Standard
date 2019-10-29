using System;
using System.IO;
using System.Threading.Tasks;
using Kooboo.Json;

namespace Cosmos.Serialization.Json.Kooboo
{
    /// <summary>
    /// KoobooJson helper
    /// </summary>
    public static partial class KoobooJsonHelper
    {
        /// <summary>
        /// Pack async
        /// </summary>
        /// <param name="o"></param>
        /// <param name="option"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static async Task<Stream> PackAsync<T>(T o, JsonSerializerOption option = null)
        {
            var ms = new MemoryStream();

            if (o is null)
                return ms;

            await PackAsync(o, ms, option);

            return ms;
        }

        /// <summary>
        /// Pack async
        /// </summary>
        /// <param name="o"></param>
        /// <param name="stream"></param>
        /// <param name="option"></param>
        /// <typeparam name="T"></typeparam>
        public static async Task PackAsync<T>(T o, Stream stream, JsonSerializerOption option = null)
        {
            if (o is null)
                return;

            var bytes = await KoobooJsonHelper.SerializeToBytesAsync(o, option);

            await stream.WriteAsync(bytes, 0, bytes.Length);
        }
        
        /// <summary>
        /// Unpack async
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="option"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static async Task<T> UnpackAsync<T>(Stream stream, JsonDeserializeOption option = null)
        {
            return stream is null
                ? default
                : await KoobooJsonHelper.DeserializeAsync<T>(KoobooManager.DefaultEncoding.GetString(await StreamToBytesAsync(stream)), option);
        }

        /// <summary>
        /// Unpack async
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="type"></param>
        /// <param name="option"></param>
        /// <returns></returns>
        public static async Task<object> UnpackAsync(Stream stream, Type type, JsonDeserializeOption option = null)
        {
            return stream is null
                ? default
                : await KoobooJsonHelper.DeserializeAsync(KoobooManager.DefaultEncoding.GetString(await StreamToBytesAsync(stream)), type, option);
        }

        private static async Task<byte[]> StreamToBytesAsync(Stream stream)
        {
            var bytes = new byte[stream.Length];

            if (stream.CanSeek && stream.Position > 0)
                stream.Seek(0, SeekOrigin.Begin);

            await stream.ReadAsync(bytes, 0, bytes.Length);

            if (stream.CanSeek)
                stream.Seek(0, SeekOrigin.Begin);

            return bytes;
        }
    }
}