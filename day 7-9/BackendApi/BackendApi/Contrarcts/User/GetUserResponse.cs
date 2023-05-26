using Microsoft.AspNetCore.Identity;

namespace BackendApi.Contrarcts.User
{
    public class GetUserResponse
    {
        public int idUser { get; set; }
        public string userLogin { get; set; } 
        public string userPassword { get; set; }
        public DateTime regDate { get; set; }
        public bool isDeleted { get; set; }

        public int idRole { get; set; }

    }
}
