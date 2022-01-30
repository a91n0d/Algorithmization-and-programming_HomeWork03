using System;

namespace Algorithmization_and_programming_HomeWork03
{
    class Program
    {
        static void Main(string[] args)
        {
            int number1, lenNumber1, number2, lenNumber2;

            Console.WriteLine("Введите первое число");
            EnterNumber(out number1, out lenNumber1);

            Console.WriteLine("Введите второе число");
            EnterNumber(out number2, out lenNumber2);

            int[] numberArr1 = NumberToArray(number1, lenNumber1);
            int[] numberArr2 = NumberToArray(number2, lenNumber2);
            int[] resultArr = ColumnAddition(numberArr1, numberArr2);
            int result = ArrayToNumber(resultArr);
            Console.WriteLine($"{number1} + {number2} = {result}");
        }

        static void EnterNumber(out int parseNumber, out int lenght)
        {
            string number = Console.ReadLine();
            lenght = number.Length;
            if (!int.TryParse(number, out parseNumber))
            {
                Console.WriteLine("Некоректный ввод.\nВведите целое число:");
                EnterNumber(out parseNumber, out lenght);
            }
        }

        static int[] NumberToArray(int number, int lenght)
        {
            int[] arr = new int[lenght];
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = number % 10;
                number /= 10;
            }

            return arr;
        }

        static int[] ColumnAddition(int[] numberArr1, int[] numberArr2)
        {
            int lenResultArr = numberArr1.Length >= numberArr2.Length ? numberArr1.Length + 1 : numberArr2.Length + 1;
            int[] resultArr = new int[lenResultArr];
            int temp = 0;
            for (int i = 0; i < resultArr.Length; i++)
            {
                if (i >= numberArr1.Length && i >= numberArr2.Length)
                {
                    resultArr[i] = temp;
                    continue;
                }
                else if (i >= numberArr1.Length)
                {
                    temp += numberArr2[i];
                }
                else if (i >= numberArr2.Length)
                {
                    temp += numberArr1[i];
                }
                else
                {
                    temp += numberArr1[i] + numberArr2[i];                   
                }

                resultArr[i] = temp % 10;
                temp /= 10;
            }

            return resultArr;
        }
        static int ArrayToNumber(int[] arr)
        {
            int number = 0;
            int index = 1;
            for (int i = 0; i < arr.Length; i++)
            {                
                number += arr[i] * index;
                index *= 10;
            }

            return number;
        }
    }
}
