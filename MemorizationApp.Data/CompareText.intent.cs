using DiffPlex;
using DiffPlex.Model;
using MemorizationApp.Data.Classes;

namespace MemorizationApp.Data
{
    public class CompareTextIntent
    {
        public static CompareTextResponse DoCompare(string connection, CompareTextRequest data)
        {
            RecitalsRepository repo = new RecitalsRepository(connection);
            Recital originalRecital = repo.getById(data.RecitalId);

            if(originalRecital == null || data.CompareText == null)
            {
                return new CompareTextResponse { Status = ResponseStatus.Error, Message = "Invalid Data" };
            }

            try
            {
                CompareTextData responseData = CompareText(originalRecital.Text, data.CompareText, data.Preferences);
                return new CompareTextResponse { Status = ResponseStatus.Success, Data = responseData };
            }
            catch(Exception e)
            {
                Console.WriteLine("Compare Text Error: " + e);
                return new CompareTextResponse { Status = ResponseStatus.Error, Message = "An error occured, please try again soon" };
            }
        }

        private static CompareTextData CompareText(string recitalText, string compareText, List<CompareType> preferences)
        {
            //set preferences on session?
            var differ = new Differ();
            var diff = differ.CreateCharacterDiffs(recitalText, compareText, false); //ignoreWhiteSpace, ignoreCasing

            List<DiffPieces> piecesOld = MapDiff(diff, TextVersion.Old);
            List<DiffPieces> piecesNew = MapDiff(diff, TextVersion.New);

            return new CompareTextData { RecitalText = piecesOld, CompareText = piecesNew };
        }


        private static List<DiffPieces> MapDiff(DiffResult diff, TextVersion version)
        {
            List<DiffPieces> mappedDiff = new List<DiffPieces>();
            string text = string.Join("", version == TextVersion.Old ? diff.PiecesOld : diff.PiecesNew);
            int index = 0;

            for (int i = 0; i < diff.DiffBlocks.Count; i++)
            {
                var block = diff.DiffBlocks[i];
                var start = version == TextVersion.Old ? block.DeleteStartA : block.InsertStartB;
                var count = version == TextVersion.Old ? block.DeleteCountA : block.InsertCountB;

                string startText = text.Substring(index, start - index);
                string diffText = text.Substring(start, count);
                mappedDiff.AddRange(new DiffPieces[] { new DiffPieces { Text = startText }, new DiffPieces { Text = diffText, IsDiff = true } });

                index += start + count;

                if (i == diff.DiffBlocks.Count - 1)
                {
                    string endText = text?.Substring(start + count);
                    mappedDiff.Add(new DiffPieces { Text = endText });
                }
            }

            return mappedDiff;
        }

    }
}

public enum CompareType
{
    Spellcheck,
    IgnorePunctuation,
    CaseInsensitive,
}

enum TextVersion
{
    Old,
    New,
}

// TODO:
// use regex to split? add a mark, percentage of words correct. 
// the logic is basic, fix it for different lengths strings, multiple words. 
// give spans a classname?
