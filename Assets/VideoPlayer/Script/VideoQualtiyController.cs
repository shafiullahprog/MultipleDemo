using TMPro;
using UnityEngine;

[RequireComponent(typeof(VideoPlayerControls))]
public class VideoQualtiyController : MonoBehaviour
{
    VideoPlayerControls videoPlayerControls;
    public TMP_Dropdown qualitySelector;
    private void Start()
    {
        SetResolution(1920,1080);
        videoPlayerControls = GetComponent<VideoPlayerControls>();
        qualitySelector.onValueChanged.AddListener(SelectQuality);
    }

    private void SelectQuality(int value)
    {
        int width = 1920, height = 1080;

        switch (value)
        {
            case 0:
                width = 1920; height = 1080;
                break;
            case 1:
                width = 1280; height = 720;
                break;
            case 2:
                width = 854; height = 480;
                break;
        }
       
        SetResolution(width, height);
    }

    private void SetResolution(int width, int height)
    {
        if (videoPlayerControls == null)
            return;
        var renderTexture = videoPlayerControls.rt;
        renderTexture.Release();

        renderTexture.width = width;
        renderTexture.height = height;

        videoPlayerControls.videoPlayer.targetTexture = renderTexture;
    }
}
