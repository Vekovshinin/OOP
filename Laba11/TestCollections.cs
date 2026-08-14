using System;
using System.Collections.Generic;
using System.Linq;
using OrganizationLib;
using System.Text;
using System.Threading.Tasks;

namespace Laba11
{
    public class TestCollections
    {
        public Queue<string> queueString = new Queue<string>();
        public Queue<Organization> queueOrganization = new Queue<Organization>();

        public SortedDictionary<string, InsuranceСompany> sortedDictionaryStringInsuranceСompany = new SortedDictionary<string, InsuranceСompany>();
        public SortedDictionary<Organization, InsuranceСompany> sortedDictionaryOrganizationInsuranceСompany = new SortedDictionary<Organization, InsuranceСompany>();

        public void RandInit(int count)
        {
            for(int i = 0; i < count; i++)
            {
                InsuranceСompany insuranceCompany = new InsuranceСompany();
                insuranceCompany.RandInit();

                while (queueOrganization.Contains(insuranceCompany.BaseOrganization))
                    insuranceCompany.RandInit();
                try
                {
                    sortedDictionaryStringInsuranceСompany.Add(insuranceCompany.ToString(), insuranceCompany);
                    sortedDictionaryOrganizationInsuranceСompany.Add(insuranceCompany.BaseOrganization, insuranceCompany);
                    queueString.Enqueue(insuranceCompany.ToString());
                    queueOrganization.Enqueue(insuranceCompany.BaseOrganization);
                }
                catch (Exception)
                {
                    --i;
                }
            }
        }
    }
}
