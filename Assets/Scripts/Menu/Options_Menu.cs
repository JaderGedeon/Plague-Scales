/// <>
/// ######################################################################### © Burnout Studios #############################################################################
/// ############################################################################# 15/11/2023 ################################################################################
/// ###################################################################### Sistema de Configurações #########################################################################
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
    /* #################################################################### Declaração de Variaveis #########################################################################*/
        /*AudioMixer responsável pelas Musicas*/
            public AudioMixer music;
        /*AudioMixer responsável pelos Efeitos Especiais*/
            public AudioMixer SFX;
        /*Array que será preenchido com as resoluções da tela*/
            Resolution[] resolutions;
        /*Dropdown de Resoluções*/
            public TMP_Dropdown resolution_dropdown;
    /* #################################################################### Configurações de Tela ########################################################################### */
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

    /* #################################################################### Configurações de Som ############################################################################ */

        /*### Volume Música ###*/
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
            
