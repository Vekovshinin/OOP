using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrganizationLib
{
    public class BinarySearchByEmployeeCount : IComparer<Organization>
    {
        public int Compare(Organization x, Organization y)
        {
            return x.EmployeeCount.CompareTo(y.EmployeeCount);
        }
    }
}
