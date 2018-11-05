namespace QuizFinalProject.Models
{
    public class Answer
    {
        public int Id { get; set; }
        public string AnswerText { get; set; }
        public bool IsRight { get; set; }
        public Question Question { get; set; }

    }
}