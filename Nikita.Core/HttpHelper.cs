using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Web;

namespace Nikita.Core
{
    public class HttpHelper
    {
        #region 私有变量

        private readonly CookieContainer _cc;
        private string _accept = "image/gif, image/x-xbitmap, image/jpeg, image/pjpeg, application/x-shockwave-flash, application/x-silverlight, application/vnd.ms-excel, application/vnd.ms-powerpoint, application/msword, application/x-ms-application, application/x-ms-xbap, application/vnd.ms-xpsdocument, application/xaml+xml, application/x-silverlight-2-b1, */*";
        private string _contentType = "application/x-www-form-urlencoded";
        private int _currentTry;
        private int _delay = 1000;
        private Encoding _encoding = Encoding.GetEncoding("utf-8");
        private int _maxTry = 3;
        private string _userAgent = "Mozilla/4.0 (compatible; MSIE 7.0; Windows NT 5.1; .NET CLR 2.0.50727; .NET CLR 3.0.04506.648; .NET CLR 3.5.21022)";

        #endregion 私有变量

        #region 属性

        public string Accept
        {
            get { return _accept; }
            set { _accept = value; }
        }

        public string ContentType
        {
            get { return _contentType; }
            set { _contentType = value; }
        }

        /// <summary>
        /// Cookie容器
        /// </summary>
        public CookieContainer CookieContainer
        {
            get
            {
                return _cc;
            }
        }

        /// <summary>
        /// 获取网页源码时使用的编码
        /// </summary>
        /// <value></value>
        public Encoding Encoding
        {
            get
            {
                return _encoding;
            }
            set
            {
                _encoding = value;
            }
        }

        public int MaxTry
        {
            get
            {
                return _maxTry;
            }
            set
            {
                _maxTry = value;
            }
        }

        public int NetworkDelay
        {
            get
            {
                Random r = new Random();
                return (r.Next(_delay / 1000, _delay / 1000 * 2)) * 1000;
            }
            set
            {
                _delay = value;
            }
        }

        public string UserAgent
        {
            get { return _userAgent; }
            set { _userAgent = value; }
        }

        #endregion 属性

        #region 构造函数

        /// <summary>
        /// Initializes a new instance of the <see cref="HttpHelper"/> class.
        /// </summary>
        public HttpHelper()
        {
            _cc = new CookieContainer();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="HttpHelper"/> class.
        /// </summary>
        /// <param name="cc">The cc.</param>
        public HttpHelper(CookieContainer cc)
        {
            this._cc = cc;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="HttpHelper"/> class.
        /// </summary>
        /// <param name="contentType">Type of the content.</param>
        /// <param name="accept">The accept.</param>
        /// <param name="userAgent">The user agent.</param>
        public HttpHelper(string contentType, string accept, string userAgent)
        {
            this._contentType = contentType;
            this._accept = accept;
            this._userAgent = userAgent;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="HttpHelper"/> class.
        /// </summary>
        /// <param name="cc">The cc.</param>
        /// <param name="contentType">Type of the content.</param>
        /// <param name="accept">The accept.</param>
        /// <param name="userAgent">The user agent.</param>
        public HttpHelper(CookieContainer cc, string contentType, string accept, string userAgent)
        {
            this._cc = cc;
            this._contentType = contentType;
            this._accept = accept;
            this._userAgent = userAgent;
        }

        #endregion 构造函数

        #region 公共方法

        /// <summary>
        /// 返回 HTML 字符串的解码结果
        /// </summary>
        /// <param name="str">字符串</param>
        /// <returns>解码结果</returns>
        public static string HtmlDecode(string str)
        {
            return HttpUtility.HtmlDecode(str);
        }

        /// <summary>
        /// 返回 HTML 字符串的编码结果
        /// </summary>
        /// <param name="inputData">字符串</param>
        /// <returns>编码结果</returns>
        public static string HtmlEncode(string inputData)
        {
            return HttpUtility.HtmlEncode(inputData);
        }

        public CookieCollection GetCookieCollection(string cookieString)
        {
            CookieCollection getCookieCollection = new CookieCollection();
            //string cookieString = "SID=ARRGy4M1QVBtTU-ymi8bL6X8mVkctYbSbyDgdH8inu48rh_7FFxHE6MKYwqBFAJqlplUxq7hnBK5eqoh3E54jqk=;Domain=.google.com;Path=/,LSID=AaMBTixN1MqutGovVSOejyb8mVkctYbSbyDgdH8inu48rh_7FFxHE6MKYwqBFAJqlhCe_QqxLg00W5OZejb_UeQ=;Domain=www.google.com;Path=/accounts";
            Regex re = new Regex("([^;,]+)=([^;,]+);Domain=([^;,]+);Path=([^;,]+)", RegexOptions.IgnoreCase);
            foreach (Match m in re.Matches(cookieString))
            {
                //name,   value,   path,   domain
                Cookie c = new Cookie(m.Groups[1].Value, m.Groups[2].Value, m.Groups[3].Value, m.Groups[3].Value);
                getCookieCollection.Add(c);
            }
            return getCookieCollection;
        }

        public string GetEncoding(string url)
        {
            HttpWebRequest request = null;
            HttpWebResponse response = null;
            StreamReader reader = null;
            try
            {
                request = (HttpWebRequest)WebRequest.Create(url);
                request.Timeout = 20000;
                request.AllowAutoRedirect = false;
                response = (HttpWebResponse)request.GetResponse();
                if (response.StatusCode == HttpStatusCode.OK && response.ContentLength < 1024 * 1024)
                {
                    if (response.ContentEncoding.Equals("gzip", StringComparison.InvariantCultureIgnoreCase))
                    {
                        reader = new StreamReader(new GZipStream(response.GetResponseStream(), CompressionMode.Decompress));
                    }
                    else
                    {
                        reader = new StreamReader(response.GetResponseStream(), Encoding.ASCII);
                    }

                    string html = reader.ReadToEnd();
                    Regex regCharset = new Regex(@"charset\b\s*=\s*(?<charset>[^""]*)");
                    if (regCharset.IsMatch(html))
                    {
                        return regCharset.Match(html).Groups["charset"].Value;
                    }
                    else if (response.CharacterSet != string.Empty)
                    {
                        return response.CharacterSet;
                    }
                    else
                    {
                        return Encoding.Default.BodyName;
                    }
                }
            }
            catch
            {
            }
            finally
            {
                if (response != null)
                {
                    response.Close();
                    response = null;
                }
                if (reader != null)
                    reader.Close();
                if (request != null)
                    request = null;
            }
            return Encoding.Default.BodyName;
        }

        /// <summary>
        /// 获取HTML页面内制定Key的Value内容
        /// </summary>
        /// <param name="html"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public string GetHiddenKeyValue(string html, string key)
        {
            string result = "";
            string sRegex = string.Format("<input\\s*type=\"hidden\".*?name=\"{0}\".*?\\s*value=[\"|'](?<value>.*?)[\"|'^/]", key);
            Regex re = new Regex(sRegex, RegexOptions.IgnoreCase | RegexOptions.IgnorePatternWhitespace | RegexOptions.Multiline);
            Match mc = re.Match(html);
            if (mc.Success)
            {
                result = mc.Groups[1].Value;
            }
            return result;
        }

        /// <summary>
        /// 获取指定页面的HTML代码
        /// </summary>
        /// <param name="url">指定页面的路径</param>
        /// <param name="cookieContainer">Cookie集合</param>
        /// <param name="postData">回发的数据</param>
        /// <param name="isPost">是否以post方式发送请求</param>
        /// <returns></returns>
        public string GetHtml(string url, CookieContainer cookieContainer, string postData, bool isPost)
        {
            return GetHtml(url, cookieContainer, postData, isPost, url);
        }

        /// <summary>
        /// 获取指定页面的HTML代码
        /// </summary>
        /// <param name="url">指定页面的路径</param>
        /// <param name="cookieContainer">Cookie集合</param>
        /// <param name="postData">回发的数据</param>
        /// <param name="isPost">是否以post方式发送请求</param>
        /// <param name="referer"></param>
        /// <returns></returns>
        public string GetHtml(string url, CookieContainer cookieContainer, string postData, bool isPost, string referer)
        {
            if (string.IsNullOrEmpty(postData))
            {
                var cookie = new CookieCollection();
                return GetHtml(url, cookieContainer, referer);
            }

            //Thread.Sleep(NetworkDelay);
            _currentTry++;
            try
            {
                byte[] byteRequest = Encoding.Default.GetBytes(postData);

                var httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
                httpWebRequest.CookieContainer = cookieContainer;
                httpWebRequest.ContentType = _contentType;
                httpWebRequest.Referer = referer;
                httpWebRequest.Accept = _accept;
                httpWebRequest.UserAgent = _userAgent;
                httpWebRequest.Method = isPost ? "POST" : "GET";
                httpWebRequest.ContentLength = byteRequest.Length;

                httpWebRequest.AllowAutoRedirect = false;

                Stream stream = httpWebRequest.GetRequestStream();
                stream.Write(byteRequest, 0, byteRequest.Length);
                stream.Close();

                HttpWebResponse httpWebResponse;
                try
                {
                    httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                    //redirectURL = httpWebResponse.Headers["Location"];// Get redirected uri
                }
                catch (WebException ex)
                {
                    httpWebResponse = (HttpWebResponse)ex.Response;
                }
                Stream responseStream = httpWebResponse.GetResponseStream();
                string html = string.Empty;
                if (responseStream != null)
                {
                    StreamReader streamReader = new StreamReader(responseStream, _encoding);
                    html = streamReader.ReadToEnd();
                    streamReader.Close();
                    responseStream.Close();
                }

                _currentTry = 0;
                return html;
            }
            catch (Exception)
            {
                if (_currentTry <= _maxTry)
                {
                    GetHtml(url, cookieContainer, postData, isPost);
                }

                _currentTry = 0;
                return string.Empty;
            }
        }

        /// <summary>
        /// 获取指定页面的HTML代码
        /// </summary>
        /// <param name="url">指定页面的路径</param>
        /// <param name="cookieContainer"></param>
        /// <param name="reference"></param>
        /// <returns></returns>
        public string GetHtml(string url, CookieContainer cookieContainer, string reference)
        {
            //Thread.Sleep(NetworkDelay);
            _currentTry++;

            try
            {
                var httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
                httpWebRequest.CookieContainer = cookieContainer;
                httpWebRequest.ContentType = _contentType;
                httpWebRequest.Referer = reference;
                httpWebRequest.Accept = _accept;
                httpWebRequest.UserAgent = _userAgent;
                httpWebRequest.Method = "GET";

                var httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();

                Stream responseStream = httpWebResponse.GetResponseStream();
                string html = string.Empty;
                if (responseStream != null)
                {
                    StreamReader streamReader = new StreamReader(responseStream, _encoding);
                    html = streamReader.ReadToEnd();
                    streamReader.Close();
                    responseStream.Close();

                    _currentTry = 0;
                }
                return html;
            }
            catch (Exception)
            {
                if (_currentTry <= _maxTry)
                {
                    GetHtml(url, cookieContainer, reference);
                }

                _currentTry = 0;
                return string.Empty;
            }
        }

        /// <summary>
        /// 获取指定页面的HTML代码
        /// </summary>
        /// <param name="url">指定页面的路径</param>
        /// <returns></returns>
        public string GetHtml(string url)
        {
            return GetHtml(url, _cc, url);
        }

        /// <summary>
        /// 获取指定页面的HTML代码
        /// </summary>
        /// <param name="url">指定页面的路径</param>
        /// <param name="reference"></param>
        /// <returns></returns>
        public string GetHtml(string url, string reference)
        {
            return GetHtml(url, _cc, reference);
        }

        /// <summary>
        /// 获取指定页面的HTML代码
        /// </summary>
        /// <param name="url">指定页面的路径</param>
        /// <param name="postData">回发的数据</param>
        /// <param name="isPost">是否以post方式发送请求</param>
        /// <returns></returns>
        public string GetHtml(string url, string postData, bool isPost)
        {
            const string redirectUrl = "";
            return GetHtml(url, _cc, postData, isPost, redirectUrl);
        }

        /// <summary>
        /// 获取指定页面的Stream
        /// </summary>
        /// <param name="url">指定页面的路径</param>
        /// <param name="cookieContainer"></param>
        /// <returns></returns>
        public Stream GetStream(string url, CookieContainer cookieContainer)
        {
            return GetStream(url, cookieContainer, url);
        }

        /// <summary>
        /// 获取指定页面的Stream
        /// </summary>
        /// <param name="url">指定页面的路径</param>
        /// <param name="cookieContainer"></param>
        /// <param name="reference"></param>
        /// <returns></returns>
        public Stream GetStream(string url, CookieContainer cookieContainer, string reference)
        {
            //Thread.Sleep(delay);

            _currentTry++;
            try
            {
                var httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
                httpWebRequest.CookieContainer = cookieContainer;
                httpWebRequest.ContentType = _contentType;
                httpWebRequest.Referer = reference;
                httpWebRequest.Accept = _accept;
                httpWebRequest.UserAgent = _userAgent;
                httpWebRequest.Method = "GET";

                var httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                Stream responseStream = httpWebResponse.GetResponseStream();
                _currentTry = 0;
                return responseStream;
            }
            catch (Exception e)
            {
                if (_currentTry <= _maxTry)
                {
                    CookieCollection cookie = new CookieCollection();
                    GetHtml(url, cookieContainer, url);
                }

                _currentTry = 0;
                return null;
            }
        }

        /// <summary>
        /// 判断URL是否有效
        /// </summary>
        /// <param name="url">待判断的URL，可以是网页以及图片链接等</param>
        /// <returns>200为正确，其余为大致网页错误代码</returns>
        public int GetUrlError(string url)
        {
            int num = 200;
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(new Uri(url));
                ServicePointManager.Expect100Continue = false;
                ((HttpWebResponse)request.GetResponse()).Close();
            }
            catch (WebException exception)
            {
                if (exception.Status != WebExceptionStatus.ProtocolError)
                {
                    return num;
                }
                if (exception.Message.IndexOf("500 ", StringComparison.Ordinal) > 0)
                {
                    return 500;
                }
                if (exception.Message.IndexOf("401 ", StringComparison.Ordinal) > 0)
                {
                    return 401;
                }
                if (exception.Message.IndexOf("404", StringComparison.Ordinal) > 0)
                {
                    num = 404;
                }
            }
            catch
            {
                num = 401;
            }
            return num;
        }

        /// <summary>
        /// 移除Html标记
        /// </summary>
        /// <param name="content"></param>
        /// <returns></returns>
        public string RemoveHtml(string content)
        {
            const string regexstr = @"<[^>]*>";
            return Regex.Replace(content, regexstr, string.Empty, RegexOptions.IgnoreCase);
        }

        #endregion 公共方法
    }
}