using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ControleMenuPrincipal : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject menuOpcoes;
    public GameObject volumeSliderObj;
    public GameObject cameraObj;
    
    private AudioSource cameraAudio;
    private Slider volumeSlider;
    private bool isOptionOpen;
    
      void Start()
    {
        volumeSlider =  volumeSliderObj.GetComponent<Slider>();
        cameraAudio = cameraObj.GetComponent<AudioSource>();
        isOptionOpen = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        SceneManager.LoadScene("ClickerGame");
    }

    public void ToggleMenuOption()
    {
        menuOpcoes.SetActive(isOptionOpen);
        isOptionOpen = !isOptionOpen;        
    }

    public void SetVolumeSlider()
    {
        cameraAudio.volume = volumeSlider.value;
    }

    public void OpenLink(string link)
    {
        switch(link){
            case "github": Application.OpenURL("www.github.com/hyansu");
            print("github");
            break;
            case "instagram": Application.OpenURL("www.instagram.com/hyantsu");
            print("github");
            break;
        }
        
    }
    
}
