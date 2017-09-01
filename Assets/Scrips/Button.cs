using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    public Sprite normal;
    public Sprite over;
    public Sprite down;
    public AudioSource button;
    public LevelManager levelManager;
    public string buttonLevel;

    // Use this for initialization
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0)){
           
        }
    }

    private void OnMouseOver()
    {
        GetComponent<SpriteRenderer>().sprite = over;
    }

    private void OnMouseDown()
    {
        GetComponent<SpriteRenderer>().sprite = down;
        button.Play();
    }

    private void OnMouseUp()
    {
        levelManager.LoadLevel(buttonLevel);
    }

    private void OnMouseExit()
    {
        GetComponent<SpriteRenderer>().sprite = normal;
    }
}
