
using UnityEngine;
using TMPro;

public class Numpad : MonoBehaviour
{
    public int correctAnswer = 5;
    public TMP_Text answerText;
    public GameManager gameManager;
    public AudioSource AD;

    private string currentAnswer = "";

    public void answer(int num)
    {
        // Limit answer length to avoid excessively long numbers.
        if (currentAnswer.Length >= 9)
            return;

        currentAnswer += num.ToString();
        UpdateAnswerDisplay();
    }
    public void ResetInput()
    {
        currentAnswer = "";
        UpdateAnswerDisplay();
    }
    private void UpdateAnswerDisplay()
    {
        if (answerText != null)
            answerText.text = currentAnswer == "" ? " " : currentAnswer;
    }

    public void num0()
    {
        answer(0); 
        AD.Play();
    }
    public void num1()
    {
        answer(1); 
        AD.Play();
    }
    public void num2() 
    { 
        answer(2);
        AD.Play();
    }
    public void num3() {
        answer(3);
        AD.Play();
    }
    public void num4() { answer(4);
        AD.Play();
    }
    public void num5() {
        answer(5); AD.Play(); 
    }
    public void num6() {
        answer(6); AD.Play();
    }
    public void num7() { 
        answer(7); AD.Play(); 
    }
    public void num8() {
        answer(8); AD.Play();
    }
    public void num9() { 
        answer(9); AD.Play();
    }

    public void numX()
    {
        AD.Play();
        if (currentAnswer.Length > 0)
        {
            currentAnswer =
                currentAnswer.Substring(0, currentAnswer.Length - 1);
        }

        UpdateAnswerDisplay();
    }


    public void numQ()
    {
        if (!int.TryParse(currentAnswer, out int enteredAnswer))
        {
            ResetInput();
            return;
        }

        gameManager.CheckAnswer(enteredAnswer);
    }


    public void SetCorrectAnswer(int newAnswer)
    {
        correctAnswer = newAnswer;
        currentAnswer = "";
        UpdateAnswerDisplay();
    }
}
