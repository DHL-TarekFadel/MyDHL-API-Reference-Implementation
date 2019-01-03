using System.Runtime.Serialization;

namespace GloWS_REST_Library.Objects.Common
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
            [EnumMember(Value = "ALL_CHECK_POINTS")]
            AllCheckpoints,
            [EnumMember(Value = "LAST_CHECK_POINT_ONLY")]
            LastCheckpointOnly
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
            /// <remarks/>
            CFR,

            /// <summary>
            /// Customs, Insurance and Freight
            /// </summary>
            CIF,

            /// <remarks/>
            CIP,

            /// <remarks/>
            CPT,

            /// <remarks/>
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

            /// <remarks/>
            DEQ,

            /// <remarks/>
            DES,

            /// <summary>
            /// Ex-works
            /// </summary>
            EXW,

            /// <remarks/>
            FAS,

            /// <remarks/>
            FCA,

            /// <summary>
            /// Freight On Board
            /// </summary>
            FOB,
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
            VAT
        }
        // ReSharper restore StringLiteralTypo
        // ReSharper restore CommentTypo

        // ReSharper disable CommentTypo
        // ReSharper disable StringLiteralTypo
        public enum ODDOption
        {
            /// <summary>
            /// TV
            /// </summary>
            [EnumMember(Value = "TV")]
            TV,
            /// <summary>
            /// SW
            /// </summary>
            [EnumMember(Value = "SW")]
            SW,
            /// <summary>
            /// SX
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
    }
}
