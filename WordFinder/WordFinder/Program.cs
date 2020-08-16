using System;
using System.Reflection.Metadata.Ecma335;

namespace WordFinder
{
    class WordFinder
    {
        public string word = null;
        public int rows, columns;
        public string[,] matrix;
        public string orientation;

        public void CreateMatrix(int a, int b) 
        {
            this.matrix = new string[a,b];
        }

        public bool SearchWord()
        {
            int indexWord = 0;
            char[] splitedWord = word.ToCharArray();
            try
            {
                for (int i = 0; i < rows; i++)
                {
                    //Check horizontally
                    for (int j = 0; j < columns; j++)
                    {
                        if (matrix[i, j] == splitedWord[indexWord].ToString())
                        {
                            if (word.Length - 1 == indexWord)
                            {
                                orientation = "horizontal";
                                return true;
                            }
                            else
                            {
                                indexWord++;
                            }
                        }
                        else if (indexWord != 0)
                        {
                            indexWord = 0;
                        }
                    }
                    
                    //Check Vertically
                    for (int j = 0; j < rows; j++)
                    {
                        if (matrix[j, i] == splitedWord[indexWord].ToString())
                        {
                            if (word.Length - 1 == indexWord)
                            {
                                orientation = "vertical";
                                return true;
                            }
                            else
                            {
                                indexWord++;
                            }
                        }
                        else if (indexWord != 0)
                        {
                            indexWord = 0;
                        }
                    }

                }
                return false;
            } catch (Exception) {
                return false;
            }
        }
    }

    public class Logger
    {
        public void Log(string message) { Console.WriteLine(message); }
    }
    class Program
    {
        static void Main(string[] args)
        {
            int a, b;
            string inputA, inputB;
            Logger _logger = new Logger();
            ConsoleKeyInfo name;
            WordFinder _wordFinder = new WordFinder();
            try
            {
                _logger.Log("Welcome to Word Finder Program!");
                _logger.Log("Please enter the word you want to find:");

                _wordFinder.word = Console.ReadLine().ToLower();

                _logger.Log("Please enter the number of rows for the matrix: ");
                 name = Console.ReadKey();
                inputA = name.KeyChar.ToString();
                _logger.Log("\nPlease enter the number of columns for the matrix: ");
                name = Console.ReadKey();
                inputB = name.KeyChar.ToString();
                    if (int.TryParse(inputA, out _wordFinder.rows) && int.TryParse(inputB, out _wordFinder.columns))
                    {
                        _wordFinder.CreateMatrix(_wordFinder.rows, _wordFinder.columns);
                        _logger.Log("\nLet's fill the elements in the matrix :");
                        for (int i = 0; i < _wordFinder.rows; i++)
                        {
                            for (int j = 0; j < _wordFinder.columns; j++)
                            {
                                _logger.Log($"\nelement - [{i},{j}]: ");
                                name = Console.ReadKey();
                                _wordFinder.matrix[i, j] = name.KeyChar.ToString().ToLower();
                            }
                        }
                        bool result = _wordFinder.SearchWord();
                        if (result)
                        {
                            _logger.Log($"\nWe found your word, orientation: {_wordFinder.orientation}");
                        }
                        else 
                        {
                            _logger.Log($"\nWe didn't found your word in the given matrix, try again");
                        }
                    }
                    else
                    {
                        _logger.Log("\nThe program was not able to create the matrix with the values provided, please use numbers");
                    }
            }
            catch (Exception)
            {

                _logger.Log("\nYou enter an invalid param, please try again later");
            }

            
        }
    }
}
