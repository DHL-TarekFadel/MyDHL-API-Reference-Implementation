using System;
using MyDHLAPI_REST_Library.Objects;
using MyDHLAPI_REST_Library.Objects.Common;
using MyDHLAPI_REST_Library.Objects.Exceptions;
using MyDHLAPI_REST_Library.Objects.Tracking;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using MyDHLAPI_REST_Library.Objects.ePOD;
using System.Reflection;
using System.Diagnostics;
using System.Threading.Tasks;

namespace MyDHLAPI_REST_Library
{
    public class MyDHLAPI
    {
        private readonly string _baseURL;

        private readonly string _username;
        private readonly string _password;

        #region "JSON Request and Response properties

        // General
        public string LastJSONRequest { get; set; }
        public string LastJSONResponse { get; set; }

        // Rate Query
        public string LastRateQueryJSONRequest { get; set; }
        public string LastRateQueryJSONResponse { get; set; }

        // Ship
        public string LastShipJSONRequest { get; set; }
        public string LastShipJSONResponse { get; set; }

        // Tracking
        public string LastTrackingJSONRequest { get; set; }
        public string LastTrackingJSONResponse { get; set; }

        //ePoD
        public string LastEPoDJSONRequest { get; set; }
        public string LastEPoDJSONResponse { get; set; }

        #endregion
        public MyDHLAPI(string username, string password, string baseUrl)
        {
            _username = username;
            _password = password;
            _baseURL = baseUrl;
        }

        public string GetVersion()
        {
            return FileVersionInfo.GetVersionInfo(Assembly.GetAssembly(this.GetType()).Location).ProductVersion;
        }

        public Task<string> SendRequestAndReceiveResponseAsync(string req, string endpoint)
        {
            return Task.Run(() => SendRequestAndReceiveResponse(req, endpoint));
        }

        public string SendRequestAndReceiveResponse(string req, string endpoint)
        {
            WebRequest request = WebRequest.Create($"{_baseURL}/{endpoint}");
            request.Credentials = new NetworkCredential(_username, _password);
            request.ContentType = "application/json";
            request.PreAuthenticate = true;
            request.UseDefaultCredentials = false;
            request.Method = "POST";
            string encoded = System.Convert.ToBase64String(Encoding.GetEncoding("ISO-8859-1").GetBytes(_username + ":" + _password));
            request.Headers.Add("Authorization", "Basic " + encoded);
            using (StreamWriter sr = new StreamWriter(request.GetRequestStream(), Encoding.UTF8))
            {
                sr.Write(req);
                sr.Flush();
                sr.Close();
            }

            string respString = string.Empty;

            try
            {
                WebResponse resp = request.GetResponse();
                StreamReader respReader = new StreamReader(resp.GetResponseStream());
                respString = respReader.ReadToEnd();
            }
            catch (Exception)
            {
                throw;
            }

            return respString;
        }

        public Task<KnownTrackingResponse> KnownAWBTrackingAsync(List<string> AWBs
                                                                , Enums.LevelOfDetails levelOfDetails = Enums.LevelOfDetails.AllCheckpoints
                                                                , Enums.PiecesEnabled detailsRequested = Enums.PiecesEnabled.ShipmentOnly
                                                                , Enums.EstimatedDeliveryDateEnabled eddEnabled = Enums.EstimatedDeliveryDateEnabled.No)
        {
            return Task.Run(() => KnownAWBTracking(AWBs, levelOfDetails, detailsRequested, eddEnabled));
        }

        // ReSharper disable once InconsistentNaming
        public KnownTrackingResponse KnownAWBTracking (List<string> AWBs
                                                       , Enums.LevelOfDetails levelOfDetails = Enums.LevelOfDetails.AllCheckpoints
                                                       , Enums.PiecesEnabled detailsRequested = Enums.PiecesEnabled.ShipmentOnly
                                                       , Enums.EstimatedDeliveryDateEnabled eddEnabled = Enums.EstimatedDeliveryDateEnabled.No)
        {
            KnownTrackingRequest ktr = new KnownTrackingRequest
            {
                Request = new Request
                {
                    ServiceHeader = new ServiceHeader()
                },
                AWBNumber = new AWBNumber(AWBs),
                PiecesEnabled = detailsRequested,
                LevelOfDetails = levelOfDetails,
                EstimatedDeliveryDateEnabled = eddEnabled                
            };
            //foreach (string awb in AWBs)
            //{
            //    ktr.AWBNumber.ArrayOfAWBNumberItem.Add(new AWBNumber(awb));
            //}

            // Validate the request

            List<ValidationResult> validationResult = Common.Validate(ref ktr);
            if (validationResult.Any())
            {
                throw new MyDHLAPIValidationException(validationResult);
            }

            LastJSONRequest = JsonConvert.SerializeObject(KnownTrackingRequest.DecorateRequest(ktr), Formatting.Indented);
            LastTrackingJSONRequest = LastJSONRequest;
            LastJSONResponse = SendRequestAndReceiveResponse(LastJSONRequest, "TrackingRequest");
            LastTrackingJSONResponse = LastJSONResponse;

            KnownTrackingResponse retval;

            try
            {
                // Deserialize the result back to an object.
                List<string> errors = new List<string>();

                retval = JsonConvert.DeserializeObject<KnownTrackingResponse>(LastJSONResponse, new JsonSerializerSettings() {
                        Error = delegate (object sender, Newtonsoft.Json.Serialization.ErrorEventArgs args)
                        {
                            errors.Add(args.ErrorContext.Error.Message);
                            args.ErrorContext.Handled = true;
                        }
                    });
            }
            catch
            {
                retval = new KnownTrackingResponse();
            }

            return retval;
        }

        public Task<RateQueryResponse> RateQueryAsync(RateQueryRequest rqr)
        {
            return Task.Run(() => RateQuery(rqr));
        }

        public RateQueryResponse RateQuery(RateQueryRequest rqr)
        {
            // Validate the request

            List<ValidationResult> validationResult = Common.Validate(ref rqr);
            if (validationResult.Any()) {
                throw new MyDHLAPIValidationException(validationResult);
            }

            LastJSONRequest = JsonConvert.SerializeObject(rqr, Formatting.Indented);
            LastRateQueryJSONRequest = LastJSONResponse;
            LastJSONResponse = SendRequestAndReceiveResponse(LastJSONRequest, "RateRequest");
            LastRateQueryJSONResponse = LastJSONResponse;

            RateQueryResponse retval;

            try {
                // Deserialize the result back to an object.
                List<string> errors = new List<string>();

                retval = JsonConvert.DeserializeObject<RateQueryResponse>(LastJSONResponse, new JsonSerializerSettings() {
                    Error = delegate (object sender, Newtonsoft.Json.Serialization.ErrorEventArgs args) {
                        errors.Add(args.ErrorContext.Error.Message);
                        args.ErrorContext.Handled = true;
                    }
                });
            }
            catch
            {
                retval = new RateQueryResponse();
            }

            return retval;
        }

        public Task<EPodResponse> GetEPoDAsync(string awbNumber, string accountNumber, Enums.EPodType ePodType)
        {
            return Task.Run(() => GetEPod(awbNumber, accountNumber, ePodType));
        }

        public EPodResponse GetEPod(string awbNumber, string accountNumber, Enums.EPodType ePodType)
        {
            // Trim our numbers
            awbNumber = awbNumber.Trim();
            accountNumber = accountNumber.Trim();

            EPodRequest req = new EPodRequest();

            req.Body.ShipmentDetails.AWB = awbNumber;

            req.Body.RequestCriteria.RequestCriterions.Add(new RequestEnumCriterion(Enums.EPodCriterionType.ImageContent, ePodType));
            req.Body.RequestCriteria.RequestCriterions.Add(new RequestStringCriterion(Enums.EPodCriterionType.IsExternal, "true"));

            if (!string.IsNullOrWhiteSpace(accountNumber))
            {
                ShipmentTransaction shipmentTransaction = new ShipmentTransaction(accountNumber, Enums.EPodCustomerRoleType.Payer);
                req.Body.ShipmentDetails.ShipmentTransaction = shipmentTransaction;
            }

            // Validate the request
            List<ValidationResult> validationResult = Common.Validate(ref req);

            // Validate whether the account number is required
            if (string.IsNullOrWhiteSpace(accountNumber))
            {
                if (ePodType == Enums.EPodType.Detailed
                    || ePodType == Enums.EPodType.DetailedTable)
                {
                    validationResult.Add(new ValidationResult("You must use an account number when requested detailed ePODs"));
                }
            }

            if (validationResult.Any()) {
                throw new MyDHLAPIValidationException(validationResult);
            }

            LastJSONRequest = JsonConvert.SerializeObject(req, Formatting.Indented);
            LastEPoDJSONRequest = LastJSONRequest;
            LastJSONResponse = SendRequestAndReceiveResponse(LastJSONRequest, "getePOD");
            LastEPoDJSONResponse = LastJSONResponse;

            EPodResponse retval;

            try
            {
                // Deserialize the result back to an object.
                List<string> errors = new List<string>();

                retval = JsonConvert.DeserializeObject<EPodResponse>(LastJSONResponse, new JsonSerializerSettings()
                {
                    Error = delegate (object sender, Newtonsoft.Json.Serialization.ErrorEventArgs args)
                    {
                        errors.Add(args.ErrorContext.Error.Message);
                        args.ErrorContext.Handled = true;
                    }
                });
            }
            catch
            {
                retval = null;
            }

            return retval;
        }

        public Task<CreateShipmentResponse> RequestShipmentAsync(CreateShipmentRequest req)
        {
            return Task.Run(() => RequestShipment(req));
        }

        public CreateShipmentResponse RequestShipment(CreateShipmentRequest req)
        {
            // Validate the request

            List<ValidationResult> validationResult = Common.Validate(ref req);
            if (validationResult.Any())
            {
                string errors = MyDHLAPIValidationException.PrintResults(validationResult);
                throw new MyDHLAPIValidationException(validationResult);
            }

            LastJSONRequest = JsonConvert.SerializeObject(req, Formatting.Indented);
            LastShipJSONRequest = LastJSONRequest;
            LastJSONResponse = SendRequestAndReceiveResponse(LastJSONRequest, "ShipmentRequest");
            LastShipJSONResponse = LastJSONResponse;

            CreateShipmentResponse retval;

            try
            {
                // Deserialize the result back to an object.
                List<string> errors = new List<string>();

                retval = JsonConvert.DeserializeObject<CreateShipmentResponse>(LastJSONResponse, new JsonSerializerSettings()
                {
                    Error = delegate (object sender, Newtonsoft.Json.Serialization.ErrorEventArgs args)
                    {
                        errors.Add(args.ErrorContext.Error.Message);
                        args.ErrorContext.Handled = true;
                    }
                });
            }
            catch
            {
                retval = new CreateShipmentResponse();
            }

            return retval;
        }
    }
}


//KnownTrackingResponse test = new KnownTrackingResponse();
//test.trackShipmentRequestResponse = new trackShipmentRequestResponse();
//test.trackShipmentRequestResponse.trackingResponse = new trackingResponse();
//test.trackShipmentRequestResponse.trackingResponse.TrackingResponse = new TrackingResponse();
//test.trackShipmentRequestResponse.trackingResponse.TrackingResponse.Response = new Response();
//test.trackShipmentRequestResponse.trackingResponse.TrackingResponse.Response.ServiceHeader = new ServiceHeader();
//List<AWBInfo> items = new List<AWBInfo>();
//AWBInfo @info = new AWBInfo();
//AWBInfoItem aii = new AWBInfoItem()
//{
//    AWBNumber = "1234567890"
//    ,
//    Status = new Status()
//    {
//        ActionStatus = "Success"
//    }
//};

//ShipmentInfo si = new ShipmentInfo();
//si.OriginServiceArea = new ServiceArea()
//{
//    ServiceAreaCode = "DXB",
//                    Description = "Dubai, United Arab Emirates",
//                    FacilityCode = "MEY"
//                };
//si.DestinationServiceArea = new ServiceArea()
//{
//    ServiceAreaCode = "AUH",
//                    Description = "Abu Dhabi, United Arab Emirates"
//                };
//si.ConsigneeName = "Mr. Mohammad";
//                si.ShipperName = "Tarek Fadel";
//                si.Pieces = 1;
//                si.Weight = 0.5M;
//                si.ShipmentDate = DateTime.Now;
//                ShipmentEvent se = new ShipmentEvent();
//EventItem sei = new EventItem();
//sei.Date = DateTime.Now;
//                sei.Time = TimeSpan.FromHours(3);
//                sei.ServiceArea = new ServiceArea() { ServiceAreaCode = "AUH", Description = "Abu Dhabi-AE" };
//sei.ServiceEvent = new ServiceEvent() { EventCode = "PU", Description = "Shipment picked up" };
//se.ArrayOfShipmentEventItem = new List<EventItem>() { sei };
//                si.ShipmentEvent = new List<ShipmentEvent>();
//                si.ShipmentEvent.Add(se);
//                aii.ShipmentInfo = si;
//                PieceInfo pi = new PieceInfo();
//List<PieceInfoItem> piis = new List<PieceInfoItem>();
//PieceInfoItem pii = new PieceInfoItem();
//PieceDetails pd = new PieceDetails();
//pd.AWBNumber = "1234567890";
//                pd.LicensePlate = "JJD123456789012";
//                pd.Weight = 0.5M;
//                pd.WeightUnit = "KG";
//                pd.Depth = 0.0M;
//                pd.Width = 0.0M;
//                pd.Height = 0.0M;
//                pd.ActualDepth = 0.0M;
//                pd.ActualWidth = 0.0M;
//                pd.ActualHeight = 0.0M;
//                pd.DimWeight = 0.0M;
//                pii.PieceDetails = pd;
//                List<PieceEvent> pes = new List<PieceEvent>();
//PieceEvent pe = new PieceEvent();
//pe.ArrayOfPieceEventItem = new List<EventItem>() { sei };
//                pes.Add(pe);
//                pii.PieceEvent = pes;
//                piis.Add(pii);
//                pi.ArrayOfPieceInfoItem = piis;
//                aii.Pieces = new Pieces() { PieceInfo = pi };
//info.ArrayOfAWBInfoItem = aii;
//                items.Add(@info);
//                test.trackShipmentRequestResponse.trackingResponse.TrackingResponse.AWBInfo = items;

//                string teststr = JsonConvert.SerializeObject(test, Formatting.Indented);
