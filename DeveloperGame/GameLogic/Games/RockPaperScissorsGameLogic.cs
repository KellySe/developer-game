using GameLogic.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameLogic.Games
{
    public class RockPaperScissorsGameLogic : IGameLogic
    {
        private RockPaperScissorsGameState GameState;

        public bool GameComplete { get; set; }

        /// <summary>
        /// These 3 properties aren't stored in the RockPaperScissorsGameState class, 
        /// as I want them to persist if the user chooses to play another round.
        /// </summary>
        public double PlayerScore { get; set; }
        public double ComputerScore { get; set; }
        public int RoundNumber { get; set; }

        /// <summary>
        /// Initialise the global properties and set GameComplete to be false.
        /// </summary>
        public void Initialise()
        {
            GameState = new RockPaperScissorsGameState();
            GameState.ValidOption = true; // setting this to true, to avoid telling the user they have entered an invalid option on the first round.
            GameComplete = false;
        }

        public RockPaperScissorsGameLogic()
        {
            Initialise();
        }

        /// <summary>
        /// The core game functionality, first I get the computer's choice, then I get the player's choice, finally check to see who won.
        /// </summary>
        public void PlayGameRound(string entry)
        {
            GetComputerChoice();
            GetPlayerChoice(entry);
            CheckWinner();
        }

        /// <summary>
        /// This method simulates the computer's choice, by generating a number between 1 & 3.
        /// Then using a switch statement to convert each int into a string, before assigning it to the GameState.ComputerChoice property.
        /// </summary>
        public void GetComputerChoice()
        {
            GameState.ComputerChoiceInt = new Random().Next(1, 4);
            GameState.ComputerChoice = "";
            switch (GameState.ComputerChoiceInt)
            {
                case 1:
                    GameState.ComputerChoice = "rock";
                    break;
                case 2:
                    GameState.ComputerChoice = "paper";
                    break;
                case 3:
                    GameState.ComputerChoice = "scissors";
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// Takes a string and tries to match it to a valid choice.
        /// If the choice is invalid, it increments the DunceCount property (more on this later).
        /// </summary>
        public void GetPlayerChoice(string entry)
        {
            switch (entry.ToLower())
            {
                case "rock":
                case "r":
                    GameState.PlayerChoice = "rock";
                    GameState.ValidOption = true;
                    break;
                case "paper":
                case "p":
                    GameState.PlayerChoice = "paper";
                    GameState.ValidOption = true;
                    break;
                case "scissors":
                case "s":
                    GameState.PlayerChoice = "scissors";
                    GameState.ValidOption = true;
                    break;
                default:
                    GameState.ValidOption = false;
                    GameState.DunceCount++;
                    break;
            }
        }

        /// <summary>
        /// Returns the End Game Text surprisingly.
        /// 3 Different strings could be returned, depending whether it was a draw, the player won or the computer won.
        /// </summary>
        public string EndGameText()
        {
            System.Threading.Thread.Sleep(500);

            //If it's a draw, it will exit the method and return the following string.
            if (GameState.Draw)
            {
                // Handle whether it's the first round or not - 'round/rounds'
                if (RoundNumber == 1)
                {
                    return $"It's a draw{Environment.NewLine}" +
                        $"After {RoundNumber} round, the scores are{Environment.NewLine}" +
                        $"Computer - {ComputerScore}{Environment.NewLine}" +
                        $"Player - {PlayerScore}";
                }
                else
                {
                    return $"It's a draw{Environment.NewLine}" +
                        $"After {RoundNumber} rounds, the scores are{Environment.NewLine}" +
                        $"Computer - {ComputerScore}{Environment.NewLine}" +
                        $"Player - {PlayerScore}";
                }
                
            }

            //This code will only be reached if it isn't a draw, so someone must've won, first I check to see if the player won.
            if (GameState.PlayerWon)
            {
                if (RoundNumber == 1)
                {
                    return $"Well done, you defeated the robots!{Environment.NewLine}" +
                        $"After {RoundNumber} round, the scores are{Environment.NewLine}" +
                        $"Computer - {ComputerScore}{Environment.NewLine}" +
                        $"Player - {PlayerScore}";
                }
                else
                {
                    return $"Well done, you defeated the robots!{Environment.NewLine}" +
                        $"After {RoundNumber} rounds, the scores are{Environment.NewLine}" +
                        $"Computer - {ComputerScore}{Environment.NewLine}" +
                        $"Player - {PlayerScore}";
                }
            } 
            //Otherwise the computer must've won.
            else
            {
                if (RoundNumber == 1)
                {
                    return $"You lost! Switch on!{Environment.NewLine}" +
                        $"After {RoundNumber} round, the scores are{Environment.NewLine}" +
                        $"Computer - {ComputerScore}{Environment.NewLine}" +
                        $"Player - {PlayerScore}";
                }
                else
                {
                    return $"You lost! Switch on!{Environment.NewLine}" +
                        $"After {RoundNumber} rounds, the scores are{Environment.NewLine}" +
                        $"Computer - {ComputerScore}{Environment.NewLine}" +
                        $"Player - {PlayerScore}";
                }
                
            }
        }

        /// <summary>
        /// The method uses a switch statement containing nestes if/else statements to determine who won.
        /// Depending who won; update the appropriate GameState property (Draw / PlayerWon), 
        /// it will increment their score, the round number, and change GameComplete to true.
        /// </summary>
        public void CheckWinner()
        {
            switch (GameState.ComputerChoice)
            {
                case "rock":
                    if (GameState.PlayerChoice == "rock")
                    {
                        PlayerScore += 0.5;
                        ComputerScore += 0.5;
                        RoundNumber++;
                        GameState.Draw = true;
                        GameComplete = true;
                        break;
                    }
                    else if (GameState.PlayerChoice == "paper")
                    {
                        PlayerScore++;
                        RoundNumber++;
                        GameState.PlayerWon = true;
                        GameComplete = true;
                        break;
                    }
                    else if (GameState.PlayerChoice == "scissors")
                    {
                        ComputerScore++;
                        RoundNumber++;
                        GameState.PlayerWon = false;
                        GameComplete = true;
                        break;
                    }
                    break;
                case "paper":
                    if (GameState.PlayerChoice == "rock")
                    {
                        ComputerScore++;
                        RoundNumber++;
                        GameState.PlayerWon = false;
                        GameComplete = true;
                        break;
                    }
                    else if (GameState.PlayerChoice == "paper")
                    {
                        PlayerScore += 0.5;
                        ComputerScore += 0.5;
                        RoundNumber++;
                        GameState.Draw = true;
                        GameComplete = true;
                        break;
                    }
                    else if (GameState.PlayerChoice == "scissors")
                    {
                        PlayerScore++;
                        RoundNumber++;
                        GameState.PlayerWon = true;
                        GameComplete = true;
                        break;
                    }
                    break;
                case "scissors":
                    if (GameState.PlayerChoice == "rock")
                    {
                        PlayerScore++;
                        RoundNumber++;
                        GameState.PlayerWon = true;
                        GameComplete = true;
                        break;
                    }
                    else if (GameState.PlayerChoice == "paper")
                    {
                        ComputerScore++;
                        RoundNumber++;
                        GameState.PlayerWon = false;
                        GameComplete = true;
                        break;
                    }
                    else if (GameState.PlayerChoice == "scissors")
                    {
                        PlayerScore += 0.5;
                        ComputerScore += 0.5;
                        RoundNumber++;
                        GameState.Draw = true;
                        GameComplete = true;
                        break;
                    }
                    break;
                default:
                    break;
            }
        }

        public void HandlePlayerResponse(string entry)
        {
            PlayGameRound(entry);
        }

        /// <summary>
        /// If the game has been completed, it will jump to the EndGameText() method and return that string.
        /// If the user has not entered a ValidOption (Rock/r, Paper/p or Scissors/s) then it will prompt them again.
        /// If the user repeatedly enters an invalid option, then it will return a different string, depending on how thick they're being.
        /// </summary>
        public string GetNextPrompt()
        {
            if (GameComplete)
            {
                return EndGameText();
            }

            if (GameState.ValidOption)
            {
                return $"Let's play Rock Paper Scissors.{Environment.NewLine}" +
                    $"What will you pick; Rock, Paper or Scissors?";
            }
            else if (GameState.DunceCount < 3)
            {
                return $"That's not a valid option!{Environment.NewLine}" +
                    $"Please choose Rock, Paper or Scissors!{Environment.NewLine}";
            }
            else if (GameState.DunceCount < 5)
            {
                return $"You're really quite thick aren't you...{Environment.NewLine}" +
                    $"Choose Rock, Paper or Scissors!{Environment.NewLine}";
            }
            else if (GameState.DunceCount < 7)
            {
                return $"You're getting on my nerves now...{Environment.NewLine}" +
                    $"Choose Rock, Paper or Scissors!{Environment.NewLine}";
            }
            else
            {
                return $"Just type \"R\" and put me out of my misery.";
            }
        }       
    }
}
