using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Modas.ViewModels
{
    public class PageInfoViewModel
    {
        public int TotalEvents { get; set; }
        public int EventsPerPage { get; set; }
        public int CurrentPageNumber { get; set; }

        public int TotalPages => (int)Math.Ceiling((decimal)TotalEvents / EventsPerPage);

        public int PreviousPage => CurrentPageNumber == 1 ? 1 : CurrentPageNumber - 1;
        public int NextPage => CurrentPageNumber == TotalPages ? CurrentPageNumber : CurrentPageNumber + 1;
        public int EventRangeStart => (CurrentPageNumber - 1) * EventsPerPage + 1;
        public int EventRangeEnd => CurrentPageNumber == TotalPages ? TotalEvents : EventRangeStart + EventsPerPage - 1;
    }
}
