using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Tooling.Connector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_My_Work_1
{
    public class ConnectionFactory
    {
        public static IOrganizationService GetService()
        {
            string connectionString = "AuthType=OAuth;" +
                                        "Username=PedroSousa@MyWork1863.onmicrosoft.com;" +
                                        "Password=!@#123Pedro;" +
                                        "Url=https://orgc622c02f.crm2.dynamics.com/;" +
                                        "AppId=4b629688-7ebe-48c7-9dc7-9de972db4704;" +
                                        "RedirectUri=app://58145B91-0C36-4500-8554-080854F2AC97;";

            CrmServiceClient crmServiceClient = new CrmServiceClient(connectionString);

            return crmServiceClient.OrganizationWebProxyClient;
        }
    }
}
