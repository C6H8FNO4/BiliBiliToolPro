﻿using System.Collections.Generic;
using System.Text.Json;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Ray.BiliBiliTool.Config.Options;
using Ray.BiliBiliTool.Infrastructure;

namespace Ray.BiliBiliTool.Config.Extensions
{
    public static class ServiceCollectionExtension
    {
        /// <summary>
        /// 注册配置
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddBiliBiliConfigs(this IServiceCollection services, IConfiguration configuration)
        {
            //Options
            services.AddOptions()
                .Configure<JsonSerializerOptions>(o => o = JsonSerializerOptionsBuilder.DefaultOptions)
                .Configure<BiliBiliCookieOptions>(configuration.GetSection("BiliBiliCookie"))
                .Configure<DailyTaskOptions>(configuration.GetSection("DailyTaskConfig"))
                .Configure<LiveLotteryTaskOptions>(configuration.GetSection("LiveLotteryTaskConfig"))
                .Configure<LiveFansMedalTaskOptions>(configuration.GetSection("LiveFansMedalTaskConfig"))
                .Configure<UnfollowBatchedTaskOptions>(configuration.GetSection("UnfollowBatchedTaskConfig"))
                .Configure<VipBigPointTaskOptions>(configuration.GetSection("VipBigPointTaskConfig"))
                .Configure<SecurityOptions>(configuration.GetSection("Security"))
                .Configure<ReceiveVipPrivilegeOptions>(configuration.GetSection("ReceiveVipPrivilegeConfig"))
                .Configure<Dictionary<string, int>>(Constants.OptionsNames.ExpDictionaryName, configuration.GetSection(Constants.OptionsNames.ExpDictionaryName))
                .Configure<Dictionary<string, string>>(Constants.OptionsNames.DonateCoinCanContinueStatusDictionaryName, configuration.GetSection(Constants.OptionsNames.DonateCoinCanContinueStatusDictionaryName));

            return services;
        }
    }
}
