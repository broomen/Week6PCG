using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    public GameObject mainRoom;
    public GameObject enemyRoom;
    public GameObject neutralRoom;
    public GameObject specialRoom;
    public int gridSize = 100;
    public int[] floorplan = new int[100];
    public int maxRooms = 10;
    int roomCounter = 0; //to ensure X amount of special rooms
    int mainroomIndex;
    int leftroomIndex = 0;
    int rightroomIndex = 0;
    int downroomIndex = 0;
    int uproomIndex = 0;
    public int specialRoomAmount = 0;
    bool needsSpecial = true;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < floorplan.Length; i++)
        {
            floorplan[i] = 0;
        }
        mainroomIndex = Random.Range(1, 100); //cant be 0, between 1 and 99
        floorplan[mainroomIndex] = 1;
        int nextRoom = 0;
        int currIndex = mainroomIndex;
        Debug.Log("Main room: " + mainroomIndex);

        int removeRoomAmount = 0; //check how many rooms to remove from maxRooms based on below if statements
        if (floorplanCheckerLeft(mainroomIndex)){
            determineNextRoomType(mainroomIndex - 1);
            removeRoomAmount++;
            leftroomIndex = mainroomIndex - 1;
        }
        if (floorplanCheckerRight(mainroomIndex))
        {
            determineNextRoomType(mainroomIndex + 1);
            removeRoomAmount++;
            rightroomIndex = mainroomIndex + 1;
        }
        if (floorplanCheckerDown(mainroomIndex))
        {
            determineNextRoomType(mainroomIndex + 10);
            removeRoomAmount++;
            downroomIndex = mainroomIndex + 10;
        }
        maxRooms -= removeRoomAmount;
        for (int i = 0; i < maxRooms; i++)
        {
            int path = Random.Range(1, 4); //determines if going left right or down
            if(path == 1 && leftroomIndex != 0)
            {
                currIndex = crawlPath(leftroomIndex);
            }
            if (path == 2 && rightroomIndex != 0)
            {
                currIndex = crawlPath(rightroomIndex);
            }
            if (path == 3 && downroomIndex != 0)
            {
                currIndex = crawlPath(downroomIndex);
            }
            //nextRoom = determineNextRoom(currIndex);
            //currIndex = nextRoom;
            determineNextRoomType(currIndex);
            roomCounter++;
        }
        for(int i = 0; i < floorplan.Length; i++)
        {
            if(floorplan[i] != 0)
            {
                placeRoom(i);
            }
        }

        //check the 4 rooms surrounding it, randomly decide on one
        //randomly pick between room 1 and room 2

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    int crawlPath(int index)
    {
        int nextIndex = index;
        List<string> directions = new List<string>();
        if (floorplanCheckerUp(index))
        {
            directions.Add("u");
        }
        if (floorplanCheckerDown(index))
        {
            directions.Add("d");
        }
        if (floorplanCheckerLeft(index))
        {
            directions.Add("l");
        }
        if (floorplanCheckerRight(index))
        {
            directions.Add("r");
        }
        bool crawling = true;
        int direction;
        while (crawling)
        {
            direction = Random.Range(0, directions.Count);
            if (directions[direction] == "u")
            {
                if (floorplan[index - 10] == 0)
                {
                    nextIndex = index - 10;
                    crawling = false;
                } else
                {
                    nextIndex = crawlPath(index - 10);
                    crawling = false;
                }
            }
            if (directions[direction] == "d")
            {
                if (floorplan[index + 10] == 0)
                {
                    nextIndex = index + 10;
                    crawling = false;
                }
                else
                {
                    nextIndex = crawlPath(index + 10);
                    crawling = false;
                }
            }
            if (directions[direction] == "l")
            {
                if (floorplan[index - 1] == 0)
                {
                    nextIndex = index - 1;
                    crawling = false;
                }
                else
                {
                    nextIndex = crawlPath(index - 1);
                    crawling = false;
                }
            }
            if (directions[direction] == "r")
            {
                if (floorplan[index + 1] == 0)
                {
                    nextIndex = index + 1;
                    crawling = false;
                }
                else
                {
                    nextIndex = crawlPath(index + 1);
                    crawling = false;
                }
            }
        }
        return nextIndex;
    }

    void placeRoom(int index)
    {
        Vector3 roomPos = new Vector3(0,0,0);
        if(index >= 0 && index < 10)
        {
            roomPos = new Vector3(20 * (index % 10), 0, 0);
        } 
        else if(index >= 10 && index < 20)
        {
            roomPos = new Vector3(20 * (index % 10), -20, 0);
        }
        else if (index >= 20 && index < 30)
        {
            roomPos = new Vector3(20 * (index % 10), -40, 0);
        }
        else if (index >= 30 && index < 40)
        {
            roomPos = new Vector3(20 * (index % 10), -60, 0);
        }
        else if (index >= 40 && index < 50)
        {
            roomPos = new Vector3(20 * (index % 10), -80, 0);
        }
        else if (index >= 50 && index < 60)
        {
            roomPos = new Vector3(20 * (index % 10), -100, 0);
        }
        else if (index >= 60 && index < 70)
        {
            roomPos = new Vector3(20 * (index % 10), -120, 0);
        }
        else if (index >= 70 && index < 80)
        {
            roomPos = new Vector3(20 * (index % 10), -140, 0);
        }
        else if (index >= 80 && index < 90)
        {
            roomPos = new Vector3(20 * (index % 10), -160, 0);
        }
        else if (index >= 90 && index < 100)
        {
            roomPos = new Vector3(20 * (index % 10), -180, 0);
        }
        if (floorplan[index] == 1)
        {
            GameObject room = Instantiate(mainRoom, roomPos, Quaternion.identity);
            getDoors(room, index);
        }
        if (floorplan[index] == 2)
        {
            GameObject room = Instantiate(enemyRoom, roomPos, Quaternion.identity);
            getDoors(room, index);
        }
        if (floorplan[index] == 3)
        {
            GameObject room = Instantiate(neutralRoom, roomPos, Quaternion.identity);
            getDoors(room, index);
        }
        if (floorplan[index] == 4)
        {
            PublicVars.paperAmount++;
            GameObject room = Instantiate(specialRoom, roomPos, Quaternion.identity);
            getDoors(room, index);
        }
    }

    void getDoors(GameObject room, int index)
    {
        if (floorplanCheckerUp(index) && index != mainroomIndex)
        {
            if (floorplan[index - 10] != 0)
            {
                room.GetComponent<Rooms>().upDoor.SetActive(true);
            }
        }
        if (floorplanCheckerDown(index))
        {
            if (floorplan[index + 10] != 0 && index + 10 != mainroomIndex)
            {
                room.GetComponent<Rooms>().downDoor.SetActive(true);
            }
        }
        if (floorplanCheckerLeft(index))
        {
            if (floorplan[index - 1] != 0)
            {
                room.GetComponent<Rooms>().leftDoor.SetActive(true);
            }
        }
        if (floorplanCheckerRight(index))
        {
            if (floorplan[index + 1] != 0)
            {
                room.GetComponent<Rooms>().rightDoor.SetActive(true);
            }
        }
    }
    void determineNextRoomType(int roomIndex)
    {
        int roomType = 0;
        if (needsSpecial)
        {
            Debug.Log("RoomCounter: " + roomCounter);
            Debug.Log("Max Rooms: " + maxRooms);
            Debug.Log("Special Rooms: " + specialRoomAmount);
            roomType = Random.Range(2, 5);
        } 
        else if (!needsSpecial)
        {
            roomType = Random.Range(2, 4);
        }
        if (needsSpecial && (maxRooms - roomCounter) < 4 && specialRoomAmount < 3)
        {
            roomType = 4;
        }
        if (roomType == 4)
        {
            specialRoomAmount++;
        }
        if(specialRoomAmount == 3) //ensure only 3 special rooms
        {
            needsSpecial = false;
        }
        floorplan[roomIndex] = roomType;
        if (roomIndex == mainroomIndex)
        {
            floorplan[roomIndex] = 1;
        }
        if(roomIndex == 0)
        {
            floorplan[roomIndex] = 0;
        }
    }
    int determineNextRoom(int index)
    {
        int nextRoomIndex = 0;
        int randomDirection;
        if (!floorplanCheckerUp(index) && !floorplanCheckerDown(index) && !floorplanCheckerLeft(index) && !floorplanCheckerRight(index))
        {
            Debug.Log("No suitable spots");
            nextRoomIndex = index;  
        }
        while (nextRoomIndex == 0)
        {
            randomDirection = Random.Range(1, 5);
            if (randomDirection == 1 && floorplanCheckerUp(index))
            {
                nextRoomIndex = index - 10;
            } 
            else if (randomDirection == 2 && floorplanCheckerDown(index))
            {
                nextRoomIndex = index + 10;
            } 
            else if (randomDirection == 3 && floorplanCheckerLeft(index))
            {
                nextRoomIndex = index - 1;
            } 
            else if(randomDirection == 4 && floorplanCheckerRight(index))
            {
                nextRoomIndex = index + 1;
            }
        }
        return nextRoomIndex;
    }

    bool floorplanCheckerUp(int index)
    {
        if((index - 10) < 0)
        {
            return false;
        }
        else
        {
            return true;
            /*
            if (floorplan[index-10] == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
            */
        }
    }
    bool floorplanCheckerDown(int index) //checks index below it
    {
        if ((index + 10) > 99)
        {
            return false;
        }
        else
        {
            return true;
            /*
            if (floorplan[index + 10] == 0) //if room hasn't been built, returns true
            {
                return true;
            }
            else
            {
                return false;
            }
            */
        }
    }
    bool floorplanCheckerLeft(int index)
    {
        if ((index - 1) < 0)
        {
            return false;
        }
        else if(index % 10 == 0)
        {
            return false;
        }
        else
        {
            return true;
            /*
            if (floorplan[index - 1] == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
            */
        }
    }
    bool floorplanCheckerRight(int index)
    {
        if(((index + 1) % 10) == 0)
        {
            return false;
        }
        else
        {
            return true;
            /*
            if (floorplan[index + 1] == 0)
            {
                return true;
            }
            else
            {
                Debug.Log("RoomTaken");
                return false;
            }
            */
        }
    }
}
