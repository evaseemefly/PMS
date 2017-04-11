using System;
using System.IO;
using System.Collections;
using System.Drawing;//not in this using System.Drawing.Drawing2D; 
using System.Drawing.Imaging;//in this ImageFormat.Jpeg 

namespace Common
{
    public class PicturePretreatment
    {
        public Stream picture_stream;
        public Image picture_bitmap;
        public string picture_format = "unknow";
        public string error_message = "It's OK";
        public bool noError = true;
        public PicturePretreatment(Stream ps)
        {
            picture_stream = ps;
            try
            {
                picture_bitmap = new Bitmap(picture_stream);//读取为图片
                picture_format = PicturePretreatment.ExtendedNameTest(picture_bitmap.RawFormat);//获取真实扩展名
            }
            catch
            {
                error_message = "It's not a picture";
                noError = false;
            }

        }
        /// <summary>
        /// 将图片预处理标准化
        /// </summary>
        /// <returns>true表示正常，false表示异常，可参考error_message</returns>
        public bool PicturePretreatments()
        {
            if (noError != true) return false;
            int pixel_limit = 1000000;//像素限制
            int pixel_hight_limit = 1000;//高阈值
            int pixel_width_limit = 1000;//宽阈值
            int qulity_limit = 80;//压缩率阈值
            int bit_limit = 88000;//文件大小限制
            //先判断gif图
            picture_bitmap = new Bitmap(picture_stream);//读取为图片
            if (picture_stream.Length <= bit_limit)//满足文件大小要求,不处理
            {
                //不作处理
            }
            else//不满足文件大小要求
            {

                //step1:gif图问题处理
                if (picture_bitmap.RawFormat.Equals(ImageFormat.Gif))
                {
                    error_message = "gif图过大，但无法压缩";//暂时无法处理多画面图
                    return false;
                }
                //step2:初步处理
                picture_bitmap = new Bitmap(picture_stream);//读取为图片
                //step2.1:像素方面处理
                if (picture_bitmap.Height * picture_bitmap.Width > pixel_limit)//看像素数是否过多
                {
                    if (picture_bitmap.Height >= picture_bitmap.Width)//如果是比较高的图
                    {
                        picture_stream = resize_pic(picture_stream, pixel_hight_limit * picture_bitmap.Width / picture_bitmap.Height, pixel_hight_limit);//以高限度为准
                    }
                    else//比较宽的图
                    {
                        picture_stream = resize_pic(picture_stream, pixel_width_limit, pixel_width_limit * picture_bitmap.Height / picture_bitmap.Width);//以宽限度为准
                    }
                }
                //step2.2：压缩方面处理
                else//如果像素数比较正常，处理压缩率
                {
                    picture_stream = rebdqulity_pic(picture_stream, qulity_limit);//按阈值压缩率压缩
                }

                //step3：循环检查大小
                while (true)
                {
                    //step3.1:满足了直接跳出
                    if (picture_stream.Length <= bit_limit)//满足文件大小要求,跳出
                    {
                        break;
                    }
                    //step3.2:阈值检查
                    if (pixel_hight_limit > 100)//检查各项阈值是否还有缩小的可能
                        if (pixel_width_limit > 100)
                            if (qulity_limit > 10)
                            {
                                //正常，继续
                            }
                            else
                            {
                                error_message = "各项属性已无法再缩小";
                                return false;//报错
                            }
                    //step3.3:先使用修剪尺寸的方式
                    if (picture_stream.Length <= bit_limit)//满足文件大小要求,不处理
                    {
                        break;
                    }
                    else//不满足文件大小要求
                    {
                        picture_bitmap = new Bitmap(picture_stream);//读取图片
                        if (picture_bitmap.Height >= picture_bitmap.Width)//如果是比较高的图
                        {
                            pixel_hight_limit = pixel_hight_limit - 50;//减小尺寸阈值
                            picture_stream = PicturePretreatment.resize_pic(picture_stream, pixel_hight_limit * picture_bitmap.Width / picture_bitmap.Height, pixel_hight_limit);//以高限度为准
                        }
                        else//比较宽的图
                        {
                            pixel_width_limit = pixel_width_limit - 50;//减小尺寸阈值
                            picture_stream = PicturePretreatment.resize_pic(picture_stream, pixel_width_limit, pixel_width_limit * picture_bitmap.Height / picture_bitmap.Width);//以宽限度为准
                        }
                    }
                    //step3.4再使用修改压缩率的方式
                    if (picture_stream.Length <= bit_limit)//满足文件大小要求,不处理
                    {
                        break;
                    }
                    else//不满足文件大小要求
                    {
                        picture_bitmap = new Bitmap(picture_stream);//读取图片
                                                                    //再改压缩率
                        qulity_limit = qulity_limit - 5;//降低压缩率
                        picture_stream = PicturePretreatment.rebdqulity_pic(picture_stream, qulity_limit);//按阈值压缩率压缩，暂时有问题？？？
                    }
                }
                //step4:处理完成重新写图片，并测试图片格式
                picture_bitmap = new Bitmap(picture_stream);//读取图片
                picture_format = ExtendedNameTest(picture_bitmap.RawFormat);//看一下处理后的图片格式
            }
            return true;
        }

        /// <summary>
        /// 修改图片尺寸
        /// </summary>
        /// <param name="szfile"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <returns></returns>
        public static Stream resize_pic(Stream szfile, int width, int height)
        {
            Image img = null;//原始图片
            Image bmcpy = null;//生成图片
            Graphics gh = null;//处理用格式
            img = Image.FromStream(szfile);//读取待处理图片
            bmcpy = new Bitmap(width, height);//新建生成图片，按照要求的大小
            gh = Graphics.FromImage(bmcpy);//按新要求建立格式
            gh.DrawImage(img, new Rectangle(0, 0, width, height));//转换函数
            //bmcpy.Save("stream.jpg", ImageFormat.Jpeg);//回存
            //FileStream refile = new FileStream("restream.jpg", FileMode.Create, FileAccess.ReadWrite);
            //bmcpy.Save(refile, img.RawFormat);//回存
            szfile.Close();
            MemoryStream ms = new MemoryStream();
            //bmcpy.Save("szfile" + ExtendedNameTest(img.RawFormat), img.RawFormat);//回存
            bmcpy.Save(ms, img.RawFormat);//回存
            return ms;
        }

        /// <summary>
        /// 更改压缩率
        /// </summary>
        /// <param name="szfile"></param>
        /// <param name="lqulity"></param>
        /// <returns></returns>
        public static Stream rebdqulity_pic(Stream szfile, long lqulity)//
        {
            Bitmap myBitmap;
            ImageCodecInfo myImageCodecInfo;
            Encoder myEncoder;
            EncoderParameter myEncoderParameter;
            EncoderParameters myEncoderParameters;
            // Get an ImageCodecInfo object that representsthe JPEG codec. 
            myImageCodecInfo = GetEncoderInfo("image/jpeg");
            myEncoder = Encoder.Quality;
            myEncoderParameters = new EncoderParameters(1);
            myEncoderParameter = new EncoderParameter(myEncoder, lqulity);
            myEncoderParameters.Param[0] = myEncoderParameter;
            myBitmap = new Bitmap(szfile);

            //myBitmap.Save("rpfile" + ExtendedNameTest(myBitmap.RawFormat), myImageCodecInfo, myEncoderParameters);//ceshi

            MemoryStream ms = new MemoryStream();
            myBitmap.Save(ms, myImageCodecInfo, myEncoderParameters);
            //szfile.Close();
            return ms;
        }
        private static ImageCodecInfo GetEncoderInfo(String mimeType)
        {
            int j;
            ImageCodecInfo[] encoders;
            encoders = ImageCodecInfo.GetImageEncoders();
            for (j = 0; j < encoders.Length; ++j)
            {
                if (encoders[j].MimeType == mimeType) return encoders[j];
            }
            return null;
        }


        /// <summary>
        /// 将 Stream 转成 byte[]
        /// </summary>
        /// <param name="stream"></param>
        /// <returns></returns>
        public static byte[] StreamToBytes(Stream stream)
        {
            byte[] bytes = new byte[stream.Length];
            stream.Read(bytes, 0, bytes.Length);
            // 设置当前流的位置为流的开始
            stream.Seek(0, SeekOrigin.Begin);
            return bytes;
        }
        /// <summary>
        /// 将本图片转为比特流
        /// </summary>
        /// <returns></returns>
        public byte[] ToBytes()
        {
            byte[] bytes = new byte[picture_stream.Length];
            picture_stream.Read(bytes, 0, bytes.Length);
            // 设置当前流的位置为流的开始
            picture_stream.Seek(0, SeekOrigin.Begin);
            return bytes;
        }

        /// 将 byte[] 转成 Stream
        public static Stream BytesToStream(byte[] bytes)
        {
            Stream stream = new MemoryStream(bytes);
            return stream;
        }

        /// <summary>
        /// 检测文件格式,获取扩展名
        /// </summary>
        /// <param name="image_format"></param>
        /// <returns></returns>
        private static string ExtendedNameTest(ImageFormat image_format)
        {
            string format = "unknow";
            if (image_format.Equals(ImageFormat.Bmp)) format = ".bmp";
            if (image_format.Equals(ImageFormat.Gif)) format = ".gif";
            if (image_format.Equals(ImageFormat.Jpeg)) format = ".jpg";
            if (image_format.Equals(ImageFormat.Png)) format = ".png";
            return format;
        }
        /// <summary>
        /// 流存成文件
        /// </summary>
        /// <param name="picture_stream"></param>
        /// <param name="file_name"></param>
        public static void StreamToFile(Stream picture_stream, string file_name)//file name 不要加扩展名
        {
            Image img = Image.FromStream(picture_stream);//读取待处理流成为图片
            img.Save(file_name + ExtendedNameTest(img.RawFormat), img.RawFormat);
        }

        /// <summary>
        /// 流存成文件
        /// </summary>
        /// <param name="file_name">文件名（不含拓展名）</param>
        /// <returns>图片文件名+拓展名</returns>
        public string ToFile(string file_name)//file name 不要加扩展名
        {
            Image img = Image.FromStream(picture_stream);//读取待处理流成为图片
            string fileFullName = file_name + ExtendedNameTest(img.RawFormat);
            img.Save(fileFullName, img.RawFormat);
            return fileFullName;
        }
    }
}
