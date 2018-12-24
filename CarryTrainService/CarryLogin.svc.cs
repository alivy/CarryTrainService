


namespace CarryTrainService
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码、svc 和配置文件中的类名“CarryLogin”。
    // 注意: 为了启动 WCF 测试客户端以测试此服务，请在解决方案资源管理器中选择 CarryLogin.svc 或 CarryLogin.svc.cs，然后开始调试。
    /// <summary>
    /// 登录服务接口逻辑
    /// </summary>
    public class CarryLogin : ICarryLogin
    {
        public void DoWork()
        {

        }

        /// <summary>
        /// 验证码
        /// </summary>
        public void VerificationCode()
        {

            //请求头
            var headers = new
            {
                User - Agent = "ua.random",
                Host = "kyfw.12306.cn",
                Referer = "https://kyfw.12306.cn/otn/passport?redirect=/otn/"
            };
            //登录页
            var url = "https://kyfw.12306.cn/otn/login/init";

            //第一步，get请求获取验证码
            // 请求数据是不变的，随机数可以使用random.random()
            var data1 = new
            {
                login_site = "E",
                module = "login",
                rand = "sjrand" + "&0.17231872703389062"
            };
             url = "https://kyfw.12306.cn/passport/captcha/captcha-image?{}";
            //第二步 输入验证码， POST请求验证验证码
            var data2 = new
            {
                answer = "positions", //坐标值
                module = "login",
                rand = "sjrand"
            };
            url = "https://kyfw.12306.cn/passport/captcha/captcha-check";
            //请求成功以后返回的result_code是4

            //第三步  验证码通过以后，POST发送账号登录请求
            var data3 = new
            {
                username = "17620372030",
                password = "yanhaomiao123",
                appid = "otn"
            };
            url = "https://kyfw.12306.cn/passport/web/login";

            //3.1 请求验证回调 
            var data31 = new
            {
                appid = "otn"
            };
            url = "https://kyfw.12306.cn/passport/web/auth/uamtk";

            // 3.2 获取用户名
            var data32 = new
            {
                //此处为data31请求回调数据newapptk
                tk = "DlTjQ_OlwgCqIKat - BACXDsyBJr9KyeLz3ofgvlupHw641110"
            };
            url = "https://kyfw.12306.cn/otn/uamauthclient";
        }

        /// <summary>
        /// 登录
        /// </summary>
        public void LogIn()
        {
        }
    }
}
