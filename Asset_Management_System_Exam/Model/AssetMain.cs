using System;
using System.Collections.Generic;

namespace Asset_Management_System_Exam.Model;

public partial class AssetMain
{
    public int AssetId { get; set; }

    public int AssetTypeId { get; set; }

    public int VendorId { get; set; }

    public int AssetDetailsId { get; set; }

    public string AssetName { get; set; } = null!;

    public int PurchaseOrderId { get; set; }

    public DateTime DateAdded { get; set; }

    public string Status { get; set; } = null!;

    public virtual AssetDetail AssetDetails { get; set; } = null!;

    public virtual AssetType AssetType { get; set; } = null!;

    public virtual PurchaseOrder PurchaseOrder { get; set; } = null!;

    public virtual Vendor Vendor { get; set; } = null!;
}
