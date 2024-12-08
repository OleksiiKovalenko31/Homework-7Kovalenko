// See https://aka.ms/new-console-template for more information

// ---------------------
// | 0,0 || 0,1 || 0,2 |
// ---------------------
// | 1,0 || 1,1 || 1,2 |
// ---------------------
// | 2,0 || 2,1 || 2,2 |
// ---------------------

using System;
using System.ComponentModel.Design;
using static System.Runtime.InteropServices.JavaScript.JSType;
Console.OutputEncoding = System.Text.Encoding.UTF8;

int numberOfmoves = 1;
bool blendOut;
bool toggle = true; 
string inSymbol = " ";
int inputNum = 0;
string Gamer1 = "X" , Gamer2 = "O", Gamer = "", NameGamer = "";

//Створюємо масив і малюємо поле
string [,] GameArray = { { "1", "2", "3" }, {"4", "5", "6" }, { "7", "8", "9" } };
while (true)
    
{
    Console.Clear();
    Console.WriteLine("---------------");
    int ji;
   
    for (ji = 0; ji < 3; ji++)
    {
        for (int j = 0; j < 3; j++)
        {
            if (GameArray[ji, j] == inSymbol)
            {
                GameArray[ji, j] = Gamer;
            }
            Console.Write($"| {GameArray[ji, j]} |"); 

        }
        Console.WriteLine("\n---------------");
    }
    Console.WriteLine($"Хід - {numberOfmoves}");

    //Перевірка на виграш
    //Строки
    if ((GameArray[0, 0] == GameArray[0, 1] && GameArray[0, 0] == GameArray[0, 2]) || (GameArray[1, 0] == GameArray[1, 2] && GameArray[1, 1] == GameArray[1, 2]) || (GameArray[2, 0] == GameArray[2, 2] && GameArray[2,1] == GameArray[2, 2]))
    {
        Console.WriteLine($"Виграв {NameGamer} Вітаю!");
        break;
    }
    // Стовбики
    if ((GameArray[0, 0] == GameArray[2, 0] && GameArray[1, 0] == GameArray[2, 0]) || (GameArray[0, 1] == GameArray[2, 1] && GameArray[1, 1] == GameArray[2, 1]) || (GameArray[0, 2] == GameArray[2, 2] && GameArray[1, 2] == GameArray[2, 2]))
    {

            Console.WriteLine($"Виграв {NameGamer} Вітаю!");

        break;
    }
    //Діагоналі
    if ((GameArray[0, 0] == GameArray[2, 2] && GameArray[1, 1] == GameArray[2, 2]) || (GameArray[0, 2] == GameArray[2, 0] && GameArray[1, 1] == GameArray[2, 0]))
    {
        Console.WriteLine($"Виграв {NameGamer} Вітаю!");
        break;
    }
    // Нічия
    if (numberOfmoves == GameArray.Length + 1)
    {
        bool draw = false;
        foreach (string item in GameArray)
        {
            draw = int.TryParse(item, out int Num);
            if (draw == false)
            {
                Console.WriteLine("Нічия");
                break;
            }
        }
        break;
    }
  
    //Тумблер на перемикання гравця.
    if (toggle)
    {
        Gamer = Gamer1;
        NameGamer = "Гравець 1";
        Console.Write($"{NameGamer} введіть число від 1 до 9: ");
        blendOut = int.TryParse(Console.ReadLine(), out inputNum);
        toggle = false;
    }
    else
    {
        Gamer = Gamer2;
        NameGamer = "Гравець 2";
        Console.Write($"{NameGamer} введіть число від 1 до 9: ");
        blendOut = int.TryParse(Console.ReadLine(), out inputNum);
        toggle = true;
    }



    //Перевірка на коректність введених даних
    foreach (string numm in GameArray)
    {
        if (numm == Convert.ToString(inputNum))
        {
            blendOut = true;
            break;
        }
        else { blendOut =false; }   
    }

    if (blendOut == true && inputNum <= 9 && inputNum > 0)
    {
        inSymbol = Convert.ToString(inputNum);
        numberOfmoves++;

    }
    else if (blendOut == false && inputNum <= 9 && inputNum > 0)
    {
        Console.Write("Поле занято! ");
        Console.ReadKey();
        toggle = !toggle;
    }
    else 
    {
        Console.Write("неверный формат! ");
        Console.ReadKey();
        toggle = !toggle;
    }
    
    
}