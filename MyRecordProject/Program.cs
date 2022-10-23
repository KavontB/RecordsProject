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
            //int counter = 0;
            List<string> recordNumbers = new List<string>();
            List<string> accountNumbers = new List<string>();
            List<string> fName = new List<string>();
            List<string> amountList = new List<string>();
            try
            {

                foreach (var line in file)
                {


                    var spaced = Regex.Replace(line, @"\s+", " ");
                    var strArr = spaced.Split(' ');
                    var recAndAcc = strArr[0] + " " + strArr[1];
                    var record = string.Join("", line.Take(4));
                    recordNumbers.Add(record);

                    // List<char> rNum = recordNum.ToList();
                    //var recordNum = line.Take(4);
                    // var record = string.Join("", recordNum);
                    //rNums.Add(record);

                    // List<char> rNum = recordNum.ToList();
                    // var accountNum = line.Skip(4).Take(14);
                    // var account = string.Join("", accountNum);
                    //  aNums.Add(account);
                    //I dont want to do it by the number of spaces because names can be different lengths 
                    //and i didnt want my code to only work for this file
                    var account = "";
                   
                    if (string.Join("", recAndAcc.Take(1)).Contains(" "))
                    {
                        account = string.Join("", recAndAcc.Skip(2).Take(10));
                        accountNumbers.Add(account);
                    }
                    else { 
                    account = string.Join("", recAndAcc.Skip(4).Take(10));
                    accountNumbers.Add(account);
                }
                    /*var first = idk[1];
                   var val = string.Join("", first);
                   fName.Add(val);
                   */

                    //var num =idk.TakeLast(7);

                    //var reversed = idk[idk.Length - 1].Reverse();
                    

                    var endOfLine = strArr[strArr.Length - 1];
                   // noname.TakeLast()


                    var amount = "";
                    if (string.Join("", endOfLine.TakeLast(1)).Contains("."))
                    {
                        amount = string.Join("", endOfLine.TakeLast(5));
                       // Console.WriteLine(string.Join("", endOfLine.TakeLast(5).Skip(4)));
                       // Console.WriteLine(string.Join("", endOfLine.TakeLast(5)));
                        amountList.Add(amount);
                    }
                    else
                    {
                        amount = string.Join("", endOfLine.TakeLast(7));
                        amountList.Add(amount);
                    }
                    

                    
                    //Convert.ToDouble(num);
                   // Console.WriteLine(num);
                    


                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error :{0} ", ex.Message);
            }
            for (int i = 0; i < recordNumbers.Count(); i++)
            {
                var value = 0.0;
                if (validate.RecordNumber_IsValid(recordNumbers[i]) == false)
                {
                    Console.WriteLine("Invalid Record Number " +
                        "on line " + $"{i + 1}");
                }
                if (validate.AccountNumber_IsValid(accountNumbers[i]) == false)
                {
                   
                    Console.WriteLine(recordNumbers[i] + " Account Number " + $"{accountNumbers[i]}");
                
                }
                try
                {
                     value = Convert.ToDouble(amountList[i]);
                }catch
                {
                    
                }
                if (validate.Amount_IsValid(value) == false)
                {

                    Console.WriteLine(recordNumbers[i] + " Amount " + $"{amountList[i]}");
                }
                

            }
           
        }

           


        }

    }

