﻿using System;
using Kucoin.Api;
using Kucoin.Utility;

namespace Kucoin.Account.Orders
{
    public abstract class ClientOrder : IChronological
    {
        #region Public Properties

        /// <summary>
        /// Get the user.
        /// </summary>
        public IKucoinApiUser User { get; }

        /// <summary>
        /// Get or set the symbol.
        /// </summary>
        public string Symbol { get; set; }

        /// <summary>
        /// Get the order type.
        /// </summary>
        public abstract OrderType Type { get; }

        /// <summary>
        /// Get or set the order side.
        /// </summary>
        public OrderSide Side { get; set; }

        /// <summary>
        /// Get or set the quantity.
        /// </summary>
        public decimal Quantity { get; set; }

        /// <summary>
        /// Get or set the client order ID.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Get the transact time.
        /// </summary>
        public DateTime Time { get; internal set; }

        #endregion Public Properties

        #region Constructors

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="user"></param>
        protected ClientOrder(IKucoinApiUser user)
        {
            Throw.IfNull(user, nameof(user));

            User = user;
        }

        #endregion Constructors
    }
}
