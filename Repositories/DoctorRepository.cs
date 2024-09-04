using Microsoft.EntityFrameworkCore;
using TestTask.Context;
using TestTask.Dtos;
using TestTask.Dtos.Doctors;
using TestTask.Models;
using System.Linq.Dynamic.Core;

namespace TestTask.Repositories;

public class DoctorRepository:IDoctorRepository
{
    private readonly TestTaskContext _context;

    public DoctorRepository(TestTaskContext context)
    {
        _context = context;
    }

    public async Task<Guid> CreateItem(CreateOrUpdateDoctor item)
    {
        var doctor = new Doctor()
            {
                Id = Guid.NewGuid(),
                LastName = item.LastName,
                FirstName = item.FirstName,
                ThirdName = item.ThirdName,
                CabinetId= item.CabinetId,
                SpecializationId=item.SpecializationId,
                SectorId = item.SectorId,
            };
        _context.Doctors.Add(doctor);
        await _context.SaveChangesAsync();
        
        return doctor.Id;
    }
    public async Task<Doctor?> UpdateItem(CreateOrUpdateDoctor item, Guid id)
    {
        var doctor = await _context.Doctors.FirstOrDefaultAsync(x=>x.Id==id);
        if (doctor != null)
        {
            doctor.LastName = item.LastName;
            doctor.FirstName = item.FirstName;
            doctor.ThirdName = item.ThirdName;
            doctor.CabinetId = item.CabinetId;
            doctor.SpecializationId = item.SpecializationId;
            doctor.SectorId = item.SectorId;
            await _context.SaveChangesAsync();
        }

        return doctor;
    }

    public async Task DeleteItem(Guid id)
    {
        var doctor = await _context.Doctors.FirstOrDefaultAsync(x=>x.Id==id);
        if (doctor != null)
        {
            _context.Doctors.Remove(doctor);
            await _context.SaveChangesAsync();
        }
         
    }

    public async Task<IEnumerable<Doctor>> GetItemList(FilterDto filters)
    {
        var items = _context.Doctors
            .Include(x=>x.Sector)
            .Include(x=>x.Cabinet)
            .Include(x=>x.Specialization)
            .AsQueryable();
        if (!string.IsNullOrEmpty(filters.SortColumn))
            items=   items.OrderBy($"{filters.SortColumn} {filters.SortType.ToString()}");
        var offset = filters.Limit * (filters.Page - 1);
        items = items.Skip(offset).Take(filters.Limit);
        return await items.ToArrayAsync();
    }

    public async Task<Doctor?> GetItemById(Guid id)
    {
        return  await _context.Doctors.FirstOrDefaultAsync(x=>x.Id==id);
    }
}