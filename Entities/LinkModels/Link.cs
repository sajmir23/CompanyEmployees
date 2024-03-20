using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.LinkModels
{
     //  1.Deklarojme properties per ate qe duam te shfaqim per klientin pra href,rel,method.

    public class Link
    {
        public string? Href {  get; set; }
        public string? Rel {  get; set; }
        public string? Method { get; set; } 

        public Link() { }

        public Link(string href,string rel,string method)
        {
            Href = href;
            Rel = rel;
            Method = method;
        }
    }

    //  2.Krijohet klasa qe do te mbaje te gjitha link-et tona te cialt do te mbahen ne forme liste.
    //Me pas do te krijohet nje liste e re bosh.


    public class LinkResourceBase
    {
        public LinkResourceBase() { }

        public List<Link> Links { get; set; } = new List<Link>();

    }


    //  3.Our response needs to describe the root of the controller, we need a wrapper for our links.

    public class LinkCollectionWrapper<T> : LinkResourceBase
    {
        public List<T> Value { get; set; } = new List<T>();

        public LinkCollectionWrapper()
        { }

        public LinkCollectionWrapper(List<T> value) => Value = value;
    }

}
