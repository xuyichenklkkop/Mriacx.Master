using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mriacx.Common.Utils
{
    public static class StringExtensions
    {
        public static List<string> RemoveEmptySplit(this string str, params char[] splits)
        {
            if (string.IsNullOrWhiteSpace(str))
            {
                return new List<string>();
            }

            var split = new[] { ',' };
            if (splits.Length > 0)
            {
                split = splits;
            }

            return str.Split(split, StringSplitOptions.RemoveEmptyEntries).ToList();
        }

        /// <summary>
        /// 分割字符
        /// </summary>
        /// <param name="str"></param>
        /// <param name="split"></param>
        /// <returns></returns>
        public static List<string> RemoveEmptySplit(this string str, string split)
        {
            if (string.IsNullOrWhiteSpace(str))
            {
                return new List<string>();
            }

            return str.Split(new[] { split }, StringSplitOptions.RemoveEmptyEntries).ToList();
        }
    }
}
