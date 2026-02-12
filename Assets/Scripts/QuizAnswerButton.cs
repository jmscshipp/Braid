using TMPro;
using UnityEngine;

public class QuizAnswerButton : MonoBehaviour
{
    private TMP_Text text;
    private QuizUIManager uiManager;

    private void Awake()
    {
        text = GetComponentInChildren<TMP_Text>();
    }

    public void SetupAnswer(string newText, QuizUIManager manager)
    {
        text.text = newText;
        uiManager = manager;
    }

    public void OnClick()
    {
        uiManager.ReceiveAnswer(text.text);
    }
}
