using AutoStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AutoStore.WebUI.Models
{
    public class AutoPagingListView
    {
        public IEnumerable<Auto> Autos { get; set; }
        public PagingInfo PagingInfo { get; set; }
        public string CurrentCategory { get; set; }

    }
}