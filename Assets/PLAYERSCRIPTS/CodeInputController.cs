using UnityEngine;
using UnityEngine.UI;

public class CodeInputController : MonoBehaviour
{
    public DoorController doorController;  // A reference to the door controller script
    public GameObject inputFieldGameObject; // A reference to the input field game object

    private InputField inputField;  // A reference to the input field component

    private void Start()
    {
    {
        int enteredCode;

        if (int.TryParse(inputField.text, out enteredCode))  // Try to parse the entered code as an integer
        {
            doorController.CheckCode(enteredCode); // Call the CheckCode method on the door controller script with the entered code
        }
        else
        {
            Debug.Log("Invalid code!");  // Display an error message if the entered code is invalid
        }

        inputField.text = "";  // Clear the input field text
    }
}
