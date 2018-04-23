using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	public static GameManager instance = null;

	public GameObject targets;
	public GameObject mobs;

	public GameObject commandPanel;

    public GameObject redButton;
    public GameObject colorCube;


    public GameObject spawner;

	void Awake()
	{
		if (instance == null)
			instance = this;
		else if (instance != this)
			Destroy(gameObject);
		DontDestroyOnLoad(gameObject);
	}

	// Use this for initialization
	void Start()
	{
	}

	// Update is called once per frame
	void Update()
	{
		if (Input.GetKeyDown(KeyCode.H))
		{
			commandPanel.SetActive(!commandPanel.active);
		}

        if (Input.GetKeyDown(KeyCode.L))
        {
            colorCube.GetComponent<ColorCube>().changeColor();
        }

        if (Input.GetKeyDown(KeyCode.M))
        {
            spawner.GetComponent<EnemySpawner>().spawnWave();
        }
    }
}
