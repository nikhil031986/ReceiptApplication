namespace ReceiptEntity
{
    public class EnUserDetails
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public int IsAdmin { get; set; }
        public int IsEdit { get; set; }
        public int IsDelete { get; set; }
        public EnUserDetails()
        { }
        public EnUserDetails(int userId, string userName, string password, int isAdmin, int isEdit, int isDelete)
        {
            UserId = userId;
            UserName=userName;
            Password=password;
            IsAdmin = isAdmin;
            IsEdit = isEdit;
            IsDelete = isDelete;
        }
    }
}
