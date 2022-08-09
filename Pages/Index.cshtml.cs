using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PaperScissorsRock.Operations;

namespace PaperScissorsRock.Pages
{
    [BindProperties]
    public class IndexModel : PageModel
    {
        
        

        




        //hold the selected choice from the radio button
        public string HumanChoice { get; set; }
        //is the list of 3 options for human

        public List<string> HumanChoiceOptions;
        //give the result as text

        public string Result { get; set; }
        public string? Image { get; set; }

        public IndexModel()
        {
            HumanChoiceOptions = new List<string>();
            HumanChoiceOptions.Add("Rock");
            HumanChoiceOptions.Add("Paper");
            HumanChoiceOptions.Add("Scissors");
        }

        public void OnGet()
        {
            Image = "paperscissorsrock.jpg";
        }
        public void OnPost()
        {
            // 0 represents rock, 1 is paper, and 2 is scissors
            string Human = HumanChoice;
            //random number 0, 1, 2
            string Computer = ComputerChoice();
            //run the result method
            Result = GameResult(Human, Computer);
        }

        private string GameResult(string human, string computer)
        {
            string message = "you chose" + human + " . The computer chose " + computer;

            if (human == computer)
            {
                Scores.Draw++;
                message += " . It's a Draw!";
                Image = "draw.png";
            }
            else if (human == "Rock" && computer == "Scissors" || human == "Paper" && computer == "Rock" || human == "Scissors" && computer == "Paper")
            {
                Scores.Win++;
                message += " . You Won!";
                Image = "youwin.webp";
            }
            else
            {
                Scores.Lose++;
                message += " . You Lose!";
                Image = "youlose.jpg";
            }
            ViewData[index: "Draw"] = Scores.Draw;
            ViewData[index: "Win"] = Scores.Win;
            ViewData[index: "Lose"] = Scores.Lose;
            return message;
        }

        public string ComputerChoice()
        {
            //create an object from the class
            Random CompGuess = new Random();

            return ComputerChoiceCalc(CompGuess.Next(0, 3));
        }
        private string ComputerChoiceCalc(int choice)
        {
            switch (choice)
            {
                case 0:
                    return "Rock";
                    case 1:
                    return "Paper";
                case 2: return "Scissors"; 

            }
            return null;
        }
    }
}