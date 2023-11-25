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
            
