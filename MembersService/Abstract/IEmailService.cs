﻿using Members.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MembersService.Abstract
{
    public interface IEmailService
    {
        void SendEmail(EmailContract emailContract);
    }
}
