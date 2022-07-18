using _05.FootballTeamGenerator.Common;
using _05.FootballTeamGenerator.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.FootballTeamGenerator.Core
{
    public class Engine
    {
        private List<Player> players = new List<Player>();
        private List<Team> teams = new List<Team>();
        public void Run()
        {
            string input;
            string playerName;
            while ((input = Console.ReadLine()) != "END")
            {
                try
                {
                    string[] inputData = input.Split(';', StringSplitOptions.RemoveEmptyEntries).ToArray();
                    string command = inputData[0];
                    string teamName = inputData[1];
                    Team currentTeam = teams.Find(x => x.Name == teamName);
                    switch (command)
                    {
                        case "Team":
                            teams.Add(new Team(teamName));
                            break;
                        case "Add":
                            playerName = inputData[2];
                            int playerEndurance = int.Parse(inputData[3]);
                            int playerSprint = int.Parse(inputData[4]);
                            int playerDribble = int.Parse(inputData[5]);
                            int playerPassing = int.Parse(inputData[6]);
                            int playerShooting = int.Parse(inputData[7]);
                            if (currentTeam == null)
                            {
                                throw new ArgumentException(String.Format(GlobalConstants.NotExistingTeamExceptionMessage, teamName));
                            }
                            currentTeam.AddPlayer(new Player(playerName, playerEndurance, playerSprint, playerDribble, playerPassing, playerShooting));
                            break;
                        case "Remove":
                            playerName = inputData[2];
                            if (currentTeam == null)
                            {
                                throw new ArgumentException(String.Format(GlobalConstants.NotExistingTeamExceptionMessage, teamName));
                            }
                            else if (!currentTeam.TeamPlayers.Select(x => x.Name).Contains(playerName))
                            {
                                throw new ArgumentException(String.Format(GlobalConstants.MissingPlayerExceptionMessage, playerName, currentTeam.Name));
                            }
                            else
                            {
                                Player currentPlayer = currentTeam.TeamPlayers.Find(x => x.Name == playerName);
                                currentTeam.RemovePlayer(currentPlayer);
                            }
                            break;
                        case "Rating":
                            if (currentTeam == null)
                            {
                                throw new ArgumentException(String.Format(GlobalConstants.NotExistingTeamExceptionMessage, teamName));
                            }
                            Console.WriteLine($"{currentTeam.Name} - {currentTeam.Rating}");
                            break;
                        default:
                            break;
                    }
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                }

            }
        }
    }
}
