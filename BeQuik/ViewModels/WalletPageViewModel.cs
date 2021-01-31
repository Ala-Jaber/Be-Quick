using System;
using System.Collections.Generic;

namespace BeQuik.ViewModels
{
    public class WalletPageViewModel : BaseViewModel
    {
        public List<Model.Transaction> TransactionList { get; set; }
        public WalletPageViewModel()
        {
            TransactionList = new List<Model.Transaction>
            {
                new Model.Transaction{ Name="MT-D1BAC6B3EFT", Credit=0.00, Depth=1.25, Date=DateTime.Now},
                new Model.Transaction{ Name="MT-D1BAC6B3EFT", Credit=10.20, Depth=0.00, Date=DateTime.Now},
                new Model.Transaction{ Name="MT-D1BAC6B3EFT", Credit=20.10, Depth=32.25, Date=DateTime.Now},
                new Model.Transaction{ Name="MT-D1BAC6B3EFT", Credit=35.00, Depth=21.25, Date=DateTime.Now},
                new Model.Transaction{ Name="MT-D1BAC6B3EFT", Credit=0.35, Depth=12.25, Date=DateTime.Now},
            };
            OpenPage(new Views.WalletPage());
        }
    }
}