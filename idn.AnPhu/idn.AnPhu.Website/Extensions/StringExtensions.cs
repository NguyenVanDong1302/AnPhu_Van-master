using Client.Core.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace idn.AnPhu.Website.Extensions
{
    public static class StringExtensions
    {
        public static string ToUrlSegment(this string value, int maxLength)
        {
            if (String.IsNullOrWhiteSpace(value))
            {
                return null;
            }

            string segment = value.NormalizeVNString();

            //value = value.Trim();
            //var segment = value;
            //if (value.ContainsAsciiChars())
            //{
            //    segment = segment.ToLower();

            //    //Step 1: Replace anything except a-z or -
            //    segment = Regex.Replace(segment, @"[^a-z0-9\- ]+", "");
            //    //Step 2: Replace spaces with -
            //    segment = Regex.Replace(segment, @" ", "-");
            //    //Step 3: Replace multiple - with just one (in case multiple unwanted chars where replaced in step 1 or step 2)
            //    segment = Regex.Replace(segment, @"-+", "-");
            //    //Step 4: Replace starting and ending - with nothing
            //    segment = Regex.Replace(segment, @"^-+|-+$", "");
            //}
            //else
            //{
            //    //will be url encoded by browser and encoded / decoded by webserver
            //}

            if (segment.Length > maxLength)
            {
                segment = segment.Substring(0, maxLength);
            }

            return segment;
        }

        public static string ToUrlSegment(this string value)
        {
            var maxLength = 2000; //url length on most browsers
            return value.ToUrlSegment(maxLength);
        }

        public static string ToTitleOnTable(this string value, int length)
        {
            string temp = "";
            if (value.Length > length)
            {
                temp = value.Substring(0, length) + "...";
            }
            else
            {
                temp = value;
            }
            return temp;
        }

    }
}