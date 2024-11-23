namespace GuessTheGame
{
    public partial class MainPage : ContentPage
    {
        private int _randomNumber;
        private int _attempts;

        public MainPage()
        {
            InitializeComponent();
            StartNewGame();
        }

        private void StartNewGame()
        {
            Random random = new Random(); 
            _randomNumber = random.Next(1, 101); // Generate number between 1 and 100
            _attempts = 0;
            ResultLabel.Text = "Enter a number between 1 and 100.";
            AttemptsLabel.Text = "Attempts: 0";
            GuessEntry.Text = string.Empty;
        }

        private void OnSubmitGuessClicked(object sender, EventArgs e)
        {
            if (int.TryParse(GuessEntry.Text, out int guess))
            {
                _attempts++;
                AttemptsLabel.Text = $"Attempts: {_attempts}";

                if (guess < _randomNumber)
                {
                    ResultLabel.Text = "Too low! Try again.";
                }
                else if (guess > _randomNumber)
                {
                    ResultLabel.Text = "Too high! Try again.";
                }
                else
                {
                    ResultLabel.Text = $"Correct! The number was {_randomNumber}.";
                    StartNewGame(); // Restart the game
                }
            }
            else
            {
                ResultLabel.Text = "Please enter a valid number.";
            }

            GuessEntry.Text = string.Empty; // Clear input
        }
    }
}
