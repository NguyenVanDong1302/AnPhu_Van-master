using Client.Core.Data.Entities.Validation;
using Client.Core.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace idn.AnPhu.Biz.Models
{
    //internal class AppDicDomain
    //{
    //}

    public class AppDicDomain : EntityBase
    {
        [Length(50)]
        [DataColum]
        [DataColumEx("Domain_Code")]
        public string Domain_Code { get; set; }

        [Length(150)]
        [DataColum]
        [DataColumEx("Item_Code")]
        public string Item_Code { get; set; }

        [DataColum]
        [DataColumEx("Item_Value")]
        public string Item_Value { get; set; }

        [DataColum]
        [DataColumEx("Item_Order")]
        public int Item_Order { get; set; }

        [DataColum]
        [DataColumEx("Is_Active")]
        public bool Is_Active { get; set; }

        [DataColum]
        public string Image { get; set; }

    }
}
