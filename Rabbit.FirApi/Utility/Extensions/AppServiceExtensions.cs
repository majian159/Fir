using System;
using System.Linq;

namespace Rabbit.FirApi.Utility.Extensions
{
    /// <summary>
    /// App服务扩展方法。
    /// </summary>
    public static class AppServiceExtensions
    {
        /// <summary>
        /// 是否存在指定版本的App。
        /// </summary>
        /// <param name="appService">App服务。</param>
        /// <param name="version">App版本。</param>
        /// <returns>存在返回true，否则返回false。</returns>
        public static bool IsExistVersion(this IAppService appService, string version)
        {
            var allVersions = appService.GetAllVersions();
            return allVersions != null && allVersions.Any(i => i.Version == version);
        }

        /// <summary>
        /// 是否存在指定版本的App。
        /// </summary>
        /// <param name="appService">App服务。</param>
        /// <param name="version">App版本。</param>
        /// <returns>存在返回true，否则返回false。</returns>
        public static bool IsExistVersion(this IAppService appService, Version version)
        {
            if (version == null)
                throw new ArgumentNullException("version");

            var versionString = version.ToString();
            var allVersions = appService.GetAllVersions();
            return allVersions != null && allVersions.Any(i => i.Version == versionString);
        }
    }
}