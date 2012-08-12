using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace gameSticksWindows
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    namespace gameSticks
    {


        /// <summary>
        /// Abstract class is a class that has no direct instances, 
        /// but whose descendants may have direct instances. 
        /// There are case i which it is useful to define classes 
        /// for which the programmer never intends to instantiate any 
        /// objects; because such classes normally are used as base-classes in
        /// inheritance hierarchies, we call such classes abstract classes These 
        /// classes cannot be used to instantiate objects; because abstract 
        /// classes are incomplete. Derived classes called concrete classesmust 
        /// define the missing pieces.
        ///  
        /// The parent class must have following functions:
        ///  public abstract void setComputerDifficulty();
        ///  public abstract int intWriteMenu();
        ///  public abstract void wrtieOutput(string output);
        ///  public abstract string getInput();
        /// </summary>
        public abstract class classGame
        {
            // Definition of Global variable in the class
            private int G_intStickssLeft = 0;
            private int G_intCurrentPlayer = 0;
            private int G_intComputer = 1;
            private int G_intHumanPlayers = 0;
            string[] G_strPlayers = new string[2];

            /// <summary>
            /// Grafical/Interface to handel a choice of computer difficulty
            /// 1) Easy
            /// 2) Hard
            /// 3) Really Hard
            /// </summary>
            public abstract void setComputerDifficulty();

            /// <summary>
            /// Grafical/Interface to handel a menu of how you like to start game.
            /// 1) Human vs. Human
            /// 2) Computer vs. Human
            /// 3) Computer difficulty
            /// 4) Exit
            /// </summary>
            public abstract int intWriteMenu();

            /// <summary>
            /// Must be able to handel output to users screen.
            /// </summary>
            /// <param name="output">output is feedback from game loop.</param>
            public abstract void wrtieOutput(string output);

            /// <summary>
            /// This need return the useds input back to the game loop.
            /// </summary>
            /// <returns>Input to game loop</returns>
            public abstract string getInput();

            /// <summary>
            /// Handle command allowed to be used in the game.
            /// </summary>
            /// <param name="input">Command</param>
            private int interpreter(string input)
            {
                // Call function when command 42 given.
                if (input == "power")
                    cheat();

                // Call function setComputerDifficultyChange with parmeter 1
                if (input == "set computer 1")
                {
                    setComputerDifficultyChange(1);
                    // using function wrtieOutput to write out to screen.
                    // (Function is abstract and there for is must be defined in parent class)
                    wrtieOutput("Computer difficulty changed to 1");
                }

                // Call function setComputerDifficultyChange with parmeter 2
                if (input == "set computer 2")
                {
                    setComputerDifficultyChange(2);
                    // using function wrtieOutput to write out to screen.
                    // (Function is abstract and there for is must be defined in parent class)
                    wrtieOutput("Computer difficulty changed to 2");
                }

                // Call function setComputerDifficultyChange with parmeter 3
                if (input == "set computer 3")
                {
                    setComputerDifficultyChange(3);
                    // using function wrtieOutput to write out to screen.
                    // (Function is abstract and there for is must be defined in parent class)
                    wrtieOutput("Computer difficulty changed to 3");
                }

                // Call G_intStickssLeft set -99 (This stop game next game loop.
                if (input == "stop")
                {
                    G_intStickssLeft = -99;
                    // Return 1 due we need remove a stick to activeate game loop
                    return 1;
                }

                if (input == "reset")
                {
                    //                    gameGetHumanNames(G_intHumanPlayers);

                    //Call function gameInit() to reset game.
                    gameInit();


                }

                // Display help 
                if (input == "help")
                {
                    // using function wrtieOutput to write out to screen.
                    // (Function is abstract and there for is must be defined in parent class)
                    wrtieOutput("Stop - End the game.");
                    wrtieOutput("set computer # - Change computer level (1-3).");
                    wrtieOutput("reset - reset current game.");
                }

                return 0;
            }

            /// <summary>
            /// Validate users input
            /// </summary>
            /// <param name="input">if input in a number between 1-3 the are converted 
            /// to a number and returend else they will passed to interpreter.</param>
            /// <returns>return 0-3 - 0 returned when the input number not between 1-3.</returns>
            private int validate(string input)
            {

                // Definition of functions variable.
                int numVal = 0;

                // trying to conver input to a number.
                Int32.TryParse(input, out numVal);

                // if numVal is not changed away from 0 then call function handle text commands
                if (numVal == 0)
                   // calling handle of text commands
                    numVal = interpreter(input);

                // return result number between 0-3
                return numVal;
            }

            /// <summary>
            /// This cunction add a extra stick allowing the use have new change to win game.
            /// </summary>
            /// <returns></returns>
            private void cheat()
            {
                //if G_intStickssLeft 1,5,9 or 13 add extra stick else default
                switch (G_intStickssLeft)
                {
                    case 1:
                    case 5:
                    case 9:
                    case 13:
                        G_intStickssLeft = G_intStickssLeft + 1;
                        // using function wrtieOutput to write out to screen.
                        // (Function is abstract and there for is must be defined in parent class)
                        wrtieOutput("Oh look like you can win now. :)");
                        break;
                    default:
                        // using function wrtieOutput to write out to screen.
                        // (Function is abstract and there for is must be defined in parent class)
                        wrtieOutput("No need to win you can win with current number.");
                        break;
                }
  
            }

            /// <summary>
            ///  set Computer Difficulty in G_intComputer
            /// </summary>
            /// <param name="difficulty">Number between 1-3</param>
            protected void setComputerDifficultyChange(int difficulty)
            {
                G_intComputer = difficulty;

            }

            /// <summary>
            /// Main game loop this will start the game.
            /// </summary>
            /// <returns></returns>
            public Boolean boolGameRun()
            {
                // Definition of functions variable.
                int intChoice = 0;

                //as long we dont get the right input from the intWriteMenu();
                while (intChoice != 4)
                {
                    intChoice = intWriteMenu();
                    // will use the game function based on users choice
                    if (intChoice == 1) { gameHumanVsHuman(); }
                    if (intChoice == 2) { gameComputerVsHuman(); } // Line Computer vs Human
                    if (intChoice == 3) { setComputerDifficulty(); } // Line Computer difficulty
                }

                return true;


            }

            /// <summary>
            /// Initialize the game and find who starts.
            /// </summary>
            /// <returns> always true</returns>
            private Boolean gameInit()
            {
                // sets number of sticks to 15
                G_intStickssLeft = 15;

                //Make sure a random user starts every time.
                Random random = new Random();
                G_intCurrentPlayer = random.Next(0, 2);
               
                // Naaa a computer with diffilcuty 3 ALWAYS start and there he will win by default.
                if ((G_intComputer == 3) && (G_strPlayers[G_intCurrentPlayer] == "Computer"))
                    G_intCurrentPlayer = 0;

                return true;
            }

            /// <summary>
            /// Get players names.
            /// </summary>
            /// <param name="intHumanPlayers">Number of players 1 or 2</param>
            private void gameGetHumanNames(int intHumanPlayers)
            {
                
                // Definition of functions variable.
                int intCurrentPlayer = 1;
                int intTmp = 0;

                // Save number of human player in Global var.
                G_intHumanPlayers = intHumanPlayers;

                // Where there only one Human player we make the first player computer.
                if (intHumanPlayers == 1)  // Line Computer vs Human
                    G_strPlayers[intCurrentPlayer] = "Computer";  // Line Computer vs Human

                

                // As long we dont 2 players get players name.
                while (intCurrentPlayer <= intHumanPlayers)
                {
                    // using function wrtieOutput to write out to screen.
                    // (Function is abstract and there for is must be defined in parent class)
                    wrtieOutput("Hvad er spiller " + intCurrentPlayer + " navn?");

                    //save a copy of intCurrentPlayer use we dont want to change intCurrentPlayer now
                    intTmp = intCurrentPlayer - 1;
                    // use intTmp to define where write the name of next player in the player list. 
                    G_strPlayers[intTmp] = getInput();
                    intCurrentPlayer++;
                }


            }

            /// <summary>
            /// Change current player.
            /// </summary>
            /// <returns>next player</returns>
            private int gameNextHumanPlayer()
            {
                // change G_intCurrentPlayer btween 0 and 1.
                if (G_intCurrentPlayer == 0) { G_intCurrentPlayer = 1; } else { G_intCurrentPlayer = 0; }

                return G_intCurrentPlayer;
            }

            /// <summary>
            /// Create out for next screen after a stick is removed
            /// </summary>
            private void gameText()
            {
                // Definition of functions variable.
                int intMaxChoice = 3;

                //Set intMaxChoice is there is less then 3 sticks left. this used in out to define
                //how the stick it posible to take for writing to screen.
                if (G_intStickssLeft < 2) { intMaxChoice = 1; }
                else if (G_intStickssLeft < 3) { intMaxChoice = 2; }
                
                // using function wrtieOutput to write out to screen.
                // (Function is abstract and there for is must be defined in parent class)
                wrtieOutput(G_strPlayers[G_intCurrentPlayer] + " Vælg antal 1 til " + intMaxChoice + ". Antal heste tilbage " + G_intStickssLeft + ": ");
            }

            /// <summary>
            /// In case of computer player turn call function gameMoveComputer(); 
            /// else handle human players input.
            /// </summary>
            private void gameMove()
            {
                // Definition of functions variable.
                string stringInput;
                int intChoice;

                if (G_strPlayers[G_intCurrentPlayer] == "Computer")  // Line Computer vs Human
                {  // Line Computer vs Human
                    gameMoveComputer();  // Line Computer vs Human
                    return;  // Line Computer vs Human
                }  // Line Computer vs Human

                // get human player input
                stringInput = getInput();


                // Validate human player input
                intChoice = validate(stringInput);

                // As long as the human players input is wrong do this.
                while ((intChoice < 1 || intChoice > 3))
                {

                    //Write out game text.
                    gameText();
                    // get new human player input
                    stringInput = getInput();
                    // Validate human player input
                    intChoice = validate(stringInput);

                }

                // remove selected sticks.
                G_intStickssLeft = G_intStickssLeft - intChoice;


            }
            /// <summary>
            /// Check if we have a winner.
            /// </summary>
            /// <returns> return true if we have a winner else false</returns>
            private Boolean gameWin()
            {
                // if have more then 1 stick left we dont have a winner.
                if (G_intStickssLeft > 1)
                {
                    return false;
                }

                
                // less then one stick then we need to change player write the right player as winner.
                if (G_intStickssLeft < 1)
                {
                    //change player
                    gameNextHumanPlayer();
                    return true;
                }

                if (G_intStickssLeft == 1)
                {

                    //There only one left then we have winner and he current player.
                    return true;
                }

                return false;
            }

            private void getGameWinner()
            {
                // using function wrtieOutput to write out to screen.
                // (Function is abstract and there for is must be defined in parent class)
                wrtieOutput("Winner!!" + G_strPlayers[G_intCurrentPlayer]);
                wrtieOutput("Hit enter to continue");
                
                //Reset function did set it -99 and dont need to wait for player input
                if (G_intStickssLeft > -99)
                    getInput();
            }

            /// <summary>
            /// Start humanVsHuman Game.
            /// </summary>
            private void gameHumanVsHuman()
            {
                //call gameHumanVs with 2 to set both players human
                gameHumanVs(2);
            }

            /// <summary>
            /// Internal start and main game function.
            /// if intPlayerCount == 2 (HumanVsHuman)
            /// if intPlayerCount == 1 (HumanVsComputer)
            /// </summary>  
            private void gameHumanVs(int intPlayerCount)
            {
                // Definition of functions variable.
                Boolean boolWin = false;

                //Call function gameGetHumanNames to get players names
                gameGetHumanNames(intPlayerCount);
                // setting all game data to Initialize
                gameInit();
                while (!boolWin)
                {
                    //get next player
                    gameNextHumanPlayer();
                    
                    //write game text
                    gameText();

                    // get players move
                    gameMove();

                    //check if we have a winner.
                    boolWin = gameWin();
                }

                //call this find out if and who did really win
                getGameWinner();

            }

            private void gameMoveComputer()
            {
                // Definition of functions variable.
                int intChoice;

                //Ahhh This always get the best move. 
                intChoice = (G_intStickssLeft - 1) % 4;

                if (G_intComputer == 1) // Line Computer difficulty
                { // Line Computer difficulty
                    Random random = new Random(); // Line Computer difficulty
                    intChoice = random.Next(1, 3); // Line Computer difficulty
                } // Line Computer difficulty

                //There was no best move then just remove 1 and the human make an error
                if (intChoice < 1 || intChoice > 3)
                {
                    intChoice = 1;
                }
                // using function wrtieOutput to write out to screen.
                // (Function is abstract and there for is must be defined in parent class)
                wrtieOutput("Computer (" + G_intComputer + ") : " + intChoice); // Function to write to output from program
                G_intStickssLeft = G_intStickssLeft - intChoice; // Removing selected amount.

            }

            private void gameComputerVsHuman()
            { // Ny function Computer vs Human
                gameHumanVs(1);
            }



        }





    }

}
