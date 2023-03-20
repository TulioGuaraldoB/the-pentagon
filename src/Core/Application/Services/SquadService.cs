using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Domain.Adapters;
using Core.Domain.Entities;
using Core.Domain.Services;

namespace Core.Application.Services
{
    public class SquadService : ISquadService
    {
        private readonly ISquadRepository _squadRepository;

        public SquadService(ISquadRepository squadRepository)
        {
            _squadRepository = squadRepository;
        }

        public List<Squad> GetAllSquads()
        {
            return _squadRepository.GetAllSquads();
        }

        public Squad GetSquadById(int squadId)
        {
            return _squadRepository.GetSquadById(squadId);
        }

        public async Task CreateSquad(Squad squad)
        {
            await _squadRepository.CreateSquad(squad);
        }
    }
}