using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public Question[] questions;
    public static List<Question> unansweredQuestions;
    private Question currentQuestion;

    static List<float> opennessScore = new List<float>();
    static List<float> conscientiousnessScore = new List<float>();
    static List<float> extraversionScore = new List<float>();
    static List<float> agreeablenessScore = new List<float>();
    static List<float> neuroticismScore = new List<float>();

    public static int questionIndex;

    float opennessLevel = 0;
    float conscientiousnessLevel = 0;
    float extraversionLevel = 0;
    float agreeablenessLevel = 0;
    float neuroticismLevel = 0;

    [SerializeField]
    private Text questionText;
    [SerializeField]
    private Slider playerInput;

    void Start() {

        if (unansweredQuestions == null) {
            unansweredQuestions = questions.ToList<Question>();
        }

        currentQuestion = unansweredQuestions[questionIndex];
        questionText.text = currentQuestion.question;
    }

    public void NextQuestion() {

        switch (currentQuestion.personality) {
            case Question.questionType.Openness:
                opennessScore.Add(playerInput.value);
                break;
            case Question.questionType.Agreeableness:
                agreeablenessScore.Add(playerInput.value);
                break;
            case Question.questionType.Conscientiousness:
                conscientiousnessScore.Add(playerInput.value);
                break;
            case Question.questionType.Neuroticism:
                neuroticismScore.Add(playerInput.value);
                break;
            case Question.questionType.Extraversion:
                extraversionScore.Add(playerInput.value);
                break;
            default:
                throw new System.ArgumentException("Not valid personality");
        }

        questionIndex = questionIndex + 1;

        if (questionIndex == unansweredQuestions.Count)
        {
            Debug.Log(questionIndex == unansweredQuestions.Count);
            opennessLevel = opennessScore.Average();
            Debug.Log(opennessLevel);
            SceneManager.LoadScene("GameOver");
        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

}
