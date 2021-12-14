using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class Button_back : MonoBehaviour
{
    public GameObject panel;
    public GameObject VideoPanel;
    public VideoPlayer Video;

    public void closePanel(){      //Fecha o painel da interface
        if(panel != null){
            panel.SetActive(false);
        }
        runVideo();
        //changeScene();  //Funcao que muda a cena e leva o usuario para visualizacao das constelacoes
    }

    private void runVideo(){    //Comeca video de viagem estelar
        if(VideoPanel != null){
            VideoPanel.SetActive(true);
        }
        Video.loopPointReached += CloseVideoPanel;
        return;
    }

    void CloseVideoPanel(UnityEngine.Video.VideoPlayer vp){
        VideoPanel.SetActive(false);
        //UnityEngine.SceneManagement.SceneManager.LoadScene ("NewScene");  //Vai para proxima cena
    }
}
