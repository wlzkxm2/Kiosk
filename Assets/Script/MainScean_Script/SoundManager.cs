using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;

    // 버튼 클릭시 나올 사운드
    private AudioSource buttonSound;
    [SerializeField] private AudioClip click;
    [SerializeField] private AudioClip negative;
    [SerializeField] private AudioClip popUp;

    private void Awake() {
        if(Instance != null){
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    // Start is called before the first frame update
    private void Start()
    {
        buttonSound = GetComponent<AudioSource>();
    }

    public void ClickSound(){
        // 사운드가 재생중일수도 있으므로 중복재생을 막기위해
        // 실행중인 사운드를 정지
        buttonSound.Stop();

        buttonSound.clip = click;
        buttonSound.Play();
    }

    public void NagativeSound(){
        buttonSound.Stop();

        buttonSound.clip = negative;
        buttonSound.Play();
    }

    public void PopUpSound(){
        buttonSound.Stop();

        Debug.Log("popup");

        buttonSound.clip = popUp;
        buttonSound.Play();
    }
}
