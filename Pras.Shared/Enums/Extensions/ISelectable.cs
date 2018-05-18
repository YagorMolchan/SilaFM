using System;

namespace Pras.Shared.Enums.Extensions
{
    public interface ISelectable
    {
        Guid Id { get; set; }
        String Title { get; set; }
    }
}
