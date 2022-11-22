using System;

namespace AutoStore.WebUI.Models
{
    public class PagingInfo
    {
        //количество продуктов
        public int TotalItems { get; set; }
        //количество продуктов в одной странице
        public int ItemPerPage { get; set; }
        //номер текущей страницы
        public  int ThisPage { get; set; }
        //количество страниц
        public int TotalPages { get { return (int)Math.Ceiling((decimal)TotalItems / ItemPerPage); } }

    }
}