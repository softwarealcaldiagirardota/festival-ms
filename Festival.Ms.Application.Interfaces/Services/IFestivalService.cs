using System;
namespace Festival.Ms.Application.Interfaces.Services
{
    public interface IFestivalService
    {
        Task<DTO.Models.Festival> GetFestival(long id);
    }

    
}

