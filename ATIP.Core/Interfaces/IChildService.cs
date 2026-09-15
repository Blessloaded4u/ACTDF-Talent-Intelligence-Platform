using ATIP.Core.DTOs.Children;
using ATIP.Core.Entities;
using ATIP.Core.Enums;

namespace ATIP.Core.Interfaces;

public interface IChildService
{
    Task<Child> CreateAsync(CreateChildRequest request);

    Task<Child?> GetByIdAsync(int childId);

    Task<IReadOnlyList<Child>> GetAllAsync(ChildStatus? status = null);

    Task<Child?> UpdateAsync(
    int childId,
    UpdateChildRequest request);

    Task<bool> ArchiveAsync(int childId);
}