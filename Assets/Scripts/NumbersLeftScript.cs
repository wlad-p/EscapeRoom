using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumbersLeftScript : MonoBehaviour
{
    [SerializeField]
    public int number;

    // OK = 0, DEL = 1
    [SerializeField]
    public int button;


    public float activationDistance = 100f;
    private Camera _mainCamera;
    private Renderer _renderer;

    private Ray _ray;
    private RaycastHit hit;


    public Puzzle2 puzzle2;

    void Start()
    {
        _mainCamera = Camera.main;
        _renderer = GetComponent<Renderer>();
    }


    public void OnButtonClick()
    {
        if(button == -1){
            Debug.Log("number: " + number);
            puzzle2.EnterNumberLeft(number);
            
       }
        else if(number == -1){
            if(button == 0){
                puzzle2.SubmitLeft();
            }
            else if(button == 1){
                puzzle2.DeleteLeft();
            }
        }
        
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            _ray = new Ray(
                _mainCamera.ScreenToWorldPoint(Input.mousePosition),
                _mainCamera.transform.forward);
            
            if(Physics.Raycast(_ray, out hit, activationDistance))
            {
                if(hit.transform == transform)
                {
                    OnButtonClick();
                }
            }
            
        }
    }

}
