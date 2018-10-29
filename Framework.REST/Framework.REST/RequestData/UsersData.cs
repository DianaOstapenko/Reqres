using System.Collections.Generic;

namespace Framework.REST.RequestData
{
    public class UsersDto
    {
        public string Page { get; set; }
        public int Total { get; set; }
        public List<UserDto> Data { get; set; }
        public int TotalPages { get; set; }
    }

    public class UserDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Avatar { get; set; }
    }
    public class UserRequest
    {
        public string Name { get; set; }
        public string Job { get; set; }
    }

    public class UserResponse
    {
        public string Name { get; set; }
        public string Job { get; set; }
        public int Id { get; set; }
        public string CreatedAt { get; set; }
        public string UpdatedAt { get; set; }
    }
}