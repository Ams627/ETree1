using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml.Linq;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System.Reflection;

namespace ETree1
{
    class Program
    {
        private static void Print(string s)
        {
            Console.WriteLine(s);
        }
        private static void Main(string[] args)
        {
            try
            {
                var str1 = Expression.Constant("Hello", typeof(string));
                var mi = typeof(Program).GetMethod("Print", BindingFlags.Static | BindingFlags.NonPublic);
                var lambda = Expression.Lambda(Expression.Call(mi, str1));
                Action res = (Action)lambda.Compile();
                res();
            }
            catch (Exception ex)
            {
                var fullname = System.Reflection.Assembly.GetEntryAssembly().Location;
                var progname = Path.GetFileNameWithoutExtension(fullname);
                Console.Error.WriteLine($"{progname} Error: {ex.Message}");
            }

        }
    }
}
