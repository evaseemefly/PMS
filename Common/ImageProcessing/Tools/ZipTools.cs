using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using ICSharpCode.SharpZipLib;
using ICSharpCode.SharpZipLib.Zip;
using ICSharpCode.SharpZipLib.Core;
namespace Common
{
    public class ZipTools
    {
        /// <summary>
        /// 压缩一系列文件。说明：把“D:\来源目录\文档.txt”这一个文件，压缩成“文档.zip”
        /// </summary>
        /// <param name="zipFileName">Zip文件的名字@"D:\文档.zip"</param>
        /// <param name="sourceDirectory">目录@"D:\"</param>
        /// <param name="fileFilter">文件选择器，用于匹配压缩的文件"20170101"</param>
        public static void ZipFile(string zipFileName, string sourceDirectory, string fileFilter)
        {
            FastZip fastZip = new FastZip();
            fastZip.CreateZip(zipFileName, sourceDirectory, false, fileFilter);
        }
        /// <summary>
        /// 解压缩
        /// </summary>
        /// <param name="zipFileName">Zip文件名字@"D:\文档.zip"</param>
        /// <param name="targetDirectory">解压目标地址@"D:\"</param>
        /// <param name="password">密码如"20170101"或null。null表示无密码。""也是一种密码。</param>
        public static void UnZipFile(string zipFileName, string targetDirectory, string password)
        {
            FastZip fastZip = new FastZip();
            fastZip.Password = password; // 压缩密码。null表示无密码。""也是一种密码。 
            fastZip.ExtractZip(zipFileName, targetDirectory, null);
        }
        /// <summary>
        /// 说明：来源可以是文件，也可以是byte[]。通过ZipOutputStream把它压缩到MemoryStream里。
        /// 本法适用于网络传输大数据。可以在传输前，压缩减少数据长度。
        /// </summary>
        /// <param name=""></param>
        public static byte[] ZipStream(byte[] sourceStream)
        {
            MemoryStream zipMemoryStream1 = new MemoryStream();
            ZipOutputStream zipOutputStream1 = new ZipOutputStream(zipMemoryStream1);
            ZipEntry zipEntry1 = new ZipEntry("实体一");
            zipOutputStream1.PutNextEntry(zipEntry1);
            zipOutputStream1.Write(sourceStream, 0, sourceStream.Length);
            zipOutputStream1.Close();
            return zipMemoryStream1.ToArray();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sourceFileName"></param>
        /// <returns></returns>
        public static byte[] FileToByte(string sourceFileName)
        {
            return File.ReadAllBytes(sourceFileName);
        }
        /// <summary>
        /// 流解压缩
        /// </summary>
        /// <param name="sourceStream"></param>
        /// <returns></returns>
        public static byte[] UnZipStream(byte[] sourceStream)
        {
            MemoryStream unzipMemoryStream2 = new MemoryStream();
            MemoryStream zipMemoryStream2 = new MemoryStream(sourceStream);
            ZipInputStream zipInputStream2 = new ZipInputStream(zipMemoryStream2);
            ZipEntry zipEntry2 = zipInputStream2.GetNextEntry(); // 获取一个压缩实体 
            byte[] tBytesBuffer = new byte[4096]; int ReadCount = 0;
            while ((ReadCount = zipInputStream2.Read(tBytesBuffer, 0, 4096)) != 0) // 每次4KB，解压到内存流。 
            {
                unzipMemoryStream2.Write(tBytesBuffer, 0, ReadCount);
            }
            return unzipMemoryStream2.ToArray();
        }
        /// <summary>
        /// 把byte[]存成文件
        /// </summary>
        /// <param name="sourceStream"></param>
        /// <param name="sourceDirectory"></param>
        public static void ByteToFile(byte[] sourceStream, string targetDirectory)
        {
            File.WriteAllBytes(targetDirectory, sourceStream);
        }

    }
}

