   /// <summary>
   /// ######################################################################### � Burnout Studios #############################################################################
   /// ############################################################################# 15/11/2023 ################################################################################
   /// ###################################################################### Sistema de Menu Principal ########################################################################
   /// </summary>

using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Main_Menu : MonoBehaviour
{
    /* #################################################################### Declara��o de Variaveis ##########################################################################*/
    
        // Variavel que recebe o nome da cena a ser carrega no "Novo Jogo", se n�o for preenchida a fun��o novo jogo n�o funcionar�;
            [SerializeField] private string Cena_Play;

    // #################################################################### Bot�o de Inicio de Jogo ##########################################################################
    public void StartGame ()
    {
        // Carrega a Cena do Level 1/ Tutorial. ###ATEN��O### Para funcionar � necess�rio colocar as cenas no MENU "BUILD SETTINGS", respeitando a Hierarquia;
            SceneManager.LoadScene(Cena_Play);
    }

    /* ######################################################################## Bot�o de Op��es ##############################################################################
        Utiliza-se da fun��o "Set Active Bool" na unity, desativando o Parent do menu Principal e Ativando o do Menu de Op��es. 
         Para Modificar as fun��es relacionadas as configura��es contidas nesse menu, verificar o script "Options_Menu"*/

    /* ####################################################################### Bot�o de Cr�ditos #############################################################################
        Utiliza-se da fun��o "Set Active Bool" na unity, desativando o Parent do menu Principal e Ativando o do Menu de Cr�ditos.*/

    //###################################################################### Bot�o de Sair do Jogo ###############################################################################

public void Exit()
{
    //Debug.Log("Saindo...");
    // Fecha a aplica��o (Lembrete : N�o funciona no Editor)
        Application.Quit();
}

}

