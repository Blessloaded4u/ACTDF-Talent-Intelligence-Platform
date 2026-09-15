using ATIP.Core.DTOs.Children;
using ATIP.Core.Entities;
using ATIP.Core.Enums;
using ATIP.Core.Interfaces;
using ATIP.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace ATIP.Infrastructure.Services;

public class ChildService : IChildService
{
    private readonly AtipDbContext _dbContext;

    public ChildService(AtipDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Child> CreateAsync(CreateChildRequest request)
    {
        var child = new Child
        {
            FirstName = request.FirstName.Trim(),
            MiddleName = request.MiddleName?.Trim(),
            LastName = request.LastName.Trim(),
            DateOfBirth = request.DateOfBirth,
            Gender = request.Gender?.Trim(),
            Phone = request.Phone?.Trim(),
            Address = request.Address?.Trim(),
            State = request.State?.Trim(),
            Lga = request.Lga?.Trim(),
            SchoolName = request.SchoolName?.Trim(),
            ClassLevel = request.ClassLevel?.Trim(),
            DiscoveryDate = request.DiscoveryDate,
            DiscoveryLocation = request.DiscoveryLocation?.Trim(),
            DiscoveryNotes = request.DiscoveryNotes?.Trim(),
            Status = ChildStatus.Active,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow
        };

        _dbContext.Children.Add(child);

        await _dbContext.SaveChangesAsync();

        return child;
    }

    public async Task<Child?> GetByIdAsync(int childId)
    {
        return await _dbContext.Children
            .FirstOrDefaultAsync(child => child.ChildId == childId);
    }

    public async Task<IReadOnlyList<Child>> GetAllAsync(
    ChildStatus? status = null)
    {
        var query = _dbContext.Children
            .AsQueryable();

        if (status is null)
        {
            query = query.Where(
                child => child.Status == ChildStatus.Active);
        }
        else
        {
            query = query.Where(
                child => child.Status == status.Value);
        }

        return await query
            .OrderBy(child => child.LastName)
            .ThenBy(child => child.FirstName)
            .ToListAsync();
    }

    public async Task<Child?> UpdateAsync(
    int childId,
    UpdateChildRequest request)
    {
        var child = await _dbContext.Children
            .FirstOrDefaultAsync(child => child.ChildId == childId);

        if (child is null)
        {
            return null;
        }

        if (request.FirstName is not null)
        {
            child.FirstName = request.FirstName.Trim();
        }

        if (request.MiddleName is not null)
        {
            child.MiddleName = request.MiddleName.Trim();
        }

        if (request.LastName is not null)
        {
            child.LastName = request.LastName.Trim();
        }

        if (request.DateOfBirth is not null)
        {
            child.DateOfBirth = request.DateOfBirth;
        }

        if (request.Gender is not null)
        {
            child.Gender = request.Gender.Trim();
        }

        if (request.Phone is not null)
        {
            child.Phone = request.Phone.Trim();
        }

        if (request.Address is not null)
        {
            child.Address = request.Address.Trim();
        }

        if (request.State is not null)
        {
            child.State = request.State.Trim();
        }

        if (request.Lga is not null)
        {
            child.Lga = request.Lga.Trim();
        }

        if (request.SchoolName is not null)
        {
            child.SchoolName = request.SchoolName.Trim();
        }

        if (request.ClassLevel is not null)
        {
            child.ClassLevel = request.ClassLevel.Trim();
        }

        if (request.DiscoveryDate is not null)
        {
            child.DiscoveryDate = request.DiscoveryDate;
        }

        if (request.DiscoveryLocation is not null)
        {
            child.DiscoveryLocation = request.DiscoveryLocation.Trim();
        }

        if (request.DiscoveryNotes is not null)
        {
            child.DiscoveryNotes = request.DiscoveryNotes.Trim();
        }

        child.UpdatedAt = DateTime.UtcNow;

        await _dbContext.SaveChangesAsync();

        return child;
    }
    public async Task<bool> ArchiveAsync(int childId)
    {
        var child = await _dbContext.Children
            .FirstOrDefaultAsync(child => child.ChildId == childId);

        if (child is null)
        {
            return false;
        }

        child.Status = ChildStatus.Archived;
        child.UpdatedAt = DateTime.UtcNow;

        await _dbContext.SaveChangesAsync();

        return true;
    }
}
