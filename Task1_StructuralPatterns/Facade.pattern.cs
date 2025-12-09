using System;
class AuthService { public void CheckUser(string login, string pass) { } }
class PaymentService { public void Pay(decimal sum) { } }
class NotificationService { public void SendMail(string msg) { } }

class ShopFacade
{
    private readonly AuthService _auth = new();
    private readonly PaymentService _payment = new();
    private readonly NotificationService _notify = new();

    public void Buy(string login, string pass, decimal amount)
    {
        _auth.CheckUser(login, pass);
        _payment.Pay(amount);
        _notify.SendMail("Purchase successful!");
    }
}

