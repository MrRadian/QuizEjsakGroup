using System.Collections.Generic;

namespace Assets.Scripts.Models
{
    public class QuizQuestion
    {
        public string Question { get; set; }
        public List<QuizAnswer> Answers { get; set; }
    }
}