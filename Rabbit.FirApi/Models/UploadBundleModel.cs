using System;
using System.Linq;

namespace Rabbit.FirApi.Models
{
    /// <summary>
    /// 上传捆模型。
    /// </summary>
    public class UploadBundleModel
    {
        /// <summary>
        /// 上传Url。
        /// </summary>
        public string Url
        {
            get;
            set;
        }

        /// <summary>
        /// Package键值。
        /// </summary>
        public string Key
        {
            get;
            set;
        }

        /// <summary>
        /// 包字节组。
        /// </summary>
        public byte[] Bytes
        {
            get;
            set;
        }

        /// <summary>
        /// 捆的象征。
        /// </summary>
        public string Token
        {
            get;
            set;
        }

        /// <summary>
        /// 初始化一个新的上传捆模型。
        /// </summary>
        /// <param name="bundle">捆信息。</param>
        /// <param name="bytes">捆字节组。</param>
        public UploadBundleModel(AppTokenModel.BundleItemModel bundle, byte[] bytes)
        {
            if (bundle == null)
            {
                throw new ArgumentNullException("bundle");
            }
            var url = bundle.Url;
            var key = bundle.Key;
            var token = bundle.Token;
            if (string.IsNullOrWhiteSpace(url))
            {
                throw new ArgumentException("上传地址不能为空。");
            }
            if (string.IsNullOrWhiteSpace(key))
            {
                throw new ArgumentException("上传键值不能为空。");
            }
            if (string.IsNullOrWhiteSpace(token))
            {
                throw new ArgumentException("捆象征不能为空。");
            }
            if (bytes == null || !bytes.Any())
            {
                throw new ArgumentException("bytes");
            }
            Url = url;
            Key = key;
            Token = token;
            Bytes = bytes;
        }
    }
}