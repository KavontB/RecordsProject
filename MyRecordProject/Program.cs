using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace MyRecordProject
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"C:\Users\kavon\Downloads\SampleFile.txt";

            var file = File.ReadAllLines(path);
            Validate validate = new Validate();
            List<string> recordNumbers = new List<string>();
            List<string> accountNumbers = new List<string>();
            List<string> stateList = new List<string>();
            //List<string> cityList = new List<string>();
            List<string> amountList = new List<string>();



            foreach (var line in file)
            {


                var spaced = Regex.Replace(line, @"\s+", " ");
                var strArr = spaced.Split(' ');
                var recAndAcc = strArr[0] + " " + strArr[1];
                var record = string.Join("", line.Take(4));
                recordNumbers.Add(record);


                //I dont want to do it by the number of spaces because names can be different lengths 
                //and i wanted my code to be dynamic
                var account = "";

                if (string.Join("", recAndAcc.Take(1)).Contains(" "))
                {
                    account = string.Join("", recAndAcc.Skip(2).Take(10));
                    accountNumbers.Add(account);
                }
                else
                {
                    account = string.Join("", recAndAcc.Skip(4).Take(10));
                    accountNumbers.Add(account);
                }





                var endOfLine = strArr[strArr.Length - 1];
                //var secondToLast = strArr[strArr.Length - 2];



                var reversedStrArr = strArr.Reverse();

                var reversedEndOfLine = endOfLine.Reverse();

                var amount = "";
                var state = "";
                //var city = "";

                if (string.Join("", reversedStrArr.First().TakeLast(1)).Contains("."))
                {
                    amount = string.Join("", reversedStrArr.First().TakeLast(5));
                    state = string.Join("", reversedEndOfLine.Skip(5).Take(2).Reverse());
                    // city = string.Join("", reversedEndOfLine.Skip(7).Reverse());
                    // cityList.Add(city);
                    stateList.Add(state);
                    amountList.Add(amount);
                }
                else
                {

                    amount = string.Join("", reversedStrArr.First().TakeLast(7));
                    state = string.Join("", reversedEndOfLine.Skip(7).Take(2).Reverse());
                    // city = string.Join("", reversedEndOfLine.Skip(9).Reverse());
                    // Console.WriteLine(city);
                    //cityList.Add(city);
                    stateList.Add(state);
                    amountList.Add(amount);

                }
            }

            for (int i = 0; i < recordNumbers.Count(); i++)
            {
                var value = 0.0;
                if (!validate.RecordNumber_IsValid(recordNumbers[i]))
                {
                    Console.WriteLine("Invalid Record Number " +
                        "on line " + $"{i + 1}");
                }
                if (!validate.AccountNumber_IsValid(accountNumbers[i]))
                {

                    Console.WriteLine(recordNumbers[i] + " Account Number " + $"{accountNumbers[i]}");

                }
                try { value = Convert.ToDouble(amountList[i]); } catch { }
                if (!validate.Amount_IsValid(value))
                {

                    Console.WriteLine(recordNumbers[i] + " Amount " + $"{amountList[i]}");
                }
                if (!validate.State_IsValid(stateList[i]))
                {
                    Console.WriteLine(recordNumbers[i] + " State " + $"{stateList[i]}");
                }

            }

        }

    }

}

