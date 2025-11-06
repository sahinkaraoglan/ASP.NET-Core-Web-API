using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.LinkModels
{
    public class Link
    {
        public String? Href { get; set; }
        public String? Rel { get; set; }
        public String? Method { get; set; }

        public Link()
        {
                
        }

        public Link(string? href, string? rel, string? method)
        {
            Href = href;
            Rel = rel;
            Method = method;
        }
    }

    public class LinkResourceBase
    {
        public LinkResourceBase()
        {

        }
        public List<Link> Links { get; set; } = new List<Link>();
    }
}
