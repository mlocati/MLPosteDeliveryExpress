using Microsoft.VisualStudio.TestTools.UnitTesting;
using MLPosteDeliveryExpress;
using MLPosteDeliveryExpress.Waybill;
using MLPosteDeliveryExpress.Waybill.Request;
using MLPosteDeliveryExpress.Waybill.Services;
using System.Text;
using System.Text.RegularExpressions;

namespace Test
{
    [TestClass]
    public class WaybillGenerationTests
    {
        [TestMethod]
        public void GenerationWorks()
        {
            Options.Sandbox = true;
            var account = new Account("my-client-it", "my-client-secret", "my-cost-center-code");
            var waybill = new Waybill()
            {
                ClientReferenceId = "12312312341",
                Product = AptusCode.PosteDeliveryBusinessExpress,
                PrintFormat = PrintFormat.PDF_10x11,
                Data = new()
                {
                    Content = "contenuto",
                    Sender = new()
                    {
                        FirstLastName = "Mario Rossi",
                        Street = "Viale Europa",
                        StreetNumber = "192",
                        ZipCode = "00142",
                        City = "ROMA",
                        StateOrProvince = "RM",
                        CountryISO4 = "ITA1",
                        CountryName = "Italia",
                        Email = "mail@mail.it",
                        Phone = "37747383787287",
                        Notes1 = "sender note 1",
                        Notes2 = "sender note 2",
                    },
                    Receiver = new()
                    {
                        FirstLastName = "Ditta test",
                        ContactName = "Aldo Bianchi",
                        ZipCode = "80010",
                        Street = "VIALE DEL TRAMONTO 10",
                        StreetNumber = "27",
                        City = "NAPOLI",
                        StateOrProvince = "RM",
                        CountryISO4 = "ITA1",
                        CountryName = "Italia",
                        Email = "mail@mail.it",
                        Phone = "11111111111",
                        Notes1 = "note spedizione 1",
                        Notes2 = "note spedizione 2",
                    }
                }
            };
            waybill.Data.Services.Add(new CashOnDelivery(543.21M, CashOnDelivery.PaymentModes.BankCheck));
            waybill.Data.Declared.Add(new()
            {
                Width = 25,
                Height = 10,
                Length = 10,
                Weight = 10,
            });
            var request = new Container
            {
                CostCenterCode = Account.SANDBOX_COST_CENTER_CODE,
                ShipmentDate = new DateTime(2020, 11, 26, 09, 2, 20, 986),
            };
            request.Waybills.Add(waybill);
            var createdWaybills = Creator.Create(account, request).Waybills;
            Assert.IsNotNull(createdWaybills);
            Assert.AreEqual(1, createdWaybills.Count);
            var createdWayBill = createdWaybills[0];
            Assert.IsFalse(string.IsNullOrEmpty(createdWayBill.Code));
            using var pdfStream = Downloader.Download(createdWayBill);
            using var pdfReader = new StreamReader(pdfStream, Encoding.ASCII, false);
            var line = pdfReader.ReadLine();
            Assert.IsFalse(string.IsNullOrEmpty(line));
            Assert.IsTrue(Regex.IsMatch(line, @"^%PDF-\d+(\.\d+)?$"));
            pdfStream.Position = 0;
            var temporaryFile = Path.GetTempFileName();
            try
            {
                using (var temporaryFileStream = File.Create(temporaryFile))
                {
                    pdfStream.CopyTo(temporaryFileStream);
                }
            }
            finally
            {
                try { File.Delete(temporaryFile); } catch { }
            }
        }
    }
}