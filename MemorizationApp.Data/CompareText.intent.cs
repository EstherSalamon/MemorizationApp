using MemorizationApp.Data.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MemorizationApp.Data
{
    public class CompareText
    {
        public static CompareTextResponse DoCompare(CompareTextRequest data, string connection)
        {
            return DoCompare(data, connection, CompareType.Exact);
        }

        public static CompareTextResponse DoCompare(CompareTextRequest data, string connection, CompareType compareType)
        {
            RecitalsRepository repo = new RecitalsRepository(connection);
            Recital originalRecital = repo.getById(data.RecitalId);

            CompareTextResponse response = new CompareTextResponse();

            switch(compareType)
            {
                case CompareType.Exact:
                    response = ExactTextCompare(originalRecital.Text, data.CompareText);
                    break;
            }

            return response; // TODO: change to status: success, data: response
        }

        private static CompareTextResponse ExactTextCompare(string recitalText, string compareText)
        {
            List<string> finalRecitalText = new List<string>();
            List<string> finalCompareText = new List<string>();

            string[] recitalTextWords = recitalText.Split(" ").Where(word => word != "").ToArray();
            string[] compareTextWords = compareText.Split(" ").Where(word => word != "").ToArray();

            try
            {
                for (int i = 0; i < recitalTextWords.Length; i++)
                {
                    if (i != recitalTextWords.Length && i == compareTextWords.Length)
                    {
                        finalRecitalText.Add(Spanify(String.Join(" ", recitalTextWords.Skip(i))));
                        break;
                    }
                    else if (!AreStringsEqual(recitalTextWords[i], compareTextWords[i]))
                    {
                        finalRecitalText.Add(Spanify(recitalTextWords[i]));
                        finalCompareText.Add(Spanify(compareTextWords[i]));
                    }
                    else
                    {
                        finalRecitalText.Add(recitalTextWords[i]);
                        finalCompareText.Add(compareTextWords[i]);
                    }
                }

                if(compareTextWords.Length > recitalTextWords.Length)
                {
                    finalCompareText.Add(Spanify(String.Join(" ", compareTextWords.Skip(recitalTextWords.Length))));
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("exact compare error: " + e);
            }

            return new CompareTextResponse { RecitalText = String.Join(" ", finalRecitalText), CompareText = String.Join(" ", finalCompareText) };
        }

        private static string Spanify(string text)
        {
            return $"<span>{text}</span>";
        }



        private static bool AreStringsEqual(string string1, string string2)
        {
            return AreStringsEqual(string1, string2, CompareType.Exact);
        }

        private static bool AreStringsEqual(string string1, string string2, CompareType type)
        {
            if(type == CompareType.Exact)
            {
                return string1 == string2;
            }
            else if(type == CompareType.Spellcheck)
            {
                if(string1 == string2)
                {
                    return true;
                }
                else
                {
                    return AreStringsSameLetters(string1, string2);
                }
            }
            else
            {
                return string1 == string2;
            }
        }

        private static bool AreStringsSameLetters(string string1, string string2)
        {
            return false; // TODO
        }
    }
}

public enum CompareType
{
    Exact,
    Spellcheck,
}

// TODO:
// use regex to split? add a mark, percentage of words correct. 
// the logic is basic, fix it for different lengths strings, multiple words. 
// give spans a classname?
