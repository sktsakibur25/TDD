public class BankAccount {
    public string AccountNo { get; set; }
    public string Name { get; set; }
    public double Balance   { get; private set; }
    
    public void Deposit(double amount)
    {
        Balance = Balance + amount;
    }

    public void Withdraw(double amount)
    {
        if (Balance - amount >= 0)
        {
            Balance -= amount;
        }
        else
        {
            throw new ApplicationException("Insufficient balance");
        }
    }
}
