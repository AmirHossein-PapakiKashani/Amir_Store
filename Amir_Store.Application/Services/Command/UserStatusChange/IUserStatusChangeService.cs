using Amir_Store.Application.Interfaces.Context;
using Amir_Store.Common.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amir_Store.Application.Services.Command.UserStatusChange
{
    public interface IUserStatusChangeService
    {
        ResultDto Execute(long  userId);
    }

    public class UserStatusChangeService : IUserStatusChangeService
    {
        public readonly IDataBaseContext _context;
        public UserStatusChangeService(IDataBaseContext context)
        {
            _context = context;
        }

        public ResultDto Execute(long userId)
        {
            var user = _context.Users.Find(userId);
            if (user == null)
            {
                return new ResultDto { IsSuccess = false, Message = "کاربر یافت نشد" };
            }

            user.IsActive = !user.IsActive;
            _context.SaveChanges();
            string userstate = user.IsActive == true ? "فعال" : "غیرفعال";
            return new ResultDto { IsSuccess =  true, Message = $"کاربر با موفقیت {userstate} شد!" };
        }

    }
}
