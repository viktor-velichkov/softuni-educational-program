using System;
using System.Collections.Generic;
using System.Text;

namespace _05.FootballTeamGenerator.Common
{
    public class GlobalConstants
    {
        public const string InvalidNameExceptionMessage = "A name should not be empty.";
        public const string InvalidStatExceptionMessage = "{0} should be between 0 and 100.";
        public const string MissingPlayerExceptionMessage = "Player {0} is not in {1} team.";
        public const string NotExistingTeamExceptionMessage = "Team {0} does not exist.";

    }
}
