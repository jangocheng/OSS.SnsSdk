﻿#region Copyright (C) 2017   Kevin   （OS系列开源项目）

/***************************************************************************
*　　	文件功能描述：公号二维码管理部分
*
*　　	创建人： Kevin
*       创建人Email：1985088337@qq.com
*    	创建日期：2017-1-16
*       
*****************************************************************************/

#endregion

using System.Text;
using Newtonsoft.Json;
using OSS.Common.Extention;
using OSS.Http;
using OSS.Http.Models;
using OSS.Social.WX.Offcial.Basic.Mos;

namespace OSS.Social.WX.Offcial.Basic
{
    /// <summary>
    ///   二维码处理
    /// </summary>
    public partial class WxOffBasicApi
    {
        /// <summary>
        /// 获取二维码ticket
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        public WxQrCodeResp GetQrCodeTicket(WxCreateSenceQrReq req)
        {
            var reqest = new OsHttpRequest();

            reqest.HttpMothed = HttpMothed.POST;
            reqest.AddressUrl = string.Concat(m_ApiUrl, "/cgi-bin/qrcode/create");
            reqest.CustomBody = JsonConvert.SerializeObject(req);

            return RestCommonOffcial<WxQrCodeResp>(reqest);
        }


        /// <summary>
        /// 获取二维码图片地址
        /// </summary>
        /// <param name="ticket"></param>
        /// <returns></returns>
        public string GetQrCodeUrl(string ticket)
        {
            return string.Concat("https://mp.weixin.qq.com/cgi-bin/showqrcode?ticket=",ticket.UrlEncode());
        }

        /// <summary>
        /// 生成短链
        /// </summary>
        /// <param name="longUrl">需要转换的长链接，支持http://、https://、weixin://wxpay 格式的url</param>
        /// <returns></returns>
        public WxShortUrlResp GetShortUrl(string longUrl)
        {
            var req=new OsHttpRequest();
            req.HttpMothed=HttpMothed.POST;
            req.AddressUrl = string.Concat(m_ApiUrl, "/cgi-bin/shorturl");
            req.CustomBody = $"{{\"action\":\"long2short\",\"long_url\":\"{longUrl}\"}}";

            return RestCommonOffcial<WxShortUrlResp>(req);
        }
        
    }
}
