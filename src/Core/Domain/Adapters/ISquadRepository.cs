using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Domain.Entities;

namespace Core.Domain.Adapters
{
    public interface ISquadRepository
    {
        List<Squad> GetAllSquads();
        Squad GetSquadById(int squadId);
        Task CreateSquad(Squad squad);
    }
}