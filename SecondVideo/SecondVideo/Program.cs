// See https://aka.ms/new-console-template for more information

byte smalestNumber = 255;
short middleNumber = 32_000;
int usualNumber = 1_000_000;
long biggestNumber = 100_000_000_000;

float withPoint = 1.32F;
double betterPoint = 1.1312451266D;
decimal financialPoint = 1.32M;

string justWords = "Простая строка";

bool isTrue = true;

Console.WriteLine($"{smalestNumber} - Smallest number type\n" +
                  $"{middleNumber} - Middle number type\n" +
                  $"{usualNumber} - Most offence used number type\n" +
                  $"{biggestNumber} - Biggest number type\n" +
                  $"\n" +
                  $"{withPoint} - Float, number with dot\n" +
                  $"{betterPoint} - Double, common dot type, have 'D' on the end\n" +
                  $"{financialPoint} - Decimal, most often used dot type in financial organizatoion\n" +
                  $"\n" +
                  $"{justWords} - Thats just string, type here any words =)\n" +
                  $"\n" +
                  $"{isTrue} - thats bool, he wants told you about true and false");

// Some magic here

Console.WriteLine();

bool isInt = true;
bool isDividedByTwo = true;

bool isRightNumber = isInt == true;

bool isEven = isRightNumber == true && isDividedByTwo == true;
bool isOdd = isRightNumber == true && isDividedByTwo == false;

Console.WriteLine("Четное? " + isEven + "\nНечетное? " + isOdd + "\nА вообще число правильное? " + isRightNumber);


