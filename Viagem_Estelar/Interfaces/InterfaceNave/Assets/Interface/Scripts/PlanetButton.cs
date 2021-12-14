using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class PlanetButton : MonoBehaviour
{
    public GameObject panel;
    public GameObject VideoPanel;
    public VideoPlayer Video;
    //public Button botao;
    private Text ButtonText;
    public GameObject planet;
    public Text DistanceText;
    public Animator PlanetRotation;

    public void closePanel(){      //Fecha o painel da interface
        if(panel != null){
            panel.SetActive(false);
        }
        runVideo();
        getPlanet();
        changeDistanceText();
        startAnimation();
    }

    private void runVideo(){    //Comeca video de viagem estelar
        if(VideoPanel != null){     //Ativa painel e roda video
            VideoPanel.SetActive(true);
        }
        Video.loopPointReached += CloseVideoPanel;  //Quando acabar o video, vai para essa funcao
        return;
    }

    void CloseVideoPanel(UnityEngine.Video.VideoPlayer vp){     //Fecha painel do video
        VideoPanel.SetActive(false);
    }

    private void getPlanet(){   //Coloca o planeta escolhido na frente da nave
        //ButtonText = transform.Find("Text").GetComponent<Text>();
        planet.SetActive(true);
        //Get button text
        //Active planet with same name as button text
        //Active planet animation
    }

    private void changeDistanceText(){
        float distPlanet = 0f;

        ButtonText = transform.Find("Text").GetComponent<Text>();

        if(ButtonText.text.Equals ("Mercúrio")){
            distPlanet = 0.39f;
        }
        if(ButtonText.text.Equals ("Vênus")){
            distPlanet = 0.72f;
        }
        if(ButtonText.text.Equals ("Marte")){
            distPlanet = 1.52f;
        }
        if(ButtonText.text.Equals ("Jupiter")){
            distPlanet = 1.52f;
        }
        if(ButtonText.text.Equals ("Urano")){
            distPlanet = 19.1f;
        }
        if(ButtonText.text.Equals ("Netuno")){
            distPlanet = 30.0f;
        }
        if(ButtonText.text.Equals ("Lua")){
            DistanceText.text = "Distância da Terra:  384.400 km";   //Change distance text that depends on planet name
            return;
        }
        if(ButtonText.text.Equals ("Sol")){
            distPlanet = 1.0f;
        }

        DistanceText.text = "Distância da Terra:  " + distPlanet + " UA";   //Change distance text that depends on planet name
    }

    void startAnimation(){
        PlanetRotation.SetTrigger("Active");
    }
}
