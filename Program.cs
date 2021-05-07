using System;

namespace MPLSDogCalc
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int number_of_days;
            string code = "No service code entered";
            CostCalc[] calculations = new CostCalc[2];

            System.Console.WriteLine("Welcome to MPLS Dog Boarding Compute Rate Program\nThis program will compute the rate of your dogs stay based on a standard rate of $75.00\nor Two add-on packages, Package A: Bathing and Grooming for $169.00 per day or Package C: Bathing for $112.00 per day.\n");
            
            for (var x = 0; x < calculations.Length; x++)
            {
                //initializing
                number_of_days = welcome();
                code = getCode();
                calculations[x] = new CostCalc(number_of_days, code);
                Console.WriteLine(calculations[x]);
            }
        }
        public static int welcome()
        {
            int number_of_days;
            System.Console.WriteLine("Enter the number of days the dog will stay: ");
            number_of_days = Convert.ToInt32(Console.ReadLine());
            return number_of_days;
        }

        public static string getCode()
        {
            string code;
            Console.WriteLine("Please enter A for bath and groom, C for only bath");
            code = Console.ReadLine().ToUpper();
            code = checkCode(code);

            return code;
        }
        public static string checkCode(string code)
        {
            while(code != "A" & code != "C")
            {
                Console.WriteLine("Invalid entry -- Please Enter A for bath and groom C for just bath");
                code = Console.ReadLine();
                code = code.ToUpper();
            }
            return code;
        }
    }
    public class CostCalc
    {
        const double Rate = 75.00, CODE_A = 169.00, CODE_C = 112.00;
        string Code { get; set; } = "N/A";
        int DayCount { get; set; }
        double Total { get; set; }

        //default Constructor
        public CostCalc() { }

        //Overload Constructor
        public CostCalc(int dayCount, string code)
        {
            DayCount = dayCount;
            Code = code;
            computeRate(Code);
        }
        public CostCalc(int dayCount)
        {
            DayCount = dayCount;
            computeRate(Code);
        }

        //Working Method that determines Cost
        public double computeRate(string aValue)
        {
            const double CODE_A = 169.00, CODE_C = 112.00;

            //Decision logic for add-on, by code
            if(Code == "A")
            {
               return Total = CODE_A * DayCount;
            }else if(Code == "C")
            {
               return Total = CODE_C * DayCount;
            }
            else { return Total = Rate * DayCount; }
            
        }

        //Working method that validates code

        public override string ToString()
        {
            return string.Format($"Number of days for stay: [{DayCount}] Add on Services Code: [{Code}] Total cost of stay: [${Total}]\nThank you for using MPLS Dog Boarding Compute Rate Program");
        }

    }
}
