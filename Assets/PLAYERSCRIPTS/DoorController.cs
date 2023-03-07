using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class DoorController : MonoBehaviour
{
    public GameObject paperHolder;  // A reference to the game object that holds the papers

    private string code = "";       // The code entered by the player
    private bool isPromptActive = false;  // Flag to indicate whether the prompt is active or not

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Y) && !isPromptActive)  // Check if the player pressed the interaction key and the prompt is not active
        {
            isPromptActive = true;
            PromptForCode();
        }
    }

    private void PromptForCode()
    {
        inputField.gameObject.SetActive(true);  // Activate the input field game object
        inputField.text = "";  // Clear the input field text
        inputField.Select();  // Set the focus on the input field

        Debug.Log("Enter the code:");
    }

    public void AddCodeDigit(int code)
    {
        if (isPromptActive && this.code.Length < 8)  // Check if the prompt is active and the code has not reached 8 digits
        {
            this.code += code.ToString();  // Add the code to the code string
            Debug.Log("Code: " + this.code);
        }

        if (this.code.Length == 8)  // Check if the code has reached 8 digits
        {
            CheckCode();
            isPromptActive = false;  // Deactivate the prompt
        }
    }

    public void SubmitCode(int code)
    {
        this.code = code.ToString();
        CheckCode();
    }

    private void CheckCode()
    {
        string expectedCode = "";  // The expected code based on the papers

        // Iterate over the papers and add their numbers to the expected code string
        foreach (Transform paper in paperHolder.transform)
        {
            PaperInfo paperInfo = paper.GetComponent<PaperInfo>();
            expectedCode += paperInfo.firstNumber.ToString() + paperInfo.secondNumber.ToString();
        }

        if (code == expectedCode)
        {
            // TODO: Implement the code is correct behavior (e.g. open the door)
            Debug.Log("Code is correct!");
        }
        else
        {
            // TODO: Implement the code is incorrect behavior (e.g. display an error message)
            Debug.Log("Code is incorrect!");
        }

        code = "";  // Reset the code
    }
}
