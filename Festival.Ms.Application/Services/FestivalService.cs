using System;
using Festival.Ms.Application.Interfaces;
using Festival.Ms.Application.Interfaces.Services;
using Festival.Ms.DAL.Interfaces.Entities;
using Festival.Ms.DAL.Interfaces.Repositories;
using Festival.Ms.DAL.Mappers;
using Festival.Ms.DAL.Repositories;


namespace Festival.Ms.Application.Services
{
    public class FestivalService : IFestivalService
    {
        private readonly IFestivalRepository _festivalRespository;

        public FestivalService(IFestivalRepository festivalRepository)
        {
            _festivalRespository = festivalRepository;
        }

        public async Task<DTO.Models.Festival> GetFestival(long id)
        {
            return FestivalMapper.Map(await _festivalRespository.GetFestival(id));
        }
    }
}

