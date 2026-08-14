using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrganizationLib
{
    public class SortByType : IComparer<Organization>
    {
        
        int IComparer<Organization>.Compare(Organization x, Organization y)
        {
            return x.Type.CompareTo(y.Type);
        }
    }
}

