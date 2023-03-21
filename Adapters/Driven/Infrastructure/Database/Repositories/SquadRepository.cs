using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Adapters.Driven.Infrastructure.Database.Context;
using Core.Domain.Adapters;
using Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Adapters.Driven.Infrastructure.Database.Repositories
{
    public class SquadRepository : ISquadRepository
    {
        private readonly DatabaseContext _db;

        public SquadRepository(DatabaseContext db)
        {
            _db = db;
        }

        public List<Squad> GetAllSquads()
        {
            try
            {
                var squads = _db.Squads.ToList();
                return squads;
            }
            catch (Exception ex)
            {
                throw new Exception($"data not found. {(ex ?? ex.InnerException).Message}");
            }
        }

        public Squad GetSquadById(int squadId)
        {
            try
            {
                var squad = _db.Squads.Where(s => s.Id == squadId).FirstOrDefault();
                return squad;
            }
            catch (Exception ex)
            {
                throw new Exception($"record not found. {(ex ?? ex.InnerException).Message}");
            }
        }

        public async Task CreateSquad(Squad squad)
        {
            try
            {
                _db.Entry(squad).State = EntityState.Added;
                await _db.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"failed to create squad. ${(ex ?? ex.InnerException).Message}");
            }
        }
    }
}