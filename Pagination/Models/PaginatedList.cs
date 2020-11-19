﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pagination.Models
{
    public class PaginatedList<T> : List<T>
    {
        public PaginatedList(List<T> items, int count, int pageIndex, int pageSize)
        {

            PageIndex = pageIndex;

            Totolpages = (int)Math.Ceiling(count / (double)pageSize);
            this.AddRange(items);

        }

        public int PageIndex { get; private set; }
        public int Totolpages { get; set; }

        public bool PreviousPage
        {
            get
            {
                return (PageIndex > 1);

            }
        }

        public bool NextPage
        {
            get
            {
                return PageIndex < Totolpages;

            }
        }

        public static async Task<PaginatedList<T>> CreateAsync(IQueryable<T> source, int pageindex, int pageSize)
        {
            var count = await source.CountAsync();
            var items = await source.Skip((pageindex - 1) * pageSize).Take(pageSize).ToListAsync();
            return new PaginatedList<T>(items, count, pageindex, pageSize);
        }

    }
}
