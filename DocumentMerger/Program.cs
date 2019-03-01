using System;
using System.IO;

namespace DocumentMerger
{
    class Program
    {
        static void Main(string[] args)
        {
            bool RunProgram = true;
            string FirstFile = null;
            string SecondFile = null;
            string RunAgain = null;
            string CombinedFile = null;
            StreamWriter FileCombo = null;
            string FirstFileContents = null;
            string SecondFileContents = null;
            string ComboFileContents = System.String.Empty;

            //While loop used to operate the whole program
            while (RunProgram == true) 
            {
                //Gets the first file name, attempts/reads it, gets the content
                //in it and puts it to a string to be added later
                //Included in the upload are test1 and test2 txt documents for testing

                try
                {
                    Console.WriteLine("Document Merger");
                    Console.WriteLine("");
               

                    while (true)
                    {
                        Console.WriteLine("Please input the first file name");
                        FirstFile = Console.ReadLine();

                        if (File.Exists(FirstFile))
                        {
                            Console.WriteLine("File found, continuing");
                            Console.WriteLine("");
                            try
                            {
                                using (StreamReader sr = new StreamReader(FirstFile))
                                {
                                    FirstFileContents = sr.ReadToEnd();
                                    break;
                                }
                            }
                            catch (IOException e)
                            {
                                Console.WriteLine("The file could not be read:");
                                Console.WriteLine(e.Message);
                                Environment.Exit(0);
                            }
                        }
                        else
                        {
                            Console.WriteLine("File name not found, try again");
                            Console.WriteLine("");
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Exception: " + e.Message);
                    Environment.Exit(0);
                }


                //Just like getting the info for the first file, but for second one this time.
                while (true)
                {
                    try
                    {
                        Console.WriteLine("Please input the second file name");
                        SecondFile = Console.ReadLine();
                        if (File.Exists(SecondFile))
                        {
                            Console.WriteLine("File 2 found, continuing");
                            Console.WriteLine("");
                            try
                            {
                                using (StreamReader sr = new StreamReader(SecondFile))
                                {
                                    SecondFileContents = sr.ReadToEnd();
                                    break;
                                }
                            }
                            catch (IOException e)
                            {
                                Console.WriteLine("The file could not be read:");
                                Console.WriteLine(e.Message);
                                Environment.Exit(0);
                            }
                        }
                        else
                        {
                            Console.WriteLine("File 2 name not found, try again");
                            Console.WriteLine("");

                        }

                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Exception: " + e.Message);
                        Environment.Exit(0);
                    }
                }

                //Takes the inputs and combines it all 
                Console.WriteLine("By magical powers, {0} and {1} are now combined!", FirstFile, SecondFile);
                CombinedFile = FirstFile + SecondFile + ".txt";
                Console.WriteLine("They have successfully formed/saved as {0}", CombinedFile);
                ComboFileContents = FirstFileContents + SecondFileContents;

                using (FileCombo = new StreamWriter(FirstFile + SecondFile))
                {
                    FileCombo.WriteLine(ComboFileContents);
                    Console.WriteLine("");
                    Console.WriteLine("{0} has {1} character/characters", CombinedFile, ComboFileContents.Length);
                    FileCombo.Close();
                }

                Console.WriteLine("");
                Console.WriteLine("Run again? Type Yes if you want to...");
                RunAgain = Console.ReadLine();

                if(RunAgain == "Yes")
                {
                    RunProgram = true;
                }

                else
                {
                    RunProgram = false;
                    Environment.Exit(0);
                }
               
            }

        }
    }
}
