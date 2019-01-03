using System.ComponentModel.DataAnnotations;
using GloWS_REST_Library.Objects.Plumbing.Attributes;

namespace GloWS_REST_Library.Objects.Common {
    public class Dimensions {
        /// <summary>
        /// Piece height/length
        /// </summary>
        [Required]
        [PositiveDecimal]
        public decimal Length { get; set; }

        /// <summary>
        /// Piece width
        /// </summary>
        [Required]
        [PositiveDecimal]
        public decimal Width { get; set; }

        /// <summary>
        /// Piece height/depth
        /// </summary>
        [Required]
        [PositiveDecimal]
        public decimal Height { get; set; }

        public Dimensions() { }

        /// <summary>
        /// Dimensions of the package/piece
        /// </summary>
        /// <param name="height">y-axis length</param>
        /// <param name="width">x-axis length</param>
        /// <param name="depth">z-axis length</param>
        public Dimensions(decimal height, decimal width, decimal depth)
        {
            this.Height = height;
            this.Width = width;
            this.Length = depth;
        }
    }
}
