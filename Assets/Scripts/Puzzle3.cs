using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle3 : MonoBehaviour
{
    public GameObject door;
    private bool solved = false;

    private Renderer renderer;
    private string morseCode = "- . . .  - - -  - . -"; 
    public Color onColor = Color.red;
    public Color offColor = Color.white;
    public float dotDuration = 0.2f; // Duration for a dot in seconds
    public float dashDuration = 1.0f; // Duration for a dash in seconds
    public float spaceDuration = 0.5f; // Duration for a space between symbols in seconds

    private string targetWord = "bok";
    private string userInput = "";


    IEnumerator ChangeColor()
    {
        while(true){
            foreach (char symbol in morseCode)
            {
                switch (symbol)
                {
                    case '.':
                        renderer.material.color = onColor;
                        yield return new WaitForSeconds(dotDuration);
                        break;
                    case '-':
                        renderer.material.color = onColor;
                        yield return new WaitForSeconds(dashDuration);
                        break;
                    case ' ':
                        renderer.material.color = offColor;
                        yield return new WaitForSeconds(spaceDuration);
                        break;
                }

                // After each symbol, turn off the color
                renderer.material.color = offColor;
            }
        }
    }
    

    // Start is called before the first frame update
    void Start()
    {
        renderer = GetComponent<Renderer>();
        StartCoroutine(ChangeColor());
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown)
        {

            
            if (Input.inputString.Length == 1 && (char.IsLetterOrDigit(Input.inputString[0]) || char.IsWhiteSpace(Input.inputString[0])))
            {
                // Append the pressed key to the user input
                userInput += Input.inputString;

                Debug.Log(userInput);

                // Check if the user input matches the target word
                if (userInput.Contains(targetWord))
                {
                    solved = true;
                }
            }
        }

        if(solved){
            door = GameObject.Find("Door3");
            door.transform.Translate(Vector3.up * 2f * Time.deltaTime);

        }
    }
}
