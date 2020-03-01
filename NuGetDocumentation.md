DHL Express MyDHL API .NET Library
============================================================

Implemented Operations
------------------------------

* Rate Query
* Shipment Generation
* Pickup Request
* Cancel/Delete Pickup
* Tracking
* ePOD Retrieve

Pending Operations (will come in future versions)
--------------------------

* Update Shipment


Usage
=====

Example
-------

Instantiate the MyDHLAPI object

    MyDHLAPI myDHLAPI = new MyDHLAPI(username, password, baseURL);

Call the appropriate method (tracking as an example)

    resp = myDHLAPI.KnownAWBTracking(new List<string>() { "1234567891" }
                                     , Enums.LevelOfDetails.AllCheckpoints
                                     , Enums.PiecesEnabled.Both
                                     , Enums.EstimatedDeliveryDateEnabled.Yes);