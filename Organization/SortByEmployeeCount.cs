using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrganizationLib
{
    public class SortByEmployeeCount : IComparer
    {
        int IComparer.Compare(object x, object y)
        {
            Organization organization1 = (Organization)x;
            Organization organization2 = (Organization)y;
            if (organization1.EmployeeCount > organization2.EmployeeCount)
                return 1;
            if (organization1.EmployeeCount < organization2.EmployeeCount)
                return -1;
            return 0;
        }
    }
}
