using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

[RequireComponent(typeof(VideoPlayerControls))]
public class VideoSkip : MonoBehaviour
{
    VideoPlayer videoPlayer;
    public Button forwardButton, backwardButton;
    public double skipTime;
    void Start()
    {
        videoPlayer = GetComponent<VideoPlayer>();
        forwardButton.onClick.AddListener(() => SkipVideo(skipTime));
        backwardButton.onClick.AddListener(() => SkipVideo(-skipTime));
    }
    void SkipVideo(double timeToSkip)
    {
        if (videoPlayer == null)
        {
            return;
        }
        double newTime = videoPlayer.time + timeToSkip;
        videoPlayer.time = Mathf.Clamp((float)newTime, 0, (float)videoPlayer.length);
    }
}
