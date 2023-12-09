using System;
public interface IOrderState
{
    void ProcessOrder(Order order);
}

public class NewOrder : IOrderState
{
    public void ProcessOrder(Order order)
    {
        Console.WriteLine("Sifariş alındı");
        order.ChangeState(new InPreparation());
    }
}

public class InPreparation : IOrderState
{
    public void ProcessOrder(Order order)
    {
        Console.WriteLine("Sifariş gonderilmek ucun hazırlanir.");
        order.ChangeState(new Shipped());
    }
}

public class Shipped : IOrderState
{
    public void ProcessOrder(Order order)
    {
        Console.WriteLine("Sifariş teslim edilmek ucun gonderildi.");
        order.ChangeState(new Delivered());
    }
}

public class Delivered : IOrderState
{
    public void ProcessOrder(Order order)
    {
        Console.WriteLine("Sifariş teslim edildi ve isler tamamlandi.");
    }
}

public class Order
{
    private IOrderState currentState;

    public Order()
    {
        currentState = new NewOrder();
    }

    public void ChangeState(IOrderState newState)
    {
        currentState = newState;
    }

    public void ProcessOrder()
    {
        currentState.ProcessOrder(this);
    }
}

class Program
{
    static void Main(string[] args)
    {
        Order order = new Order();

        order.ProcessOrder();
        order.ProcessOrder();
        order.ProcessOrder();
        order.ProcessOrder();
        
    }
}