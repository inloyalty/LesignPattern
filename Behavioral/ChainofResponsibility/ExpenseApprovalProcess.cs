using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.Behavioral.ChainofResponsibility
{
    public record ExpenseRequest(string name, decimal amount);

    public interface IManager
    {

        void NextApprover(IManager manager);
        void ApproveRequest(ExpenseRequest expenseRequest);
    }


    public class SeniorManager : IManager
    {
        private IManager _manager;
        public void ApproveRequest(ExpenseRequest expenseRequest)
        {
            if (expenseRequest.amount < 1000)
                Console.WriteLine($"Approve by Manager {expenseRequest.amount}");
            else
                _manager?.ApproveRequest(expenseRequest);
        }

        public void NextApprover(IManager manager)
        {
            _manager = manager;
        }
    }

    public class VP : IManager
    {
        private IManager _manager;
        public void ApproveRequest(ExpenseRequest expenseRequest)
        {
            if (expenseRequest.amount < 5000)
                Console.WriteLine($"Approve by VP {expenseRequest.amount}");
            else
                _manager?.ApproveRequest(expenseRequest);
        }

        public void NextApprover(IManager manager)
        {
            _manager = manager;
        }
    }


    public class CEO : IManager
    {
        private IManager _manager;
        public void ApproveRequest(ExpenseRequest expenseRequest)
        {
            Console.WriteLine($"Approve by CEP {expenseRequest.amount}");

        }

        public void NextApprover(IManager manager)
        {
            _manager = manager;
        }
    }

    public class ExpenseChainOfResposibilityClient
    {

        public static void Test()
        {
            var manager = new SeniorManager();
            var vp = new VP();
            var ceo = new CEO();

            // Set the Approval process 
            manager.NextApprover(vp);
            vp.NextApprover(ceo);

            var expense = new ExpenseRequest("Headphone", 900);
            manager.ApproveRequest(expense);

            expense = new ExpenseRequest("Monitor", 4000);
            manager.ApproveRequest(expense);


            expense = new ExpenseRequest("CPU", 10000);
            manager.ApproveRequest(expense);

        }
    }
    
}
