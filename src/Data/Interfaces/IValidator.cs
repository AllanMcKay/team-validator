using System.Collections.Generic;
using Data.Models;

namespace Data.Interfaces
{
    public interface IValidator
    {
        ValidationResult ValidatePlayerPurchase(Team team, Player player);
        ValidationResult ValidateTransfer(Team team, Player playerIn, Player playerOut);
        ValidationResult Validate(Team team);
    }
}