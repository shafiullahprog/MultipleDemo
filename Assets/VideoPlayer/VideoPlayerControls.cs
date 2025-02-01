using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class VideoPlayerControls : MonoBehaviour
{
    public static event Action<VideoPlayer> OnVideoPlay;
    public static event Action<VideoPlayer> OnVideoPause;

    public RenderTexture rt;
    public VideoPlayer videoPlayer;
    public GameObject play;
    public GameObject pause;

    public bool isPlaying;
    public bool IsPlaying
    {
        get { return isPlaying; }
        set
        {
            isPlaying = value;
            if (!isPlaying)
                OnVideoPause?.Invoke(videoPlayer);
            else if (isPlaying)
                OnVideoPlay?.Invoke(videoPlayer);
        }
    }

    private void OnEnable()
    {
        videoPlayer.prepareCompleted += OnPrepare;
        videoPlayer.loopPointReached += Pause;
    }

    private void OnDisable()
    {
        videoPlayer.prepareCompleted -= OnPrepare;
        videoPlayer.loopPointReached -= Pause;
    }

    public void PlayVideoURL(string url)
    {
        videoPlayer.source = VideoSource.Url;
        videoPlayer.Stop();
        videoPlayer.url = url;
        videoPlayer.Prepare();
    }

    public void CloseVideo(RenderTexture rt)
    {
        videoPlayer.url = null;
        videoPlayer.Stop();
        videoPlayer.SetDirectAudioMute(0, false);
        rt.Release();
        IsPlaying = false;
        gameObject.SetActive(false);
    }

    //UI call
    public void PlayPause(VideoPlayer vp)
    {
        if (videoPlayer.isPlaying)
        {
            videoPlayer.Pause();
            play.SetActive(true);
            pause.SetActive(false);
            IsPlaying = false;
        }
        else
        {
            videoPlayer.Play();
            play.SetActive(false);
            pause.SetActive(true);
            IsPlaying = true;
        }
    }

    public void OnPrepare(VideoPlayer videoPlayer)
    {
        videoPlayer.targetTexture = rt;
        videoPlayer.GetComponent<RawImage>().texture = rt;
        Play(videoPlayer);
    }

    public void Play(VideoPlayer videoPlayer)
    {
        videoPlayer.Play();
        play.SetActive(false);
        pause.SetActive(true);
        IsPlaying = true;
    }

    public void Pause(VideoPlayer videoPlayer)
    {
        videoPlayer.Pause();
        play.SetActive(true);
        pause.SetActive(false);
        IsPlaying = false;
    }


}
