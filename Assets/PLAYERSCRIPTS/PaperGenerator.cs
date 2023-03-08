using UnityEngine;

public class PaperGenerator : MonoBehaviour
{
    public GameObject paperPrefab;
    public int numberOfPapers = 4;

    private void Start()
    {
        for (int i = 0; i < numberOfPapers; i++)
        {
            Vector3 randomPosition = new Vector3(Random.Range(-10f, 10f), Random.Range(-10f, 10f), 0f);

            GameObject paperObject = Instantiate(paperPrefab, randomPosition, Quaternion.identity);
            paperObject.name = "Paper" + (i + 1);
        }
    }
}
