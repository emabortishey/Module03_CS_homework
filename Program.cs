using System.Diagnostics.Metrics;
using System;
using static System.Console;
using System.Runtime.CompilerServices;
using System.Xml.Linq;

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

// массив который необходимо фильтровать
int[] orig = { 4, 1, 2, 3, 4, 2 };
// массив с числами с помощью которых будет проходить фильтрация
int[] filt = { 2, 4 };

// вызов метода и пприсвоение результата оригу
orig = mass_filtration(ref orig, filt);

// вывод результата (я неприлично долго мучалась с тем, что вместо
// массива у меня выводился System.Int[] поэтому залезла на форум
// и нашла там такой способ для вывода без ошибки так ещё и через запятую
WriteLine("Строка после фильтрации: " + string.Join(", ", orig));

int[] mass_filtration(ref int[] orig_mass, int[] filt_mass)
{
    // массив в который будут сохраняться значения
    // прошедшие фильтрацию без исключения
    int[] buff_mass = new int[orig_mass.Length];
    // счётчик для массива записи
    int counter = 0;
    // счётчик для удаленных элементов который
    // понадобится при создании массива без нулевых
    // значений в конце
    int deleted_count = 0;
    // параметр проверки прошёл ли элемент фильтрацию успешно
    bool check = false;

    //проходимся по оригинальному массиву
    for (int i = 0; i < orig_mass.Length; i++)
    {
        // при проходу по каждому значению ориг. массива
        // с помощью форича проверяем, не подходит ли оно
        // под какой-либо элемент из массива фильтрации
        foreach(int j in filt_mass)
        {
            // если хоть раз обнаружится равенство,
            // проверка не будет пройдена
            if(orig_mass[i] == j)
            {
                check = true;
            }
        }

        // если значение прошло фильтрацию успешно, записываем его
        // в буферный массив и увеличиваем его счётчик тек. индекса
        if (check == false) 
        {
            buff_mass[counter] = orig_mass[i];

            counter++;
        }
        // если элемент не прошёл фильтрацию, увеличиваем счётчик
        // удалённых элементов и возвращаем параметр проверки в фолс
        else
        {
            deleted_count++;

            check = false;
        }
    }

    // урезанный массив без нулевых элементов после оставшихся
    // (т.к. при возвращении просто буферного массива у мя после
    // оставшихся элементов выводились нули, а метод для
    // ресайза какого-нибудь я не нашла, поэтому решила сделать так)
    int[] buff_mass_clear = new int[buff_mass.Length - deleted_count];

    // в новый буф массив записываются элементы до
    // длины буф. массива - количество удаленных элементов
    for(int i = 0;i<buff_mass.Length-deleted_count;i++)
    {
        buff_mass_clear[i] = buff_mass[i];
    }

    // возвращаем чистый буферный массив
    return buff_mass_clear;
}

// ZADANIE 4

/*

Создайте класс «Веб-сайт». Необходимо хранить в
полях класса: название сайта, путь к сайту, описание
сайта, ip адрес сайта. Реализуйте методы класса для ввода
данных, вывода данных, реализуйте доступ к отдельным
полям через методы класса. 

*/

Web_Site RedWeb = new Web_Site("RedWeb", "RedWeb.ah", "RedWeb - your choice our pleasure.", 1247649356);

WriteLine("\nИспытание вывода с помощью метода print:\n");
RedWeb.print();
WriteLine($"\nИспытание вывода с помощью гетеров:\n\nНазвание: {RedWeb.Name}, \nПуть: {RedWeb.Way} \nОписание: {RedWeb.Description} \nАйпи адрес: {RedWeb.IP}");

public class Web_Site
{
    string _name;
    string _way;
    string _description;
    long _ip;

    public Web_Site(string name_p, string way_p, string desc_p, long ip_p)
    {
        _name = name_p;
        _way = way_p;
        _description = desc_p;
        _ip = ip_p;
    }

    public string Name
    {
        get { return _name; }
        set { _name = value; }
    }
    public string Way
    {
        get { return _way; }
        set { _way = value; }
    }
    public string Description
    {
        get { return _description; }
        set { _description = value; }
    }
    public long IP
    {
        get { return _ip; }
        set { _ip = value; }
    }

    public void print()
    {
        WriteLine($"Название: {_name}, \nПуть: {_way} \nОписание: {_description} \nАйпи адрес: {_ip}");
    }
}