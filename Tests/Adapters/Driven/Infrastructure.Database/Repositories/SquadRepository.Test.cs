using System;
using System.Collections.Generic;
using System.Linq;
using Adapters.Driven.Infrastructure.Database.Context;
using Adapters.Driven.Infrastructure.Database.Repositories;
using Core.Domain.Adapters;
using Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Moq;
using Xunit;

namespace Tests.Adapters.Driven.Infrastructure.Database.Repositories
{
    public class SquadRepositoryTest
    {
        [Fact]
        public void Should_Return_Success_On_GetAllSquadsRepository()
        {
            // Assert
            var mockContextOptions = new DbContextOptionsBuilder<DatabaseContext>();
            var mockContext = new Mock<DatabaseContext>(mockContextOptions.Options);
            var mockSet = new Mock<DbSet<Squad>>();
            var data = new List<Squad>() { new Squad {
                Id = 1,
                Name = "ajksdfqweprij",
                Corp = Corp.Navy,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
                DeletedAt = null
            } };

            mockSet.As<IQueryable<Squad>>().Setup(m => m.Provider).Returns(data.AsQueryable().Provider);
            mockSet.As<IQueryable<Squad>>().Setup(m => m.Expression).Returns(data.AsQueryable().Expression);
            mockSet.As<IQueryable<Squad>>().Setup(m => m.ElementType).Returns(data.AsQueryable().ElementType);
            mockSet.As<IQueryable<Squad>>().Setup(m => m.GetEnumerator()).Returns(data.AsQueryable().GetEnumerator());
            mockContext.Setup(m => m.Squads).Returns(mockSet.Object);

            // Act
            var squadRepository = new SquadRepository(mockContext.Object);
            var squads = squadRepository.GetAllSquads();

            // Assert
            Assert.NotNull(squads);
        }

        [Theory]
        [InlineData(21)]
        public void Should_Return_Success_On_GetSquadByIdRepository(int id)
        {
            // Arrange
            var data = new Squad
            {
                Id = 1,
                Name = "ajksdfqweprij",
                Corp = Corp.Navy,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
                DeletedAt = null
            };

            // Act
            var squadRepository = new Mock<ISquadRepository>();
            squadRepository.Setup(s => s.GetSquadById(id)).Returns(data);
            var squad = squadRepository.Object.GetSquadById(id);

            // Assert
            Assert.NotNull(squad);
        }
    }
}