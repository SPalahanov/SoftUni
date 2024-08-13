using Boardgames.Data.Models;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

using static Boardgames.Data.DataConstraints;

namespace Boardgames.DataProcessor.ImportDto
{
    [XmlType(nameof(Boardgame))]
    //[XmlType("Boardgame")]
    public class ImportBoardgameDto
    {
        //[XmlElement("Name")]
        [XmlElement(nameof(Name))]
        [MinLength(BoardgameNameMinLength)]
        [MaxLength(BoardgameNameMaxLength)]
        public string Name { get; set; } = null!;

        [XmlElement(nameof(Rating))]
        [Range(BoardgameRatingMinValue, BoardgameRatingMaxValue)]
        public double Rating { get; set; }

        [XmlElement(nameof(YearPublished))]
        [Range(BoardgameYearPublishedMinValue, BoardgameYearPublishedMaxValue)]
        public int YearPublished { get; set; }

        [XmlElement(nameof(CategoryType))]
        public int CategoryType { get; set; }

        [XmlElement(nameof(Mechanics))]
        public string Mechanics { get; set; } = null!;
    }
}
