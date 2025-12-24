using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SistemAntrianAlat.Models
{
    public class Pengajuan
    {
        public int PengajuanId { get; set; }
        public string UnitKerja { get; set; }
        public string Alat { get; set; }
        public string Alasan { get; set; }
        public string Status { get; set; }
        public DateTime TglPengajuan { get; set; }

    }
}