using System.Collections.Generic;

namespace PairingTest.Web.Models
{
    public class QuestionnaireViewModel
    {
        public int QuestionnaireID { get; set; }
        public string QuestionnaireTitle { get; set; }
        public IList<QuestionnaireViewModel> Questions { get; set; }
    }
}