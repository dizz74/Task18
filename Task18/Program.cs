using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task18
{
    class Program
    {
        static void Main(string[] args)
        {
            string testString = "nfndif [fdfdf{aaaaaa}] (3333) (fffff) {ff{ff}f} {[(ddd)]}";// ok
            string testString2 = "nfndif [fdfdf{aa[aaaa}] (3333) (fffff) {ff{ff}f} {[(ddd)]}";// nok
            string testString3 = "nfndif [fdfdf{aaaaaa}] (3333) (fffff) {ff{ff}f} {[(ddd)]})";// nok
            string testString4 = "nfndif [fdfdf{aaaaaa}] (3333) (fffff) {ff{ff}f} }{[(ddd)]}";// nok
            string testString5 = "((f)";// nok
            string testString6 = "{s}f)";// nok
            string testString7 = "((f{a}";// nok
            string testString8 = "[avc[error}]}";// nok
            string testString9 = "{[[[a]]]}";// ok


            CheckString(testString);
            CheckString(testString2);
            CheckString(testString3);
            CheckString(testString4);
            CheckString(testString5);
            CheckString(testString6);
            CheckString(testString7);
            CheckString(testString8);
            CheckString(testString9);
            Console.ReadKey();
        }


        static void CheckString(string testStr)
        {
            Stack<char> stack = new Stack<char>();

            bool error = false;
            foreach (char curChr in testStr)
            {
                if (curChr == '{' || curChr == '(' || curChr == '[') stack.Push(curChr);
                if (curChr == '}' || curChr == ')' || curChr == ']')
                {

                    if (stack.Count == 0 || !IsPair(stack.Pop(), curChr))
                    {
                        error = true;
                        break;
                    }

                }
            }
            if (stack.Count > 0) error = true;

            if (error) Console.WriteLine("Строка {0} С ОШИБКОЙ скобок", testStr);
            else Console.WriteLine("Строка {0} ОК", testStr);
        }


        static bool IsPair(char c1, char c2)
        {
            if (c1 == '{') return c2 == '}';
            if (c1 == '[') return c2 == ']';
            if (c1 == '(') return c2 == ')';
            return false;
        }
    }
}
