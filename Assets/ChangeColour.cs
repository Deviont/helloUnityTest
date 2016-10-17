using UnityEngine;
using System.Collections;

public class ChangeColour : MonoBehaviour {

    public string posx = "";
    public string posy = "";
    public string posz = "";
    private bool showText = false;
    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {

            Vector3 MousePos = Input.mousePosition;
            {
                posx = "X: "+MousePos.x.ToString();
                posy = "Y: "+MousePos.y.ToString();
                posz = "Z: "+MousePos.z.ToString();
            }
        }
    }

    void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GetComponent<Renderer>().material.color = Color.red;
            transform.localScale += new Vector3(0.05F, 0.05F, 0.05F);
           
        }
        if (!showText)
        {
            showText = true;
        }

    }

    void OnGUI()
    {
        if (showText)
        {
                
            GUI.Label(new Rect(0, 0, 100, 20), "Coordinates:");
                GUI.Label(new Rect(0, 20, 100, 20), posx);
                GUI.Label(new Rect(0, 40, 100, 20), posy);
                GUI.Label(new Rect(0, 60, 100, 20), posz);
        }

        }
    }


   