using System;
using UnityEngine;

[CreateAssetMenu(fileName = "QuizDatabase", menuName = "ARQuiz/Quiz Database")]
public class QuizDatabase: ScriptableObject
{
    public QuizQuestion[] questions;
}

[Serializable]
public class QuizQuestion 
{
    public string questionText;
    public Sprite optionA;
    public Sprite optionB;
    public int score;
    public string correctOption; 
}

