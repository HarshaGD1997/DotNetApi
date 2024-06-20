using System;

namespace DotNetApiCreate.Dtos
{
    //making class partial to have easy access to modify model
    //Dto Data Transfer Object
    public partial class UserDto
    {
        public string FirstName { get; set; } = "";
        public string LastName { get; set; } = "";
        public string Email { get; set; } = "";
        public string Gender { get; set; } = "";
        public bool Active { get; set; }

    }
}