namespace MyDHLAPI_REST_Library.Objects.RateQuery.Response {
    public class Charge {
        public string ChargeType { get; set; }

        public decimal? ChargeAmount { get; set; }

        /// <inheritdoc />
        public override string ToString()
        {
            return $"{ChargeType} : {ChargeAmount}";
        }
    }
}