using System;
using System.Collections.Generic;

namespace Asset_Management_System_Exam.Model;

public partial class Vendor
{
    public int VendorId { get; set; }

    public string VendorName { get; set; } = null!;

    public string ContactNumber { get; set; } = null!;

    public string Address { get; set; } = null!;

    public virtual ICollection<AssetMain> AssetMains { get; set; } = new List<AssetMain>();

    public virtual ICollection<PurchaseOrder> PurchaseOrders { get; set; } = new List<PurchaseOrder>();
}
