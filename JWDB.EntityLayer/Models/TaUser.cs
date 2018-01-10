using System;
using System.Collections.Generic;

namespace JWDB.EntityLayer.Models
{
    public partial class TaUser : IAuditEntity
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string UserPw { get; set; }
        public string UserNm { get; set; }
        public string Tel { get; set; }
        public string Hp { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public DateTime RegDtm { get; set; }
        public string RegId { get; set; }
        public DateTime? UpdDtm { get; set; }
        public string UpdId { get; set; }
    }
}
