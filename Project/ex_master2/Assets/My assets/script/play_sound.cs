using UnityEngine;
using UnityEngine.SceneManagement;

public class play_sound : MonoBehaviour
{
    [SerializeField] private AudioClip music;

    private bool start_flg = true;
    private AudioSource audiosource;

    // Start is called before the first frame update
    private void Start()
    {
        audiosource = GetComponent<AudioSource>();
    }
    public void PlayOneShot()
    {
        if (start_flg)
        {
            audiosource.PlayOneShot(music);
            //start_flg = false;
        }
    }

    public void Play()
    {
        AudioSource audioSource = GetComponent<AudioSource>();

        if (SceneManager.GetActiveScene().name == "ex_wood")
        {
            audioSource.clip = data_util_wood._auditoryStimuli;
        }
        else //if (SceneManager.GetActiveScene().name == "shoot_outside")
        {
            audioSource.clip = datautil_for_shooting.sound_;
        }

        audioSource.Play();
    }

    public void PlayIR()
    {
        AudioSource audioSource = GetComponent<AudioSource>();
        audioSource.clip = datautil.sound_;
        audioSource.Play();
    }
    public void Stop()
    {
        AudioSource audioSource = GetComponent<AudioSource>();
        audioSource.Stop();
        Debug.LogWarning("finish");
    }
}
