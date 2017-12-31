﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace CSPN.helper
{
    public class ImageHelper
    {
        /// <summary>
        /// 将图片数据转换为Base64字符串
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public static string ToBase64(Bitmap image)
        {
            MemoryStream ms = new MemoryStream();
            image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            byte[] arr = new byte[ms.Length];
            ms.Position = 0;
            ms.Read(arr, 0, (int)ms.Length);
            ms.Close();
            string base64 = Convert.ToBase64String(arr);
            return base64;
        }

        /// <summary>
        /// 将Base64字符串转换为图片
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public static Bitmap ToImage(string base64)
        {
            byte[] bytes = Convert.FromBase64String(base64.Remove(0, 22));
            MemoryStream ms = new MemoryStream(bytes);
            Bitmap bitmap = new Bitmap(ms);
            return bitmap;
        }
    }
}