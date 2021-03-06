﻿using System;
using System.Linq;
using Kucoin.Api;
using Kucoin.Utility;
using Kucoin.WebSocket.Events;
using Microsoft.Extensions.Logging;

namespace Kucoin.WebSocket.UserData
{
    public class SingleUserDataWebSocketClient : UserDataWebSocketClient, ISingleUserDataWebSocketClient
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        public SingleUserDataWebSocketClient()
            : this (new WebSocketStreamProvider())
        { }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="streamProvider"></param>
        /// <param name="logger"></param>
        public SingleUserDataWebSocketClient(IWebSocketStreamProvider streamProvider, ILogger<SingleUserDataWebSocketClient> logger = null)
            : base(streamProvider.CreateStream(), logger)
        { }

        public override void Subscribe(string listenKey, IKucoinApiUser user, Action<UserDataEventArgs> callback)
        {
            Throw.IfNull(user, nameof(user));

            // Ensure only one user is subscribed.
            if (ListenKeys.Count > 0 && !ListenKeys.Single().Value.Equals(user))
                throw new InvalidOperationException($"{nameof(SingleUserDataWebSocketClient)}: Can only subscribe to a single a user.");

            base.Subscribe(listenKey, user, callback);
        }
    }
}
