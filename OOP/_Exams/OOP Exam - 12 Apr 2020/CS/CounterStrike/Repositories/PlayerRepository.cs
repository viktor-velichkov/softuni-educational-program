using CounterStrike.Models.Players.Contracts;
using CounterStrike.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using CounterStrike.Utilities.Messages;

namespace CounterStrike.Repositories
{
    public class PlayerRepository : IPlayerRepository
    {
        private ICollection<IPlayer> models;
        public PlayerRepository()
        {
            this.models = new List<IPlayer>();
        }
        public IReadOnlyCollection<IPlayer> Models => (IReadOnlyCollection<IPlayer>)this.models;

        public void Add(IPlayer model)
        {
            if (model == null)
            {
                throw new ArgumentException(ExceptionMessages.InvalidPlayerRepository);
            }
            this.models.Add(model);
        }

        public IPlayer FindByName(string name)
        {
            return this.models.FirstOrDefault(x => x.Username == name);
        }

        public bool Remove(IPlayer model)
        {
            return this.models.Remove(model);
        }
    }
}
