using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Entity
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Diagnostics.CodeAnalysis;

    namespace DomainLayer.Model
    {
        public abstract class AuditableEntity
        {
            [NotNull]
            public int CreatedBy { get; set; }

            [NotNull]
            public int UpdatedBy { get; set; }

            [AllowNull]
            public int? DeletedBy { get; set; }

            [NotNull]
            public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

            [NotNull]
            public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

            [AllowNull]
            public DateTime? DeletedAt { get; set; }

            // Add IsDeleted property to indicate soft delete
            public bool IsDeleted { get; set; }
        }
    }

}
