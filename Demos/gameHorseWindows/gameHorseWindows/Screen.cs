using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using gameSticksWindows.gameSticks;

namespace gameSticksWindows
{
    public class screenWindows : classGame
    {

        List<string> msgLog = new List<string>();
        public override void setComputerDifficulty()
        {

            string stringInput = "";
            FormSetComputerDifficulty CurrentForm = new FormSetComputerDifficulty();
            CurrentForm.ShowDialog();
            stringInput = CurrentForm.diff;
            CurrentForm.Close();

            int intChoice = Convert.ToInt32(stringInput);


            if (intChoice >= 1 && intChoice <= 3)
                setComputerDifficultyChange(intChoice);

        }   // Function End Computer difficulty

        public override int intWriteMenu()
        {

            string stringInput = "";
            FormStartGame CurrentForm = new FormStartGame();
            CurrentForm.ShowDialog();
            stringInput = CurrentForm.result;
            CurrentForm.Close();
            return Convert.ToInt32(stringInput);
        }

        public override void wrtieOutput(string output)
        {
            msgLog.Add(output);
        }

        public override string getInput()
        {
            string stringInput = "";
            UserDialog CurrentForm = new UserDialog(msgLog);
            CurrentForm.ShowDialog();
            stringInput = CurrentForm.result;
            CurrentForm.Close();
            return stringInput;
        }
    }

    public class screenConsole : classGame
    {

        public override void setComputerDifficulty()
        {
            // Function Begin Computer difficulty
            Console.WriteLine("### Computer difficulty ###");
            Console.WriteLine("# 1) Easy. #");
            Console.WriteLine("# 2) Hard. #");
            Console.WriteLine("# 3) Really Hard. #");
            Console.WriteLine("Vælg: ");
            string stringInput = Console.ReadLine();
            int intChoice = Convert.ToInt32(stringInput);

            if (intChoice >= 1 && intChoice <= 3)
                setComputerDifficultyChange(intChoice);

        }   // Function End Computer difficulty

        public override int intWriteMenu()
        {

            Console.WriteLine("### MENU ###");
            Console.WriteLine("# 1) Human vs. Human #");
            Console.WriteLine("# 2) Computer vs. Human #"); // Line Computer vs Human
            Console.WriteLine("# 3) Computer difficulty #"); // Line Computer difficulty
            Console.WriteLine("# 4) Exit. #");
            Console.WriteLine("Vælg: ");
            string stringInput = Console.ReadLine();
            return Convert.ToInt32(stringInput);
        }

        public override void wrtieOutput(string output)
        {
            Console.WriteLine(output);
        }

        public override string getInput()
        {
           return Console.ReadLine(); 
        }
    }


}
