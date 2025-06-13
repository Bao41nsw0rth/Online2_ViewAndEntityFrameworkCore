using Microsoft.EntityFrameworkCore;

namespace Online2.Models.Views
{
    [Keyless]
    public class ViewAssignmentsPerDevice
    {
        public string DeviceCode { get; set; }
        public string DeviceName { get; set; }
        public int total_assignments { get; set; }
    }
}
