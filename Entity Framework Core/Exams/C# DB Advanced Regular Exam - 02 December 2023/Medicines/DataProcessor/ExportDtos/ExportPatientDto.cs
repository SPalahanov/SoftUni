using Medicines.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Medicines.DataProcessor.ExportDtos
{
    [XmlType("Patient")]
    public class ExportPatientDto
    {
        [XmlElement("Name")]
        public string FullName { get; set; } = null!;

        [XmlElement("AgeGroup")]
        public string AgeGroup { get; set; } = null!;

        [XmlArray("Medicines")]
        public ExportMedicineDto[] Medicines { get; set; } = new ExportMedicineDto[0];

        [XmlAttribute("Gender")]
        public string Gender { get; set; } = null!;
    }
}
