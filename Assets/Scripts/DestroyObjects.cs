using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class DestroyObjects : MonoBehaviour
{

    public static int points = 0;

    private void OnMouseDown()
    {

        if (GameObject.Find("Objects").GetComponent<Points>().colorPick.Equals("Red") && gameObject.name == ("RedCube(Clone)"))
        {
            Destroy(gameObject);
            Points.points += 5;
        }
        else if (GameObject.Find("Objects").GetComponent<Points>().colorPick.Equals("Blue") && gameObject.name == "BlueCube(Clone)")
        {
            Destroy(gameObject);
            Points.points += 5;
        }
        else if (GameObject.Find("Objects").GetComponent<Points>().colorPick.Equals("Green") && gameObject.name == "GreenCube(Clone)")
        {
            Destroy(gameObject);
            Points.points += 5;
        }
        else if (GameObject.Find("Objects").GetComponent<Points>().colorPick.Equals("Pink") && gameObject.name == "PinkCube(Clone)")
        {
            Destroy(gameObject);
            Points.points += 5;
        }
        else if (GameObject.Find("Objects").GetComponent<Points>().colorPick.Equals("Yellow") && gameObject.name == "YellowCube(Clone)")
        {
            Destroy(gameObject);
            Points.points += 5;
        }
        else if (GameObject.Find("Objects").GetComponent<Points>().colorPick.Equals("Orange") && gameObject.name == "OrangeCube(Clone)")
        {
            Destroy(gameObject);
            Points.points += 5;
        }
        else if (GameObject.Find("Objects").GetComponent<Points>().colorPick.Equals("Purple") && gameObject.name == "PurpleCube(Clone)")
        {
            Destroy(gameObject);
            Points.points += 5;
        }
        else
        {
            Points.points -= 3;
        }

    }
}
