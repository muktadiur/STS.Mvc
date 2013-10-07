using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;

namespace STS.Models.Repository
{
    public class CertificateRepository
    {
        public X509Certificate2 Get(string friendlyName)
        {
            var store = new X509Store(StoreName.My, StoreLocation.LocalMachine);
            store.Open(OpenFlags.ReadOnly);
     
            try
            {
                var result = store.Certificates
                                  .Cast<X509Certificate2>()
                                  .SingleOrDefault(o => o.FriendlyName.Equals(friendlyName, StringComparison.OrdinalIgnoreCase));

                if (result == null)
                {
                    throw new ApplicationException(string.Format("No certificate was found for friendly Name {0}", friendlyName));
                }

                return result;
            }
            finally
            {
                store.Close();
            }
        }

        public IEnumerable<string> GetList()
        {
            var store = new X509Store(StoreName.My, StoreLocation.LocalMachine);
            store.Open(OpenFlags.ReadOnly);

            try
            {
                var result = store.Certificates
                                  .Cast<X509Certificate2>()
                                  .Select(o => o.FriendlyName)
                                  .OrderBy(o => o)
                                  .ToList();
                return result;
            }
            finally
            {
                store.Close();
            }
        }
    }
}