using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SplashScreen : MonoBehaviour {

    Image uiImage;
    Canvas parentCanvas;

    [SerializeField]
    Sprite[] images;

    [SerializeField]
    float fadeTime;

    [SerializeField]
    float displayTime;

    [SerializeField]
    float transparentTime;

	void Start () {

        parentCanvas = GetComponent<Canvas>();

        if (parentCanvas.worldCamera != Camera.main)
            parentCanvas.worldCamera = Camera.main;

        DontDestroyOnLoad(gameObject);

        uiImage = GetComponentInChildren<Image>();

        uiImage.sprite = images[0];

        //StartCoroutine(CycleImages());
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    /*IEnumerator CycleImages()
    {
        if (!clickToProceed)
        {
            for(int i = 0; i < images.Length; i++)
            {
                uiImage.sprite = images[i];
                uiImage;
            }
        }
    }*/
}
