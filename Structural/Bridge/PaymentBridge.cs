using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.Structural.Bridge
{
    // Impemetor 

    public interface IPaymentGateway
    {
        void MakePayment(decimal amount);

    }

    // Concreate implementor 

    public class CreditCardPayment : IPaymentGateway
    {
        public void MakePayment(decimal amount)
        {
            Console.WriteLine($"Credit Card Payment :{amount}");
        }
    }

    public class UPIPayment : IPaymentGateway
    {
        public void MakePayment(decimal amount)
        {
            Console.WriteLine($"UPI Payment :{amount}");

        }
    }

     public class PayPalPayment : IPaymentGateway
    {
        public void MakePayment(decimal amount)
        {
            Console.WriteLine($"PayPal Payment :{amount}");

        }
    }

    // Abstration 

    public abstract class PaymentProcessor
    {

        protected readonly IPaymentGateway _paymentGateway;

        protected PaymentProcessor(IPaymentGateway paymentGateway)
        {
            _paymentGateway = paymentGateway;
        }

        public abstract void MakePayment(decimal amount);


    }

    // Concreate Abstration 

    public class OnlinePayment : PaymentProcessor
    {

        public OnlinePayment(IPaymentGateway paymentGateway) : base(paymentGateway)
        {
        }

        public override void MakePayment(decimal amount)
        {
            Console.WriteLine("Online Order payment processig started..");
            _paymentGateway.MakePayment(amount);
            Console.WriteLine("Online Order payment processig completed..");

        }
    }

    public class SubsriptionPayment : PaymentProcessor
    {
        public SubsriptionPayment(IPaymentGateway paymentGateway) : base(paymentGateway) { }
        public override void MakePayment(decimal amount)
        {
            Console.WriteLine("Subscription payment processig started..");
            _paymentGateway.MakePayment(amount);
            Console.WriteLine("Subscription payment processig completed..");
        }
    }

    public class PaymentBridgeClient
    {

        public static void Test()
        {

            // Make the payment using credit card
            PaymentProcessor paymentProcessor = new OnlinePayment(new CreditCardPayment());
            paymentProcessor.MakePayment(100);

            // Make the online payment using UPI
            paymentProcessor = new OnlinePayment(new UPIPayment());
            paymentProcessor.MakePayment(200);

            paymentProcessor = new SubsriptionPayment(new PayPalPayment());
            paymentProcessor.MakePayment(300);

 
        }
    }
}
