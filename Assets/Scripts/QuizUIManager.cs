using TMPro;
using UnityEngine;

public class QuizUIManager : MonoBehaviour
{
    // hardcoded value for the entire game, maybe move later??
    private float passPercentage = 0.75f;

    [SerializeField]
    private Quiz currentQuiz;
    private Question currentQuestion;
    private int currentQuestionIndex = 0;
    public int correctAnswers = 0; // for future reference, we'll need to reset this when we start a new quiz

    [SerializeField]
    private GameObject quizQuestionUI;
    [SerializeField]
    private GameObject quizAnswerUIPrefab;

    [SerializeField]
    private Transform answerUIParent;
    [SerializeField]
    private GameObject resultUI;

    private void Start()
    {
        LoadQuestion(currentQuestionIndex);
    }

    public void LoadQuestion(int questionNum)
    {
        ClearAnswers();

        currentQuestion = currentQuiz.questions[questionNum];
        quizQuestionUI.GetComponentInChildren<TMP_Text>().text = currentQuestion.question;

        for (int i = 0; i < currentQuestion.answers.Length; i++)
        {
            GameObject quizAnswerButton = Instantiate(quizAnswerUIPrefab, answerUIParent);
            quizAnswerButton.GetComponent<QuizAnswerButton>().SetupAnswer(currentQuestion.answers[i], this);
        }
    }

    private void ClearAnswers()
    {
        // delete answers
        foreach (Transform oldAnswer in answerUIParent)
        {
            Destroy(oldAnswer.gameObject);
        }
    }

    public void NextQuestion()
    {
        // if we just finished the last question
        if (currentQuestionIndex == currentQuiz.questions.Length - 1)
        {
            ClearAnswers();
            quizQuestionUI.SetActive(false);
            resultUI.SetActive(true);
            Debug.Log("result: " + correctAnswers / currentQuiz.questions.Length);
            if (correctAnswers / currentQuiz.questions.Length >= passPercentage)
            {
                resultUI.GetComponentInChildren<TMP_Text>().text = "Pass :)"; // HARDCODED
            }
            else
            {
                resultUI.GetComponentInChildren<TMP_Text>().text = "Fail :("; // HARDCODED
            }
        }
        else
            LoadQuestion(++currentQuestionIndex);
    }

    public void ReceiveAnswer(string answer)
    {
        if (currentQuestion.correctAnswer == answer)
        {
            correctAnswers++;
        }
        NextQuestion();
    }
}
