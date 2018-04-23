using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakeScreen : MonoBehaviour {
    [HideInInspector]
    public static ShakeScreen Instance;
    
    private GameObject cam;
    private float shakingStrength = 0f;
    private Vector3 positionOrigin;

    void Awake () {
        if (Instance == null) {
            Instance = this;
        } else {
            Debug.LogError("Une autre instance de ShakeScreen is already present!");
        }
        cam = Camera.main.gameObject;
        positionOrigin = cam.transform.localPosition;
	}

	void Update () {
		if (Mathf.Approximately(shakingStrength, 0f)) {
            cam.transform.localPosition = positionOrigin;
        }
        else {
            float speed = 25f;
            Vector3 noise = new Vector3(Mathf.PerlinNoise(Time.fixedTime * speed, 0f), Mathf.PerlinNoise((Time.fixedTime + 5f) * speed, 10f), Mathf.PerlinNoise((Time.fixedTime + speed) * 30f, 30f));
            cam.transform.localPosition = positionOrigin + noise * shakingStrength * 0.12f;
        }
    }

    public void SetShakingStrength(float strength) {
        shakingStrength = strength;
    }

    public void ScreenShakeImpulsion(float strength, float duration) {
        StartCoroutine(ScreenShakeCortoutine(strength, duration));
    }

    private IEnumerator ScreenShakeCortoutine(float strength, float duration) {
        float startTime = Time.fixedTime;
        while (Time.fixedTime < startTime + duration) {
            float attenuation = 1f - Mathf.InverseLerp(startTime, startTime + duration, Time.fixedTime);
            SetShakingStrength(strength * attenuation);
            yield return new WaitForFixedUpdate();
        }
        SetShakingStrength(0f);
    }


}
