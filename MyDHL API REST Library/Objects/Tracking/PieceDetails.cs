using MyDHLAPI_REST_Library.Objects.Plumbing.Attributes;

namespace MyDHLAPI_REST_Library.Objects.Tracking
{
    public class PieceDetails
    {
        [AWBNumber]
        public string AWBNumber { get; set; }

        public string LicensePlate { get; set; }

        public decimal? ActualDepth { get; set; }

        public decimal? ActualWidth { get; set; }

        public decimal? ActualHeight { get; set; }

        public decimal? ActualWeight { get; set; }

        public decimal Depth { get; set; }

        public decimal Width { get; set; }

        public decimal Height { get; set; }

        public decimal Weight { get; set; }

        public string PackageType { get; set; }

        public decimal DimWeight { get; set; }

        public decimal CalculatedActualDimWeight => ((ActualDepth * ActualHeight * ActualWidth) ?? 0) / 5000;

        public decimal CaluclatedDimWeight => (Depth * Height * Width) / 5000;

        public string WeightUnit { get; set; }
    }
}