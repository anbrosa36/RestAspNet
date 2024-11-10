using Microsoft.AspNetCore.Mvc;
using RestApplication.Data.VO;
using RestApplication.Hypermedia.Constants;
using System.Text;

namespace RestApplication.Hypermedia.Enricher
{
    public class PersonEnricher : ContentResponseEnricher<PersonVO>
    {
      
        protected override Task EnrichModel(PersonVO content, IUrlHelper urlHelper)
        {
            var path = "api/person";
            string link = GetLink(content.Id, urlHelper, path);

            content.Links.Add(new HyperMediaLink()
            {
                Action = HttpActionVerb.GET,
                Href= link,
                Rel = RelationTypes.self,
                Type= ResponseTypeFormat.DefaultGet
            });

            content.Links.Add(new HyperMediaLink()
            {
                Action = HttpActionVerb.POST,
                Href = link,
                Rel = RelationTypes.self,
                Type = ResponseTypeFormat.DefaultPost
            });
            content.Links.Add(new HyperMediaLink()
            {
                Action = HttpActionVerb.PUT,
                Href = link,
                Rel = RelationTypes.self,
                Type = ResponseTypeFormat.DefaultPut
            });
            content.Links.Add(new HyperMediaLink()
            {
                Action = HttpActionVerb.DELETE,
                Href = link,
                Rel = RelationTypes.self,
                Type = "int"            
            });
            return Task.CompletedTask;
        }

        private string GetLink(int id, IUrlHelper urlHelper, string path)
        {
            lock (this)
            {
                var url = new { controller = path,id };
                return new StringBuilder(urlHelper.Link("DefaultApi", url))
                    .Replace("%2F", "/").ToString();
            }
        }
    }
}
