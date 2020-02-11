using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Modas.ViewModels
{
    public class ApiListViewModel
    {
        public IEnumerable<ApiViewEvent> Events { get; set; }
        public PageInfoViewModel PagingInfo { get; set; }
    }
    public class ApiViewEvent
    {
        public int EventId { get; set; }
        public DateTime TimeStamp { get; set; }
        public bool Flagged { get; set; }
        public string LocationName { get; set; }
    }
}
