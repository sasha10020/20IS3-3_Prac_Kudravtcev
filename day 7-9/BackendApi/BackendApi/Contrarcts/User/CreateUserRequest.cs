namespace BackendApi.Contrarcts.User
{
    public class CreateUserRequest
    {
      public int idUser { get; set; }
        public string userLogin { get; set; } = null!;
        public string userPassword { get; set; } = null!;
        public DateTime regDate { get; set; }
        public bool isDeleted { get; set; } = false;
        
        public int idRole { get; set; } = 0;

    }
}
