using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataRepository
{
    public class Luat
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public string ma_luat { get; set; }
        public string ten_luat { get; set; }
        public string noi_dung { get; set; }
        public DateTime ngay_ban_hanh { get; set; }
        public int muc_xu_phat { get; set; }

    }
}
