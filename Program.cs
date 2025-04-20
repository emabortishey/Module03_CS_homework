using static System.Console;

// ZADANIE 1

/*

Напишите метод, который отображает квадрат из
некоторого символа. Метод принимает в
качестве параметра: длину стороны квадрата, символ.

*/

WriteLine("Квадрат со стороной 5 из символов *:\n");
print_square('*', 5);

void print_square(char symb, int side)
{
    for(int i = 0; i< side; i++)
    {
        for(int j = 0; j < side; j++)
        {
            Write(symb + " ");
        }
        WriteLine();
    }
}

// ZADANIE 2

string number = ReadLine();
char[] first_half = new char[(number.Length)/2];
char[] second_half = new char[(number.Length) / 2];

if(number.Length % 2 == 0)
{
    number.CopyTo(0, first_half, 0, (number.Length) / 2);

    number.CopyTo(((number.Length - 1) / 2)+1, second_half, 0, (number.Length) / 2);
}