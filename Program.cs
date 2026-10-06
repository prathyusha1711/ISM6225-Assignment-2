// QUESTION 1 - Subscription Revenue Calculator

Console.Write("Enter the current number of customers: ");
int customers = Convert.ToInt32(Console.ReadLine());

Console.Write("Enter the monthly price per customer: $");
decimal monthlyPrice = Convert.ToDecimal(Console.ReadLine());

Console.Write("Enter the percentage price increase: ");
decimal percentageIncrease = Convert.ToDecimal(Console.ReadLine());

decimal currentMonthlyRevenue = customers * monthlyPrice;
decimal increaseRate = percentageIncrease / 100M;
decimal projectedPrice = monthlyPrice * (1M + increaseRate);
decimal projectedMonthlyRevenue = customers * projectedPrice;
decimal dollarIncrease = projectedMonthlyRevenue - currentMonthlyRevenue;

Console.WriteLine($"Current monthly revenue: {currentMonthlyRevenue:C2}");
Console.WriteLine($"Projected monthly revenue: {projectedMonthlyRevenue:C2}");
Console.WriteLine($"Dollar increase: {dollarIncrease:C2}");



// QUESTION 2 - Investment Doubling Time

Console.Write("Enter the annual return rate as a percentage: ");
double ratePercentage = Convert.ToDouble(Console.ReadLine());

if (ratePercentage <= 0)
{
    Console.WriteLine("Annual return rate must be greater than zero.");
}
else
{
    double rate = ratePercentage / 100;
    double doublingTime = Math.Log(2) / Math.Log(1 + rate);

    string classification;

    if (doublingTime < 10)
    {
        classification = "Fast";
    }
    else if (doublingTime <= 20)
    {
        classification = "Moderate";
    }
    else
    {
        classification = "Slow";
    }

    Console.WriteLine($"Doubling time: {doublingTime:F2} years");
    Console.WriteLine($"Classification: {classification}");
}

// QUESTION 3 - Delivery Region Triangle

try
{
    Console.Write("Enter side a: ");
    double a = Convert.ToDouble(Console.ReadLine());

    Console.Write("Enter side b: ");
    double b = Convert.ToDouble(Console.ReadLine());

    Console.Write("Enter side c: ");
    double c = Convert.ToDouble(Console.ReadLine());

    if (a <= 0 || b <= 0 || c <= 0)
    {
        Console.WriteLine("All side lengths must be positive.");
    }
    else if (a + b <= c || a + c <= b || b + c <= a)
    {
        Console.WriteLine("Invalid triangle. The side lengths do not satisfy the triangle rule.");
    }
    else
    {
        double s = (a + b + c) / 2;
        double area = Math.Sqrt(s * (s - a) * (s - b) * (s - c));

        Console.WriteLine($"Triangle area: {area:F2}");
    }
}
catch (FormatException)
{
    Console.WriteLine("Invalid input. Enter numeric side lengths.");

}


// QUESTION 4 - Cloud Usage Invoice

Console.Write("Enter the number of compute hours used: ");
decimal hours = Convert.ToDecimal(Console.ReadLine());

if (hours < 0)
{
    Console.WriteLine("Compute hours cannot be negative.");
}
else
{
    decimal usageCharge;

    if (hours <= 100)
    {
        usageCharge = hours * 0.12M;
    }
    else if (hours <= 500)
    {
        usageCharge =
            (100M * 0.12M) +
            ((hours - 100M) * 0.09M);
    }
    else
    {
        usageCharge =
            (100M * 0.12M) +
            (400M * 0.09M) +
            ((hours - 500M) * 0.06M);
    }

    decimal serviceFee = usageCharge * 0.05M;
    decimal totalInvoice = usageCharge + serviceFee;

    Console.WriteLine($"Usage charge: {usageCharge:C2}");
    Console.WriteLine($"Service fee: {serviceFee:C2}");
    Console.WriteLine($"Total invoice: {totalInvoice:C2}");
}

// QUESTION 5 - Daily Sales Entry with a Sentinel


decimal totalSales = 0M;
int validSalesCount = 0;
bool stopProgram = false;

while (stopProgram == false)
{
    Console.Write("Enter a sale amount (-1 to stop): ");
    decimal saleAmount = Convert.ToDecimal(Console.ReadLine());

    if (saleAmount == -1M)
    {
        stopProgram = true;
    }
    else if (saleAmount < 0)
    {
        Console.WriteLine("Invalid sale amount. Please enter zero or a positive value.");
    }
    else
    {
        totalSales = totalSales + saleAmount;
        validSalesCount = validSalesCount + 1;
    }
}

if (validSalesCount == 0)
{
    Console.WriteLine("No valid sales were entered.");
}
else
{
    decimal averageSale = totalSales / validSalesCount;

    Console.WriteLine("Number of valid sales: " + validSalesCount);
    Console.WriteLine("Total sales: $" + totalSales.ToString("F2"));
    Console.WriteLine("Average sale: $" + averageSale.ToString("F2"));
}

// QUESTION 6 - Investment Payback Simulator


Console.Write("Enter the initial investment: $");
decimal initialInvestment = Convert.ToDecimal(Console.ReadLine());

Console.Write("Enter the expected monthly benefit: $");
decimal monthlyBenefit = Convert.ToDecimal(Console.ReadLine());

if (initialInvestment <= 0 || monthlyBenefit <= 0)
{
    Console.WriteLine("Initial investment and monthly benefit must both be greater than zero.");
}
else
{
    decimal cumulativeBenefits = 0M;
    int month = 0;

    while (cumulativeBenefits < initialInvestment && month < 600)
    {
        month = month + 1;

        cumulativeBenefits = cumulativeBenefits + monthlyBenefit;

        decimal unrecoveredBalance =
            initialInvestment - cumulativeBenefits;

        if (unrecoveredBalance < 0)
        {
            unrecoveredBalance = 0;
        }

        Console.WriteLine(
            "Month " + month +
            ": Unrecovered balance = $" +
            unrecoveredBalance.ToString("F2"));
    }

    if (cumulativeBenefits >= initialInvestment)
    {
        Console.WriteLine("Payback month: " + month);

        Console.WriteLine(
            "Cumulative benefits at payback: $" +
            cumulativeBenefits.ToString("F2"));
    }
    else
    {
        Console.WriteLine("Investment was not recovered within 600 months.");
    }
}
// QUESTION 7 - Weekly Demand Bar Chart


int[] demand = new int[7];

for (int i = 0; i < demand.Length; i++)
{
    Console.Write("Enter demand for day " + (i + 1) + ": ");
    int value = Convert.ToInt32(Console.ReadLine());

    while (value < 0)
    {
        Console.WriteLine("Demand cannot be negative.");
        Console.Write("Enter demand for day " + (i + 1) + ": ");
        value = Convert.ToInt32(Console.ReadLine());
    }

    demand[i] = value;
}

Console.WriteLine();
Console.WriteLine("Weekly Demand Bar Chart");

for (int i = 0; i < demand.Length; i++)
{
    int numberOfStars = demand[i] / 10;

    Console.Write("Day " + (i + 1) + ": " + demand[i] + " ");

    for (int j = 0; j < numberOfStars; j++)
    {
        Console.Write("*");
    }

    Console.WriteLine();
}

// QUESTION 8 - Customer Risk Score Method


Console.Write("Enter missed payments: ");
int missedPayments = Convert.ToInt32(Console.ReadLine());

Console.Write("Enter support tickets: ");
int supportTickets = Convert.ToInt32(Console.ReadLine());

Console.Write("Enter months inactive: ");
int monthsInactive = Convert.ToInt32(Console.ReadLine());

if (missedPayments < 0 || supportTickets < 0 || monthsInactive < 0)
{
    Console.WriteLine("All inputs must be zero or greater.");
}
else
{
    int riskScore = ComputeRiskScore(
        missedPayments,
        supportTickets,
        monthsInactive);

    string classification;

    if (riskScore < 30)
    {
        classification = "Low";
    }
    else if (riskScore < 60)
    {
        classification = "Moderate";
    }
    else
    {
        classification = "High";
    }

    Console.WriteLine("Risk score: " + riskScore);
    Console.WriteLine("Classification: " + classification);
}

static int ComputeRiskScore(
    int missedPayments,
    int supportTickets,
    int monthsInactive)
{
    int score =
        missedPayments * 20 +
        supportTickets * 5 +
        monthsInactive * 8;

    return score;
}
// QUESTION 9 - Transaction Anomaly Screening


Console.Write("How many transaction amounts will be entered? ");
int count = Convert.ToInt32(Console.ReadLine());

if (count < 3 || count > 20)
{
    Console.WriteLine("Number of transactions must be from 3 through 20.");
}
else
{
    decimal[] transactions = new decimal[count];

    for (int i = 0; i < count; i++)
    {
        Console.Write("Enter transaction " + (i + 1) + ": $");
        decimal amount = Convert.ToDecimal(Console.ReadLine());

        while (amount < 0)
        {
            Console.WriteLine("Transaction amount cannot be negative.");
            Console.Write("Enter transaction " + (i + 1) + ": $");
            amount = Convert.ToDecimal(Console.ReadLine());
        }

        transactions[i] = amount;
    }

    decimal total = 0M;
    decimal minimum = transactions[0];
    decimal maximum = transactions[0];

    for (int i = 0; i < count; i++)
    {
        total = total + transactions[i];

        if (transactions[i] < minimum)
        {
            minimum = transactions[i];
        }

        if (transactions[i] > maximum)
        {
            maximum = transactions[i];
        }
    }

    decimal mean = total / count;

    Console.WriteLine();
    Console.WriteLine("Minimum: $" + minimum.ToString("F2"));
    Console.WriteLine("Maximum: $" + maximum.ToString("F2"));
    Console.WriteLine("Total: $" + total.ToString("F2"));
    Console.WriteLine("Mean: $" + mean.ToString("F2"));

    Console.WriteLine();
    Console.WriteLine("Transaction Screening Results");

    for (int i = 0; i < count; i++)
    {
        string result;

        if (transactions[i] > 1.5M * mean)
        {
            result = "Review";
        }
        else
        {
            result = "Normal";
        }

        Console.WriteLine(
            "Transaction " + (i + 1) +
            ": $" + transactions[i].ToString("F2") +
            " - " + result);
    }

}

// QUESTION 10 - Seven Day Performance Summary



decimal[] sales = new decimal[7];

for (int i = 0; i < sales.Length; i++)
{
    bool validInput = false;

    while (validInput == false)
    {
        try
        {
            Console.Write("Enter sales for day " + (i + 1) + ": $");
            decimal value = Convert.ToDecimal(Console.ReadLine());

            if (value < 0)
            {
                Console.WriteLine("Sales cannot be negative.");
            }
            else
            {
                sales[i] = value;
                validInput = true;
            }
        }
        catch (FormatException)
        {
            Console.WriteLine("Invalid input. Enter a numeric sales value.");
        }
    }
}

decimal q10Total = CalculateTotal(sales);
decimal q10Average = CalculateAverage(sales);
decimal q10Highest = FindHighest(sales);
decimal q10Lowest = FindLowest(sales);
int q10DaysAboveAverage =
    CountDaysAboveAverage(sales, q10Average);

Console.WriteLine();
Console.WriteLine("Daily Sales");

for (int i = 0; i < sales.Length; i++)
{
    Console.WriteLine(
        "Day " + (i + 1) + ": $" +
        sales[i].ToString("F2"));
}

Console.WriteLine("Total sales: $" +
    q10Total.ToString("F2"));

Console.WriteLine("Average sales: $" +
    q10Average.ToString("F2"));

Console.WriteLine("Highest sales: $" +
    q10Highest.ToString("F2"));

Console.WriteLine("Lowest sales: $" +
    q10Lowest.ToString("F2"));

Console.WriteLine("Days above average: " +
    q10DaysAboveAverage);

string q10Classification;

if (q10DaysAboveAverage >= 4)
{
    q10Classification = "Strong";
}
else if (q10DaysAboveAverage >= 2)
{
    q10Classification = "Balanced";
}
else
{
    q10Classification = "Concentrated";
}

Console.WriteLine(
    "Week classification: " + q10Classification);


// METHOD 1
static decimal CalculateTotal(decimal[] values)
{
    decimal result = 0M;

    for (int i = 0; i < values.Length; i++)
    {
        result = result + values[i];
    }

    return result;
}


// METHOD 2
static decimal CalculateAverage(decimal[] values)
{
    decimal result = 0M;

    for (int i = 0; i < values.Length; i++)
    {
        result = result + values[i];
    }

    return result / values.Length;
}


// METHOD 3
static decimal FindHighest(decimal[] values)
{
    decimal highestValue = values[0];

    for (int i = 1; i < values.Length; i++)
    {
        if (values[i] > highestValue)
        {
            highestValue = values[i];
        }
    }

    return highestValue;
}


// METHOD 4
static decimal FindLowest(decimal[] values)
{
    decimal lowestValue = values[0];

    for (int i = 1; i < values.Length; i++)
    {
        if (values[i] < lowestValue)
        {
            lowestValue = values[i];
        }
    }

    return lowestValue;
}


// METHOD 5
static int CountDaysAboveAverage(
    decimal[] values,
    decimal average)
{
    int aboveAverageCount = 0;

    for (int i = 0; i < values.Length; i++)
    {
        if (values[i] > average)
        {
            aboveAverageCount =
                aboveAverageCount + 1;
        }
    }

    return aboveAverageCount;
}

