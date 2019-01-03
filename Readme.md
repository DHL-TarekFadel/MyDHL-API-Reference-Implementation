This project is a reference implementation of GloWS in .NET.
============================================================

This project includes:
* A library for RESTful GloWS operations
* A test application for all GloWS operations

This project will include (at a later date):
* A library for SOAP GloWS operations (work in progress)

_Please note that this is all a work in progress. This message will be removed when all components reach v1.0 state_

RESTful Library
===============

Implemented RESTful Operations
------------------------------

* Tracking
* Rate Query
* Shipment Generation
* ePOD Retrieve

SOAP Library
============

Implemented Operations
----------------------

--none--

Usage
=====

Requirements
-------

To use the test app, you must create a `credentials.txt` and ensure that it is included while building. This file should contain your username on `line 1` and your password on `line 2`. __Do not include this in source control if you intent to publish to the Internet__

You also have the option to use the `defaults.txt` file to set default values which all forms in the test app will use to pre-populate the form (saving your time). __Do not include this in source control if you intend to publish to the Internet__

Example
----
Instantiate the GloWS object

    GloWS glows = new GloWS(username, password, baseURL);

Call the appropriate method (tracking as an example)

    resp = glows.KnownAWBTracking(new List<string>() { "1234567891" }
                                  , Enums.LevelOfDetails.AllCheckpoints
                                  , Enums.PiecesEnabled.Both
                                  , Enums.EstimatedDeliveryDateEnabled.Yes);

