using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STS.Models.Entity
{
    public class IMSClaimTypes
    {
        public const string UserName = "http://imshealth.xmlsoap.org/ws/2013/05/identity/claims/username";
        public const string FirstName = "http://imshealth.xmlsoap.org/ws/2013/05/identity/claims/firstname";
        public const string LastName = "http://imshealth.xmlsoap.org/ws/2013/05/identity/claims/lastname";
        public const string Email = "http://imshealth.xmlsoap.org/ws/2013/05/identity/claims/email";
        public const string RoleId = "http://imshealth.xmlsoap.org/ws/2013/05/identity/claims/roleid";
        public const string Active = "http://imshealth.xmlsoap.org/ws/2013/05/identity/claims/active";
        public const string ReceiveEmailAlert = "http://imshealth.xmlsoap.org/ws/2013/05/identity/claims/receiveemailalert";
        public const string RoleDescription = "http://imshealth.xmlsoap.org/ws/2013/05/identity/claims/roledescription";
        public const string GeoDescription = "http://imshealth.xmlsoap.org/ws/2013/05/identity/claims/geodescription";
        public const string GeoCode = "http://imshealth.xmlsoap.org/ws/2013/05/identity/claims/geocode";
        public const string DefaultNav = "http://imshealth.xmlsoap.org/ws/2013/05/identity/claims/defaultnav";
    }
}
