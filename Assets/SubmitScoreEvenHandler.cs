using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SubmitScoreEvenHandler : MonoBehaviour
{
    public GameObject SubmitButton;
    public GameObject NameInput;

    Text buttonText;
    public void Clicked()
    {
        buttonText = SubmitButton.transform.GetChild(0).GetComponent<Text>();
        buttonText.text = "Submitted!";
        SubmitButton.GetComponent<Button>().interactable = false;

        var playerName = NameInput.GetComponent<InputField>().text;
        NameInput.GetComponent<InputField>().interactable = false;
        var score = GameManager.Instance.Score;

        FirebaseHandler.AddScore(playerName, score);
    }
}
