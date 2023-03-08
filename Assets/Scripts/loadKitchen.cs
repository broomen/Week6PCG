using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class loadKitchen : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        public Tilemap dining_area_1;
        public Tilemap dining_area_2;
        Tilemap[] dining_areas = {dining_area_1, dining_area_2};

        Random rnd = new Random();
        int index_dining = rnd.Next(2);
        for (int i = 0; i < 2; i++) {
            if (dining_areas[i] == dining_areas[index_dining]) {
                dining_areas[i].SetActive(true);
            } else {
                dining_areas[i].SetActive(false);
            }
        }

        public Tilemap kitchen_left_area_1;
        public Tilemap kitchen_left_area_2;
        public Tilemap kitchen_left_area_3;
        Tilemap[] kitchen_left_areas = {kitchen_left_area_1, kitchen_left_area_2, kitchen_left_area_3};
        int index_left_area = rnd.Next(3);
        for (int i = 0; i < 2; i++) {
            if (kitchen_left_areas[i] == kitchen_left_areas[index_left_area]) {
                kitchen_left_areas[i].SetActive(true);
            } else {
                kitchen_left_areas[i].SetActive(false);
            }
        }

        public Tilemap kitchen_right_area_1;
        public Tilemap kitchen_right_area_2;
        public Tilemap kitchen_right_area_3;
        Tilemap[] kitchen_right_areas = {kitchen_right_area_1, kitchen_right_area_2, kitchen_right_area_3};
        int index_right_area = rnd.Next(3);
        for (int i = 0; i < 2; i++) {
            if (kitchen_right_areas[i] == kitchen_right_areas[index_right_area]) {
                kitchen_right_areas[i].SetActive(true);
            } else {
                kitchen_right_areas[i].SetActive(false);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
