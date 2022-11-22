using AutoStore.Domain.Entities;
using System.Collections.Generic;

namespace AutoStore.Domain.Abstract
{
    public interface IAutoRepository
    {
        IEnumerable<Auto> Autos { get; }
        void SaveAuto(Auto auto);
        Auto DeleteAuto(int autoId);
    }
}
