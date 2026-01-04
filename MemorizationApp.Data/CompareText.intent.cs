using MemorizationApp.Data.Classes;
using Microsoft.IdentityModel.Tokens;
using NHunspell;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
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

            try
            {
                response.Data = ExactTextCompare(originalRecital.Text, data.CompareText, CompareType.ExactNoPunctuation);
                response.Status = ResponseStatus.Success;
            }
            catch(Exception e)
            {
                Console.WriteLine("Compare Text Error: " + e);
                response.Status = ResponseStatus.Error;
                response.Message = "An error occured, please try again soon";
            }

            return response;
        }

        private static CompareTextData ExactTextCompare(string recitalText, string compareText, CompareType type)
        {
            List<string> finalRecitalText = new List<string>();
            List<string> finalCompareText = new List<string>();

            string[] recitalTextWords = RemovePunctuation(recitalText, type).Split(" ").Where(word => !word.IsNullOrEmpty()).ToArray();
            string[] compareTextWords = RemovePunctuation(compareText, type).Split(" ").Where(word => !word.IsNullOrEmpty()).ToArray();

            for (int i = 0; i < recitalTextWords.Length; i++)
            {
                if (i == compareTextWords.Length)
                {
                    finalRecitalText.Add(Spanify(String.Join(" ", recitalTextWords.Skip(i))));
                    break;
                }
                else if(AreWordsEqual(recitalTextWords[i], compareTextWords[i], type))
                {
                    finalRecitalText.Add(recitalTextWords[i]);
                    finalCompareText.Add(compareTextWords[i]);
                }
                else
                {
                    int startIndex = i;
                    int endIndex = i + 1;
                    for(int j = i + 1; j < recitalTextWords.Length; j++)
                    {
                        if(j == compareTextWords.Length || AreWordsEqual(recitalTextWords[j], compareTextWords[j], type))
                        {
                            break;
                        }
                        else
                        {
                            i = j;
                            endIndex++;
                        }
                    }

                    //if(isExtraWord)
                    // else if(isMissingWord)
                    //else

                    var spanifiedWords = SpanifyByTheLetter(String.Join(" ", recitalTextWords[startIndex..endIndex]), String.Join(" ", compareTextWords[startIndex..endIndex]));
                    finalRecitalText.Add(spanifiedWords.Item1);
                    finalCompareText.Add(spanifiedWords.Item2);
                }
            }

            if(compareTextWords.Length > recitalTextWords.Length)
            {
                finalCompareText.Add(Spanify(String.Join(" ", compareTextWords.Skip(recitalTextWords.Length))));
            }

            return new CompareTextData { RecitalText = String.Join(" ", finalRecitalText), CompareText = String.Join(" ", finalCompareText) };
        }

        private static string Spanify(string text)
        {
            return $"<span>{text}</span>";
        }

        private static string RemovePunctuation(string text, CompareType type)
        {
            switch(type)
            {
                case CompareType.Exact:
                case CompareType.Spellcheck:
                    return text;
                default:
                    text = Regex.Replace(text, @"[^\w\d\s]", "");
                    return text;
            }
        }

        private static bool AreWordsEqual(string word1, string word2, CompareType type)
        {
            return word1 == word2 || (IsSpellcheckType(type) && SpellcheckWord(word1, word2));
        }

        private static bool IsSpellcheckType(CompareType type)
        {
            return type == CompareType.Spellcheck || type == CompareType.SpellcheckNoPunctuation;
        }

        private static bool SpellcheckWord(string originalWord, string misspelledWord)
        {
            Hunspell hunspell = new Hunspell("en_us.aff", "en_us.dic");
            List<string> suggestions = hunspell.Suggest(misspelledWord);
            return suggestions.Contains(originalWord);
           // TODO add custom dictionary
        }

        private static Tuple<string, string> SpanifyByTheLetter(string word1, string word2)
        {
            string revisedWord1 = "";
            string revistedWord2 = "";

            bool finishedWord2 = false;

            for(int i = 0; i < word1.Length; i++)
            {
                if(i >= word2.Length)
                {
                    revisedWord1 += Spanify(word1.Substring(i));
                    break;
                }
                else if (word1[i] == word2[i])
                {
                    revisedWord1 += word1[i];
                    revistedWord2 += word2[i];
                }
                else
                {
                    int startIndex = i;
                    int length = 1;
                    for(int j = i + 1; j < word1.Length; j++)
                    {
                        if(j == word2.Length || word1[j] == word2[j])
                        {
                            break;
                        }
                        // TODO needs lookahead
                        else
                        {
                            i = j;
                            length++;
                        }
                    }

                    string substring1 = word1.Substring(startIndex, length);
                    string substring2;
                    if (startIndex + length == word1.Length &&  word2.Length > word1.Length)
                    {
                        finishedWord2 = true;
                        substring2 = word2.Substring(startIndex);
                    }
                    else
                    {
                        substring2 = word2.Substring(startIndex, length);
                    }

                    revisedWord1 += Spanify(substring1);
                    revistedWord2 += Spanify(substring2);
                }
            }

            if(word2.Length > word1.Length && !finishedWord2)
            {
                revistedWord2 += Spanify(word2.Substring(word1.Length));
            }

            return new Tuple<string, string>(revisedWord1, revistedWord2);
        }
    }
}

public enum CompareType
{
    Exact,
    ExactNoPunctuation,
    Spellcheck,
    SpellcheckNoPunctuation,
}

// TODO:
// use regex to split? add a mark, percentage of words correct. 
// the logic is basic, fix it for different lengths strings, multiple words. 
// give spans a classname?
