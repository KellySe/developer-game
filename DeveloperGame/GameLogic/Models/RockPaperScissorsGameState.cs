namespace GameLogic.Models
{
    class RockPaperScissorsGameState
    {
        public int PlayerChoiceInt { get; set; }
        public int ComputerChoiceInt { get; set; }
        public string ComputerChoice { get; set; }
        public string PlayerChoice { get; set; }
        public int DunceCount { get; set; }
        public bool ValidOption { get; set; }
        public bool Draw { get; set; }
        public bool PlayerWon { get; set; }
    }
}
