using TMPro;
using UnityEngine;

public class QuizUIManager : MonoBehaviour
{
    [SerializeField]
    private Quiz currentQuiz;
    private Question currentQuestion;
    private int currentQuestionIndex = 0;

    [SerializeField]
    private GameObject quizQuestionUI;
    [SerializeField]
    private GameObject quizAnswerUIPrefab;

    [SerializeField]
    private Transform answerUIParent;

    private void Start()
    {
        LoadQuestion(currentQuestionIndex);
    }

    public void LoadQuestion(int questionNum)
    {
        // delete any previous answers
        foreach (Transform oldAnswer in answerUIParent)
        {
            Destroy(oldAnswer.gameObject);
        }

        currentQuestion = currentQuiz.questions[questionNum];
        quizQuestionUI.GetComponentInChildren<TMP_Text>().text = currentQuestion.question;

        for (int i = 0; i < currentQuestion.answers.Length; i++)
        {
            Debug.Log("adding " + currentQuestion.answers[i]);
            GameObject quizAnswerButton = Instantiate(quizAnswerUIPrefab, answerUIParent);
            quizAnswerButton.GetComponent<QuizAnswerButton>().SetupAnswer(currentQuestion.answers[i], this);
        }
    }

    public void NextQuestion()
    {
        // if we just finished the last question
        if (currentQuestionIndex == currentQuiz.questions.Length - 1)
        {
            // exit quiz
        }
        LoadQuestion(++currentQuestionIndex);
    }

    public void ReceiveAnswer(string answer)
    {
        if (currentQuestion.correctAnswer == answer)
        {
            // good
        }
        else
        {
            // bad
        }
        NextQuestion();
    }
}
