using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class SplashScreen : MonoBehaviour
{
    [System.Serializable]
    public struct States
    {
        public Sprite image;
        public Color colour;
        public float duration;
        public float lerp;
    }

    public GameObject mainMenu;

    //public States[] states_array;

    private VideoPlayer video_player;
    //private Image splash_screen;
    //private int state_index;
    //private bool is_running;
    //private float state_timer;
    //private int phase_index;

    // Use this for initialization
    void Start ()
    {
        mainMenu.SetActive(false);

        video_player = gameObject.GetComponent<VideoPlayer>();
        video_player.loopPointReached += VideoEnded;
        //splash_screen = gameObject.GetComponent<Image>();
        //state_index = 0;
        //is_running = false;
        //state_timer = 0;
        //phase_index = 0;
    }
	
	// Update is called once per frame
	void Update ()
    {
        //if (is_running)
        //    SplashTransition();
	}

    //void SplashTransition()
    //{
    //    if (state_index < states_array.Length)
    //    {
    //        Color solid_colour = states_array[state_index].colour;
    //        Color faded_colour = solid_colour;
    //        faded_colour.a = 0;

    //        splash_screen.sprite = states_array[state_index].image;

    //        if (phase_index < 3)
    //        {
    //            state_timer += Time.deltaTime;

    //            switch (phase_index)
    //            {
    //                case 0:
    //                    {
    //                        float t = state_timer / states_array[state_index].lerp;
    //                        splash_screen.color = Color.Lerp(faded_colour, solid_colour, t);

    //                        if (state_timer > states_array[state_index].lerp)
    //                        {
    //                            state_timer -= states_array[state_index].lerp;
    //                            ++phase_index;
    //                        }

    //                        break;
    //                    }
    //                case 1:
    //                    {
    //                        if (state_timer > states_array[state_index].duration)
    //                        {
    //                            state_timer -= states_array[state_index].duration;
    //                            ++phase_index;
    //                        }

    //                        break;
    //                    }
    //                case 2:
    //                    {
    //                        float t = state_timer / states_array[state_index].lerp;
    //                        splash_screen.color = Color.Lerp(solid_colour, faded_colour, t);

    //                        if (state_timer > states_array[state_index].lerp)
    //                        {
    //                            state_timer -= states_array[state_index].lerp;
    //                            phase_index = 0;
    //                            ++state_index;
    //                        }

    //                        break;
    //                    }
    //                default:
    //                    {
    //                        Debug.Log("Splash Screen phase switch statement out of index");
    //                        break;
    //                    }
    //            }
    //        }
    //    }
    //    else
    //    {
    //        startButton.SetActive(true);
    //        quitButton.SetActive(true);

    //        is_running = false;
    //    }
    //}

    void VideoEnded(UnityEngine.Video.VideoPlayer vp)
    {
        vp.Stop();
        //is_running = true;

        mainMenu.SetActive(true);
    }
}
