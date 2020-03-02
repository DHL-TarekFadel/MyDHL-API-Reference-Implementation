### Welcome to the MyDHL API .NET reference implementation

This project is serves 2 purposes:
1. To create a .NET library ([NuGet Package](https://www.nuget.org/packages/DHL.MyDHL_API.RESTLibrary#)) which customers can just use in their .NET projects.
2. To have source code which shows customers how to use the library and/or how it is created to they can create their own.

RESTful Library
===============

Implemented RESTful Operations
------------------------------

* Rate Query
* Shipment Generation
* Pickup Request
* Cancel/Delete Pickup
* Tracking
* ePOD Retrieve

Pending RESTful Operations
--------------------------

* Update Shipment

SOAP Library
============

Implemented SOAP Operations
----------------------

--none--

Pending SOAP Operations
-----------------------

* Rate Query
* Shipment Generation
* Update Shipment
* Pickup Request
* Cancel/Delete Pickup
* Tracking
* ePOD Retrieve

Usage
=====

Requirements
-------

To use the test app, you must create a `credentials.txt` and ensure that it is included while building. This file should contain your username on `line 1` and your password on `line 2`. __Do not include this in source control if you intent to publish to the Internet.__

You also have the option to use the `defaults.json` file to set default values which all forms in the test app will use to pre-populate the form (saving your time). __Do not include this in source control if you intend to publish to the Internet.__

A `defaults-example.json` file is included for your reference.

Example
----
Instantiate the MyDHLAPI object
```C#
MyDHLAPI myDHLAPI = new MyDHLAPI(username, password, baseURL);
```

Call the appropriate method (tracking as an example)
```C#
resp = myDHLAPI.KnownAWBTracking(new List<string>() { "1234567891" }
                                 , Enums.LevelOfDetails.AllCheckpoints
                                 , Enums.PiecesEnabled.Both
                                 , Enums.EstimatedDeliveryDateEnabled.Yes);
```