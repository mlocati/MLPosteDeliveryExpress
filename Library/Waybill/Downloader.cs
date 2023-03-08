using System;
using System.IO;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace MLPosteDeliveryExpress.Waybill
{
    public static class Downloader
    {
        public static async Task<MemoryStream> DownloadAsync(Response.Waybill waybill)
        {
            if (string.IsNullOrEmpty(waybill.DownloadURL))
            {
                throw new Exception("Empty waybill download URL");
            }
            return await Downloader.DownloadAsync(waybill.DownloadURL);
        }

        public static async Task<MemoryStream> DownloadAsync(string waybillDownloadURL)
        {
            if (waybillDownloadURL.Length == 0)
            {
                throw new Exception("Empty waybill download URL");
            }
            using var client = new HttpClient();
            using var response = await client.GetAsync(waybillDownloadURL);
            response.EnsureSuccessStatusCode();
            var memoryStream = new MemoryStream();
            try
            {
                response.Content.CopyTo(memoryStream, null, CancellationToken.None);
                memoryStream.Seek(0, SeekOrigin.Begin);
            }
            catch
            {
                memoryStream.Dispose();
                throw;
            }
            return memoryStream;
        }
    }
}