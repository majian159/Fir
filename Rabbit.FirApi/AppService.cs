using Newtonsoft.Json;
using Rabbit.FirApi.Models;
using Rabbit.FirApi.Utility;
using System;
using System.Collections;
using System.Text;

namespace Rabbit.FirApi
{
    /// <summary>
    /// 一个抽象的App服务。
    /// </summary>
    public interface IAppService
    {
        /// <summary>
        /// 上传这个App的相关捆。
        /// </summary>
        /// <param name="model">上传捆模型。</param>
        void UploadApp(UploadBundleModel model);

        /// <summary>
        /// 更新这个App的信息。
        /// </summary>
        /// <param name="model">更新App模型。</param>
        void UpdateInfo(UpdateAppModel model);

        /// <summary>
        /// 删除这个App。
        /// </summary>
        void Delete();

        /// <summary>
        /// 获取所有版本信息。
        /// </summary>
        /// <returns>版本信息数组。</returns>
        AppVersionModel[] GetAllVersions();
    }

    /// <summary>
    /// App服务。
    /// </summary>
    public sealed class AppService : IAppService
    {
        private readonly string _userToken;
        private readonly string _appToken;

        /// <summary>
        /// 初始化一个新的App服务。
        /// </summary>
        /// <param name="userToken">用户象征。</param>
        /// <param name="appToken">App象征。</param>
        public AppService(string userToken, AppTokenModel appToken)
        {
            if (string.IsNullOrWhiteSpace(userToken))
            {
                throw new ArgumentNullException("userToken");
            }
            if (appToken == null)
            {
                throw new ArgumentNullException("appToken");
            }
            if (string.IsNullOrWhiteSpace(appToken.Id))
            {
                throw new ArgumentException("AppId不能为空。");
            }
            _userToken = userToken;
            _appToken = appToken.Id;
        }

        /// <summary>
        /// 上传这个App的相关捆。
        /// </summary>
        /// <param name="model">上传捆模型。</param>
        public void UploadApp(UploadBundleModel model)
        {
            if (model == null)
            {
                throw new ArgumentNullException("model");
            }
            var key = model.Key;
            var bytes = model.Bytes;
            var url = model.Url;
            var token = model.Token;
            using (var webClient = WebClientHelper.GetWebClient())
            {
                var createBytes = new CreateBytes();
                var arrayList = new ArrayList
                {
                    createBytes.CreateFieldData("key", key),
                    createBytes.CreateFieldData("token", token),
                    createBytes.CreateFieldData("file", "App.ipa", "application/octet-stream", bytes)
                };
                webClient.Headers.Add("Content-Type", createBytes.ContentType);
                var data = createBytes.JoinBytes(arrayList);
                var bytes2 = webClient.UploadData(url, data);
                Console.WriteLine(Encoding.UTF8.GetString(bytes2));
            }
        }

        /// <summary>
        /// 更新这个App的信息。
        /// </summary>
        /// <param name="model">更新App模型。</param>
        public void UpdateInfo(UpdateAppModel model)
        {
            if (model == null)
            {
                throw new ArgumentNullException("model");
            }
            var text = model.ToString();
            if (string.IsNullOrWhiteSpace(text))
            {
                return;
            }
            using (var webClient = WebClientHelper.GetWebClient())
            {
                webClient.Headers["Content-Type"] = "application/x-www-form-urlencoded";
                var address = string.Format("http://fir.im/api/v2/app/{0}?token={1}", _appToken, _userToken);
                var bytes = webClient.UploadData(address, "PUT", Encoding.UTF8.GetBytes(text));
                Console.WriteLine(Encoding.UTF8.GetString(bytes));
            }
        }

        /// <summary>
        /// 删除这个App。
        /// </summary>
        public void Delete()
        {
            using (var webClient = WebClientHelper.GetWebClient())
            {
                var address = string.Format("http://fir.im/api/v2/app/{0}?token={1}", _appToken, _userToken);
                var bytes = webClient.UploadData(address, "DELETE", new byte[0]);
                Console.WriteLine(Encoding.UTF8.GetString(bytes));
            }
        }

        /// <summary>
        /// 获取所有版本信息。
        /// </summary>
        /// <returns>版本信息数组。</returns>
        public AppVersionModel[] GetAllVersions()
        {
            AppVersionModel[] result;
            using (var webClient = WebClientHelper.GetWebClient())
            {
                var content = Encoding.UTF8.GetString(webClient.DownloadData(string.Format("http://fir.im/api/v2/app/{0}/versions?token={1}", _appToken, _userToken)));
                result = JsonConvert.DeserializeObject<AppVersionModel[]>(content);
            }
            return result;
        }
    }
}