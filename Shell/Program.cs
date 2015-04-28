using Rabbit.FirApi;
using Rabbit.FirApi.Models;
using Rabbit.FirApi.Utility.Extensions;
using System;
using System.IO;

namespace Shell
{
    internal class Program
    {
        /// <summary>
        /// 用户票据，从"http://fir.im/user/info"获得。
        /// </summary>
        private const string UserToken = "xxxxxxxxxxxxxxxxxxxxxxxxx";
        /// <summary>
        /// 用户票据，从"http://fir.im/user/info"获得。
        /// </summary>
        private const string UserId = "xxxxxxxxxxxxxxxxxxxxxxxxx";

        private static void Main()
        {
            //初始化一个授权服务。
            var authorizeService = new AuthorizeService(UserId, UserToken);

            //创建创建或者获取一条App记录。
            var app = authorizeService.CreateOrGetApp("Rabbit.Test", PlatformType.Ios);

            //对这个App创建一个服务者。
            var appService = new AppService(UserToken, app);

            #region 上传一个App

            //App二进制流。
            var packageBytes = File.ReadAllBytes(@"d:\Test.ipa");
            //1.上传App文件。
            appService.UploadApp(new UploadBundleModel(app.Bundle.Package, packageBytes));
            //2.更新这个App的信息。
            appService.UpdateInfo(new UpdateAppModel
            {
                Name = "Rabbit",
                Description = "一个测试App。",
                Version = new Version(1, 0, 0, 0)
            });

            #endregion 上传一个App

            //获取这个App的所有版本信息。
            var versions = appService.GetAllVersions();
            foreach (var model in versions)
            {
                Console.WriteLine("AppId={0},FileId={1},Version={2}", model.AppId, model.FileId, model.Version);
            }

            //是否存在版本为1.0.0.0的App。
            appService.IsExistVersion("1.0.0.0");
            appService.IsExistVersion(new Version(1, 0, 0, 0));

            //删除这个App。
            //            appService.Delete();
        }
    }
}