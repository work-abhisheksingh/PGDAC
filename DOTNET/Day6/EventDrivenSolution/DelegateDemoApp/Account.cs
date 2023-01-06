namespace Banking;
using EGovernance;
using BankManager;
public class Account{

    public event TaxOperation overBalance;
    public event TaxOperation underBalance;
    public double Balance{get;set;}
    public Account(double amount){
        this.Balance=amount;
    }
    public void Deposit(double amount){
        this.Balance+=amount;
    }
    public void Withdraw(double amount){
        this.Balance-=amount;
    }
    public override string ToString()
    {
        return base.ToString() + "Current Balance ="+ this.Balance;
    }


    public void ProcessTax(){
        if(this.Balance >=250000){
            //raise an event   
            overBalance(this.Balance);    
        }
        else if(this.Balance<5000){
            underBalance(this.Balance);
            Console.WriteLine("Your Account has been blocked due to low balance...!!!");
        }
    }

}