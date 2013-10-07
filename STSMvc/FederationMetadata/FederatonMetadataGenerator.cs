using System;
using System.IO;
using System.IdentityModel.Metadata;
using System.IdentityModel.Protocols.WSTrust;
using System.IdentityModel.Tokens;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Xml;

using System.Linq;
using STS.Models.Interface;
using STS.Models.Repository;

namespace STSMvc.FederationMetadata
{
    public class FederatonMetadataGenerator
    {
        private readonly ISTSConfigRepository _configRepository;
        private readonly CertificateRepository _certificateRepository;
        private readonly X509Certificate2 _certificate;

        public FederatonMetadataGenerator(ISTSConfigRepository configRepository)
        {
            _configRepository = configRepository;
            _certificateRepository=new CertificateRepository();
            _certificate = _certificateRepository.Get(_configRepository.CertificateFriendlyName);
        }

        public string Generate()
        {
            var tokenServiceDescriptor = GetTokenServiceDescriptor();
            var id = new EntityId(_configRepository.IssuerUri);
            var entity = new EntityDescriptor(id) {SigningCredentials = new X509SigningCredentials(_certificate)};

            entity.RoleDescriptors.Add(tokenServiceDescriptor);

            var ser = new MetadataSerializer();
            var sb = new StringBuilder(512);

            ser.WriteMetadata(XmlWriter.Create(new StringWriter(sb), new XmlWriterSettings { OmitXmlDeclaration = true }), entity);
            return sb.ToString();
        }

        private SecurityTokenServiceDescriptor GetTokenServiceDescriptor()
        {
            var descriptor = new SecurityTokenServiceDescriptor();
            descriptor.ServiceDescription = _configRepository.IssuerUri;
            descriptor.Keys.Add(GetSigningKeyDescriptor());

            descriptor.SecurityTokenServiceEndpoints.Add(new EndpointReference(_configRepository.IssuerUri));
            descriptor.PassiveRequestorEndpoints.Add(new EndpointReference(_configRepository.IssuerUri));

            foreach (var claimType in _configRepository.ClaimTypes)
                descriptor.ClaimTypesOffered.Add(new DisplayClaim(claimType));


            descriptor.ProtocolsSupported.Add(new Uri("http://docs.oasis-open.org/wsfed/federation/200706"));

            return descriptor;
        }

        private KeyDescriptor GetSigningKeyDescriptor()
        {
            var clause = new X509SecurityToken(_certificate).CreateKeyIdentifierClause<X509RawDataKeyIdentifierClause>();
            var key = new KeyDescriptor(new SecurityKeyIdentifier(clause)) {Use = KeyType.Signing};

            return key;
        }

    }
}