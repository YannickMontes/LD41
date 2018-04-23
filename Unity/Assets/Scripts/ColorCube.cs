using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorCube : MonoBehaviour {

    [SerializeField]
    private List<Material> matList;

    [SerializeField]
    private Animator animator;

    bool isChangingColor = false;

    public Material currentMaterial;

    public void changeColor() {
        animator.SetTrigger("TriggerBtn");
        int currentIndex = matList.IndexOf(currentMaterial);
        currentIndex++;
        if (currentIndex >= matList.Count)
        {
            currentMaterial = matList[0];
        }
        else
        {
            currentMaterial = matList[currentIndex];
        }

        isChangingColor = true;
    }
	// Use this for initialization
	void Start () {
        if(matList !=null)
            currentMaterial = matList[0];
    }
	
	// Update is called once per frame
	void Update () {
        if (isChangingColor)
        {
            this.GetComponent<Renderer>().material = currentMaterial;
            isChangingColor = false;
        }
    }

   /* private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponentInParent<Weapon>() != null)
        {
            changeColor();
        }
    }*/
}
