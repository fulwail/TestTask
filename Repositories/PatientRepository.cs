using Microsoft.EntityFrameworkCore;
using TestTask.Context;
using TestTask.Dtos;
using TestTask.Dtos.Patients;
using TestTask.Models;
using System.Linq.Dynamic.Core;

namespace TestTask.Repositories;

public class PatientRepository:IPatientRepository
{
    private readonly TestTaskContext _context;

    public PatientRepository(TestTaskContext context)
    {
        _context = context;
    }

    public async Task<Guid> CreateItem(CreateOrUpdatePatient item)
    {
        var patient = new Patient()
            {
                Id = Guid.NewGuid(),
                LastName = item.LastName,
                FirstName = item.FirstName,
                ThirdName = item.ThirdName,
                Address = item.Address,
                BirthDate = item.BirthDate,
                SectorId = item.SectorId,
            };
        _context.Patients.Add(patient);
        await _context.SaveChangesAsync();
        
        return patient.Id;
    }
    public async Task<Patient?> UpdateItem(CreateOrUpdatePatient item, Guid id)
    {
        var patient = await _context.Patients.FirstOrDefaultAsync(x=>x.Id==id);
        if (patient != null)
        {
            patient.LastName = item.LastName;
            patient.FirstName = item.FirstName;
            patient.ThirdName = item.ThirdName;
            patient.Address = item.Address;
            patient.BirthDate = item.BirthDate;
            patient.SectorId = item.SectorId;
            await _context.SaveChangesAsync();
        }

        return patient;
    }

    public async Task DeleteItem(Guid id)
    {
        var patient = await _context.Patients.FirstOrDefaultAsync(x=>x.Id==id);
        if (patient != null)
        {
            _context.Patients.Remove(patient);
            await _context.SaveChangesAsync();
        }
         
    }

    public async Task<IEnumerable<Patient>> GetItemList(FilterDto filters)
    {
        var items = _context.Patients
            .Include(x=>x.Sector)
            .AsQueryable();
        if (!string.IsNullOrEmpty(filters.SortColumn))
            items=   items.OrderBy($"{filters.SortColumn} {filters.SortType.ToString()}");
        var offset = filters.Limit * (filters.Page - 1);
        items =  _context.Patients.Skip(offset).Take(filters.Limit);
        return await items.ToArrayAsync();
    }

    public async Task<Patient?> GetItemById(Guid id)
    {
        return  await _context.Patients.FirstOrDefaultAsync(x=>x.Id==id);
    }
}