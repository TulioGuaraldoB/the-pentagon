using System;
using System.Text.Json.Serialization;
using Core.Domain.Entities;

namespace Adapters.Driving.Api.Dtos
{
    public class SquadDto
    {
        public SquadResponse ParseSquadResponse(Squad squad)
        {
            return new SquadResponse()
            {
                Name = squad.Name,
                Corp = squad.Corp,
            };
        }

        public Squad ParseSquadRequest(SquadRequest squadRequest)
        {
            return new Squad()
            {
                Name = squadRequest.Name,
                Corp = squadRequest.Corp,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
            };
        }
    }

    public class SquadResponse
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("squad_corp")]
        public Corp? Corp { get; set; }
    }

    public class SquadRequest
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("squad_corp")]
        public Corp? Corp { get; set; }
    }

}