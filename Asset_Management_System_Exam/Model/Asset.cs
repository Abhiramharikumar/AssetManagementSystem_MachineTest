namespace Asset_Management_System_Exam.Model
{
    public class Asset
    {
            public int AssetId { get; set; }
        public string AssetName { get; set; }
            public int AssetTypeId { get; set; }
            public int VendorId { get; set; }
            public int PurchaseOrderId { get; set; }
            public string Status { get; set; }  // e.g., "Available", "In Use", "Disposed"
            public DateTime DateAdded { get; set; } = DateTime.Now;

            // Navigation Properties
            public virtual AssetType AssetType { get; set; }
            public virtual Vendor Vendor { get; set; }
            public virtual PurchaseOrder PurchaseOrder { get; set; }
        }

    }

