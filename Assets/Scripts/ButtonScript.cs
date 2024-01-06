using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScript : MonoBehaviour
{
    [SerializeField]
    public int planetNumber;

    public float activationDistance = 100f;
    private Camera _mainCamera;
    private Renderer _renderer;

    private Ray _ray;
    private RaycastHit hit;

    private void Start()
    {
        _mainCamera = Camera.main;
        _renderer = GetComponent<Renderer>();

    }


    public void OnButtonClick()
    {
        Debug.Log("Planet: " + planetNumber);
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
