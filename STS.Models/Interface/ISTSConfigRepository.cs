using System;
using System.Collections.Generic;

namespace STS.Models.Interface
{
    public interface ISTSConfigRepository
    {
        string CertificateFriendlyName { get; }
        IEnumerable<string> EndPoints { get; }
        string IssuerBaseAddress { get; }
        string IssuerRelativeAddress { get; }
        string IssuerUri { get; }
        IEnumerable<string> ClaimTypes { get; }
        double TokenLifeTimeInDays { get; }
    }
}