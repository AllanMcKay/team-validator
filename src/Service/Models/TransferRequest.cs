using Data.Models;
using System.ComponentModel.DataAnnotations;

namespace Service
{
    
    public class TransferRequest
    {
        [Required]
        public Team CurrentTeam{get;set;}

        [Required]
        public Player PlayerOut{get;set;}

        [Required]
        public Player PlayerIn{get;set;}
    }
}