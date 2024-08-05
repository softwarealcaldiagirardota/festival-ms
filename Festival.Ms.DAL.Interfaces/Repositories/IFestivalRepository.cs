using System;
using System.Data;
using Festival.Ms.DAL.EntityConfig;
using Festival.Ms.DAL.Interfaces.Entities;

namespace Festival.Ms.DAL.Interfaces.Repositories
{
    public interface IFestivalRepository
    {
      
        Task<FestivalEntity?> GetFestival(long id);
    }


  
}

