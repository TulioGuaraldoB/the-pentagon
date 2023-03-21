using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Domain.Entities;

namespace Core.Domain.Services
{
    public interface ISquadService
    {
        List<Squad> GetAllSquads();
        Squad GetSquadById(int squadId);
        Task CreateSquad(Squad squad);
    }
}