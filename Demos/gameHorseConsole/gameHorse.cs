using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{

    class classGame {

        private int intHorsesLeft = 0;
        private int intCurrentPlayer = 0;
        private int intComputer = 1;
        string[] strPlayers = new string[2];

        private void setComputerDifficulty() {
            // Function Begin Computer difficulty
            Console.WriteLine("### Computer difficulty ###");
            Console.WriteLine("# 1) Easy. #");
            Console.WriteLine("# 2) Hard. #");
            Console.WriteLine("# 3) Really Hard. #");
            Console.WriteLine("Vælg: ");
            string stringInput = Console.ReadLine();
            int intChoice = Convert.ToInt32(stringInput);

            if (intChoice >= 1 && intChoice <= 3)
                intComputer = intChoice;

        }   // Function End Computer difficulty

        public Boolean boolGameRun () {


            int intChoice = 0;

            while (intChoice != 4)
            {
                intChoice = intWriteMenu();
                if (intChoice == 1) { gameHumanVsHuman(); }
                if (intChoice == 2) { gameComputerVsHuman(); } // Line Computer vs Human
                if (intChoice == 3) { setComputerDifficulty(); } // Line Computer difficulty
            }

            return true;


        }

        private Boolean gameInit() {
         intHorsesLeft = 15;


         Random random = new Random();
         intCurrentPlayer = random.Next(0, 2);
         if ((intComputer == 3)  && (strPlayers[intCurrentPlayer] == "Computer") ) 
             intCurrentPlayer = 0; 

         return true;
        }

        private void gameGetHumanNames(int intHumanPlayers) {
            int intCurrentPlayer = 1;
            int intTmp = 0;
            if (intHumanPlayers == 1)  // Line Computer vs Human
                strPlayers[intCurrentPlayer] = "Computer";  // Line Computer vs Human
            
            while (intCurrentPlayer <= intHumanPlayers ) {
                Console.WriteLine("Hvad er spiller " + intCurrentPlayer + " navn?");
                intTmp = intCurrentPlayer - 1;
                strPlayers[intTmp] = Console.ReadLine();
                intCurrentPlayer++;
            }


        }

        private int gameNextHumanPlayer() {
            if (intCurrentPlayer == 0) { intCurrentPlayer = 1; } else { intCurrentPlayer = 0; } 
            
            return intCurrentPlayer;
        }

        private void gameText() {
            int intMaxChoice = 3;
            if (intHorsesLeft < 3) { intMaxChoice = 2; }
            if (intHorsesLeft < 1) { intMaxChoice = 1; }
            Console.WriteLine(strPlayers[intCurrentPlayer] + " Vælg antal 1 til " + intMaxChoice + ". Antal heste tilbage " + intHorsesLeft + ": ");
        }

        private void gameMove() {
            string stringInput;
            int intChoice;

            if (strPlayers[intCurrentPlayer] == "Computer")  // Line Computer vs Human
            {  // Line Computer vs Human
                gameMoveComputer();  // Line Computer vs Human
                return;  // Line Computer vs Human
            }  // Line Computer vs Human

            stringInput = Console.ReadLine();
            intChoice = Convert.ToInt32(stringInput);
            while ((intChoice < 1 || intChoice > 3) && (intChoice <= intHorsesLeft))
            {
                Console.WriteLine("Forkert valg!!!!");
                gameText();
                stringInput = Console.ReadLine();
                intChoice = Convert.ToInt32(stringInput);
            
            }

            intHorsesLeft = intHorsesLeft - intChoice;


        }

        private Boolean gameWin()
        {
            if (intHorsesLeft > 1)
            {
                return false;
            }

            if (intHorsesLeft < 1)
            {
                gameNextHumanPlayer();
                return true;
            }

            if (intHorsesLeft == 1)
            {
                
                return true;
            }

            return false;
        }

        private void getGameWinner() {
         Console.WriteLine("Winner!!" + strPlayers[intCurrentPlayer]);
        }

        private void gameHumanVsHuman()
        {
            gameHumanVs(2);
        }

        private void gameHumanVs(int intPlayerCount) {
            
            Boolean boolWin = false;

            gameGetHumanNames(intPlayerCount);
            gameInit();
            while (!boolWin)
            {
                gameNextHumanPlayer();
                gameText();
                gameMove();
                boolWin = gameWin();
            }

            getGameWinner();

          }

        private void gameMoveComputer(){
            // Line ALL of function 
            int intChoice;
            
  
            intChoice = (intHorsesLeft  - 1)  % 4;

            if (intComputer == 1) // Line Computer difficulty
            { // Line Computer difficulty
                Random random = new Random(); // Line Computer difficulty
                intChoice = random.Next(1, 3); // Line Computer difficulty
            } // Line Computer difficulty
            
            if (intChoice < 1 || intChoice > 3) {
                intChoice = 1;
            }
            Console.WriteLine("Computer (" + intComputer + ") : " + intChoice); 
            intHorsesLeft = intHorsesLeft - intChoice;

        }

        private void gameComputerVsHuman()
        { // Ny function Computer vs Human
            gameHumanVs(1); 
        }

        private int intWriteMenu () {
                
            Console.WriteLine("### MENU ###");
            Console.WriteLine("# 1) Human vs. Human #");
            Console.WriteLine("# 2) Computer vs. Human #"); // Line Computer vs Human
            Console.WriteLine("# 3) Computer difficulty #"); // Line Computer difficulty
            Console.WriteLine("# 4) Exit. #");
            Console.WriteLine("Vælg: ");
            string stringInput = Console.ReadLine();
            return Convert.ToInt32(stringInput);

             
   
         }

    }
    
    
    class Program
    {
        static void Main(string[] args)
        {
            classGame CurrentGame = new classGame();
        CurrentGame.boolGameRun();
        }

    }
}
