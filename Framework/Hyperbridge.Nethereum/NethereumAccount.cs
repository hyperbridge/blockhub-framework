﻿using System;
using Nethereum.Web3.Accounts;
using Hyperbridge.Wallet;

namespace Hyperbridge.Nethereum
{
    /// <summary>
    /// Nethereum account implementation
    /// </summary>
    public class NethereumAccount : IAccount
    {
        public NethereumAccount(Account account)
        {
            Account = account ?? throw new ArgumentNullException(nameof(account));
        }

        public Account Account { get; }

        public string Address => Account.Address;
        public string PrivateKey => Account.PrivateKey;
    }
}
