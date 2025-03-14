using UnityEngine;

public class RoomManager : MonoBehaviour
{
    public GameObject[] theDoors;
    public GameObject mmRoomPrefab;
    private Dungeon theDungeon;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Core.thePlayer = new Player("Mike");
        this.theDungeon = new Dungeon();
        this.setupRoom();
    }

    //disable all doors
    private void resetRoom()
    {
        this.theDoors[0].SetActive(false);
        this.theDoors[1].SetActive(false);
        this.theDoors[2].SetActive(false);
        this.theDoors[3].SetActive(false);
    }

    //show the doors appropriate to the current room
    private void setupRoom()
    {
        Room currentRoom = Core.thePlayer.getCurrentRoom();
        this.theDoors[0].SetActive(currentRoom.hasExit("west"));
        this.theDoors[1].SetActive(currentRoom.hasExit("north"));
        this.theDoors[2].SetActive(currentRoom.hasExit("east"));
        this.theDoors[3].SetActive(currentRoom.hasExit("south"));
    }

    // Update is called once per frame
    void Update()
    {
        bool didChangeRoom = false;
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            //try to goto the north
            didChangeRoom = Core.thePlayer.getCurrentRoom().tryToTakeExit("north");
            GameObject newMMRoom = Instantiate(this.mmRoomPrefab);
            Vector3 currPos = newMMRoom.transform.position;
            Vector3 newPos;
            newPos.x = currPos.x;
            newPos.y = currPos.y;
            newPos.z = currPos.z + 1.2f;
            newMMRoom.transform.position = newPos;

        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            //try to goto the west
            didChangeRoom = Core.thePlayer.getCurrentRoom().tryToTakeExit("west");
            GameObject newMMRoom = Instantiate(this.mmRoomPrefab);
            Vector3 currPos = newMMRoom.transform.position;
            Vector3 newPos;
            newPos.x = currPos.x - 1.2f;
            newPos.y = currPos.y;
            newPos.z = currPos.z;
            newMMRoom.transform.position = newPos;
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            //try to goto the east
            didChangeRoom = Core.thePlayer.getCurrentRoom().tryToTakeExit("east");
            GameObject newMMRoom = Instantiate(this.mmRoomPrefab);
            Vector3 currPos = newMMRoom.transform.position;
            Vector3 newPos;
            newPos.x = currPos.x + 1.2f;
            newPos.y = currPos.y;
            newPos.z = currPos.z;
            newMMRoom.transform.position = newPos;
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            //try to goto the south
            didChangeRoom = Core.thePlayer.getCurrentRoom().tryToTakeExit("south");
            GameObject newMMRoom = Instantiate(this.mmRoomPrefab);
            Vector3 currPos = newMMRoom.transform.position;
            Vector3 newPos;
            newPos.x = currPos.x;
            newPos.y = currPos.y;
            newPos.z = currPos.z - 1.2f;
            newMMRoom.transform.position = newPos;
        }

        //did we change rooms?
        if (didChangeRoom)
        {
            this.setupRoom();
        }
    }
}
