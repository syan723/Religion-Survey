using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public AudioClip[] STD;
    public AudioClip[] Skin;
    private bool isSTD;
    private int charIndex;
    public GameObject player;
    public Button nextButton;
    public Button previousButton;

    private AudioSource audioSource;
    private AudioClip[] currentClips;
    private int currentIndex = 0;
    public GameObject[] medals;


    void Start()
    {
        audioSource = player.GetComponent<AudioSource>();
        isSTD = MenuManager.singleTon.isSTD;
        charIndex = MenuManager.singleTon.characterIndex;
        if(charIndex != 0)
        {
            medals[charIndex-1].SetActive(true);
        }
        UpdateCurrentClips();
        PlayCurrentClip();
        UpdateButtonStates();
        
    }

    void UpdateCurrentClips()
    {
        currentClips = isSTD ? STD : Skin;
    }

    void PlayCurrentClip()
    {
        if (currentClips.Length > 0 && currentIndex >= 0 && currentIndex < currentClips.Length)
        {
            audioSource.clip = currentClips[currentIndex];
            audioSource.Play();
        }
    }

    public void NextClip()
    {
        if (currentIndex < currentClips.Length - 1)
        {
            currentIndex++;
            PlayCurrentClip();
            UpdateButtonStates();
        }
    }

    public void PreviousClip()
    {
        if (currentIndex > 0)
        {
            currentIndex--;
            PlayCurrentClip();
            UpdateButtonStates();
        }
    }

    void UpdateButtonStates()
    {
        previousButton.gameObject.SetActive(currentIndex > 0);
        nextButton.gameObject.SetActive(currentIndex < currentClips.Length - 1);
    }
}