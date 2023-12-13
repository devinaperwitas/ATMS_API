using System.ComponentModel.DataAnnotations;

namespace ATMS_API.Models
{
    public class AlatModel
    {
        public int id { get; set; }
        public int jen_id { get; set; }
        public string ala_nama { get; set; }
        public DateTime ala_tanggal { get; set; }
        public int ala_jmlmasuk { get; set; }
        public int ala_jmlkeluar { get; set; }
        public int ala_sisaalat { get; set; }
        public int ala_status { get; set; }
        public string ala_created_by { get; set; }
        public DateTime ala_created_date { get; set; }
        public string ala_modified_by { get; set; }
        public DateTime ala_modified_date { get; set; }

    }
}
