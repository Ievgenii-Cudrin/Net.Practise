using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneBook.Models
{
    public class PageInfo
    {
        public int TotalItems { get; set; }

        public int CurrentPage { get; set; }

        public int PageSize { get; set; }

        public int TotalPages { get; set; }

        public int StartPage { get; set; }

        public int EndPage { get; set; }

        public PageInfo() { }

        public PageInfo(int totlaItems, int page, int pageSize = 10)
        {
            int totalPages = (int)Math.Ceiling((decimal)totlaItems / pageSize);
            int currentPage = page;
            int startPage = currentPage - 5;
            int endPage = currentPage + 4;

            if(startPage <= 0)
            {
                endPage = endPage - (startPage - 1);
                startPage = 1;
            }

            if(endPage > totalPages)
            {
                endPage = totalPages;
                if(endPage > 10)
                {
                    startPage = endPage - 9;
                }
            }

            TotalItems = totlaItems;
            CurrentPage = currentPage;
            PageSize = pageSize;
            TotalPages = totalPages;
            StartPage = startPage;
            EndPage = endPage;
        }
    }
}
