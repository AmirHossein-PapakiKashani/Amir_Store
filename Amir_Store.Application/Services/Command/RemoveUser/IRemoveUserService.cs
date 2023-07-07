using Amir_Store.Common.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Amir_Store.Common;

namespace Amir_Store.Application.Services.Command.RemoveUser
{
    public interface IRemoveUserService
    {
        ResultDto Execute(long UserId);
    }

}
