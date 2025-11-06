using Entities.Models;
using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Dynamic.Core;

namespace Repositories.EFCore.Extensions
{
    public static class BookRepositoryExtensions
    {
        public static IQueryable<Book> FilterBooks(this IQueryable<Book> books,
            uint minPrice, uint maxPrice) =>
            books.Where(Book => 
            Book.Price >= minPrice&&
            Book.Price <= maxPrice);

        public static IQueryable<Book> Search(this IQueryable<Book> books,
            string searchTerm)
        {
            if(string.IsNullOrWhiteSpace(searchTerm))
                return books;
            var lowerCaseTerm = searchTerm.Trim().ToLower();
            return books
                .Where(b => b.Title
                .ToLower()
                .Contains(searchTerm));
        }

        public static IQueryable<Book> Sort(this IQueryable<Book> books,
            string orderByQueryString) //method signature
        {
            if(string.IsNullOrWhiteSpace(orderByQueryString)) //gelen ifadenin null olup olmadığının kontrolü yapılıyor.
                return books.OrderBy(b => b.Id); //boş ise default olarak ıd'ye göre sıralanacak.
            var orderQuery = OrderQueryBuilder
                .CreateOrderQuery<Book>(orderByQueryString);
            if(orderQuery is null)
                return books.OrderBy(b => b.Id);

            return books.OrderBy(orderQuery);


        }
    }
}
