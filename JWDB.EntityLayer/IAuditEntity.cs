using System;
using System.Collections.Generic;
using System.Text;

namespace JWDB.EntityLayer
{
    public interface IAuditEntity : IEntity
    {
        String RegId { get; set; }

        DateTime RegDtm { get; set; }

        String UpdId { get; set; }

        DateTime? UpdDtm { get; set; }
    }
}
