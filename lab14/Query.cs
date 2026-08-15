using System;
using System.Collections.Generic;
using OrganizationLib;
using System.Linq;
using lab12;
using System.Runtime.InteropServices;
using System.Net;

namespace lab14
{
    public class GenericCollection
    {
        public Queue<Organization> queue = new Queue<Organization>();
        public SortedDictionary<int, Queue<Organization>> sortedDictionary = new SortedDictionary<int, Queue<Organization>>();
        public GenericCollection(int amount, int size)
        {
            for (int i = 0; i < amount; i++)
            {
                queue = new Queue<Organization>();
                for (int j = 0; j < size; j++)
                {
                    Organization curr = new Organization();
                    curr.RandInit();
                    queue.Enqueue(curr);
                }
                sortedDictionary.Add(queue.GetHashCode(), queue);
            }
        }
    }

    public static class Query
    {
        public static IEnumerable<Organization> 
            WhereLINQ(SortedDictionary<int, Queue<Organization>> collection, int employeeCount)
        {
            return from f in collection
                   from el in f.Value
                   where el.EmployeeCount > employeeCount
                   select el;
        }

        public static IEnumerable<Organization>
            WhereExtension(this SortedDictionary<int, Queue<Organization>> collection, Func<Organization, bool> predicate)
        {
            var query =
                collection.Values.
                SelectMany(pair => pair).
                Where(predicate).
                Select(elem => elem);
            return query;
        }

        public static int
            CountLINQ(SortedDictionary<int, Queue<Organization>> collection, int employeeCount)
        {
            return (from f in collection
                    from el in f.Value
                    where el.EmployeeCount <= employeeCount
                    select el).Count();
        }

        public static int 
            CountExtension(this SortedDictionary<int, Queue<Organization>> collection, Func<Organization, bool> predicate)
        {
            var query = 
                collection.Values.
                SelectMany(pair => pair).
                Where(predicate).
                Select(elem => elem).
                Count();
            return query;
        }

        public static IEnumerable<Organization>
            UnionLINQ(SortedDictionary<int, Queue<Organization>> collection1, SortedDictionary<int, Queue<Organization>> collection2, string org)
        { 
            var query = (from f in collection1
                         from el in f.Value
                         where el.Type.Contains(org) == true
                         select el).Union(from f in collection2
                                          from el in f.Value
                                          where el.Type.Contains(org) == true
                                          select el);
            return query;
        }

        public static IEnumerable<Organization>
            UnionExtension(this SortedDictionary<int, Queue<Organization>> collection1, SortedDictionary<int, Queue<Organization>> collection2, string org)
        {
            var query1 =
                collection1.Values.
                SelectMany(pair => pair).
                Where(elem => elem.Type.Contains(org) == true).
                Select(elem => elem);

            var query2 =
                collection2.Values.
                SelectMany(pair => pair).
                Where(elem => elem.Type.Contains(org) == true).
                Select(elem => elem);

            var result = query1.Union(query2);
            return result;
        }

        public static int 
            AverageLINQ(SortedDictionary<int, Queue<Organization>> collection)
        {
            var query = ((int)(from f in collection
                              from el in f.Value
                              select el.EmployeeCount).Average());
            return query;
        }
        public static int
            AverageExtension(this SortedDictionary<int, Queue<Organization>> collection)
        {
            var query =
                (int)collection.Values
                .SelectMany(pair => pair)
                .Select(elem => elem.EmployeeCount)
                .Average();

            return query;
        }

        public static IEnumerable<IGrouping<string, Organization>>
            GroupLINQ(SortedDictionary<int, Queue<Organization>> collection)
        {
            var group = from f in collection
                        from el in f.Value
                        group el by el.Type;
            return group;
        }

        public static IEnumerable<IGrouping<string, Organization>>
            GroupExtension(this SortedDictionary<int, Queue<Organization>> collection)
        {
            var query =
                collection.Values
                .SelectMany(pair => pair)
                .GroupBy(el => el.Type)
                .Select(elem => elem);
            return query;
        }

        public static IEnumerable<Organization>
            TreeSelectLINQ(Tree<Organization> tree, string type)
        {
            var query = from el in tree
                        where el.Type.Contains(type)
                        select el;
            return query;
        }

        public static IEnumerable<Organization>
            TreeSelectExtension(this Tree<Organization> tree, Func<Organization, bool> predicate)
        {
            var query =
                tree.Select(el => el).
                Where(predicate);
            return query;
        }

        public static int
            TreeAgregateLINQ(this Tree<Organization> tree)
        {
            var query = (from el in tree
                         select el.EmployeeCount).Min();
            return query;
        }

        public static object
            TreeAgregateExtension(this Tree<Organization> tree, Func<Organization, object> compare)
        {
            var query =
                tree.Select(el => el).Min(compare);
            return query;
        }

        public static IEnumerable<Organization>
            TreeOrderByDescendingLINQ(Tree<Organization> tree)
        {
            var query = from el in tree
                        orderby el.EmployeeCount descending
                        select el;
            return query;
        }

        public static IEnumerable<Organization>
            TreeOrderByDescendingExtension(this Tree<Organization> tree, Func<Organization, object> predicate)
        {
            var query =
                tree.Select(elem => elem)
                .OrderByDescending(predicate);
            return query;
        }

        public static double AverageLINQ(Tree<Organization> tree)
        {
            return tree.Average(org => org.EmployeeCount);
        }

        public static IEnumerable<IGrouping<string, Organization>> GroupLINQ(Tree<Organization> tree)
        {
            return tree.GroupBy(org => org.Type);
        }

        public static int CountLargeOrganizations(Tree<Organization> tree, int minZnach)
        {
            return tree.Count(org => org.EmployeeCount > minZnach);
        }

        public static IEnumerable<Organization> Top5ByEmployees(Tree<Organization> tree)
        {
            return tree.OrderByDescending(org => org.EmployeeCount).Take(5);
        }

        public static IEnumerable<Organization> SearchByType(Tree<Organization> tree, string searchTerm)
        {
            return tree.Where(org => org.Type.Contains(searchTerm));
        }
    }
}
