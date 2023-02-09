using System.IO;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace MLPosteDeliveryExpress.Waybill
{
    public static class Downloader
    {
        public static MemoryStream Download(Response.Waybill waybill)
        {
            var task = DownloadAsync(waybill);
            task.Wait();
            return task.Result;
        }

        public static async Task<MemoryStream> DownloadAsync(Response.Waybill waybill)
        {
            using var client = new HttpClient();
            using var response = await client.GetAsync(waybill.DownloadURL);
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