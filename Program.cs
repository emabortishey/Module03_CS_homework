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