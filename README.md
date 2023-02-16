# MLocati's C# library to work with Poste Italiane Delivery Express API

This project contains an *UNOFFICIAL* library to use the Poste Italiane Delivery Express API.

## Requirements

In order to use this library, you need a Poste Delivery Business contract with Poste Italiane.

This library is written in .Net 6.

## Sandbox / Test environment

This library can call the APIs by using a sandbox (that is, a test environment).
By default, the test environment is used when the `DEBUG` directive is defined (`#define DEBUG`), which is true when developing in Visual Studio with the `Debug` configuration.

You can manually control the use of the sandbox by setting the `MLPosteDeliveryExpress.Options.Sandbox` property.

## Logging the communications with the API server

You can hook the MLPosteDeliveryExpress.Options.VerboseOutput` event, for example:

```c#
MLPosteDeliveryExpress.Options.VerboseOutput += (object sender, string message) =>
{
    System.Console.WriteLine(message);
};

```

## Account

You'll need the API credentials and the code of the Cost Center (it's something like `CDC-...`).
In order to get these details you need to go to https://www.mypostedeliverybusiness.it/offertaunica/

Create a `MLPosteDeliveryExpress.Account` instance with these details.

## Countries

Poste Delivery Business uses custom codes for countries (they call it `ISO4`).

For example, Italy has one ISO4 code (`ITA1`), whereas Germany has 3 ISO4 codes (`GER1` for Germany, `GER2` for Heligoland, `GER3` for Busingen).

You can fetch the list of all the countries with some code like this:

```c#
var countries = MLPosteDeliveryExpress.Country.Fetcher.Fetch(account).Countries;
```

## Taric

For international shipments, you may need to decribe the type of the product being shipped.

In order to do that, you must use a `taric` code.

You can fetch all the taric codes, as well as their Italian and English descriptions, with some code like this:

```c#
var tarics = MLPosteDeliveryExpress.Taric.Fetcher.Fetch(account).Tarics;
```

## Waybill Labels

In order to print labels to be applied to the packages to be shipped, you have to use some code like this:

```c#
var waybill = new MLPosteDeliveryExpress.Waybill.Request.Waybill()
{
    ClientReferenceId = "12312312341",
    Product = MLPosteDeliveryExpress.AptusCode.PosteDeliveryBusinessExpress,
    PrintFormat = MLPosteDeliveryExpress.Waybill.PrintFormat.PDF_A4,
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
waybill.Data.Declared.Add(new()
{
    Width = 25,
    Height = 10,
    Length = 10,
    Weight = 10,
});
var request = new MLPosteDeliveryExpress.Waybill.Request.Container
{
    CostCenterCode = MLPosteDeliveryExpress.Options.Sandbox ? MLPosteDeliveryExpress.Waybill.Request.Container.SANDBOX_COST_CENTER_CODE : account.CostCenterCode,
    ShipmentDate = new DateTime(2020, 11, 26, 09, 2, 20, 986),
};
request.Waybills.Add(waybill);
var createdWaybill = MLPosteDeliveryExpress.Waybill.Creator.Create(account, request).Waybills[0];
```

You can then fetch and save the waybill to a file with some code like this:

```c#
using var stream = MLPosteDeliveryExpress.Waybill.Downloader.Download(createdWaybill);
using var fileStream = System.IO.File.Create(@"C:\waybill.pdf");
stream.CopyTo(fileStream);
```

## Pick-up Booking

Once you generated a waybill, you can book a pickup with some code like this:

```c#
var pickupRequest = new MLPosteDeliveryExpress.PickupBooking.Request.Pickup()
{
    Operation = MLPosteDeliveryExpress.PickupBooking.Operation.Insert,
    ShipmentId = createdWaybill.Code,
    Where = new()
    {
        Address = new()
        {
            FirstName = "Henrietta Hill",
            LastName = "Gene Bowen",
            StreetName = "via colonnelle",
            StreetNumber = "4",
            ZipCode = "00073",
            City = "Castel Gandolfo",
            StateOrProvince = "RM",
            Country = "IT",
        },
    },
};
var bookingID = MLPosteDeliveryExpress.PickupBooking.Submitter.Submit(account, pickupRequest);
```
