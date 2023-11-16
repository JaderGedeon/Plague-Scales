/// <>
/// ######################################################################### � Burnout Studios #############################################################################
/// ############################################################################# 15/11/2023 ################################################################################
/// ###################################################################### Sistema de Configura��es #########################################################################
/// <>

using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using TMPro;
using System.Linq;

public class Options_Menu : MonoBehaviour
{
    /* #################################################################### Declara��o de Variaveis #########################################################################*/
        /*AudioMixer respons�vel pelas Musicas*/
            public AudioMixer music;
        /*AudioMixer respons�vel pelos Efeitos Especiais*/
            public AudioMixer SFX;
        /*Array que ser� preenchido com as resolu��es da tela*/
            Resolution[] resolutions;
        /*Dropdown de Resolu��es*/
            public TMP_Dropdown resolution_dropdown;
    /* #################################################################### Configura��es de Tela ########################################################################### */
        /*### Resolu��o de Tela ###*/
        private void Start()
        {
            resolutions = Screen.resolutions;
            /*Elimina as op��es padr�o do Dropdown*/
                resolution_dropdown.ClearOptions();
            /*Lista que vai receber as resolu��es da tela*/
                List<string> resolution_list = new List<string>();
            /*Variavel que receber� o Index da Resolu��o atual*/
                int currentResolution = 0;
            /*Preenche a lista com o conte�do do Array*/
                for (int i = 0; i < resolutions.Length; i++)
                {
                                     
                    string option = resolutions[i].width + "x" + resolutions[i].height + " " + resolutions[i].refreshRateRatio + "Hz";
                    resolution_list.Add(option);
                    
                    
                    /*Verifica em que posi��o da lista est� a resolu��o atual da tela registra o Index*/
                    if (resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
                    {
                        /*Variavel que recebe o index da resolu��o atual*/
                            currentResolution = i;
                    }
                }
            /*Insere os elementos da lista no Dropdown*/
                resolution_dropdown.AddOptions(resolution_list);
            /*Seta o Index da resolu��o atual da tela como a posi��o atual do Dropdown*/
                resolution_dropdown.value = currentResolution;

        }

        public void setresolution(int resolutionInd)
        {
            Resolution resol = resolutions[resolutionInd];
            Screen.SetResolution(resol.width, resol.height, Screen.fullScreen); 
        }

    /*### Modo de Tela ###*/
    public void ScreenMode(int smode)
            {

                /*Switch conetado ao dropdown*/
                switch (smode)
                {
                    /*Tela Cheia*/
                    case 0:
                        Screen.fullScreenMode = FullScreenMode.ExclusiveFullScreen;
                        break;
                    /*Tela Cheia Sem Borda*/
                    case 1:
                        Screen.fullScreenMode = FullScreenMode.FullScreenWindow;
                        break;
                    /*Modo Janela*/
                    case 2:
                        Screen.fullScreenMode = FullScreenMode.Windowed;
                        break;
                }

            }

    /* #################################################################### Configura��es de Som ############################################################################ */

        /*### Volume M�sica ###*/
            public void Music_Volume (float music_volume) 
            {
                /*Realiza o Link entre o volume do mixer e o slider*/
                    music.SetFloat("Volume_Music", music_volume);
            }
        /*### Volume Efeitos Sonoros ###*/
            public void SFX_Volume(float SFX_volume)
            {
                /*Realiza o Link entre o volume do mixer e o slider*/
                    SFX.SetFloat("Volume_SoundEffects", SFX_volume);
            }
}
            
