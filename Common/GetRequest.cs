using System;
using System.Data;
using System.Data.SqlClient;

using System.Web;
using System.Text.RegularExpressions;
using System.IO;
using System.Text;
namespace Base
{
    /// <summary>
    /// Core 的摘要说明
    /// </summary>
    public class GetRequest
    {
        /// <summary>
        /// 获取客户端IP
        /// </summary>
        /// <returns></returns>
        public static string GetIP()
        {
            // 优先取得代理IP 
            string userHostAddress = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
            if (string.IsNullOrEmpty(userHostAddress))
            {
                //没有代理IP则直接取客户端IP 
                userHostAddress = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
            }
            if ((userHostAddress != null) && !(userHostAddress == string.Empty))
            {
                return userHostAddress;
            }
            return "0.0.0.0";
        }


        /// <summary>
        /// 获取请求URL
        /// </summary>
        /// <returns></returns>
        public static string GetUrl()
        {
            return HttpContext.Current.Request.Url.ToString();
        }


        /// <summary>
        /// 取得提交的FORM表单并去掉前后空白
        /// </summary>
        /// <param name="strName">控件ID</param>
        /// <returns></returns>
        public static string GetFormValue(string strName)
        {
            if (HttpContext.Current.Request.Form[strName] == null)
            {
                return "";
            }
            return HttpContext.Current.Request.Form[strName].Trim();
        }


        /// <summary>
        /// 取得提交的URL后的字符串并去掉前后空白
        /// </summary>
        /// <param name="strName">控件ID</param>
        /// <returns></returns>
        public static string GetQueryStringValue(string strName)
        {
            if (HttpContext.Current.Request.QueryString[strName] == null)
            {
                return "";
            }
            return HttpContext.Current.Request.QueryString[strName].Trim();
        }


        /// <summary>
        /// 创建Cookies
        /// </summary>
        /// <param name="strName">Cookie 主键</param>
        /// <param name="strValue">Cookie 键值</param>
        /// <code>ck.setCookie("主键","键值","天数");</code>
        public static bool SetCookie(string strName, string strValue)
        {
            try
            {
                HttpCookie Cookie = new HttpCookie(strName);
                Cookie.Value = strValue;
                HttpContext.Current.Response.Cookies.Add(Cookie);
                return true;
            }
            catch
            {
                return false;
            }
        }


        /// <summary>
        /// 读取Cookies
        /// </summary>
        /// <param name="strName">Cookie 主键</param>
        /// <code>Cookie ck = new Cookie();</code>
        /// <code>ck.getCookie("主键");</code>
        public static string GetCookie(string strName)
        {
            HttpCookie Cookie = HttpContext.Current.Request.Cookies[strName];
            if (Cookie != null)
            {
                return Cookie.Value.ToString();
            }
            else
            {
                return null;
            }
        }


        /// <summary>
        /// 清除Cookies
        /// </summary>
        /// <param name="strName"></param>
        public static bool ClearCookie(string strName)
        {
            HttpCookie cookie = HttpContext.Current.Request.Cookies[strName];
            if (cookie != null)
            {
                cookie.Value = null;
                cookie.Expires = DateTime.Now.AddDays(-1.0);
                cookie.Values.Clear();
                HttpContext.Current.Response.Cookies.Set(cookie);

            }
            return true;
        }


        /// <summary>
        /// 根据指定的编码格式返回请求的参数集合
        /// </summary>
        /// <param name="request">当前请求的request对象</param>
        /// <param name="encode">编码格式字符串</param>
        /// <returns>键为参数名,值为参数值的NameValue集合</returns>
        public static System.Collections.Specialized.NameValueCollection GetRequestParameters(HttpRequest request, string encode)
        {
            System.Collections.Specialized.NameValueCollection result = null;
            System.Text.Encoding destEncode = null;

            //获取指定编码格式的Encoding对象
            if (!String.IsNullOrEmpty(encode))
            {
                try
                {
                    //获取指定的编码格式
                    destEncode = System.Text.Encoding.GetEncoding(encode);
                }
                catch
                {
                    //如果获取指定编码格式失败,则设置为null
                    destEncode = null;
                }
            }

            //根据不同的HttpMethod方式,获取请求的参数.如果没有Encoding对象则使用服务器端默认的编码.
            if (request.HttpMethod == "POST")
            {
                if (null != destEncode)
                {
                    System.IO.Stream resStream = request.InputStream;
                    byte[] filecontent = new byte[resStream.Length];
                    resStream.Read(filecontent, 0, filecontent.Length);
                    string postquery = destEncode.GetString(filecontent);
                    result = HttpUtility.ParseQueryString(postquery, destEncode);
                }
                else
                {
                    result = request.Form;
                }
            }
            else
            {
                if (null != destEncode)
                {
                    result = System.Web.HttpUtility.ParseQueryString(request.QueryString.ToString(), destEncode);
                }
                else
                {
                    result = request.QueryString;
                }
            }

            //返回结果
            return result;
        }

        //图片上传后判断是否真的是图片
        public static bool UploadFileImg(string picPath)
        {
            StreamReader sr = new StreamReader(picPath, Encoding.Default);
            string strContent = sr.ReadToEnd();
            sr.Close();
            string str = "request|script|.getfolder|.createfolder|.deletefolder|.createdirectory|.deletedirectory|.saveas|wscript.shell|script.encode|server.|.createobject|execute|activexobject|language=";
            foreach (string s in str.Split('|'))
                if (strContent.IndexOf(s) != -1)
                {
                    File.Delete(picPath);
                    return false;
                }
            return true;
        }
        /// <summary>
        /// 过滤掉不合格的字符
        /// </summary>
        /// <param name="strSource"></param>
        /// <returns></returns>
        public static string Filtrate(string strSource)
        {
            strSource = strSource.Replace("'", "");
            strSource = strSource.Replace("\"", "");
            strSource = strSource.Replace("<", "");
            strSource = strSource.Replace(">", "");
            strSource = strSource.Replace("=", "");
            strSource = strSource.Replace("or", "");
            strSource = strSource.Replace("select", "");
            strSource = strSource.Trim();
            return strSource;

        }


        /// <summary>
        ///  非法SQL字符检测
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool CheckBadWord(string str)
        {
            string pattern = @"select|insert|delete|from|count\(|drop table|update|truncate|asc\(|mid\(|char\(|xp_cmdshell|exec   master|netlocalgroup administrators|net user|or|and";
            if (Regex.IsMatch(str, pattern, RegexOptions.IgnoreCase))
                return true;
            return false;
        }
        public static string Filter(string str)
        {
            string[] pattern ={ "select", "insert", "delete", "from", "count\\(", "drop table", "update", "truncate", "asc\\(", "mid\\(", "char\\(", "xp_cmdshell", "exec   master", "netlocalgroup administrators", "net user", "or", "and" };
            for (int i = 0; i < pattern.Length; i++)
            {
                str = str.Replace(pattern[i].ToString(), "");
            }
            return str;
        }

        /// <summary>
        /// 中文检测
        /// </summary>
        /// <param name="strTest"></param>
        /// <returns></returns>
        public static Boolean IsIncludeChineseCode(string strTest)
        {
            return Regex.IsMatch(strTest, @"[\u4e00-\u9fa5]+");
        }


        /// <summary>
        /// 过滤JS脚本
        /// </summary>
        /// <param name="html"></param>
        /// <returns></returns>
        public static string WipeScript(string html)
        {
            Regex[] regex = new Regex[12];
            RegexOptions options;
            options = RegexOptions.Singleline | RegexOptions.IgnoreCase;
            regex[0] = new Regex(@"<marquee[\s\S]+</marquee *>", options);
            regex[1] = new Regex(@"<script[\s\S]+</script *>", options);
            regex[2] = new Regex(@"href *= *[\s\S]*script *:", options);
            regex[3] = new Regex(@"<iframe[\s\S]+</iframe *>", options);
            regex[4] = new Regex(@"<frameset[\s\S]+</frameset *>", options);
            regex[5] = new Regex(@"<input[\s\S]+</input *>", options);
            regex[6] = new Regex(@"<button[\s\S]+</button *>", options);
            regex[7] = new Regex(@"<select[\s\S]+</select *>", options);
            regex[8] = new Regex(@"<textarea[\s\S]+</textarea *>", options);
            regex[9] = new Regex(@"<form[\s\S]+</form *>", options);
            regex[10] = new Regex(@"<embed[\s\S]+</embed *>", options);
            regex[11] = new Regex(@"on[/s/S]*=", options);
            for (int i = 0; i < regex.Length - 1; i++)
            {
                foreach (Match match in regex[i].Matches(html))
                {
                    html = html.Replace(match.Groups[0].ToString(), "");
                }
            }
            return html;
        }


        //验证内容长度
        public static bool isContent(string strContent)
        {
            return Regex.IsMatch(strContent, @"^(\s|\S){2,5000}$");
        }


        /// <summary>
        /// 清除编辑器中的非法字符串
        /// </summary>
        /// <param name="strHTML"></param>
        /// <returns></returns>
        public static string RemoveHTMLForEditor(string strHTML)
        {
            string input = strHTML;
            Regex regex = new Regex(@"<script[\s\S]+</script *>", RegexOptions.IgnoreCase);
            //Regex regex2 = new Regex(@" no[\s\S]*=", RegexOptions.IgnoreCase);
            Regex regex3 = new Regex(@"<iframe[\s\S]+</iframe *>", RegexOptions.IgnoreCase);
            Regex regex4 = new Regex(@"<frameset[\s\S]+</frameset *>", RegexOptions.IgnoreCase);
            //Regex regex5 = new Regex(@"<div[\s\S]+</div *>", RegexOptions.IgnoreCase);
            input = regex.Replace(input, "");
            //input = regex2.Replace(input, " _disibledevent=");
            input = regex3.Replace(input, "");
            input = regex4.Replace(input, "");
            //input = regex5.Replace(input, "");
            return input;
        }


        /// <summary>
        /// 检测提交页面是否含有非法的SQL字符
        /// </summary>
        /// <returns></returns>
        public static bool CheckBadForm()
        {
            if (HttpContext.Current.Request.Form.Count > 0)
            {
                for (int i = 0; i < HttpContext.Current.Request.Form.Count; i++)
                {
                    if (CheckBadWord(HttpContext.Current.Request.Form[i]))
                        return true;
                }
            }
            return false;
        }

        //判断用户名称格式
        public static bool isUserName(string name)
        {
            return Regex.IsMatch(name, @"^[0-9a-zA-Z_]{6,20}$");
        }

        //必须为数字
        public static bool isNum(string strNum)
        {
            if (strNum == null)
                return false;
            return Regex.IsMatch(strNum, @"^\+?[1-9][0-9]*$");
        }


        //验证价格
        public static bool isProce(string strUrl)
        {
            return Regex.IsMatch(strUrl, @"^(0|[1-9]\d*)(\.\d{1,2})?$");
        }


        //判断日期格式 如:2008-1-20 或2008-01-20 而且包含了对不同年份2月的天数，闰年的控制等等：
        public static bool isDataTime(string datetime)
        {
            return Regex.IsMatch(datetime, @"^((((1[6-9]|[2-9]\d)\d{2})-(0?[13578]|1[02])-(0?[1-9]|[12]\d|3[01]))|(((1[6-9]|[2-9]\d)\d{2})-(0?[13456789]|1[012])-(0?[1-9]|[12]\d|30))|(((1[6-9]|[2-9]\d)\d{2})-0?2-(0?[1-9]|1\d|2[0-8]))|(((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00))-0?2-29-))$");
        }


        /// <summary>
        /// 验证网址检测 
        /// </summary>
        /// <param name="strUrl"></param>
        /// <returns></returns>
        public static bool isUrl(string strUrl)
        {
            return Regex.IsMatch(strUrl, @"^http://([\w-]+\.)+[\w-]+(/[\w-./?%&=]*)?$");
        }

        /// <summary>
        /// 邮箱检测 
        /// </summary>
        /// <param name="strEMail"></param>
        /// <returns></returns>
        public static bool isMail(string strEMail)
        {
            return Regex.IsMatch(strEMail, @"^\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$");
        }


        /// <summary>
        /// 检测Get请求的是否为整数
        /// </summary>
        /// <param name="strParam">传回来的参数</param>
        /// <returns>如果不是</returns>
        public static bool CheckQueryStringisInt(string strParame)
        {
            if (HttpContext.Current.Request.QueryString[strParame] == null || HttpContext.Current.Request.QueryString[strParame] == "")
            {
                return false;
            }
            else
            {
                return Regex.IsMatch(HttpContext.Current.Request.QueryString[strParame].ToString(), @"^\+?[1-9][0-9]*$");
            }
        }
        /// <summary>
        /// 替换单行文本框输入的非法字符
        /// </summary>
        /// <returns></returns>
        public static String ReplaceBadChar(string strSource)
        {
            strSource = strSource.Replace("<", "&lt;");
            strSource = strSource.Replace(">", "&gt;").ToString().Replace(">", "&gt;"); 
            strSource = strSource.Replace("'", "&#39;");
            strSource = strSource.Replace("\"", "&quot;");
            strSource = strSource.Trim();
            return strSource;
        }
    }
}