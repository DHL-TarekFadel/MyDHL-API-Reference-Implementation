using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace MyDHLAPI_REST_Library.Objects.Common
{
    public class Enums
    {
        public enum YesNo
        {
            [EnumMember(Value = "Y")]
            Yes,
            [EnumMember(Value = "N")]
            No
        }

        public enum UnitOfMeasurement
        {
            /// <summary>
            /// Standard International (KG, CM)
            /// </summary>
            SI,
            /// <summary>
            /// Standard (american) Units (LB, IN)
            /// </summary>
            SU,
        }

        public enum ShipmentType
        {
            /// <summary>
            /// Documents / non-dutiable
            /// </summary>
            [EnumMember(Value = "DOCUMENTS")]
            Documents,
            /// <summary>
            /// Dutiable / non-documents
            /// </summary>
            [EnumMember(Value = "NON_DOCUMENTS")]
            NonDocuments
        }

        public enum LevelOfDetails
        {
            [Display(Name = "All (as captured)")]
            [EnumMember(Value = "ALL_CHECK_POINTS")]
            AllCheckpoints,
            [Display(Name = "Last (as captured)")]
            [EnumMember(Value = "LAST_CHECK_POINT_ONLY")]
            LastCheckpointOnly,
            [Display(Name = "All (derived)")]
            [EnumMember(Value = "ALL_CHECKPOINTS")]
            AllDerivedCheckpoints,
            [Display(Name = "Last (derived)")]
            [EnumMember(Value = "LAST_CHECKPOINT_ONLY")]
            LastDerivedCheckpointOnly,
            [Display(Name = "Advance Shipment")]
            [EnumMember(Value = "ADVANCE_SHIPMENT")]
            AdvanceShipment,
            [Display(Name = "BBX Children")]
            [EnumMember(Value = "BBX_CHILDREN")]
            BBXChildren,
            [Display(Name = "No Events")]
            [EnumMember(Value = "SHIPMENT_DETAILS_ONLY")]
            ShipmentDetailsOnly
        }

        public static Dictionary<string, LevelOfDetails> LevelOfDetailsList
        {
            get
            {
                var retval = new Dictionary<string, LevelOfDetails>
                {
                    { "All (as captured)", LevelOfDetails.AllCheckpoints }
                    , { "Last (as captured)", LevelOfDetails.LastCheckpointOnly }
                    , { "All (derived)", LevelOfDetails.AllDerivedCheckpoints }
                    , { "Last (derived)", LevelOfDetails.LastDerivedCheckpointOnly }
                    , { "Advance Shipment", LevelOfDetails.AdvanceShipment }
                    , { "BBX Children", LevelOfDetails.BBXChildren }
                    , { "No Events", LevelOfDetails.ShipmentDetailsOnly }
                };

                return retval;
            }
        }

        public enum PiecesEnabled
        {
            /// <summary>
            /// Both Piece and Shipment
            /// </summary>
            [EnumMember(Value = "B")]
            Both,
            /// <summary>
            /// Shipment Details Only
            /// </summary>
            [EnumMember(Value = "S")]
            ShipmentOnly,
            /// <summary>
            /// Piece Details Only
            /// </summary>
            [EnumMember(Value = "P")]
            PieceOnly
        }

        public enum EstimatedDeliveryDateEnabled
        {
            [EnumMember(Value = "0")]
            No,
            [EnumMember(Value = "1")]
            Yes,
        }

        /// <summary>
        /// Determines who will be paying for the shipment.
        /// </summary>
        public enum PaymentTypes
        {
            [EnumMember(Value = "S")]
            Shipper,
            [EnumMember(Value = "R")]
            Receiver,
            [EnumMember(Value = "T")]
            ThirdParty
        }

        public enum DropOffType
        {
            /// <summary>
            /// There is already a regularly scheduled courier pickup / no pickup required
            /// </summary>
            [EnumMember(Value = "REGULAR_PICKUP")]
            RegularPickup,
            /// <summary>
            /// Also request a pickup for this shipment
            /// </summary>
            [EnumMember(Value = "REQUEST_COURIER")]
            RequestCourier
        }

        // ReSharper disable InconsistentNaming
        public enum TermsOfTrade
        {
            /// <summary>
            /// Cost & Freight
            /// </summary>
            CFR,
            /// <summary>
            /// Cost, Insurance and Freight
            /// </summary>
            CIF,
            /// <summary>
			/// Carriage and Insurance Paid to [consignee address]
			/// </summary>
            CIP,
            /// <summary>
			/// Carriage paid to [consignee address]
			/// </summary>
            CPT,
            /// <summary>
			/// Delivered at Frontier
			/// </summary>
            DAF,
            /// <summary>
            /// Duties and Taxes Paid
            /// </summary>
            DDP,
            /// <summary>
            /// Duties and Taxes Unpaid
            /// </summary>
            DDU,
            /// <summary>
            /// Deliver at place (Duties and Taxes Paid)
            /// </summary>
            DAP,
            /// <summary>
			/// Delivered Ex Quay (duty paid)
			/// </summary>
            DEQ,
            /// <summary>
			/// Delivered Ex Ship-(named port of destination) 
			/// </summary>
            DES,
            /// <summary>
            /// Ex-works
            /// </summary>
            EXW,
            /// <summary>
			/// Free Alongside Ship
			/// </summary>
            FAS,
            /// <summary>
			/// Free Carrier
			/// </summary>
            FCA,
            /// <summary>
            /// Freight On Board
            /// </summary>
            FOB
        }
        // ReSharper restore InconsistentNaming

        // ReSharper disable CommentTypo
        // ReSharper disable StringLiteralTypo
        public enum EPodType
        {
            /// <summary>
            /// epod-summary-esig / epod-summary: Summary ePOD in letter format.
            /// </summary>
            [EnumMember(Value = "epod-summary")]
            Summary,
            /// <summary>
            /// epod-detail-esig / epod-detail: Detailed ePOD in letter format.
            /// </summary>
            [EnumMember(Value = "epod-detail")]
            Detailed,
            /// <summary>
            /// epod-table-summary: Summary ePOD in table format
            /// </summary>
            [EnumMember(Value = "epod-table-summary")]
            SummaryTable,
            /// <summary>
            /// epod-table-detail / epod-table-esig / epod-table: Detailed ePOD in table format.
            /// </summary>
            [EnumMember(Value = "epod-table-detail")]
            DetailedTable,
        }
        // ReSharper restore StringLiteralTypo
        // ReSharper restore CommentTypo

        // ReSharper disable CommentTypo
        // ReSharper disable StringLiteralTypo
        public enum EPodCriterionType
        {
            /// <summary>
            /// EPod Type
            /// </summary>
            [EnumMember(Value = "IMG_CONTENT")]
            ImageContent,
            /// <summary>
            /// PDF
            /// </summary>
            [EnumMember(Value = "IMG_FORMAT")]
            ImageFormat,
            /// <summary>
            /// True/False (default: true)
            /// </summary>
            [EnumMember(Value = "DOC_RND_REQ")]
            IsRenderDocument,
            /// <summary>
            /// True/False (default: true)
            /// </summary>
            [EnumMember(Value = "EXT_REQ")]
            IsExternal,
            /// <summary>
            /// CORE_WB_NO
            /// </summary>
            [EnumMember(Value = "DUPL_HANDL")]
            DuplicateHandling,
            /// <summary>
            /// $INGEST_DATE,D
            /// </summary>
            [EnumMember(Value = "SORT_BY")]
            SortBy,
            /// <summary>
            /// en
            /// </summary>
            [EnumMember(Value = "LANGUAGE")]
            Language
        }
        // ReSharper restore StringLiteralTypo
        // ReSharper restore CommentTypo

        // ReSharper disable CommentTypo
        // ReSharper disable StringLiteralTypo
        public enum EPodCustomerRoleType
        {
            /// <summary>
            /// Payer
            /// </summary>
            [EnumMember(Value = "PY")]
            Payer,
            /// <summary>
            /// Receiver
            /// </summary>
            [EnumMember(Value = "RV")]
            Receiver,
            /// <summary>
            /// Shipper
            /// </summary>
            [EnumMember(Value = "SP")]
            Shipper
        }
        // ReSharper restore StringLiteralTypo
        // ReSharper restore CommentTypo

        // ReSharper disable CommentTypo
        // ReSharper disable StringLiteralTypo
        public enum LabelFormat
        {
            /// <summary>
            /// Portable Document Format (PDF)
            /// </summary>
            [EnumMember(Value = "PDF")]
            PDF,
            /// <summary>
            /// Zebra Programming Language (ZPL)
            /// </summary>
            [EnumMember(Value = "ZPL")]
            ZPL,
            /// <summary>
            /// Eltron Programming Language (EPL)
            /// </summary>
            [EnumMember(Value = "EPL")]
            EPL,
            /// <summary>
            /// iLEAP Word Processing Document (LP2)
            /// </summary>
            [EnumMember(Value = "LP2")]
            LP2
        }
        // ReSharper restore StringLiteralTypo
        // ReSharper restore CommentTypo
        
        // ReSharper disable CommentTypo
        // ReSharper disable StringLiteralTypo
        public enum AccountRole
        {
            /// <summary>
            /// Shipper's Account
            /// </summary>
            [EnumMember(Value = "S")]
            Shipper,
            /// <summary>
            /// Receiver's account
            /// </summary>
            [EnumMember(Value = "R")]
            Receiver,
            /// <summary>
            /// Third party's account
            /// </summary>
            [EnumMember(Value = "T")]
            ThirdParty
        }
        // ReSharper restore StringLiteralTypo
        // ReSharper restore CommentTypo

        // ReSharper disable CommentTypo
        // ReSharper disable StringLiteralTypo
        public enum NumberTypeCode
        {
            /// <summary>
            /// Currently on VAT is acceptaed
            /// </summary>
            [EnumMember(Value = "VAT")]
            VAT,
            /// <summary>
            /// Employer Identifiaction Number
            /// </summary>
            [EnumMember(Value = "EIN")]
            EmployerIDNumber,
            /// <summary>
            /// Goods and Service Tax
            /// </summary>
            [EnumMember(Value = "GST")]
            GST,
            /// <summary>
            /// Social Sercurity Number
            /// </summary>
            [EnumMember(Value = "SSN")]
            SSN,
            /// <summary>
            /// Social Sercurity Number
            /// </summary>
            [EnumMember(Value = "SSN")]
            SocialSecurityNumber,
            /// <summary>
            /// European Union Registration and Identification
            /// </summary>
            [EnumMember(Value = "EOR")]
            EOR,
            /// <summary>
            /// Data Universal Numbering System
            /// </summary>
            [EnumMember(Value = "DUN")]
            DUN,
            /// <summary>
            /// Federal Tax ID
            /// </summary>
            [EnumMember(Value = "FED")]
            FederalTaxID,
            /// <summary>
            /// State Tax ID
            /// </summary>
            [EnumMember(Value = "STA")]
            StateTaxID,
            /// <summary>
            /// Brazil CNPJ/CPF Federal Tax
            /// </summary>
            [EnumMember(Value = "CNP")]
            CNP,
            /// <summary>
            /// Brazil type IE/RG Federal Tax
            /// </summary>
            [EnumMember(Value = "IE")]
            IE,
            /// <summary>
            /// Russia bank details section - INN
            /// </summary>
            [EnumMember(Value = "INN")]
            INN,
            /// <summary>
            /// Russia bank details section - KPP
            /// </summary>
            [EnumMember(Value = "KPP")]
            KPP,
            /// <summary>
            /// Russia bank details section - OGRN
            /// </summary>
            [EnumMember(Value = "OGR")]
            OGRN,
            /// <summary>
            /// Russia bank details section – OKPO
            /// </summary>
            [EnumMember(Value = "OKP")]
            OKPO,
            /// <summary>
            /// Germany Movement Reference Number
            /// </summary>
            [EnumMember(Value = "MRN")]
            MRN
        }
        // ReSharper restore StringLiteralTypo
        // ReSharper restore CommentTypo

        // ReSharper disable CommentTypo
        // ReSharper disable StringLiteralTypo
        public enum ODDOption
        {
            /// <summary>
            /// Deliver to a DHL Express Servicepoint
            /// </summary>
            [EnumMember(Value = "TV")]
            TV,
            /// <summary>
            /// Leave with neighbour
            /// </summary>
            [EnumMember(Value = "SW")]
            SW,
            /// <summary>
            /// Signature release
            /// </summary>
            [EnumMember(Value = "SX")]
            SX
        }
        // ReSharper restore StringLiteralTypo
        // ReSharper restore CommentTypo

        // ReSharper disable CommentTypo
        // ReSharper disable StringLiteralTypo
        public enum ODDLeaveWithType
        {
            /// <summary>
            /// Leave with a neighbour
            /// </summary>
            [EnumMember(Value = "N")]
            Neighbour,
            /// <summary>
            /// Leave with the concierge/security
            /// </summary>
            [EnumMember(Value = "C")]
            Concierge
        }
        // ReSharper restore StringLiteralTypo
        // ReSharper restore CommentTypo

        // ReSharper disable CommentTypo
        // ReSharper disable StringLiteralTypo
        public enum NetworkTypeCode
        {
            /// <summary>
            /// Both Time Definite and Day Definite products will be returned
            /// </summary>
            [EnumMember(Value = "AL")]
            All,
            /// <summary>
            /// Return only Day Definite products
            /// </summary>
            [EnumMember(Value = "DD")]
            DayDefinite,
            /// <summary>
            /// Return only Time Definite products
            /// </summary>
            [EnumMember(Value = "TD")]
            TimeDefinite
        }
        // ReSharper restore StringLiteralTypo
        // ReSharper restore CommentTypo

        // ReSharper disable CommentTypo
        // ReSharper disable StringLiteralTypo
        public enum PackageTypeCode
        {
            ///// <summary>
            ///// 
            ///// </summary>
            //[EnumMember(Value = "1CE")]
            //DayDefinite,
            ///// <summary>
            ///// 
            ///// </summary>
            //[EnumMember(Value = "2BC")]
            //DayDefinite,
            ///// <summary>
            ///// 
            ///// </summary>
            //[EnumMember(Value = "2BP")]
            //DayDefinite,
            /// <summary>
            /// DHL Express Box Type 2 (Flat) [34 x 33 x 6]
            /// </summary>
            [EnumMember(Value = "2BX")]
            DHLBoxType2,
            /// <summary>
            /// DHL Express Box Type 3 [33.7 x 32.2 x 10]
            /// </summary>
            [EnumMember(Value = "3BX")]
            DHLBoxType3,
            /// <summary>
            /// DHL Express Box Type 4 [33.7 x 32.2 x 18]
            /// </summary>
            [EnumMember(Value = "4BX")]
            DHLBoxType4,
            /// <summary>
            /// DHL Express Box Type 5 (Jumbo Small) [34 x 33 x 35]
            /// </summary>
            [EnumMember(Value = "5BX")]
            DHLBoxType5,
            /// <summary>
            /// DHL Express Box Type 6 [41.7 x 35.9 x 36.9]
            /// </summary>
            [EnumMember(Value = "6BX")]
            DHLBoxType6,
            /// <summary>
            /// DHL Express Box Type 7 [48.1 x 40.4 x 38.9]
            /// </summary>
            [EnumMember(Value = "7BX")]
            DHLBoxType7,
            /// <summary>
            /// DHL Express Box Type 8 (Jumbo Large) (33.7x32.2x10)
            /// </summary>
            [EnumMember(Value = "8BX")]
            DHLBoxType8,
            ///// <summary>
            ///// 
            ///// </summary>
            //[EnumMember(Value = "CE1")]
            //DayDefinite,
            /// <summary>
            /// DHL Drawing Tube (Large)
            /// </summary>
            [EnumMember(Value = "TBL")]
            DHLDrawingTubeLarge,
            /// <summary>
            /// DHL Drawing Tube (Small)
            /// </summary>
            [EnumMember(Value = "TBS")]
            DHLDrawingTubeSmall,
            /// <summary>
            /// DHL Wine Box Type 1
            /// </summary>
            [EnumMember(Value = "WB1")]
            DHLWineBoxType1,
            /// <summary>
            /// DHL Wine Box Type 2
            /// </summary>
            [EnumMember(Value = "WB2")]
            DHLWineBoxType2,
            /// <summary>
            /// DHL Wine Box Type 3
            /// </summary>
            [EnumMember(Value = "WB3")]
            DHLWineBoxType3,
            /// <summary>
            /// DHL Wine Box Type 6
            /// </summary>
            [EnumMember(Value = "WB6")]
            DHLWineBoxType6,
            ///// <summary>
            ///// 
            ///// </summary>
            //[EnumMember(Value = "XPD")]
            //DayDefinite,
        }
        // ReSharper restore StringLiteralTypo
        // ReSharper restore CommentTypo

        // ReSharper disable CommentTypo
        // ReSharper disable StringLiteralTypo
        public enum DeliveryType
        {
            /// <summary>
            /// The fastest ("docs") transit time as quoted to the customer at booking or shipment creation. No custom clearance is considered.
            /// </summary>
            [EnumMember(Value = "QDDF")]
            CustomsClearanceNotFactoredIn,
            /// <summary>
            /// Constitutes DHL's service commitment as quoted at booking/shipment creation. QDDc builds in clearance time, and potentially other special operational non-transport component(s), when relevant.
            /// </summary>
            [EnumMember(Value = "QDDC")]
            CustomsClearanceFactoredIn
        }
        // ReSharper restore StringLiteralTypo
        // ReSharper restore CommentTypo

        // ReSharper disable CommentTypo
        // ReSharper disable StringLiteralTypo
        public enum ChargeType
        {
            /// <summary>
            /// Billing currency
            /// </summary>
            [EnumMember(Value = "BILLC")]
            BillingCurrency,
            /// <summary>
            /// Country public rates currency
            /// </summary>
            [EnumMember(Value = "PULCL")]
            PublishedLocalCurrency,
            /// <summary>
            /// Base currency
            /// </summary>
            [EnumMember(Value = "BASEC")]
            BaseCurrency
            /// <summary>
            /// Breakdown item is a discount
            /// </summary>
            //[EnumMember(Value = "DISCOUNT")]
            //Discount,
            /// <summary>
            /// Breakdown item is a tax
            /// </summary>
            //[EnumMember(Value = "TAX")]
            //Tax
        }
        // ReSharper restore StringLiteralTypo
        // ReSharper restore CommentTypo

        // ReSharper disable CommentTypo
        // ReSharper disable StringLiteralTypo
        public enum TotalChargeType
        {
            /// <summary>
            /// Total tax for the shipment
            /// </summary>
            [EnumMember(Value = "STTXA")]
            TotalTax,
            /// <summary>
            /// Total discount for the shipment
            /// </summary>
            [EnumMember(Value = "STDIS")]
            TotalDiscount,
            /// <summary>
            /// Net shipment / weight charge
            /// </summary>
            [EnumMember(Value = "SPRQT")]
            ShipmentCharges
        }
        // ReSharper restore StringLiteralTypo
        // ReSharper restore CommentTypo

        // ReSharper disable CommentTypo
        // ReSharper disable StringLiteralTypo
        public enum ItemChargeType
        {
            [EnumMember(Value = "DUTY")]
            Duty,
            [EnumMember(Value = "TAX")]
            Tax,
            [EnumMember(Value = "FEE")]
            Fee
        }
        // ReSharper restore StringLiteralTypo
        // ReSharper restore CommentTypo

        // ReSharper disable CommentTypo
        // ReSharper disable StringLiteralTypo
        public enum ChargeTypeCode
        {
            [EnumMember(Value = "XCH")]
            ExtraCharge,
            [EnumMember(Value = "FEE")]
            Fee,
            [EnumMember(Value = "SCH")]
            Surcharge,
            [EnumMember(Value = "NRI")]
            NonRevenueItem,
            /// <summary>
            /// Used when the ChargeTypeCode is not accounted for (handles new types of charge codes)
            /// </summary>
            [EnumMember(Value = "Unknown")]
            Unknown
        }
        // ReSharper restore StringLiteralTypo
        // ReSharper restore CommentTypo


        // ReSharper disable CommentTypo
        // ReSharper disable StringLiteralTypo
        public enum ShipmentReferenceType
        {
            /// <summary>
            /// Receiver/Consignee
            /// </summary>
            [EnumMember(Value = "AAO")]
            Receiver,
            /// <summary>
            /// Shipper/Consignor
            /// </summary>
            [EnumMember(Value = "CU")]
            Consignor,
            /// <summary>
            /// Freight Forwarder
            /// </summary>
            [EnumMember(Value = "FF")]
            FreightForwarder,
            /// <summary>
            /// Freight bill number for ## ex works invoice number ##
            /// </summary>
            [EnumMember(Value = "FN")]
            FreightBillNumber,
            /// <summary>
            /// Inbound center reference number
            /// </summary>
            [EnumMember(Value = "IBC")]
            InboundCenter,
            /// <summary>
            /// load list reference for ## 10-digit Shipment ID ##
            /// </summary>
            [EnumMember(Value = "LLR")]
            LoadList,
            /// <summary>
            /// Outbound center reference number for ## SHIPMENT IDENTIFIER (COUNTRY OF ORIGIN) ##
            /// </summary>
            [EnumMember(Value = "OBC")]
            OutboundCenter,
            /// <summary>
            /// Pickup request number for ## BOOKING REFERENCE NUMBER ##
            /// </summary>
            [EnumMember(Value = "PRN")]
            PickupRequestNumber,
            /// <summary>
            /// Local payer account number
            /// </summary>
            [EnumMember(Value = "ACP")]
            LocalPayerAccountNumber,
            /// <summary>
            /// Local shipper account number
            /// </summary>
            [EnumMember(Value = "ACS")]
            LocalShipperAccountNumber,
            /// <summary>
            /// Local receiver account number
            /// </summary>
            [EnumMember(Value = "ACR")]
            LocalReceiverAccountNumber,
            /// <summary>
            /// Customs declaration number
            /// </summary>
            [EnumMember(Value = "CDN")]
            CustomsDeclarationNumber,
            /// <summary>
            /// Eurolog 15-digit shipment ID
            /// </summary>
            [EnumMember(Value = "STD")]
            EurologShimpentID,
            /// <summary>
            /// Buyers order number
            /// </summary>
            [EnumMember(Value = "CO")]
            OrderNumber
        }
        // ReSharper restore StringLiteralTypo
        // ReSharper restore CommentTypo


        // ReSharper disable CommentTypo
        // ReSharper disable StringLiteralTypo
        public enum PrinterDPI
        {
            [EnumMember(Value = "200")]
            DPI_200, 
            [EnumMember(Value = "300")]
            DPI_300
        }
        // ReSharper restore StringLiteralTypo
        // ReSharper restore CommentTypo


        // ReSharper disable CommentTypo
        // ReSharper disable StringLiteralTypo
        public enum ISO3DigitLanguageCodes
        {
            [EnumMember(Value = "eng")]
            English,
            [EnumMember(Value = "bul")]
            Bugalrian,
            [EnumMember(Value = "cze")]
            Czech,
            [EnumMember(Value = "dan")]
            Danish,
            [EnumMember(Value = "ger")]
            German,
            [EnumMember(Value = "gre")]
            Greek,
            [EnumMember(Value = "est")]
            Estonian,
            [EnumMember(Value = "fin")]
            Finnish,
            [EnumMember(Value = "fre")]
            French,
            [EnumMember(Value = "hun")]
            Hungaria,
            [EnumMember(Value = "ice")]
            Icelandic,
            [EnumMember(Value = "ita")]
            Italian,
            [EnumMember(Value = "lit")]
            Lithuanian,
            [EnumMember(Value = "lav")]
            Latvian,
            [EnumMember(Value = "dut")]
            Dutch,
            [EnumMember(Value = "nno")]
            Norwegian,
            [EnumMember(Value = "pol")]
            Polish,
            [EnumMember(Value = "por")]
            Portuguse,
            [EnumMember(Value = "rum")]
            Romanian,
            [EnumMember(Value = "rus")]
            Russian,
            [EnumMember(Value = "slv")]
            Slovenian,
            [EnumMember(Value = "slo")]
            Slovak,
            [EnumMember(Value = "spa")]
            Spanish
        }
        // ReSharper restore StringLiteralTypo
        // ReSharper restore CommentTypo


        // ReSharper disable CommentTypo
        // ReSharper disable StringLiteralTypo
        public enum CustomsInvoiceType
        {
            [EnumMember(Value = "COMMERCIAL_INVOICE")]
            CommercialInvoice,
            [EnumMember(Value = "PROFORMA_INVOICE")]
            ProformaInvoice
        }
        // ReSharper restore StringLiteralTypo
        // ReSharper restore CommentTypo


        // ReSharper disable CommentTypo
        // ReSharper disable StringLiteralTypo
        public enum LogoImageFormat
        {
            [EnumMember(Value = "GIF")]
            GIF,
            [EnumMember(Value = "JPEG")]
            JPEG,
            [EnumMember(Value = "PNG")]
            PNG
        }
        // ReSharper restore StringLiteralTypo
        // ReSharper restore CommentTypo


        // ReSharper disable CommentTypo
        // ReSharper disable StringLiteralTypo
        public enum CustomerBarcodeType
        {
            [EnumMember(Value = "39")]
            Code39,
            [EnumMember(Value = "93")]
            Code93,
            [EnumMember(Value = "128")]
            Code128
        }
        // ReSharper restore StringLiteralTypo
        // ReSharper restore CommentTypo


        // ReSharper disable CommentTypo
        // ReSharper disable StringLiteralTypo
        public enum ExportReasonType
        {
            [EnumMember(Value = "PERMANENT")]
            Permanent,
            [EnumMember(Value = "TEMPORARY")]
            Temporary,
            [EnumMember(Value = "RETURN")]
            Return
        }
        // ReSharper restore StringLiteralTypo
        // ReSharper restore CommentTypo


        // ReSharper disable CommentTypo
        // ReSharper disable StringLiteralTypo
        public enum CustomsStatisticalUnitOfMeasurement
        {
            [EnumMember(Value = "BOX")]
            Box,
            [EnumMember(Value = "2GM")]
            Centigram,
            [EnumMember(Value = "2M")]
            Centimeters,
            [EnumMember(Value = "2M3")]
            CubicCentimeters,
            [EnumMember(Value = "3M3")]
            CubicFeet,
            [EnumMember(Value = "M3")]
            CubicMeters,
            [EnumMember(Value = "DPR")]
            DozenPairs,
            [EnumMember(Value = "DOZ")]
            Dozen,
            [EnumMember(Value = "2NO")]
            Each,
            [EnumMember(Value = "PCS")]
            Pieces,
            [EnumMember(Value = "GM")]
            Grams,
            [EnumMember(Value = "GRS")]
            Gross,
            [EnumMember(Value = "KG")]
            Kilograms,
            [EnumMember(Value = "L")]
            Liters,
            [EnumMember(Value = "M")]
            Meters,
            [EnumMember(Value = "3GM")]
            Milligrams,
            [EnumMember(Value = "3L")]
            Milliliters,
            [EnumMember(Value = "X")]
            NoUnitRequired,
            [EnumMember(Value = "NO")]
            Number,
            [EnumMember(Value = "2KG")]
            Ounces,
            [EnumMember(Value = "PRS")]
            Pairs,
            [EnumMember(Value = "2L")]
            Gallons,
            [EnumMember(Value = "3KG")]
            Pounds,
            [EnumMember(Value = "CM2")]
            SquareCentimeters,
            [EnumMember(Value = "2M2")]
            SquareFeet,
            [EnumMember(Value = "3M2")]
            SquareInches,
            [EnumMember(Value = "M2")]
            SquareMeters,
            [EnumMember(Value = "4M2")]
            SquareYards,
            [EnumMember(Value = "3M")]
            Yards
        }
        // ReSharper restore StringLiteralTypo
        // ReSharper restore CommentTypo


        // ReSharper disable CommentTypo
        // ReSharper disable StringLiteralTypo
        public enum AdditionalImageType
        {
            [EnumMember(Value = "INV")]
            Invoice,
            [EnumMember(Value = "CIN")]
            CommercialInvoice,
            [EnumMember(Value = "PNV")]
            ProformaInvoice,
            [EnumMember(Value = "COO")]
            CertificateOfOrigin,
            [EnumMember(Value = "NAF")]
            NAFTACertificateOfOrigin,
            [EnumMember(Value = "DCL")]
            CustomsDeclaration,
            /// <summary>
            /// Air Waybill and Waybill/archive Document
            /// </summary>
            [EnumMember(Value = "AWB")]
            Waybill
        }
        // ReSharper restore StringLiteralTypo
        // ReSharper restore CommentTypo


        // ReSharper disable CommentTypo
        // ReSharper disable StringLiteralTypo
        public enum AdditionalImageFormat
        {
            [EnumMember(Value = "PDF")]
            PDF,
            [EnumMember(Value = "PNG")]
            PNG,
            [EnumMember(Value = "TIFF")]
            TIFF,
            [EnumMember(Value = "GIF")]
            GIF,
            [EnumMember(Value = "JPEG")]
            JPEG
        }
        // ReSharper restore StringLiteralTypo
        // ReSharper restore CommentTypo


        // ReSharper disable CommentTypo
        // ReSharper disable StringLiteralTypo
        public enum ShipmentNotificationMethods
        {
            [EnumMember(Value = "EMAIL")]
            EMail
        }
        // ReSharper restore StringLiteralTypo
        // ReSharper restore CommentTypo


        // ReSharper disable CommentTypo
        // ReSharper disable StringLiteralTypo
        public enum ShipmentNotificationLanguages
        {
            [EnumMember(Value = "eng")]
            English,
            [EnumMember(Value = "zho")]
            TraditionalChinese,
            [EnumMember(Value = "chi")]
            SimplifiedChinese
        }
        // ReSharper restore StringLiteralTypo
        // ReSharper restore CommentTypo


        // ReSharper disable CommentTypo
        // ReSharper disable StringLiteralTypo
        public enum ShipmentNotificationLanguageCountryCode
        {
            [EnumMember(Value = "US")]
            US,
            [EnumMember(Value = "GB")]
            UK,
            [EnumMember(Value = "CN")]
            CN
        }
        // ReSharper restore StringLiteralTypo
        // ReSharper restore CommentTypo


        // ReSharper disable CommentTypo
        // ReSharper disable StringLiteralTypo
        public enum LandedCostShipmentPurpose
        {
            [EnumMember(Value = "COMMERCIAL")]
            BusinessToBusiness,
            [EnumMember(Value = "PERSONAL")]
            BusinessToConsumer
        }
        // ReSharper restore StringLiteralTypo
        // ReSharper restore CommentTypo


        // ReSharper disable CommentTypo
        // ReSharper disable StringLiteralTypo
        public enum LandedCostModeOfTransportType
        {
            [EnumMember(Value = "AIR")]
            Air,
            [EnumMember(Value = "OCEAN")]
            Sea,
            [EnumMember(Value = "GROUND")]
            Road
        }
        // ReSharper restore StringLiteralTypo
        // ReSharper restore CommentTypo


        // ReSharper disable CommentTypo
        // ReSharper disable StringLiteralTypo
        public enum LandedCostCarrierName
        {
            [EnumMember(Value = "DHL")]
            DHL,
            [EnumMember(Value = "FEDEX")]
            FedEx,
            [EnumMember(Value = "POST")]
            Post,
            [EnumMember(Value = "TNT")]
            TNT,
            [EnumMember(Value = "UPS")]
            UPS,
            [EnumMember(Value = "OTHERS")]
            Other
        }
        // ReSharper restore StringLiteralTypo
        // ReSharper restore CommentTypo


        // ReSharper disable CommentTypo
        // ReSharper disable StringLiteralTypo
        public enum LandedCostQuantityType
        {
            [EnumMember(Value = "BOX")]
            Box,
            [EnumMember(Value = "PRT")]
            PartOrArticle
        }
        // ReSharper restore StringLiteralTypo
        // ReSharper restore CommentTypo


        // ReSharper disable CommentTypo
        // ReSharper disable StringLiteralTypo
        public enum LandedCostChargeType
        {
            [EnumMember(Value = "FREIGHT")]
            Freight,
            [EnumMember(Value = "ADDITIONAL_CHARGE")]
            AdditionalCharge,
            [EnumMember(Value = "INSURANCE")]
            Insurance
        }
        // ReSharper restore StringLiteralTypo
        // ReSharper restore CommentTypo


        // ReSharper disable CommentTypo
        // ReSharper disable StringLiteralTypo
        public enum PickupLocationType
        {
            [EnumMember(Value = "COMMERCIAL")]
            Commercial,
            [EnumMember(Value = "RESIDENTIAL")]
            Residential
        }
        // ReSharper restore StringLiteralTypo
        // ReSharper restore CommentTypo


        // ReSharper disable CommentTypo
        // ReSharper disable StringLiteralTypo
        public enum DeletePickupRequestReason
        {
            [EnumMember(Value = "001")]
            PackageNotReady,
            [EnumMember(Value = "002")]
            RatesTooHigh,
            [EnumMember(Value = "003")]
            TransitTimeTooSlow,
            [EnumMember(Value = "004")]
            DroppedOffInPerson,
            [EnumMember(Value = "005")]
            CommitmentTimeNotMet,
            [EnumMember(Value = "006")]
            ReasonNotGiven,
            [EnumMember(Value = "007")]
            OtherUnspecified,
            [EnumMember(Value = "008")]
            PickupModified
        }
        // ReSharper restore StringLiteralTypo
        // ReSharper restore CommentTypo

    }
}
