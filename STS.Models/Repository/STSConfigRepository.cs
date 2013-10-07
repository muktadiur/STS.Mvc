using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Security.Claims;
using STS.Models.Interface;
using STS.Models.Entity;

namespace STS.Models.Repository
{
    public class STSConfigRepository : ISTSConfigRepository
    {
        public string CertificateFriendlyName
        {
            get { return "STSCert"; }
        }

        public IEnumerable<string> EndPoints
        {
            get
            {
                return new string[]
                           {
                               "http://localhost:32231/Dev/sts"
                           };
            }
        }

        public string IssuerBaseAddress
        {
            get { return "http://localhost:32231/Dev/"; }
        }

        public string IssuerRelativeAddress
        {
            get { return "/sts/issue"; }
        }

        public string IssuerUri
        {
            get 
            {
               return IssuerBaseAddress+IssuerRelativeAddress;
            }
        }

        public IEnumerable<string> ClaimTypes
        {
            get
            {
                return new string[]
                           {
                               IMSClaimTypes.UserName,
                               IMSClaimTypes.FirstName,
                               IMSClaimTypes.LastName,
                               IMSClaimTypes.Email,
                               IMSClaimTypes.RoleId,
                               IMSClaimTypes.Active,
                               IMSClaimTypes.ReceiveEmailAlert,
                               IMSClaimTypes.RoleDescription,
                               IMSClaimTypes.GeoDescription,
                               IMSClaimTypes.GeoCode,
                               IMSClaimTypes.DefaultNav
                           };
            }
        }

        public double TokenLifeTimeInDays
        {
            get { return 2.0; }
        }


    }
}