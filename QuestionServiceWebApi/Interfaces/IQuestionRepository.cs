using System.Collections.Generic;
namespace QuestionServiceWebApi.Interfaces
{
    public interface IQuestionRepository
    {
        List<Questionnaire> GetQuestionnaire();
        List<Questionnaire> GetQuestionnaire(int CatID);
        List<Questionnaire> GetQuestionnaire(int CatID, int QuestionID);

        void StoreQuestionnaireAnswer(int QuestionID, string Value);
        void DeleteQuestionnaire(int QuestionID);
    }
}