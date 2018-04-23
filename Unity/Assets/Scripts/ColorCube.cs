using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorCube : MonoBehaviour {

    [SerializeField]
    private List<Material> matList;

    int currentColor = 0;
    bool isChangingColor = false;

    public Material currentMaterial;

    public void changeColor()
    {
        if (currentColor < matList.Count)
        {
            currentColor++;
            isChangingColor = true;
        }
        else
        {
            currentColor = 0;
            isChangingColor = false;
        }
            
    }
	// Use this for initialization
	void Start () {
        currentMaterial = matList[currentColor];
    }
	
	// Update is called once per frame
	void Update () {
        if (isChangingColor)
        {
            this.GetComponent<Renderer>().material = matList[currentColor];
            currentMaterial = matList[currentColor];
            isChangingColor = false;
        }
	}
}
