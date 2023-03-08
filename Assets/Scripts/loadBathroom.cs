using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class loadBathroom : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
       Random rnd = new Random();
       int index_bathroom_top_border = rnd.Next(3);
       int index_obstacle_area = rnd.Next(3);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
