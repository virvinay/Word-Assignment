using System.Net.Http.Headers;
using Word_Assignment.Filters;

namespace WordAssignment
{
    public class Program
    {
        static void Main(string[] args)
        {
            //to store outputs of the word program
            var output = new List<string>();

            //instantiate word program with filters with their default values.
            var program = new WordProgram(GetFilters());

            //Path for the example text file
            var textFilePath = Path.Combine(Directory.GetCurrentDirectory(), "example.txt");

            //Using Stream reader over ReadAllText to cater for big files sizes.
            using (StreamReader sr = File.OpenText(textFilePath))
            {
                var text = String.Empty;

                //read record by record and pass to the word program to apply filters
                while ((text = sr.ReadLine()) != null)
                {
                    //incremently append the output of each record from the text file.
                    output.AddRange(program.ApplyWordFilters(text));
                }
            }

            //print total words count after all filters applied
            Console.WriteLine(output.Count);

            //print distinct words from initial text which were not filterd by the word program.
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