namespace MyDHLAPI_Test_App.Objects
{
    public class DefaultPiece
    {
        public int PieceID { get; set; }
        public decimal Weight { get; set; }
        public int? Height { get; set; }
        public int? Width { get; set; }
        public int? Depth { get; set; }
        public string WeightUnit { get; set; }
        public string DimUnit { get; set; }
        public string PieceContents { get; set; }
    }
}