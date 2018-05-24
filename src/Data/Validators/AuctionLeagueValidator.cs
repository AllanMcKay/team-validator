using Data.Interfaces;
using Data.Models;
using Data.Enums;
using System.Collections.Generic;
using System;
using System.Linq;

namespace Data.Validators
{
    public class AuctionLeagueValidator : IValidator
    {
        private static readonly int _MinDefenders=3;
        private static readonly int _MinMidfielders=3;
        private static readonly int _MinForwards=3;

        public ValidationResult ValidateTransfer(Team team,Player playerIn, Player playerOut){
            throw new NotImplementedException();
        }

        public ValidationResult Validate(Team team)
        {
            throw new NotImplementedException();
        }

        public ValidationResult ValidatePlayerPurchase(Team team,Player playerIn)
        {
            List<ValidationProblem> problems = new List<ValidationProblem>();

            ValidationProblem formationError = ValidateFormation(team,playerIn);
            if(formationError!=null)problems.Add(formationError);

            ValidationProblem teamPlayerCountError = ValidateTeamPlayerCount(team,playerIn);
            if(teamPlayerCountError!=null) problems.Add(teamPlayerCountError);

            return new ValidationResult(problems);
        }

        private ValidationProblem ValidateFormation(Team team,Player player)
        {
            switch (player.Position)
            {
                case Position.GoalKeeper:
                    if (team.Players.Exists(p => p.Position == Position.GoalKeeper)) { return new ValidationProblem("Cannot have more than 1 goalkeeper"); }
                    break;
                case Position.Manager:
                    if (team.Players.Exists(p => p.Position == Position.Manager)) { return new ValidationProblem("Cannot have more than 1 Manager"); }
                    break;
                case Position.Defender:
                    if (team.Players.Where(p => p.Position == Position.Manager).Count()>4) { return new ValidationProblem("Cannot have more than 5 defenders"); }
                    break;
                case Position.Midfielder:
                    if (team.Players.Where(p => p.Position == Position.Midfielder).Count() > 4) { return new ValidationProblem("Cannot have more than 5 midfielders"); }
                    break;
                case Position.Forward:
                    if (team.Players.Where(p => p.Position == Position.Forward).Count() > 2) { return new ValidationProblem("Cannot have more than 3 forwards"); }
                    break;
            }

            if (team.Players.Count == 11)
            {
                if (!team.Players.Exists(p => p.Position == Position.GoalKeeper) && player.Position != Position.GoalKeeper) { return new ValidationProblem("One space left and needs a goalkeeper"); }
                if (!team.Players.Exists(p => p.Position == Position.Manager) && player.Position != Position.Manager) { return new ValidationProblem("One space left and needs a Manager"); }
            }

            var OutfieldPlayerCount = team.Players.Where(p => p.Position != Position.Manager && p.Position != Position.GoalKeeper).Count();
            var MidfielderCount = team.Players.Where(p => p.Position == Position.Midfielder).Count();
            var ForwardCount = team.Players.Where(p => p.Position == Position.Forward).Count();
            var DefenderCount = team.Players.Where(p => p.Position == Position.Defender).Count();

            if((_MinMidfielders-MidfielderCount)>(9-OutfieldPlayerCount) && player.Position!=Position.Midfielder) { return new ValidationProblem("Needs midfielders"); }
            if ((_MinDefenders - DefenderCount) > (9 - OutfieldPlayerCount) && player.Position != Position.Defender) { return new ValidationProblem("Needs defenders"); }
            if ((_MinForwards - ForwardCount) > (9 - OutfieldPlayerCount) && player.Position != Position.Forward) { return new ValidationProblem("Needs forward"); }

            return null;
        }

        public ValidationProblem ValidateTeamPlayerCount(Team team,Player player)
        {
            if (player.Position == Position.Manager) return null;
            int TeamToAdd = player.PLTeam.ID;
            if (team.Players.Where(p => p.PLTeam.ID == TeamToAdd && p.Position!=Position.Manager).Count() > 2) return new ValidationProblem("TeamLimit","Cannot have more than 3 players from the same team");
            return null;
        }
    }
    
}