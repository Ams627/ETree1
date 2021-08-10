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
using System.Security.Cryptography;

namespace ETree1
{
    class Program
    {
        private void Print(string s)
        {
            Console.WriteLine(s);
        }

        Action GetAction(string s, Action<string> action)
        {
            var str1 = Expression.Constant(s, typeof(string));
            var lambda = Expression.Lambda(Expression.Invoke(Expression.Constant(action), str1));
            Action res = (Action)lambda.Compile();
            return res;
        }
        private static void Main(string[] args)
        {
            try
            {
                var p = new Program();
                var ares1 = p.GetAction("World", p.Print);
                ares1.Invoke();
                var ares2 = p.GetAction("Mars", x => Console.WriteLine(x));
                ares2.Invoke();
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
