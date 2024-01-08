using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Puzzle2 : MonoBehaviour
{
    GameObject door;

    public string codeLeft = "";
    public GameObject displayTextLeft;
    public TextMeshPro textLeft;

    public string codeRight = "";
    public GameObject displayTextRight;
    public TextMeshPro textRight;

    public bool solvedLeft = false;
    public bool solvedRight = true;
    
    
    public void EnterNumberLeft(int number){
        codeLeft += number.ToString();
        UpdateTextLeft();
    }

    public void SubmitLeft(){
        if(codeLeft == "16071969"){
            Debug.Log("Solved");
            solvedLeft = true;
        }
    }

    public void DeleteLeft(){
        codeLeft = "";
        UpdateTextLeft();
    }
    
    private void UpdateTextLeft(){
        textLeft.text = codeLeft;
    }

    // ------------- Right ---------------

     public void EnterNumberRight(int number){
        codeRight += number.ToString();
        UpdateTextRight();
    }

    public void SubmitRight(){
        if(codeRight == "24071969"){
            Debug.Log("Solved");
            solvedRight = true;
        }
    }

    public void DeleteRight(){
        codeRight = "";
        UpdateTextRight();
    }
    
    private void UpdateTextRight(){
        textRight.text = codeRight;
    }


    // Start is called before the first frame update
    void Start()
    {
        displayTextLeft = GameObject.Find("DisplayTextLeft");
        textLeft = displayTextLeft.GetComponent<TextMeshPro>();

        displayTextRight = GameObject.Find("DisplayTextRight");
        textRight = displayTextRight.GetComponent<TextMeshPro>();

        door = GameObject.Find("Door2");

    }

    // Update is called once per frame
    void Update()
    {
        if(solvedLeft && solvedRight){
            door.transform.Translate(Vector3.up * 2f * Time.deltaTime);
        }
    }
}
