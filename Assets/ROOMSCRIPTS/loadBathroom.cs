using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class loadBathroom : MonoBehaviour
{
    public ;
    // Start is called before the first frame update
    void Start()
    {

        public Tilemap bathroom_top_border_1;
        public Tilemap bathroom_top_border_2;
        Tilemap[] bathroom_top_borders = {bathroom_top_border_1, bathroom_top_border_2};

        Random rnd = new Random();
        int index_b_tp = rnd.Next(2);
        for (int i = 0; i < 2; i++) {
            if (bathroom_top_borders[i] == bathroom_top_borders[index_b_tp]) {
                bathroom_top_borders[i].SetActive(true);
            } else {
                bathroom_top_borders[i].SetActive(false);
            }
        }

        public Tilemap obstacle_area_1;
        public Tilemap obstacle_area_2;
        public Tilemap obstacle_area_3;
        Tilemap[] bathroom_obstacle_areas = {obstacle_area_1, obstacle_area_2, obstacle_area_3};
        int index_obstacle_area = rnd.Next(3);
        for (int i = 0; i < 2; i++) {
            if (bathroom_obstacle_areas[i] == bathroom_obstacle_areas[index_b_tp]) {
                bathroom_obstacle_areas[i].SetActive(true);
            } else {
                bathroom_obstacle_areas[i].SetActive(false);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
