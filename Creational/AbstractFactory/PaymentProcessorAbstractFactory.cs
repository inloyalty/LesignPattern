using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.Creational.AbstractFactory
{
    // Abstract Product 
    public interface IPaymentProcessor
    {
        void MakePayment();
    }


    public interface IReceiptGenerator
    {

        void GenerateReceipt();
    }

    // Concreate Product 

    public class PayPalPaymentProcessor : IPaymentProcessor
    {
        public void MakePayment()
        {
            Console.WriteLine("Paid through Palpal");
        }
    }

    public class PayPalReceiptGenerator : IReceiptGenerator
    {
        public void GenerateReceipt()
        {
            Console.WriteLine("Paypal Receipt");
        }
    }

    public class UPIPaymentProcessor : IPaymentProcessor
    {
        public void MakePayment()
        {
            Console.WriteLine("Paid through UPI");

        }
    }

    public class UPIReceiptGenerator : IReceiptGenerator
    {
        public void GenerateReceipt()
        {
            Console.WriteLine("UPI Receipt");
        }
    }

    // Abstract Factory 
    public interface IPaymentFactory
    {
        IPaymentProcessor CreatePaymentProcessor();
        IReceiptGenerator CreateReportGenerator();
    }

    //  Concreate Factories 

    public class PayPalFactory : IPaymentFactory
    {
        public IPaymentProcessor CreatePaymentProcessor()
                => new PayPalPaymentProcessor();


        public IReceiptGenerator CreateReportGenerator()
                => new PayPalReceiptGenerator();

    }

    public class UPIFactory : IPaymentFactory
    {
        public IPaymentProcessor CreatePaymentProcessor()
               => new UPIPaymentProcessor();

        public IReceiptGenerator CreateReportGenerator()
               => new UPIReceiptGenerator();
    }

    public class CheckoutService
    {

        private readonly IPaymentProcessor _paymentProcessor;
        private readonly IReceiptGenerator _receiptGenerator;

        public CheckoutService(IPaymentFactory paymentFactory)
        {
            _paymentProcessor = paymentFactory.CreatePaymentProcessor();
            _receiptGenerator = paymentFactory.CreateReportGenerator();
        }

        public void ProcessPayment()
        {
            _paymentProcessor.MakePayment();
            _receiptGenerator.GenerateReceipt();
        }
    }



    public class PaymentProcessorAbstractFactoryClient
    {

        public static void Test()
        {
            // Use the Paypal Factory 
            IPaymentFactory paymentFactory = new PayPalFactory();
            CheckoutService checkoutService = new CheckoutService(paymentFactory);
            checkoutService.ProcessPayment();

            // Make the payment using UPI 
            paymentFactory = new UPIFactory();
            checkoutService = new CheckoutService(paymentFactory);
            checkoutService.ProcessPayment();
        }
    }
}
