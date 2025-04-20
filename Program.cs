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

/*

Напишите метод, который проверяет является ли
переданное число «палиндромом». Число передаётся в
качестве параметра. Если число палиндром 
нужно вернуть из метода true, иначе false.

Палиндром — число, которое читается одинаково как
справа налево, так и слева направо.

*/

// т.к. это не особо важно, принимаю у пользователя
// число строкой для удосбтва в будущем
WriteLine("\nВведите число для проверки на палиндром: ");

string user_numb = ReadLine();

// проверка результата работы метода и вывод
if (if_poly(user_numb))
{
    WriteLine("Переданное число является палиндромом.");
}
else
{
    WriteLine("Переданное число не является палиндромом.");
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

// ZADANIE 3

/*

Напишите метод, фильтрующий массив на основании
переданных параметров. Метод принимает параметры:
оригинальный_массив, массив_с_данными_для_фильтрации.

Метод возвращает оригинальный массив без элементов, которые есть в массиве для фильтрации.
Например:
1 2 6 - 1 88 7 6 — оригинальный массив;
6 88 7 — массив для фильтрации;
1 2 - 1 — результат работы метода.

*/

int[] orig = { 4, 1, 2, 3, 4, 2 };
int[] filt = { 2, 4 };
orig = mass_filtration(ref orig, filt);

WriteLine("Строка после фильтрации: " + string.Join(", ", orig));

int[] mass_filtration(ref int[] orig_mass, int[] filt_mass)
{
    int[] buff_mass = new int[orig_mass.Length];
    int counter = 0;
    int deleted_count = 0;
    bool check = false;

    for (int i = 0; i < buff_mass.Length; i++)
    {
        foreach(int j in filt_mass)
        {
            if(orig_mass[i] == j)
            {
                check = true;
            }
        }

        if (check == false) 
        {
            buff_mass[counter] = orig_mass[i];

            counter++;
        }
        else
        {
            deleted_count++;

            check = false;
        }
    }

    int[] buff_mass_clear = new int[buff_mass.Length - deleted_count];

    for(int i = 0;i<buff_mass.Length-deleted_count;i++)
    {
        buff_mass_clear[i] = buff_mass[i];
    }

    return buff_mass_clear;
}