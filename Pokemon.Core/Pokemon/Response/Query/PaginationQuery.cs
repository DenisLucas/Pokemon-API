using System;

namespace Pokemon.Core.Pokemon.Response.Query
{
    public class PaginationQuery
    {
        public PaginationQuery()
        {
            page = 1;
            pageSize = 50;
        }
        
        public PaginationQuery(int Page, int PageSize)
        {
            page = Page;
            pageSize = PageSize;
        }
        public int page { get; set; }
        public int pageSize { get; set; }
    }
}
