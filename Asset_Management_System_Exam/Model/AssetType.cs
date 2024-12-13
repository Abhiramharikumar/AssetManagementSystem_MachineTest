using System;
using System.Collections.Generic;

namespace Asset_Management_System_Exam.Model;

public partial class AssetType
{
    public int AssetTypeId { get; set; }

    public string AssetTypeName { get; set; } = null!;

    public virtual ICollection<AssetMain> AssetMains { get; set; } = new List<AssetMain>();
}
