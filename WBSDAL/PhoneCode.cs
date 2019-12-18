using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aliyun.Acs.Core;
using Aliyun.Acs.Core.Profile;
using Aliyun.Acs.Core.Exceptions;
using Aliyun.Acs.Core.Http;


namespace WBSDAL
{
   public class PhoneCode
    {
       public static string Code(string Phone)
        {
            Random random = new Random();
            string q1 = "{\"code\":\"";

            string q2 = "\"}";

            string da = random.Next(100000, 999999).ToString();
            string qq = q1 + da + q2;


            IClientProfile profile = DefaultProfile.GetProfile("cn-hangzhou", "LTAI4Fudyw1ZdC3aKCXYXk1A", "stRWWoslckoifk3CSj7LZKb93CsCd2");
            DefaultAcsClient client = new DefaultAcsClient(profile);
            CommonRequest request = new CommonRequest();
            request.Method = MethodType.POST;
            request.Domain = "dysmsapi.aliyuncs.com";
            request.Version = "2017-05-25";
            request.Action = "SendSms";
            // request.Protocol = ProtocolType.HTTP;
            request.AddQueryParameters("PhoneNumbers", Phone);
            request.AddQueryParameters("SignName", "青衫忆笙yy");
            request.AddQueryParameters("TemplateCode", "SMS_178451830");
            request.AddQueryParameters("TemplateParam", qq);
            
            try
            {
                CommonResponse response = client.GetCommonResponse(request);
                Console.WriteLine(System.Text.Encoding.Default.GetString(response.HttpResponse.Content));
                return da;
            }
            catch (ServerException e)
            {
                Console.WriteLine(e);
                return e.Message;
            }
            catch (ClientException e)
            {
                Console.WriteLine(e);
                return e.Message;
            }
        }
    }
}
