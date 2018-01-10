﻿using System;
using Hyperbridge.Wallet;
using Hyperbridge.Ethereum;
using System.Threading.Tasks;
using N = Nethereum.Web3;

namespace Hyperbridge.Nethereum
{
    public class NethereumBalanceRead : IBalanceRead<Ether>
    {
        private string Url { get; }

        public NethereumBalanceRead(string url)
        {
            if (string.IsNullOrWhiteSpace(url)) throw new ArgumentNullException(nameof(url));
            Url = url;
        }

        public async Task<ICoin<Ether>> GetBalance(IAccount<Ether> account)
        {
            if (account == null) throw new ArgumentNullException(nameof(account));

            var client = GetClient(account);
            var balance = await client.Eth.GetBalance.SendRequestAsync(account.Address);
            decimal ether = N.Web3.Convert.FromWei(balance);

            return new EtherCoin(ether);
        }

        private N.Web3 GetClient(IAccount<Ether> account)
        {
            var nethereumAccount = new N.Accounts.Account(account.PrivateKey);
            return new N.Web3(nethereumAccount, Url);
        }
    }
}
