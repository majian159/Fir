using System;
using System.ComponentModel.DataAnnotations;

namespace Rabbit.FirApi.Models
{
    /// <summary>
    /// 更新App信息模型。
    /// </summary>
    public class UpdateAppModel
    {
        /// <summary>
        /// 修改对该app有操作权限对应的用户id
        /// </summary>
        public string Acl
        {
            get;
            set;
        }

        /// <summary>
        /// 修改短地址 3~8位数字或字符
        /// </summary>
        [StringLength(8, MinimumLength = 3)]
        public string Short
        {
            get;
            set;
        }

        /// <summary>
        /// 修改App名
        /// </summary>
        public string Name
        {
            get;
            set;
        }

        /// <summary>
        /// App版本号
        /// </summary>
        public Version Version
        {
            get;
            set;
        }

        /// <summary>
        /// 更新记录
        /// </summary>
        public string ChangeLog
        {
            get;
            set;
        }

        /// <summary>
        /// App描述
        /// </summary>
        public string Description
        {
            get;
            set;
        }

        /// <summary>
        /// 包含的设备UDID数组
        /// </summary>
        public string Devices
        {
            get;
            set;
        }

        /// <summary>
        /// 是否自动同步AppStore数据
        /// </summary>
        public bool? IsRefresh
        {
            get;
            set;
        }

        /// <summary>
        /// 是否允许在广场中显示
        /// </summary>
        public bool? IsShow
        {
            get;
            set;
        }

        /// <summary>
        /// 返回表示当前 <see cref="T:System.Object" /> 的 <see cref="T:System.String" />。
        /// </summary>
        /// <returns>
        /// <see cref="T:System.String" />，表示当前的 <see cref="T:System.Object" />。
        /// </returns>
        public override string ToString()
        {
            Func<string, string, string> getValue =
                (key, value) => !string.IsNullOrWhiteSpace(value) ? string.Format("{0}={1}", key, value) : null;
            string[] value2 =
            {
                getValue("acl", Acl),
                getValue("short", Short),
                getValue("name", Name),
                getValue("version", (Version == null) ? null : Version.ToString()),
                getValue("changelog", ChangeLog),
                getValue("desc", Description),
                getValue("devices", Devices),
                getValue("isInfoRefresh", IsRefresh.HasValue ? (IsRefresh.Value ? "true" : "false") : null),
                getValue("show", IsShow.HasValue ? (IsShow.Value ? "true" : "false") : null)
            };
            return string.Join("&", value2);
        }
    }
}