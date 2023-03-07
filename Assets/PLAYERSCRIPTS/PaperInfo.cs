using UnityEngine;

public class PaperInfo : MonoBehaviour
{
    public int firstNumber;     
    public int secondNumber;    

    private void Start()
    {
        firstNumber = Random.Range(1, 10);
        secondNumber = Random.Range(1, 10);
    }
}
