namespace Amir_Store.Application.Services.Queries.GetUsers
{
    public class GetUsersDto
    {
        
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }

        public bool IsActive { get; set; }
    }
}
