using System;
using System.Collections.Generic;

namespace NumbersToWordsConverter.Api.Models
{
    public class NumbersToWordsModel
    {
        public IList<Tuple<int, string>> Ones { get; set; }

        public IList<Tuple<int, string>> Tens { get; set; }

        public IList<Tuple<int, string>> Teens { get; set; }

        public IList<Tuple<int, string>> Hundreds { get; set; }

        public NumbersToWordsModel()
        {
            Ones = new List<Tuple<int, string>>();
            Ones.Add(new Tuple<int, string>(0, ""));
            Ones.Add(new Tuple<int, string>(1, "One"));
            Ones.Add(new Tuple<int, string>(2, "Two"));
            Ones.Add(new Tuple<int, string>(3, "Three"));
            Ones.Add(new Tuple<int, string>(4, "Four"));
            Ones.Add(new Tuple<int, string>(5, "Five"));
            Ones.Add(new Tuple<int, string>(6, "Six"));
            Ones.Add(new Tuple<int, string>(7, "Seven"));
            Ones.Add(new Tuple<int, string>(8, "Eight"));
            Ones.Add(new Tuple<int, string>(9, "Nine"));

            Teens = new List<Tuple<int, string>>();
            Teens.Add(new Tuple<int, string>(0, "Ten"));
            Teens.Add(new Tuple<int, string>(1, "Eleven"));
            Teens.Add(new Tuple<int, string>(2, "Twelve"));
            Teens.Add(new Tuple<int, string>(3, "Thirteen"));
            Teens.Add(new Tuple<int, string>(4, "Fourteen"));
            Teens.Add(new Tuple<int, string>(5, "Fifteen"));
            Teens.Add(new Tuple<int, string>(6, "Sixteen"));
            Teens.Add(new Tuple<int, string>(7, "Seventeen"));
            Teens.Add(new Tuple<int, string>(8, "Eighteen"));
            Teens.Add(new Tuple<int, string>(9, "Nineteen"));

            Tens = new List<Tuple<int, string>>();
            Tens.Add(new Tuple<int, string>(0, ""));
            Tens.Add(new Tuple<int, string>(1, "Ten"));
            Tens.Add(new Tuple<int, string>(2, "Twenty"));
            Tens.Add(new Tuple<int, string>(3, "Thirty"));
            Tens.Add(new Tuple<int, string>(4, "Forty"));
            Tens.Add(new Tuple<int, string>(5, "Fifty"));
            Tens.Add(new Tuple<int, string>(6, "Sixty"));
            Tens.Add(new Tuple<int, string>(7, "Seventy"));
            Tens.Add(new Tuple<int, string>(8, "Eighty"));
            Tens.Add(new Tuple<int, string>(9, "Ninety"));

            Hundreds = new List<Tuple<int, string>>();
            Hundreds.Add(new Tuple<int, string>(0, "hundred"));
            Hundreds.Add(new Tuple<int, string>(1, "thousand"));
            Hundreds.Add(new Tuple<int, string>(2, "million"));
        }
    }
}