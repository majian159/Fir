using Newtonsoft.Json;
using Rabbit.FirApi.Models;
using Rabbit.FirApi.Utility;
using System;

namespace Rabbit.FirApi
{
    /// <summary>
    /// 一个抽象的授权服务。
    /// </summary>
    public interface IAuthorizeService
    {
        /// <summary>
        /// 创建或获取一个App象征。
        /// </summary>
        /// <param name="appId">App标识。</param>
        /// <param name="platform">App平台。</param>
        /// <returns>App象征模型。</returns>
        AppTokenModel CreateOrGetApp(string appId, PlatformType? platform = null);
    }

    /// <summary>
    /// 授权服务实现。
    /// </summary>
    public sealed class AuthorizeService : IAuthorizeService
    {
        private readonly string _userId;
        private readonly string _usetToken;

        /// <summary>
        /// 初始化一个新的授权服务。
        /// </summary>
        /// <param name="userId">用户Id。</param>
        /// <param name="usetToken">用户象征。</param>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="usetToken" /> 为空。</exception>
        public AuthorizeService(string userId,string usetToken)
        {
            if (string.IsNullOrWhiteSpace(usetToken))
            {
                throw new ArgumentNullException("usetToken");
            }
            _userId = userId;
            _usetToken = usetToken;
        }

        /// <summary>
        /// 创建或获取一个App象征。
        /// </summary>
        /// <param name="appId">App标识。</param>
        /// <param name="platform">App平台。</param>
        /// <returns>App象征模型。</returns>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="appId" /> 为空。</exception>
        public AppTokenModel CreateOrGetApp(string appId, PlatformType? platform = null)
        {
            if (string.IsNullOrWhiteSpace(appId))
            {
                throw new ArgumentNullException("appId");
            }
            var arg = (platform.HasValue ? platform.ToString() : PlatformType.Ios.ToString()).ToLower();
            AppTokenModel result;
            using (var webClient = WebClientHelper.GetWebClient())
            {
                var text = webClient.DownloadString(string.Format("http://fir.im/api/v2/app/info/{0}?token={1}&type={2}", appId, _userId, arg));
                result = JsonConvert.DeserializeObject<AppTokenModel>(text);
            }
            return result;
        }
    }
}