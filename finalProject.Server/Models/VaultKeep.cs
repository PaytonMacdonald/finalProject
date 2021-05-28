using System;
using finalProject.Models;

namespace finalProject.Server.Models
{
    public class VaultKeep
    {
        public int Id { get; set; }
        public string CreatorId { get; set; }
        public int VaultId { get; set; }
        public int KeepId { get; set; }
        // NOTE Mick said this needs to go here
        public Profile Creator { get; set; }
    }
}
