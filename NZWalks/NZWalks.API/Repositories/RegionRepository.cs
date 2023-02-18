using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NZWalks.API.Data;
using NZWalks.API.Models.Domain;

namespace NZWalks.API.Repositories
{
    public class RegionRepository : IRegionRepository
    {
        private readonly NZWalksDbContext nZWalksDbContext;
        public RegionRepository(NZWalksDbContext nZWalksDbContext) {
            this.nZWalksDbContext = nZWalksDbContext;
        }

        public async Task<Region> AddAsync(Region region)
        {
            region.Id = Guid.NewGuid();
            await nZWalksDbContext.AddAsync(region);
            await nZWalksDbContext.SaveChangesAsync();
            
            return region;
        }

        public async Task<Boolean> DeleteAsync(Guid id)
        {
            var region = await nZWalksDbContext.Regions.FirstOrDefaultAsync(x => x.Id == id);
            if (region != null)
            {
                nZWalksDbContext.Regions.Remove(region);
                await nZWalksDbContext.SaveChangesAsync();
                return true;
            }
            // delete the region
            return false;
        }

        public async Task<IEnumerable<Region>> GetAllAsync()
        {
            return await nZWalksDbContext.Regions.ToListAsync();
        }

        public async Task<Region> GetAsync(Guid id)
        {
            return await nZWalksDbContext.Regions.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Region> UpdateAsync(Guid id, Region region)
        {
            var existingRegion = await nZWalksDbContext.Regions.FirstOrDefaultAsync(x => x.Id == id);
            if (existingRegion == null)
            {
                return null;
            }
            existingRegion.Code= region.Code;
            existingRegion.Name= region.Name;
            existingRegion.Area= region.Area;
            existingRegion.Lat= region.Lat;
            existingRegion.Long = region.Long;
            existingRegion.Population = region.Population;
            nZWalksDbContext.Regions.Update(existingRegion);
            await nZWalksDbContext.SaveChangesAsync();
            return existingRegion;
        }
    }
}
