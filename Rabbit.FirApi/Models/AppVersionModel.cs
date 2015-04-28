using Newtonsoft.Json;

namespace Rabbit.FirApi.Models
{
    /// <summary>
    /// App版型模型。
    /// </summary>
    public sealed class AppVersionModel
    {
        /// <summary>
        /// 版本号。
        /// </summary>
        public string Version
        {
            get;
            set;
        }

        /// <summary>
        /// 文件标识。
        /// </summary>
        [JsonProperty("file")]
        public string FileId
        {
            get;
            set;
        }

        /// <summary>
        /// App标识。
        /// </summary>
        [JsonProperty("app_id")]
        public string AppId
        {
            get;
            set;
        }
    }
}