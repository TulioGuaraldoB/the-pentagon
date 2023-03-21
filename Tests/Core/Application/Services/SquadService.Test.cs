using System;
using System.Collections.Generic;
using Core.Application.Services;
using Core.Domain.Adapters;
using Core.Domain.Entities;
using Moq;
using Xunit;

namespace Tests.Core.Application.Services
{
    public class SquadServiceTest
    {
        [Fact]
        public void Should_Return_Success_On_GetAllSquadsService()
        {
            // Arrange
            var mockSquadRepository = new Mock<ISquadRepository>();
            var data = new List<Squad>() { new Squad {
                Id = 1,
                Name = "ajksdfqweprij",
                Corp = Corp.Navy,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
                DeletedAt = null
            } };

            // Act
            mockSquadRepository.Setup(r => r.GetAllSquads()).Returns(data);
            var squadService = new SquadService(mockSquadRepository.Object);
            var squads = squadService.GetAllSquads();

            // Assert
            Assert.NotNull(squads);
        }

        [Theory]
        [InlineData(12)]
        public void Should_Return_Success_On_GetSquadByIdService(int id)
        {
            // Arrange
            var mockSquadRepository = new Mock<ISquadRepository>();
            var data = new Squad
            {
                Id = 12,
                Name = "ajksdfqweprij",
                Corp = Corp.Navy,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
                DeletedAt = null
            };

            // Act
            mockSquadRepository.Setup(r => r.GetSquadById(id)).Returns(data);
            var squadService = new SquadService(mockSquadRepository.Object);
            var squad = squadService.GetSquadById(id);

            // Assert
            Assert.NotNull(squad);
        }
    }
}