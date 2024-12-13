using System;
using System.Collections.Generic;

namespace Asset_Management_System_Exam.Model;

public partial class PurchaseOrder
{
    public int PurchaseOrderId { get; set; }

    public int VendorId { get; set; }

    public DateTime OrderDate { get; set; }

    public string Status { get; set; } = null!;

    public decimal TotalAmount { get; set; }

    public virtual ICollection<AssetMain> AssetMains { get; set; } = new List<AssetMain>();

    public virtual Vendor Vendor { get; set; } = null!;
}
