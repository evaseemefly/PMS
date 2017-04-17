using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace Common
{
   public class TxtSmilSynthesis
    {
        public string fileName;
        public string smileData;
        public string fileDirectry;
        public string pictureType;
        public string txtData;
        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="fd">fileDirectry文件地址</param>
        /// <param name="fn">fileName匹配文件名</param>
        /// <param name="pt">pictureType图片格式</param>
        /// <param name="td">txtData，txt内容</param>
        public TxtSmilSynthesis(string fd, string fn, string pt, string td)
        {
            fileDirectry = fd;
            fileName = fn;
            pictureType = pt;
            txtData = td;
            smileData = "<smil>\n"
                                + "<head>\n"
                                + "<meta name=\"title\" content=\"mms\"/>\n"
                                + "<meta name = \"author\" content=\"ctc\"/>\n"
                                + "<layout>\n"
                                + "<region id = \"reg0\" height=\"50%\" width=\"100%\" top=\"0\" left=\"0\" fit=\"meet\" />\n"
                                + "<region id = \"reg1\" height=\"50%\" width=\"100%\" top=\"50%\" left=\"0\" fit=\"meet\" />\n"
                                + "</layout>\n"
                                + "</head>\n"
                                + "<body>\n"
                                + "<par dur=\"5000ms\">\n"
                                + "<img src=\"" + fileName + pictureType + "\" region=\"reg0\"/>\n"
                                + "<text src=\"" + fileName + ".txt" + "\" region=\"reg1\"/>\n"
                                + "</par>\n"
                                + "</body>\n"
                                + "</smil>";
        }
        /// <summary>
        /// 生成txt和smil文件
        /// </summary>
        public void outputFile()
        {
            FileStream fs = new FileStream(fileDirectry + fileName + ".smil", FileMode.Create);
            StreamWriter sr = new StreamWriter(fs);
            sr.WriteLine(smileData);
            sr.Close();
            fs.Close();
            fs = new FileStream(fileDirectry + fileName + ".txt", FileMode.Create);
            sr = new StreamWriter(fs);
            sr.WriteLine(txtData);
            sr.Close();
            fs.Close();
        }


    }
}
