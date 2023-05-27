/*
    Function unevenNumbers(int[] array
    print all number in uneven index in array
    using Recurssion 
*/

namespace Excercise14
{
    class Program
    {
        static void Main(string[] args)
        {
            //create array with {9,8,7,6,5,4,3,2,1,0}
            int[] array = {9,8,7,6,5,4,3,2,1,0};
            unevenNumbers(array,0);
            Console.WriteLine(isSymmetric("ABCDEEdcbA"));
        }
        static void unevenNumbers(int[] array,int index)
        {
            if( index % 2 != 0)
            {
                Console.WriteLine(array[index]);
            }
            if(index < array.Length)
            {   
                unevenNumbers(array, index + 1);
            }
        }
        public static bool isSymmetric(string str)
        {
            for(int i = 0; i < str.Length/2; i++)
            {
                if(str[i] != str[str.Length - i -1 ])
                    {return false;}

            }
            return true;
        }

    }
}