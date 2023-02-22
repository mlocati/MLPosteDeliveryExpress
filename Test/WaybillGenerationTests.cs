using Microsoft.VisualStudio.TestTools.UnitTesting;
using MLPosteDeliveryExpress;
using MLPosteDeliveryExpress.Waybill;
using MLPosteDeliveryExpress.Waybill.Request;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
using static System.Text.Json.JsonElement;

namespace Test
{
    [TestClass]
    public class WaybillGenerationTests
    {
        [TestMethod]
        public void GenerationWorks()
        {
            var account = Account.Sandbox;
            var waybill = new Waybill()
            {
                ClientReferenceId = "12312312341",
                Product = AptusCode.PosteDeliveryBusinessExpress,
                PrintFormat = PrintFormat.PDF_A4,
                Data = new()
                {
                    Content = "contenuto",
                    Sender = new()
                    {
                        FirstLastName = "Ditta delle Ditte",
                        ContactName = "Mario Rossi",
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
                        Notes1 = "note spedizione 1 ",
                        Notes2 = "note spedizione 2",
                    }
                }
            };
            waybill.Data.Declared.Add(new()
            {
                Width = 25,
                Height = 10,
                Length = 30,
                Weight = 10,
            });
            var request = new Container
            {
                CostCenterCode = account.CostCenterCode,
                ShipmentDate = new DateTime(2020, 11, 26, 8, 2, 20, 986, DateTimeKind.Utc).ToLocalTime(),
            };
            request.Waybills.Add(waybill);
            var actualJson = JsonSerializer.Serialize(request, Creator.JsonSerializerOptionsCreator.Value);
            AssertSameJson(Resources.WaybillGenerationTests_request_json, actualJson);
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
                using var temporaryFileStream = File.Create(temporaryFile);
                pdfStream.CopyTo(temporaryFileStream);
            }
            finally
            {
                try { File.Delete(temporaryFile); } catch { }
            }
        }

        private static void AssertSameJson(string expected, string actual)
        {
            var expectedObject = JsonSerializer.Deserialize<Dictionary<string, object>>(expected);
            Assert.IsNotNull(expectedObject);
            var actualObject = JsonSerializer.Deserialize<Dictionary<string, object>>(actual);
            Assert.IsNotNull(actualObject);
            WaybillGenerationTests.AssertSameJson(expectedObject, actualObject);
        }

        private static void AssertSameJson(IDictionary<string, object> expected, IDictionary<string, object> actual, string keyPrefix = "")
        {
            foreach (var key in expected.Keys)
            {
                var keyDisplayName = $"{keyPrefix}{key}";
                Assert.IsTrue(actual.ContainsKey(key), $"The generated JSON doesn't contain the key {keyDisplayName}");
                Assert.IsTrue(expected[key] is JsonElement);
                Assert.IsTrue(actual[key] is JsonElement);
                WaybillGenerationTests.AssertSameJson((JsonElement)expected[key], (JsonElement)actual[key], keyDisplayName);
            }
            foreach (var key in actual.Keys)
            {
                Assert.IsTrue(expected.ContainsKey(key), $"The generated JSON contains the unknown key {keyPrefix}{key}");
            }
        }

        private static void AssertSameJson(JsonElement expected, JsonElement actual, string keyPrefix = "")
        {
            var valueKind = expected.ValueKind;
            Assert.AreEqual(valueKind, actual.ValueKind, $"Wrong generated JSON for key {keyPrefix}");
            switch (valueKind)
            {
                case JsonValueKind.Array:
                    WaybillGenerationTests.AssertSameJson(expected.EnumerateArray(), actual.EnumerateArray(), keyPrefix);
                    break;

                case JsonValueKind.Object:
                    WaybillGenerationTests.AssertSameJson(expected.EnumerateObject(), actual.EnumerateObject(), keyPrefix);
                    break;

                case JsonValueKind.String:
                    Assert.AreEqual(expected.GetString(), actual.GetString(), $"Wrong generated JSON for key {keyPrefix}");
                    break;

                case JsonValueKind.Number:
                    Assert.AreEqual(expected.GetDecimal(), actual.GetDecimal(), $"Wrong generated JSON for key {keyPrefix}");
                    break;

                case JsonValueKind.True:
                    Assert.AreEqual(expected.GetBoolean(), actual.GetBoolean(), $"Wrong generated JSON for key {keyPrefix}");
                    break;

                case JsonValueKind.False:
                    Assert.AreEqual(expected.GetBoolean(), actual.GetBoolean(), $"Wrong generated JSON for key {keyPrefix}");
                    break;

                case JsonValueKind.Null:
                    break;

                default:
                    throw new NotImplementedException($"Unrecognized value kind: {valueKind}");
            }
        }

        private static void AssertSameJson(ArrayEnumerator expected, ArrayEnumerator actual, string keyPrefix = "")
        {
            if (keyPrefix.EndsWith('.'))
            {
                keyPrefix = keyPrefix[..^1];
            }
            Assert.AreEqual(expected.Count(), actual.Count(), $"Wrong array count at key {keyPrefix}");
            expected.Reset();
            actual.Reset();
            var index = 0;
            while (expected.MoveNext())
            {
                Assert.IsTrue(actual.MoveNext());
                WaybillGenerationTests.AssertSameJson(expected.Current, actual.Current, $"{keyPrefix}[{index}].");
                index++;
            }
            Assert.IsFalse(actual.MoveNext());
        }

        private static void AssertSameJson(ObjectEnumerator expected, ObjectEnumerator actual, string keyPrefix = "")
        {
            foreach (var expectedProperty in expected)
            {
                var keyDisplayName = keyPrefix + expectedProperty.Name;
                var actualProperties = actual.Where(p => p.Name == expectedProperty.Name);
                Assert.AreEqual(1, actualProperties.Count(), $"The generated JSON doesn't contain the property {keyDisplayName}");
                var actualProperty = actualProperties.First();
                WaybillGenerationTests.AssertSameJson(expectedProperty.Value, actualProperty.Value, keyDisplayName + '.');
            }
            foreach (var actualProperty in actual)
            {
                Assert.IsFalse(expected.Where(p => p.Name == actualProperty.Name).Count() != 1, $"The generated JSON contains the extra property {keyPrefix}{actualProperty.Name}");
            }
        }
    }
}