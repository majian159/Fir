using Newtonsoft.Json;

namespace Rabbit.FirApi.Models
{
    /// <summary>
    /// App象征模型。
    /// </summary>
    public class AppTokenModel
    {
        /// <summary>
        /// 捆模型。
        /// </summary>
        public class BundleModel
        {
            /// <summary>
            /// 图标捆。
            /// </summary>
            public BundleItemModel Icon
            {
                get;
                set;
            }

            /// <summary>
            /// 应用程序包捆。
            /// </summary>
            [JsonProperty("Pkg")]
            public BundleItemModel Package
            {
                get;
                set;
            }
        }

        /// <summary>
        /// 捆项模型。
        /// </summary>
        public class BundleItemModel
        {
            /// <summary>
            /// 捆键值。
            /// </summary>
            public string Key
            {
                get;
                set;
            }

            /// <summary>
            /// 捆象征。
            /// </summary>
            public string Token
            {
                get;
                set;
            }

            /// <summary>
            /// 捆上传Url。
            /// </summary>
            public string Url
            {
                get;
                set;
            }
        }

        /// <summary>
        /// App在数据库中的Id。
        /// </summary>
        public string Id
        {
            get;
            set;
        }

        /// <summary>
        /// App短地址。
        /// </summary>
        public string Short
        {
            get;
            set;
        }

        /// <summary>
        /// App名称。
        /// </summary>
        public string Name
        {
            get;
            set;
        }

        /// <summary>
        /// App图标。
        /// </summary>
        public string Icon
        {
            get;
            set;
        }

        /// <summary>
        /// 是否在广场中展示。
        /// </summary>
        public bool IsShow
        {
            get;
            set;
        }

        /// <summary>
        /// 捆信息。
        /// </summary>
        public BundleModel Bundle
        {
            get;
            set;
        }
    }
}