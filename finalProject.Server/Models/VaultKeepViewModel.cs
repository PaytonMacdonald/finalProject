namespace finalProject.Models
{
    public class VaultKeepViewModel
    {
        public string CreatorId { get; set; }
        public int VaultId { get; set; }
        public int KeepId { get; set; }
        public Profile Creator { get; set; }

    }
}