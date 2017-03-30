using System.Collections.Generic;
using QuestionServiceWebApi.Interfaces;
using System;
using System.Linq;
using System.Data.SqlServerCe;
using System.Configuration;

namespace QuestionServiceWebApi
{
    public class QuestionRepository : IQuestionRepository
    {
        public List<Questionnaire> GetQuestionnaire()
        {
            List<Questionnaire> returnList = new List<Questionnaire>();
            try
            {
                using (SqlCeConnection cn = new SqlCeConnection(ConfigurationManager.ConnectionStrings["DB_Connection"].ToString()))
                {
                    SqlCeCommand cmd = new SqlCeCommand("SELECT * FROM Questionnaire where QuestionID IS NULL AND AnswerID IS NULL AND IsEnabled = 1", cn);
                    cn.Open();
                    SqlCeDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        returnList.AddRange(GetQuestionnaire((int)reader["CategeryID"]));
                    }

                    return returnList;
                }
            }
            catch (Exception ex)
            {
                //Log error
                return returnList;
            }
        }

        public List<Questionnaire> GetQuestionnaire(int CatID)
        {
            List<Questionnaire> returnList = new List<Questionnaire>();
            try
            {
                using (SqlCeConnection cn = new SqlCeConnection(ConfigurationManager.ConnectionStrings["DB_Connection"].ToString()))
                {
                    SqlCeCommand cmd = new SqlCeCommand(string.Format("SELECT * FROM Questionnaire where (CategeryID = {0} OR (QuestionID = {0} AND AnswerID IS NULL)) AND IsEnabled = 1", CatID), cn);
                    cn.Open();
                    SqlCeDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Questionnaire question = returnList.FirstOrDefault(x => x.QuestionnaireID == CatID);
                        if (question != null)
                        {
                            question.Questions.Add(new Questionnaire
                            {
                                QuestionnaireID = (int)reader["CategeryID"],
                                QuestionnaireTitle = (string)reader["DisplayText"],
                                Questions = new List<Questionnaire>()
                            });
                        }
                        else
                        {
                            returnList.Add(new Questionnaire
                            {
                                QuestionnaireID = (int)reader["CategeryID"],
                                QuestionnaireTitle = (string)reader["DisplayText"],
                                Questions = new List<Questionnaire>()
                            });
                        }
                    }

                    return returnList;
                }
            }
            catch (Exception ex)
            {
                //Log error
                return returnList;
            }
        }

        public List<Questionnaire> GetQuestionnaire(int CatID, int QuestionID)
        {
            List<Questionnaire> returnList = new List<Questionnaire>();
            try
            {
                using (SqlCeConnection cn = new SqlCeConnection(ConfigurationManager.ConnectionStrings["DB_Connection"].ToString()))
                {
                    SqlCeCommand cmd = new SqlCeCommand(string.Format("SELECT * FROM Questionnaire where QuestionID = {0} AND AnswerID = {1} AND IsEnabled = 1", CatID, QuestionID), cn);
                    cn.Open();
                    SqlCeDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        returnList.Add(new Questionnaire
                        {
                            QuestionnaireID = (int)reader["CategeryID"],
                            QuestionnaireTitle = (string)reader["DisplayText"],
                            Questions = new List<Questionnaire>()
                        });
                    }

                    return returnList;
                }
            }
            catch (Exception ex)
            {
                //Log error
                return returnList;
            }
        }

        public void DeleteQuestionnaire(int QuestionID)
        {
            try
            {
                using (SqlCeConnection cn = new SqlCeConnection(ConfigurationManager.ConnectionStrings["DB_Connection"].ToString()))
                {
                    SqlCeCommand cmd = new SqlCeCommand(string.Format("update Questionnaire set IsEnabled = 0 where CategeryID = {0} and IsEnabled = 1", QuestionID), cn);
                    cn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                //Log error
            }
        }

        public void StoreQuestionnaireAnswer(int QuestionID, string Value)
        {
            throw new NotImplementedException();
        }
    }
}