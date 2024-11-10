using Microsoft.AspNetCore.Mvc.Filters;
using System.Reflection.Metadata.Ecma335;

namespace RestApplication.Hypermedia.Abstract
{
    public interface IResponseEnricher
    {
        bool CanEnrich(ResultExecutingContext context);

        Task Enrich(ResultExecutingContext context);

    }
}
