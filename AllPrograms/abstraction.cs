using System;

abstract class Payment
{
    public abstract void Pay();

    public void Receipt()
    {
        Console.WriteLine("Receipt generated!");
    }
}

class CreditCardPayment : Payment
{
    
    public override void Pay()
    {
        Console.WriteLine("Payment from credit card!");
    }
}

class AbstractionDemo
{
    public static void Main()
    {
        Payment p = new CreditCardPayment();
        p.Pay();
        p.Receipt();
    }
}
