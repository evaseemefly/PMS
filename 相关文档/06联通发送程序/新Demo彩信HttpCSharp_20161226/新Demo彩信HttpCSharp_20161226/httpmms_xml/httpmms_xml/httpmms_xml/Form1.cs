using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.IO;
using System.Security.Cryptography;
using System.Xml;
using System.Collections.Specialized;

namespace httpmms_xml
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            textBox1.Text = openFileDialog1.FileName;
        }

        public string ToBase64(byte[] binaryData)       //图片转base64函数
        {
            try
            {
                string buffer1 = System.Convert.ToBase64String(binaryData, 0, binaryData.Length);
                return buffer1;
            }
            catch (System.ArgumentNullException exp)
            {
                throw new Exception(exp.Message);
            }
        }


        //MD5加密程序（32位小写）
        private static string md5(string str)
        {
            byte[] result = Encoding.Default.GetBytes(str);
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] output = md5.ComputeHash(result);
            String md = BitConverter.ToString(output).Replace("-", "");
            return md.ToLower();
        }

        private static byte[] readfile(String url)
        {

            FileStream file = File.OpenRead(url);
            byte[] content = new byte[file.Length];
            file.Read(content, 0, content.Length);
            file.Close();

            return content;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            String postUrl = url.Text.ToString();
            String phone = textBox3.Text.ToString();
            String title = textBox2.Text.ToString();
            String user = account.Text.ToString();
            String password = md5(pswd.Text.ToString());
            this.textBox4.Text = sendMMS(postUrl, phone, title, user, password);
        }

        public String sendMMS(String url, String phone,String title,String account,String password) //发送彩信
        {
            String res = "";
            try
            {

                String Content = this.ToBase64(readfile(openFileDialog1.FileName));
                String message = "<?xml version='1.0' encoding='UTF-8'?><root><head>"
                                  + "<cmdId>002</cmdId>"
                                  + "<account>" + account + "</account>" + "<password>"
                                  + password + "</password></head>"
                                  + "<body><submitMsg>"
                                  + "<msgid></msgid>"
                                  + "<phone>" + phone + "</phone><content>"
                                  + Content + "</content><title>"
                                  + title + "</title>"
                                  + "<subCode></subCode></submitMsg></body>"
                                  + "</root>";
                requestInput.Text = message;

                res = DoRquest(url, "POST", "UTF-8", message);
                
            }
            catch (Exception e)
            {
                return e.Message.ToString();
             
            }
            return res;
        }

        public string DoRquest(string uri, string method, string encodestr, string postparamers)
        {
            HttpWebResponse result = null;
            Stream ReceiveStream = null;
            try
            {
                while (true)
                {
                    HttpWebRequest wr = (HttpWebRequest)WebRequest.Create(uri);
                    wr.Method = method;
                    wr.Timeout = 10000;
                    wr.AllowWriteStreamBuffering = false;

                    Encoding encode = System.Text.Encoding.GetEncoding(encodestr);

                    if (method == "POST" && postparamers != null)
                    {
                        wr.ContentType = "application/x-www-form-urlencoded";
                        byte[] bytes = encode.GetBytes(postparamers);
                        wr.ContentLength = bytes.Length;
                        Stream requestStream = wr.GetRequestStream();
                        requestStream.Write(bytes, 0, bytes.Length);
                        requestStream.Close();
                    }

                    result = (HttpWebResponse)wr.GetResponse();
                    {
                        ReceiveStream = result.GetResponseStream();
                        StreamReader sr = new StreamReader(ReceiveStream, encode);
                        string data = sr.ReadToEnd();
                        sr.Close();
                        return data;
                    }
                }
            }
            catch
            {
                return null;
            }
            finally
            {
                if (result != null)
                    result.Close();
                if (ReceiveStream != null)
                    ReceiveStream.Close();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
      
            String postUrl = url.Text.ToString();
           String user = account.Text.ToString();
            String password = md5(pswd.Text.ToString());

            this.textBox4.Text = getReport(postUrl, user, password);
        }

        public String getReport(String url,String account, String password) //获取状态
        {
            String res = "";
            try
            {

                String Content = this.ToBase64(readfile(openFileDialog1.FileName));
                String message = "<?xml version='1.0' encoding='UTF-8'?><root><head>"
                                  + "<cmdId>004</cmdId>"
                                  + "<account>" + account + "</account>" + "<password>"
                                  + password + "</password></head>"
                                  + "</root>";
                requestInput.Text = message;
                res = DoRquest(url, "POST", "UTF-8", message);

            }
            catch (Exception e)
            {
                return e.Message.ToString();
            }
            return res;
        }

      
    }
}
