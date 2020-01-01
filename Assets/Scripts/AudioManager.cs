using UnityEngine;


public class AudioManager : MonoBehaviour
{

    [SerializeField] [Range(0, 1)] float volume = 1.0f;
    [SerializeField] AudioClip audioClip = null;
    [SerializeField] bool playOnStart = false;


    private void Awake()
    {
        if (playOnStart)
        {
            Play();
        }
    }

    public void Play()
    {
        if (audioClip)
        {
            AudioSource.PlayClipAtPoint(audioClip, Camera.main.transform.position, volume);
        }
    }
}
