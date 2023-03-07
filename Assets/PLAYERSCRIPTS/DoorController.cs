using UnityEngine;
using UnityEngine.UI;

public class DoorController : MonoBehaviour
{
    public PaperInfo[] papers; 
    public InputField codeInput;   
    public GameObject endScreen;    

    private int[] correctCode;   
    private int codeIndex;  

    
    private void Start()
    {
        
        correctCode = new int[8];
        for (int i = 0; i < papers.Length; i++)
        {
            correctCode[i * 2] = papers[i].firstNumber;
            correctCode[i * 2 + 1] = papers[i].secondNumber;
        }

        
        codeIndex = 0;
        codeInput.gameObject.SetActive(true);
    }

    
    private void OnTriggerEnter(Collider other)
    {
        
        if (codeIndex >= 8 && CheckCode())
        {
            endScreen.SetActive(true);
        }
        else
        {
            Debug.Log("Wrong combination!");
            codeIndex = 0;
            codeInput.text = "";
        }
    }

    public void EnterDigit()
    {
        int digit = int.Parse(codeInput.text.Substring(codeIndex, 1));

        if (digit == correctCode[codeIndex])
        {
            codeIndex++;
            codeInput.text = "";
        }
        else
        {
            Debug.Log("Wrong combination!");
            codeIndex = 0;
            codeInput.text = "";
        }
    }

    private bool CheckCode()
    {
        for (int i = 0; i < correctCode.Length; i++)
        {
            if (int.Parse(codeInput.text.Substring(i, 1)) != correctCode[i])
            {
                return false;
            }
        }
        return true;
    }
}
