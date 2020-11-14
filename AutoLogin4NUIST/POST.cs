using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net;
using System.IO;

namespace AutoLogin4NUIST
{
    class POST
    {
        public void Post(string username, string password,string domain)
        {
            Encoding myEncoding = Encoding.GetEncoding("gb2312");  //选择编码字符集
            string domainType = domain;
            byte[] bytes = Encoding.Default.GetBytes(password);
            string passwd_base64 = Convert.ToBase64String(bytes);

            string data = "username=" + username + "&domain=" + domainType + "&password=" + passwd_base64 + "&enablemacauth=0";  //要上传到网页系统里的数据（字段名=数值 ，用&符号连接起来）
            byte[] bytesToPost =Encoding.Default.GetBytes(data); //转换为bytes数据

            string responseResult = string.Empty;
            HttpWebRequest req = (HttpWebRequest)
            WebRequest.Create("http://a.nuist.edu.cn/index.php/index/login");   //创建一个有效的httprequest请求，地址和端口和指定路径必须要和网页系统工程师确认正确，不然一直通讯不成功
            req.Method = "POST";
            req.ContentType =   "application/x-www-form-urlencoded;charset=gb2312";
            req.ContentLength = bytesToPost.Length;

            using (Stream reqStream = req.GetRequestStream())
            {
                reqStream.Write(bytesToPost, 0, bytesToPost.Length);     //把要上传网页系统的数据通过post发送
            }
            HttpWebResponse cnblogsRespone = (HttpWebResponse)req.GetResponse();
            if (cnblogsRespone != null && cnblogsRespone.StatusCode == HttpStatusCode.OK)
            {
                StreamReader sr;
                using (sr = new StreamReader(cnblogsRespone.GetResponseStream()))
                {
                    responseResult = sr.ReadToEnd();  //网页系统的json格式的返回值，在responseResult里，具体内容就是网页系统负责工程师跟你协议号的返回值协议内容
                }
                sr.Close();
            }
            cnblogsRespone.Close();
            
        }
    }
}
