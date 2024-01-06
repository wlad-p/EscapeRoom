using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle1 : MonoBehaviour
{
    public static List<int> planetNumbersAdded = new List<int>();

    public static void EnterPlanetNumber(int planetNumber)
    {
        planetNumbersAdded.Add(planetNumber);
        CheckIfSolved();
    }

    public static void CheckIfSolved()
    {
        bool solved = true;

        if(planetNumbersAdded.Count >= 8){
            List<int> lastEight = planetNumbersAdded.GetRange(planetNumbersAdded.Count - 8, 8);
            for(int i = 0; i < 8; i++){
                if(lastEight[i] != i+1)
                {
                    solved = false;
                }
            }
            
            if(solved){
                Debug.Log("SOLVED!");
                GameObject door = GameObject.Find("Door");
                if(door != null){
                    door.transform.position = new Vector3(-2f, 6f, -0.01f);
                }
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
