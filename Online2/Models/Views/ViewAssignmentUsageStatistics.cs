using Microsoft.EntityFrameworkCore;

namespace Online2.Models.Views
{
    [Keyless]
    public class ViewAssignmentUsageStatistics
    {
        public int used_count { get; set; }
        public int unused_count { get; set; }
    }
}
