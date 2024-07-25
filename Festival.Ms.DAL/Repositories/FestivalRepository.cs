    using System;
    using System.Data;
    using System.Xml.Serialization;
    using Festival.Ms.DAL.Interfaces;
    using Festival.Ms.DAL.Interfaces.Entities;
    using Festival.Ms.DAL.Interfaces.Repositories;
    using Microsoft.VisualBasic;
    using Microsoft.EntityFrameworkCore;

    namespace Festival.Ms.DAL.Repositories
    {
        public class FestivalRepository : IFestivalRepository
        {
            private readonly IFestivalContext _festivalContext;

            public FestivalRepository(IFestivalContext festivalContext)
            {
                _festivalContext = festivalContext;
            }

            public async Task<FestivalEntity?> GetFestival(long id)
            {
                return await _festivalContext.Festival.FirstOrDefaultAsync(
                    x => x.Id.Equals(id));
            }
        }
    }

