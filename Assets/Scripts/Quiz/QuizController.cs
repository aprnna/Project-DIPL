using System.Collections;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using TMPro; 

public class QuizController : MonoBehaviour
{
    public GameObject questionTextObj;
    public GameObject optionATextObj;
    public GameObject optionBTextObj;
    public GameObject optionACube;
    public GameObject optionBCube;

    private ARFace arFace;
    private bool answered = false;
    private bool readyForAnswer = false;     
    private TMP_Text questionText;
    private SpriteRenderer optionASR;
    private SpriteRenderer optionBSR;
    private QuizManager _quizManager;

    void Start()
    {
        arFace = GetComponent<ARFace>();
        questionText = questionTextObj.GetComponent<TMP_Text>();
        optionASR = optionATextObj.GetComponent<SpriteRenderer>();
        optionBSR = optionBTextObj.GetComponent<SpriteRenderer>();
        _quizManager = QuizManager.Instance;
        LoadQuestion();
    }

    void Update()
    {
        if (arFace == null) return;

        Vector3 localEuler = arFace.transform.localEulerAngles;
        float zRot = localEuler.z;
        if (zRot > 180f) zRot -= 360f;

        if (!readyForAnswer)
        {
            if (Mathf.Abs(zRot) < 10f)   
            {
                readyForAnswer = true;
            }
            return;
        }

        if (!answered)
        {
            if (zRot < -15f)
            {
                answered = true;
                readyForAnswer = false;
                CheckAnswer("A");
            }
            else if (zRot > 15f)
            {
                answered = true;
                readyForAnswer = false;
                CheckAnswer("B");
            }
        }
    }

    void CheckAnswer(string selected)
    {
        var current = _quizManager.GetCurrentQuestion();
        string correct = current.correctOption;

        if (selected == correct)
        {
            HighlightCube(selected, Color.green);
            _quizManager.Score += current.score;
            _quizManager.SetScore(_quizManager.Score);
            StartCoroutine(NextQuestionCoroutine());
        }
        else
        {
            HighlightCube(selected, Color.red);
            Handheld.Vibrate();
            _quizManager.LoseSound.Play();
            _quizManager.ShowEndQuizPanel();
        }
    }

    IEnumerator NextQuestionCoroutine()
    {
        yield return new WaitForSeconds(2f);
        _quizManager.NextQuestion();
        answered = false;
        readyForAnswer = false;  
        ResetCubeColors();
        LoadQuestion();
    }

    void HighlightCube(string option, Color color)
    {
        if (option == "A") optionACube.GetComponent<Renderer>().material.color = color;
        else optionBCube.GetComponent<Renderer>().material.color = color;
    }

    void LoadQuestion()
    {
        var q = _quizManager.GetCurrentQuestion();
        questionText.text = q.questionText;
        optionASR.sprite = q.optionA;
        optionBSR.sprite = q.optionB;
    }

    void ResetCubeColors()
    {
        optionACube.GetComponent<Renderer>().material.color = Color.white;
        optionBCube.GetComponent<Renderer>().material.color = Color.white;
    }
}
