using Amir_Store.Application.Interfaces.Context;
using Amir_Store.Common;

namespace Amir_Store.Application.Services.Queries.GetUsers
{
    public class GetUsersService : IGetUsersService
    {
        int rowsCount = 0;
        private readonly IDataBaseContext _context;
        public GetUsersService(IDataBaseContext context)
        {
            _context =  context;
        }

       
        public ResultGetUserDto Execute(RequestGetUserDto request)
        {
            var users = _context.Users.AsQueryable();
            if(!string.IsNullOrWhiteSpace(request.Searchkey))
            {
                users = users.Where(p => p.FullName.Contains(request.Searchkey) && p.Email.Contains(request.Searchkey));
            }

            int rowsCount = 0;
            var usersList =  users.ToPaged(request.Page, 20,out rowsCount ).Select(p => new GetUsersDto
            {
                Email = p.Email,
                FullName = p.FullName,
                Id  = (int)p.Id,
            }).ToList();

            return new ResultGetUserDto { Rows = 0, Users = usersList };


        }

       
    }
}
