using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class FileHelper
    {
        /// <summary>
        /// 读取文件
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public static byte[] ReadFile(String path)
        {
            if (File.Exists(path))
            {
                FileStream file = null;
                try
                {
                    file = File.OpenRead(path);
                    byte[] pictureContent = new byte[file.Length];
                    file.Read(pictureContent, 0, pictureContent.Length);

                    return pictureContent;

                }
                catch (FileNotFoundException e)
                {
                    throw new FileNotFoundException(e.Message);
                }
                finally
                {
                    file.Close();
                }

            }
            return null;

        }
    }
}
