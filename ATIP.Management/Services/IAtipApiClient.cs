using ATIP.Core.DTOs.Children;
using ATIP.Core.Entities;
using ATIP.Core.Enums;

namespace ATIP.Management.Services;

public interface IAtipApiClient
{
    Task<Child> CreateChildAsync(CreateChildRequest request);

    Task<IReadOnlyList<Child>> GetChildrenAsync(
        ChildStatus? status = null);

    Task<Child?> GetChildAsync(int childId);

    Task<Child?> UpdateChildAsync(
        int childId,
        UpdateChildRequest request);

    Task<bool> ArchiveChildAsync(int childId);
}
