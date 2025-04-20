using System.Diagnostics.Metrics;
using System;
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

string user_numb = ReadLine();

if (if_poly(user_numb))
{
    WriteLine("Переданное число является паллиндромом.");
}
else
{
    WriteLine("Переданное число не является паллиндромом.");
}

bool if_poly(string number)
{
    string f_half = number.Substring(0, (number.Length) / 2);
    string s_half = number.Substring(((number.Length - 1) / 2) + 1, (number.Length) / 2);

    bool check = false;
    int counter = 0;

    for (int i = 0, j = f_half.Length - 1; i < f_half.Length || j > -1; i++, j--)
    {
        if (f_half[i] == s_half[j])
        {
            counter++;
        }
    }

    if (counter == f_half.Length)
    {
        return true;
    }
    else
    {
        return false;
    }
}