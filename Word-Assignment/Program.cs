using System.Net.Http.Headers;
using Word_Assignment.Filters;

namespace WordAssignment
{
    public class Program
    {
        static void Main(string[] args)
        {
            var output = new List<string>();
            var program = new WordProgram(GetFilters());

            var textFilePath = Path.Combine(Directory.GetCurrentDirectory(), "example.txt");
            
            //Using Stream reader over ReadAllText to cater for big files sizes.
            using (StreamReader sr = File.OpenText(textFilePath))
            {
                var text = String.Empty;
                while ((text = sr.ReadLine()) != null)
                {
                    output.AddRange(program.ApplyWordFilters(text));
                }
            }
                        
            Console.WriteLine(output.Count);
            Console.WriteLine(string.Join(", ", output.Distinct()));
        }

        private static List<IWordFilter> GetFilters()
        {
            return new List<IWordFilter>
            {
                new WordLengthFilter(),
                new CharacterFilter(),
                new VowelPositionFilter()
            };
        }
    }
}