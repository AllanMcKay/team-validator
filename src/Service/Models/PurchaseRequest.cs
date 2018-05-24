using Data.Models;
using System.ComponentModel.DataAnnotations;

namespace Service
{
    public class PurchaseRequest
    {
        public Team CurrentTeam{get;set;}

        [Required]
        public Player PlayerToPurchase{get;set;}
    }
}