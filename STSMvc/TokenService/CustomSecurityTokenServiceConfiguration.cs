using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IdentityModel;
using System.IdentityModel.Configuration;
using System.IdentityModel.Selectors;
using System.IdentityModel.Tokens;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using STS.Models.Interface;
using STS.Models.Repository;


namespace STSMvc.TokenService
{
    public class CustomSecurityTokenServiceConfiguration : SecurityTokenServiceConfiguration
    {
        private readonly ISTSConfigRepository _configRepository;
        private static readonly Lazy<CustomSecurityTokenServiceConfiguration> Configuration = 
            new Lazy<CustomSecurityTokenServiceConfiguration>(
                ()=>new CustomSecurityTokenServiceConfiguration(new STSConfigRepository()));
        private readonly X509Certificate2 _certificate;

        public CustomSecurityTokenServiceConfiguration(ISTSConfigRepository configRepository) : base()
        {
            _configRepository = configRepository;
            _certificate = new CertificateRepository().Get(_configRepository.CertificateFriendlyName);


            SecurityTokenService = typeof(CustomSecurityTokenService);
            DefaultTokenLifetime = TimeSpan.FromDays(configRepository.TokenLifeTimeInDays);
            MaximumTokenLifetime = TimeSpan.FromDays(configRepository.TokenLifeTimeInDays);

            TokenIssuerName = configRepository.IssuerUri;
            SigningCredentials = new X509SigningCredentials(_certificate);

        }

        public static CustomSecurityTokenServiceConfiguration Current
        {
            get
            {
                return Configuration.Value;
            }
        }
    }
}