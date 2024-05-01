using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class PlayerSetup : MonoBehaviour
{
    private Button button;
    private GameObject button2;
    private GameObject vicon1;
    private GameObject vicon2;
    private GameObject vicon3;
    private GameObject closeIcon;
    private VideoPlayer vplayer;
    private GameObject vImage;
    public bool isPlaying;
    public Button playButton;
    public Sprite Play;
    public Sprite Pause;
    [SerializeField] Slider timeSlider;
    private bool isdragging = false;





    void Start()
    {
        timeSlider.onValueChanged.AddListener(HandleTimeSliderValueChanged);
        button = gameObject.GetComponentInChildren<Button>();
        button2 = transform.Find("gallery").gameObject;
        vicon1 = transform.Find("VideoObject1").gameObject;
        vicon2 = transform.Find("VideoObject2").gameObject;
        vicon3 = transform.Find("VideoObject3").gameObject;
        vplayer = transform.Find("Player").gameObject.GetComponent<VideoPlayer>();
        vImage = transform.Find("RawImage").gameObject.GetComponent<RawImage>().gameObject;
        closeIcon = transform.Find("CloseButton").gameObject.GetComponent<Button>().gameObject;


    }
    void Update()
    {


        if (!isdragging)
        {
            timeSlider.value=(float)vplayer.time;
            if (timeSlider.maxValue != (float)vplayer.length)
            {
                timeSlider.maxValue = (float)vplayer.length;
            }
        }

        if (isPlaying)
        {
            playButton.GetComponent<Image>().sprite = Pause;

        }
        else
        {
            playButton.GetComponent<Image>().sprite = Play;
        }



    }



 
    public void PowerOn()
    {
        button.gameObject.SetActive(false);
        button2.gameObject.SetActive(true);

    }

    public void GalleryClick()
    {

        vicon1.SetActive(true);
        vicon2.SetActive(true);
        vicon3.SetActive(true);
        button2.gameObject.SetActive(false);
        closeIcon.SetActive(false);
        timeSlider.gameObject.SetActive(false);
        vImage.SetActive(false);
        playButton.gameObject.SetActive(false);
        isPlaying = false;
        vplayer.Pause();
    }
    public void PlayVideo()
    {
  
        if (!isPlaying)
        {
            vicon1.SetActive(false);
            vicon2.SetActive(false);
            vicon3.SetActive(false);
            timeSlider.gameObject.SetActive(true);
            vImage.SetActive(true);
            closeIcon.SetActive(true);
            vplayer.Play();
            playButton.gameObject.SetActive(true);
            isPlaying = true;
        }
        else
        {
            isPlaying = false;
            vplayer.Pause();

        }
    }
    public void BeginDrag()
    {
        isdragging = true;
    }
    public void EndDrag()
    {
        isdragging =false;
    }
    public void HandleTimeSliderValueChanged(float value)
    {
        if(isdragging)
        {
            vplayer.time = value;
        }
    }
    public void SetClip1()
    {
        vplayer.url = System.IO.Path.Combine(Application.streamingAssetsPath, "v1.mp4");
        PlayVideo();
    }
    public void SetClip2()
    {
        vplayer.url = System.IO.Path.Combine(Application.streamingAssetsPath, "v2.mp4");
        PlayVideo();

    }
    public void SetClip3()
    {
        vplayer.url = System.IO.Path.Combine(Application.streamingAssetsPath, "v3.mp4");
        PlayVideo();
    }
}
