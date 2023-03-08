using UnityEngine;
using UnityEngine.UI;

public class Door : MonoBehaviour
{
    public PaperGenerator paperGenerator;

    public string correctCode;

    public InputField inputField;

    private PaperInfo[] papers;
    private bool isUnlocked = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Y))
        {
            OpenDoor();
        }
    }

    private void OpenDoor()
    {
        if (!isUnlocked)
        {
            if (inputField != null && inputField.text == correctCode)
            {
                isUnlocked = true;
                Destroy(gameObject);
            }
        }
    }


    private void Start()
    {
        if (paperGenerator != null)
        {
            papers = paperGenerator.GetComponentsInChildren<PaperInfo>();

            for (int i = 0; i < papers.Length; i++)
            {
                correctCode += papers[i].firstNumber.ToString() + papers[i].secondNumber.ToString();
            }
        }
    }

}
