
Customer Customer = new();
CardPayment CardPayment = new();
Customer.Pay(CardPayment);
GiftCard GiftCard = new GiftCard();
GiftCardToIPaymentAdapter GiftCardToIPaymentAdapter = new(GiftCard);
Customer.Pay(GiftCardToIPaymentAdapter);
public interface IPayment
{
    public void PayOffTheBalance();
}
public class CardPayment:IPayment
{
    public void PayOffTheBalance()
    {
        Console.WriteLine("Pay with card");
    }
}
public class Customer
{
    public void Pay(IPayment payment)
    {
        payment.PayOffTheBalance();   
    }
}
public interface IGiftCard
{
    public void Use();
}
public class GiftCard:IGiftCard
{
    public void Use()
    {
        Console.WriteLine("Pay with giftcard");
    }
}

public class GiftCardToIPaymentAdapter : IPayment
{
    GiftCard GiftCard;
    public GiftCardToIPaymentAdapter(GiftCard giftCard)
    {
        this.GiftCard = giftCard;
    }
    public void PayOffTheBalance()
    {
        GiftCard.Use();
    }
}

