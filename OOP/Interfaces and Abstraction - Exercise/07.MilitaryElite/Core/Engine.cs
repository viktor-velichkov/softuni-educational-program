using _07.MilitaryElite.Contracts;
using _07.MilitaryElite.Exceptions;
using _07.MilitaryElite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using static _07.MilitaryElite.Contracts.ISpecialisedSoldier;

namespace _07.MilitaryElite.Core
{
    public class Engine
    {
        public void Run()
        {
            string input;
            decimal salary;
            string corps;
            List<ISoldier> soldiers = new List<ISoldier>();
            while ((input = Console.ReadLine()) != "End")
            {
                string[] unitData = input.Split();
                string unitType = unitData[0];
                string unitFirstName = unitData[2];
                string unitLastName = unitData[3];
                int unitId = int.Parse(unitData[1]);
                switch (unitType)
                {
                    case "Private":
                        salary = decimal.Parse(unitData[4]);
                        soldiers.Add(new Private(unitFirstName, unitLastName, unitId, salary));
                        break;
                    case "LieutenantGeneral":
                        salary = decimal.Parse(unitData[4]);
                        LieutenantGeneral Lieutenant = new LieutenantGeneral(unitFirstName, unitLastName, unitId, salary);
                        for (int i = 5; i < unitData.Length; i++)
                        {
                            Lieutenant.Privates.Add((IPrivate)soldiers.Find(x => x is Private && x.Id == int.Parse(unitData[i])));
                        }
                        soldiers.Add(Lieutenant);
                        break;
                    case "Engineer":
                        salary = decimal.Parse(unitData[4]);
                        corps = unitData[5];
                        try
                        {
                            Engineer engineer = new Engineer(unitFirstName, unitLastName, unitId, salary, corps);
                            for (int i = 6; i < unitData.Length; i += 2)
                            {
                                engineer.Repairs.Add(new Repair(unitData[i], int.Parse(unitData[i + 1])));
                            }
                            soldiers.Add(engineer);
                        }
                        catch (InvalidCorpsException)
                        {
                            continue;
                        }
                        break;
                    case "Commando":
                        salary = decimal.Parse(unitData[4]);
                        corps = unitData[5];
                        try
                        {
                            Commando commando = new Commando(unitFirstName, unitLastName, unitId, salary, corps);
                            for (int i = 6; i < unitData.Length; i += 2)
                            {
                                try
                                {
                                    commando.Missions.Add(new Mission(unitData[i], unitData[i + 1]));
                                }
                                catch (InvalidMissionStateException)
                                {
                                    continue;
                                }                                
                            }
                            soldiers.Add(commando);
                        }
                        catch (InvalidCorpsException)
                        {
                            continue;
                        }
                        break;
                    case "Spy":
                        int codeNumber = int.Parse(unitData[4]);
                        soldiers.Add(new Spy(unitFirstName, unitLastName, unitId, codeNumber));
                        break;
                    default:
                        break;
                }
            }
            foreach (var soldier in soldiers)
            {
                Console.WriteLine(soldier.ToString());
            }
        }

    }
}
