using QuestionServiceWebApi;
using QuestionServiceWebApi.Interfaces;

namespace PairingTest.Unit.Tests.QuestionServiceWebApi.Stubs
{
    public class FakeQuestionRepository : IQuestionRepository
    {
        public Questionnaire ExpectedQuestions { get; set; }

        public System.Collections.Generic.List<Questionnaire> GetQuestionnaire(int CatID)
        {
            throw new System.NotImplementedException();
        }

        public System.Collections.Generic.List<Questionnaire> GetQuestionnaire()
        {
            //return ExpectedQuestions;
            return null;
        }

        public System.Collections.Generic.List<Questionnaire> GetQuestionnaire(int CatID, int QuestionID)
        {
            throw new System.NotImplementedException();
        }

        public void DeleteQuestionnaire(int QuestionID)
        {
            throw new System.NotImplementedException();
        }

        public void StoreQuestionnaireAnswer(int QuestionID, string Value)
        {
            throw new System.NotImplementedException();
        }
    }
}