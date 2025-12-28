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
        public static CheckTextResponse DoCompare(CheckTextRequest requestData, string connection)
        {
            int id = requestData.RecitalId;
            string text = requestData.RecitalText;

            RecitalsRepository repo = new RecitalsRepository(connection);
            Recital originalRecital = repo.getById(id);


            return figureThisOut(originalRecital.Text, text);
        }

        private static CheckTextResponse figureThisOut(string originalText, string compareText)
        {
            List<String> adjustedOriginal = new List<string>();
            List<String> adjustedCmpoare = new List<string>();

            String[] orignalBrokens = originalText.Split(" ");
            String[] compareBrokens = compareText.Split(" ");

            for(int i = 0; i < orignalBrokens.Length; i++)
            {
                if (orignalBrokens[i] != compareBrokens[i])
                {
                    adjustedOriginal.Add($"<span>{orignalBrokens[i]}</span>");
                    adjustedCmpoare.Add($"<span>{compareBrokens[i]}</span>");
                } 
                else
                {
                    adjustedOriginal.Add(orignalBrokens[i]);
                    adjustedCmpoare.Add(compareBrokens[i]);
                }
            }

            return new CheckTextResponse { OriginalText = String.Join(" ", adjustedOriginal), FinalText = String.Join(" ", adjustedCmpoare) };
        }
    }
}

// TODO:
// use regex to split? add a mark, percentage of words correct. 
// the logic is basic, fix it for different lengths strings, multiple words. 
// give spans a classname?
// More Functionality ideas:
// spell check, marking preferences - cookies