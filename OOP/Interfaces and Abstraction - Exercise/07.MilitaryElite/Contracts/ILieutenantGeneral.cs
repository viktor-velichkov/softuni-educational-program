using System.Collections.Generic;

namespace _07.MilitaryElite.Contracts
{
    public interface ILieutenantGeneral:IPrivate
    {
        public List<IPrivate> Privates { get; set; }
    }
}
