namespace BankApp
{
    class Account
    {
        private long _accountNumber { get; set; } //TODO
        private decimal _balance { get; } //TODO

        // Daily Transactions
        public void Deposit() // TODO
        {
            //Credit()
            //      => SetBalance()
            //Notify("Amount credited: {}, Current Balance: {}")
        }
        public void Withdraw() // TODO
        {
            //GetBalance()-DebitAmount<0?Notify("Low Balance Error"):Debit()
            //=>SetBalance() 
            //GetBalance()<min?Notify(".."):return Balance?? //TODO
        }
        public void GetBalance() // TODO
        {

        }
        private void SetBalance() // TODO
        {

        }
        public void Notify() // TODO
        {

        }

        //public void GetStatement() // Future TODO
        //{
        //    // Download()
        //}
    }
}