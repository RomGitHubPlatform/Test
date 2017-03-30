using System.Collections.Generic;
using System.Runtime.Serialization;

namespace QuestionServiceWebApi
{
    [DataContract]
    public class Questionnaire
    {
        [DataMember]
        public int QuestionnaireID { get; set; }
        [DataMember]
        public string QuestionnaireTitle { get; set; }
        [DataMember]
        public IList<Questionnaire> Questions { get; set; }
    }
}