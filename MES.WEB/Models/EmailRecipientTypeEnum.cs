using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace MES.Web.Models
{
    public enum EmailRecipientTypeEnum
    {
        CreatedUser = 1,
        AssignedUser,
        AssignedGroup,
        SelectUser,
        SelectGroup,
    }
}
