[![Tests](https://github.com/mlocati/MLPosteDeliveryExpress/actions/workflows/test.yml/badge.svg)](https://github.com/mlocati/MLPosteDeliveryExpress/actions/workflows/test.yml)

# MLocati's C# library to work with Poste Italiane Delivery Express API

This project contains an *UNOFFICIAL* library to use the Poste Italiane Delivery Express API.


## Requirements

In order to use this library, you need a Poste Delivery Business contract with Poste Italiane.

This library supports .Net 6 and .Net 7.


## Logging the communications with the API server

You can hook the MLPosteDeliveryExpress.Options.VerboseOutput` event, for example:

```c#
MLPosteDeliveryExpress.Options.VerboseOutput += (object sender, MLPosteDeliveryExpress.Service.Message message) =>
{
    System.Console.WriteLine(message.Data);
};
```

## Configuring a proxy and any other HTTP client properties

If you need to configure the HTTP Client (for instance because you need to set up a proxy), you can use some code like this:

```c#
MLPosteDeliveryExpress.Options.HttpClientInitialization += (object sender, System.Net.Http.HttpClient client) =>
{
    // Configure the client here
};
```


## Account

You'll need the API credentials and the code of the Cost Center (it's something like `CDC-...`).
In order to get these details you need to go to https://www.mypostedeliverybusiness.it/offertaunica/

Create a `MLPosteDeliveryExpress.Account` instance with these details.

You can also use the account MLPosteDeliveryExpress.Account.Sandbox: in this case, the library will use the sandbox API servers (that is, a test environment).


## Countries

Poste Delivery Business uses custom codes for countries (they call it `ISO4`).

For example, Italy has one ISO4 code (`ITA1`), whereas Germany has 3 ISO4 codes (`GER1` for Germany, `GER2` for Heligoland, `GER3` for Busingen).

You can fetch the list of all the countries with some code like this:

```c#
var countries = (await MLPosteDeliveryExpress.Country.Fetcher.FetchAsync(account)).Countries;
```


## Taric

For international shipments, you may need to describe the type of the product being shipped.

In order to do that, you must use a `taric` code.

You can fetch all the taric codes, as well as their Italian and English descriptions, with some code like this:

```c#
var tarics = (await MLPosteDeliveryExpress.Taric.Fetcher.FetchAsync(account)).Tarics;
```


## Waybill Labels

In order to print the labels to be applied to the packages to be shipped, you may use some code like this:

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
    CostCenterCode = MLPosteDeliveryExpress.Options.Sandbox ? MLPosteDeliveryExpress.Account.SANDBOX_COST_CENTER_CODE : account.CostCenterCode,
    ShipmentDate = new DateTime(2020, 11, 26, 09, 2, 20, 986),
};
request.Waybills.Add(waybill);
var createdWaybill = (await MLPosteDeliveryExpress.Waybill.Creator.CreateAsync(account, request)).Waybills[0];
```

You can then fetch and save the waybill to a file with some code like this:

```c#
using var stream = await MLPosteDeliveryExpress.Waybill.Downloader.DownloadAsync(createdWaybill);
using var fileStream = System.IO.File.Create(@"C:\waybill.pdf");
stream.CopyTo(fileStream);
```

If you need to send multiple packages at once, you have to:

1. Add the dimensions and weight of each package to the `waybill.Data.Declared` list:
   ```c#
   waybill.Data.Declared.Add(new()
   {
       Width = 25,
       Height = 10,
       Length = 10,
       Weight = 10,
   });
   waybill.Data.Declared.Add(new()
   {
       Width = 50,
       Height = 60,
       Length = 70,
       Weight = 80,
   });
   ```
2. Declare that it's a multi-package shipment:
   ```c#
   waybill.Data.Services.Add(new MLPosteDeliveryExpress.Waybill.Services.MultiPack());
   ```
3. When you call the `CreateAsync` method, you'll have a waybill instance for every package you declared.

## Pick-up Booking

Once you generated a waybill, you can book a pickup with some code like this:

```c#
var pickupRequest = new MLPosteDeliveryExpress.PickupBooking.Request.Pickup()
{
    Operation = MLPosteDeliveryExpress.PickupBooking.Operation.Insert,
    BookingType = MLPosteDeliveryExpress.PickupBooking.BookingType.Single,
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
var bookingID = await MLPosteDeliveryExpress.PickupBooking.Submitter.SubmitAsync(account, pickupRequest);
```

You can also book a multiple pick-up, not associated to a specific waybill.
In this case, you can leave the `ShipmentId` field empty, and set the `BookingType` field to `MLPosteDeliveryExpress.PickupBooking.BookingType.Multiple`.


## List Pick-up Bookings

You can retrieve the list of pick-up bookins with some code like this:

```c#
var filter = new MLPosteDeliveryExpress.PickupBooking.Request.Filter()
{
    DateFrom: System.DateOnly.FromDateTime(System.DateTime.Today),
};
var pickupBookings = await MLPosteDeliveryExpress.PickupBooking.Finder(account, filter);
```


## Tracking

If you want to track the package identified by its waybill code, you can use some code like this:

```c#
var (tracking, messages) = await MLPosteDeliveryExpress.Tracking.Tracker.TrackAsync(account, createdWayBill.Code);
```

Where:
- `tracking` will contain the tracking data
- `messages` will contain any messages returned by the tracking look-up


## Deposit

It's possible to fetch the list of packages that failed to be delivered to the recipients:

```c#

var deposits = await MLPosteDeliveryExpress.Deposit.FindAsync(account, new() {
    DepisitDateFrom = System.DateOnly.FromDateTime(System.DateTime.Today.AddDays(-5)),
    DepisitDateTo = System.DateOnly.FromDateTime(System.DateTime.Today),
});
```

For each deposit, you can take an action:

```c#
await MLPosteDeliveryExpress.Deposit.Decisor.TakeActionAsync(
    account,
    deposit.ShipmentID,
    MLPosteDeliveryExpress.Deposit.Action.RetryDelivery
);
```


## Delivery Points

You search delivery points (PuntoPoste Locker, Caselle postali, Fermoposta, PuntoPoste) with some code like this:

```c#
var zipCode = "00144";
var deliveryPointType = MLPosteDeliveryExpress.DeliveryPoint.ServiceType.PuntoPoste;
var deliveryPoints = await MLPosteDeliveryExpress.DeliveryPoint.Finder.FindAsync(account, zipCode, deliveryPointType);
```

The `deliveryPoints` will contain a list of the delivery points.
