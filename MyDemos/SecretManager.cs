//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using SecretsAgent;

//namespace MyDemos
//{
//    public class SecretManager(ISecretStoreService secretStoreService)
//    {
//        private readonly ISecretStoreService _secretStoreService = secretStoreService;

//        public void GetCredentials()
//        {
//            var ftpServer = await _secretStoreService.GetSecretAsync("FtpServerAddress");
//            var ftpUsername = await _secretStoreService.GetSecretAsync("FtpUsername");
//            var ftpPassword = await _secretStoreService.GetSecretAsync("FtpPassword");
//        }
//    }
//}
