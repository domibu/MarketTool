﻿using System.Threading;
using System.Threading.Tasks;
using Kucoin.Api;

// ReSharper disable once CheckNamespace
namespace Kucoin.Cache
{
    public static class AccountInfoCacheExtensions
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="cache"></param>
        /// <param name="user"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public static Task SubscribeAndStreamAsync(this IAccountInfoCache cache, IKucoinApiUser user, CancellationToken token)
            => cache.SubscribeAndStreamAsync(user, null, token);
    }
}
