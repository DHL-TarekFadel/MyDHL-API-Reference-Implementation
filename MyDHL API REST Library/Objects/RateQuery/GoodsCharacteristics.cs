using MyDHLAPI_REST_Library.Objects.Plumbing.Attributes;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MyDHLAPI_REST_Library.Objects.RateQuery
{
    public class GoodsCharacteristics
    {
        [ValidateObject]
        [CollectionRequired]
        [CollectionLength(999, 1)]
        public List<GoodsCharacteristic> GoodsCharacteristic { get; set; }
    }

    public class GoodsCharacteristic
    {
        /// <summary>
        /// Please contact Express country representative to provide all applicable codes
        /// </summary>
        [Required]
        [StringLength(35)]
        public string CharacteristicCode { get; set; }

        /// <summary>
        /// Value related to the code
        /// </summary>
        [Required]
        [StringLength(50)]
        public string CharacteristicValue { get; set; }
    }
}