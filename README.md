
QuestionServiceWebApi
=====================
Step 1: move the mock to embedded database.
Step 2: update QuestionRepository to read data from database
Step 3: update QuestionsController to read/write to repository new functions.


Web
===
Step 1: using bootstrap, create vertical tab (each section is its own tab)
Step 2: call web api and put all required information
Step 3: display the section and every function with each section
Step 4: provide basic textbox for answer (to improve answer type - radio buttons for choices)


TODO:
=====
update and use all test cases
exten repository
exten database tables


Enhancement
===========
Implement Create/Update and Delete of questions
Display answers based on type (textbox/checkbox or Radio button)
Logging Errors
Store answers (create new table to store answers)




Database script
===============

CREATE TABLE [Questionnaire]
(
    [CateqeryID]			[int]               NOT NULL IDENTITY(1,1) CONSTRAINT [PK_Questionnaire] PRIMARY KEY,
    [QuestionID]    [int]               NULL,
    [AnswerID]		[int]               NULL,
    [DisplayText]   [varchar](2048)		NOT NULL,
    [SortOrder]     [int]               NULL,
    [IsEnabled]      [bit]               NOT NULL CONSTRAINT [DF_Questionnaire] DEFAULT (1)
)


insert into [Questionnaire] (QuestionID, AnswerID, DisplayText, SortOrder, IsEnabled) values (null, null, 'Geography Questions', 0, 1);
insert into [Questionnaire] (QuestionID, AnswerID, DisplayText, SortOrder, IsEnabled) values (1, null, 'What is the capital of Cuba?', 0, 1);
insert into [Questionnaire] (QuestionID, AnswerID, DisplayText, SortOrder, IsEnabled) values (1, null, 'What is the capital of France?', 1, 1);
insert into [Questionnaire] (QuestionID, AnswerID, DisplayText, SortOrder, IsEnabled) values (1, null, 'What is the capital of Poland?', 2, 1);
insert into [Questionnaire] (QuestionID, AnswerID, DisplayText, SortOrder, IsEnabled) values (1, null, 'What is the capital of Germany?', 3, 1);

INSERT INTO Questionnaire (QuestionID, AnswerID, DisplayText, SortOrder, IsEnabled) VALUES (NULL, NULL, 'Testing Category', 1, 1);
insert into [Questionnaire] (QuestionID, AnswerID, DisplayText, SortOrder, IsEnabled) values (6, null, 'First Question?', 0, 1);
insert into [Questionnaire] (QuestionID, AnswerID, DisplayText, SortOrder, IsEnabled) values (6, null, 'Second Question?', 1, 1);
insert into [Questionnaire] (QuestionID, AnswerID, DisplayText, SortOrder, IsEnabled) values (6, null, 'Last Question?', 2, 1);

insert into [Questionnaire] (QuestionID, AnswerID, DisplayText, SortOrder, IsEnabled) values (6, 7, 'Option 1', 1, 1);
insert into [Questionnaire] (QuestionID, AnswerID, DisplayText, SortOrder, IsEnabled) values (6, 7, 'Option 2', 2, 1);



