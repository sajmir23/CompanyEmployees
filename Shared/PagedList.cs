using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    public class PagedList<T> : List<T>
    {
        public MetaData MetaData { get; set; }

        public PagedList(List<T> items, int count, int pageNumber, int pageSize)
        {
            MetaData = new MetaData
            {
                TotalCount = count,
                PageSize = pageSize,
                CurrentPage = pageNumber,
                TotalPages = (int)Math.Ceiling(count /(double)pageSize)
            };

            AddRange(items);
        }

        public static PagedList<T> ToPagedList(IEnumerable<T> source, int pageNumber, int pageSize)
        {
            var count = source.Count();
            var items = source.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();

            return new PagedList<T>(items, count, pageNumber, pageSize);
        }


    }
}
/*
 public class IQuerable<Employee> Sort(this IQuerable<Employee> employees,string orderByquerystring)
{
    if(string.IsNullOrWhiteSpace(orderByquerystring)
        return employees.OrderBy(e=>e.Name);
 var orderquery = OrderQueryClass.CreateOrderQuery<Employee>(orderByquery);

if(string.IsNullOrWhiteSpace(orderquery))
return employees.OrderBy(e=>e.Name);

return emplyees.OrderBy(orderquery);
}

public class IQuerable<Employee>FiltersEmployees(this IQuerable<Employee> employee,uint minAge,
uint max Age)=>employee.Where(e=>e.Age >=minAge && e.Age <= maxAge)
 */

/*
 public class PageList<T>:List<T>
{
  public MetaData metadata { get; set; }

public PageList<T>(List<T> items,int count,int pagenumber,int pagesize)

MetaData=new MetaData
{
Totalcount=count
pagenumber=currentpage
pagesize=pagesize
totalpages=Math(count/pagesize)
}

AddRange(items)

public static PageList<T> ToPageList(IEnumerable<T> source,int pagenumber,int pagesize)
{
 var count=source.Count();
var items = source.Skip((pagenumber-1)* pagesize).Take(pagesize).ToList();

return new PageList<T>(items,count,pagenumber,pagesize)

}

}
 */