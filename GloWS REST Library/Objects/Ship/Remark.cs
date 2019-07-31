using System.ComponentModel.DataAnnotations;

namespace MyDHLAPI_REST_Library.Objects.Ship
{
    public class Remark
    {
        [Required]
        public string RemarkDescription { get; set; }
    }
}