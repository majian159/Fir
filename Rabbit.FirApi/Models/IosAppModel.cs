using System;
using System.Web;

namespace Rabbit.FirApi.Models
{
    /// <summary>
    /// IosApp模型。
    /// </summary>
    public sealed class IosAppModel
    {
        private readonly AppTokenModel _model;

        /// <summary>
        /// 初始化一个新的IosApp模型。
        /// </summary>
        /// <param name="model">App象征模型。</param>
        public IosAppModel(AppTokenModel model)
        {
            if (model == null)
            {
                throw new ArgumentNullException("model");
            }
            _model = model;
        }

        /// <summary>
        /// 得到直装Url。
        /// </summary>
        /// <param name="userToken">用户象征。</param>
        /// <returns>值装Url。</returns>
        public string GetInstallUrl(string userToken)
        {
            var str = string.Format("https://fir.im/api/v2/app/install/{0}?token={1}", _model.Id, userToken);
            return string.Format("itms-services://?action=download-manifest&url={0}", HttpUtility.UrlEncode(str));
        }
    }
}