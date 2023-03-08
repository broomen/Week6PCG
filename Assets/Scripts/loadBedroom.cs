using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class loadBedroom : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        public Tilemap bathroom_1;
        public Tilemap bathroom_2;
        Tilemap[] bathroom_areas = {bathroom_1, bathroom_2};

        Random rnd = new Random();
        int index_bathroom = rnd.Next(2);
        for (int i = 0; i < 2; i++) {
            if (bathroom_areas[i] == bathroom_areas[index_bathroom]) {
                bathroom_areas[i].SetActive(true);
            } else {
                bathroom_areas[i].SetActive(false);
            }
        }

        public Tilemap wall_borders;
        public Tilemap wall_borders_2;
        public Tilemap living_area_1;
        public Tilemap living_area_2;
        Tilemap[] living_areas = {living_area_1, living_area_2};

        Random rnd = new Random();
        int index_living = rnd.Next(2);
        for (int i = 0; i < 2; i++) {
            if (living_areas[i] == living_areas[index_living]) {
                living_areas[i].SetActive(true);
            } else {
                living_areas[i].SetActive(false);
            }
            if (living_areas[i] == living_area_1) {
                wall_borders.SetActive(true);
                wall_borders_2.SetActive(false);
            } else {
                wall_borders_2.SetActive(true);
                wall_borders.SetActive(false);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
