using Microsoft.EntityFrameworkCore;

namespace Online2.Models.Views
{
    [Keyless]
    public class ViewServiceStatistics
    {
        public string ServiceCode { get; set; }
        public string ServiceName { get; set; }
        public int assignments_this_year { get; set; }
        public int assignments_this_month { get; set; }
        public int assignments_this_week { get; set; }
    }
}
