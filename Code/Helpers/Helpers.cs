using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_Project.Helpers
{
    public static class ResultHandlers<T>
    {
        public static readonly Func<Exception, T> ErrorDefault = ThrowError!;

        public static readonly Func<Exception, T> LogError = (err) => { Console.WriteLine(err); return default; };
        public static readonly Func<Exception, T> ThrowError = (err) => { throw err; };
    }
}
