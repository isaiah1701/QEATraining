using System;

class BankAccount
{
    private decimal balance = 0; // Encapsulation: Keep balance private

    public static void Main()
    {
        BankAccount account = new BankAccount();
        account.Run();
    }

    public void Run()
    {
        int choice;
        
        do
        {
            DisplayMenu();
            while (!int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > 4)
            {
                Console.WriteLine("Invalid input! Please enter a number between 1 and 4.");
                DisplayMenu();
            }

            switch (choice)
            {
                case 1:
                    Deposit();
                    break;
                case 2:
                    Withdraw();
                    break;
                case 3:
                    ShowBalance();
                    break;
                case 4:
                    Console.WriteLine("Thank you for using the banking app!");
                    return;
            }
        } while (choice != 4);
    }

    private void DisplayMenu()
    {
        Console.WriteLine("\nChoose an option:");
        Console.WriteLine("1: Deposit");
        Console.WriteLine("2: Withdraw");
        Console.WriteLine("3: Show Balance");
        Console.WriteLine("4: Exit");
        Console.Write("Enter your choice: ");
    }

    private void ShowBalance()
    {
        Console.WriteLine($"Your balance is £{balance:F2}");
    }

    private void Deposit()
    {
        Console.Write("Enter the amount to deposit: ");
        if (decimal.TryParse(Console.ReadLine(), out decimal amount) && amount > 0)
        {
            balance += amount;
            Console.WriteLine($"£{amount:F2} deposited successfully.");
        }
        else
        {
            Console.WriteLine("Invalid amount. Please enter a positive number.");
        }
    }

    private void Withdraw()
    {
        Console.Write("Enter the amount to withdraw: ");
        if (decimal.TryParse(Console.ReadLine(), out decimal amount) && amount > 0)
        {
            if (balance >= amount)
            {
                balance -= amount;
                Console.WriteLine($"£{amount:F2} withdrawn successfully.");
            }
            else
            {
                Console.WriteLine("Insufficient funds.");
            }
        }
        else
        {
            Console.WriteLine("Invalid amount. Please enter a positive number.");
        }
    }
}
