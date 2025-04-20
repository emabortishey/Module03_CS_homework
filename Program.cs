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

// т.к. это не особо важно, принимаю у пользователя
// число строкой для удосбтва в будущем
string user_numb = ReadLine();

// проверка результата работы метода и вывод
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
    // первая половина строки и вторая для будущего сравнения
    // (если в строке нечётное количество символов, 
    // средний не учитывается и не записывается ни в 1 из них)
    string f_half = number.Substring(0, (number.Length) / 2);
    string s_half = number.Substring(((number.Length - 1) / 2) + 1, (number.Length) / 2);

    // счётчик идентичности символов в строках
    int counter = 0;

    // т.к. у меня почему-то не работал метод reverse, я сравниваю
    // строки циклом, с помощью двух счётчиков, 1 из которых 
    // идёт с отметки конца второй строки, а другой с начала первой
    for (int i = 0, j = f_half.Length - 1; i < f_half.Length || j > -1; i++, j--)
    {
        if (f_half[i] == s_half[j])
        {
            counter++;
        }
    }

    // если счётчик срабтал при каждом символе
    // строк, то есть они равны, возвращается тру
    if (counter == f_half.Length)
    {
        return true;
    }
    // если счётчик меньше, то фолс
    else
    {
        return false;
    }
}