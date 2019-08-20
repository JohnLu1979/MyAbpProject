﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CXD.Account.DTO
{
    public class AccountInput
    {
        public virtual string AccountName { get; set; }

        public virtual string UserName { get; set; }
        public virtual string Password { get; set; }

        public virtual int IMEICode { get; set; }
        public virtual bool IsActivated { get; set; }
    }
}
