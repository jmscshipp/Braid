using UnityEngine;

[CreateAssetMenu(fileName = "Quiz", menuName = "Scriptable Objects/Quiz")]
public class Quiz : ScriptableObject
{
    public Question[] questions;
}

[System.Serializable]
public class Question
{
    public string question = "";
    public string correctAnswer = ""; // needs to be typed EXACTLY the same in the answers array
    public string[] answers;
}