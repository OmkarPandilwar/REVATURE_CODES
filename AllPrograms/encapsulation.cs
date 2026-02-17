using System;
using System.Xml.Serialization;

class encapsulation
{
    private readonly object get;
    private string Bankname;
    private int Balance;
    private long Accno;
    private string Ifsc;
    private string loc;
    private int pin;


    public encapsulation(string Bankname ,int Balance ,long Accno ,string Ifsc, string loc,int pin)
    {
        this.Bankname=Bankname;
        this.Accno=Accno;
        this.Balance=Balance;
        this.Ifsc=Ifsc;
        this.loc=loc;
        this.pin=pin;
        Console.WriteLine("your account has been created !");

    }
    





 public string GetBankname()
{
    return this.Bankname;
}

public void SetPin(int pin ,int newpin)
    {
        if (this.pin == pin)
        {
            pin=newpin;
            Console.WriteLine(" pin changed succesfully ");
        }
        else
        {
            Console.WriteLine("invalid pin");
        }
        
    }


public void deposite(int amount)
    {
        if(amount > 0)
        {
            Balance+=amount;
        }
        else
        {
            Console.WriteLine("invalid amount please recheck ");
        }
    }


    public void withdrawl(int amount)
    {
        if (validate(Accno, pin))
        {
            if ( amount>0  && amount <= Balance)
            {
                Balance-=amount;
                Console.WriteLine("your account has been debited by rs "+amount);
                Console.WriteLine("your account balance is "+Balance);
            }
            else
            {
                Console.WriteLine("amount is insufficient or out of balance ");
            }
           
        } else
            {
                Console.WriteLine("enter valid credentials");
            }
        
    }


    public Boolean validate(long Accno ,int pin)
    {
        if(this.pin==pin && this.Accno == Accno)
        {
            return true;
        }
        else
        {
            return false;
        }
    }




    public static void Main()
    {
        encapsulation e1=new encapsulation("SBI",2000,7968010000003L,
        
        "VJBDAR12","PUNE",1234);

        Console.WriteLine(e1.Balance);
        Console.WriteLine(e1.Bankname);
        e1.deposite(2000);

        Console.WriteLine(e1.Balance);

        e1.withdrawl(500);
        Console.WriteLine(e1.Balance);


    }



}
