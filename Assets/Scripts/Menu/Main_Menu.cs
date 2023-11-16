   /// <summary>
   /// ######################################################################### © Burnout Studios #############################################################################
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
    /* #################################################################### Declaração de Variaveis ##########################################################################*/
    
        // Variavel que recebe o nome da cena a ser carrega no "Novo Jogo", se não for preenchida a função novo jogo não funcionará;
            [SerializeField] private string Cena_Play;

    // #################################################################### Botão de Inicio de Jogo ##########################################################################
    public void StartGame ()
    {
        // Carrega a Cena do Level 1/ Tutorial. ###ATENÇÃO### Para funcionar é necessário colocar as cenas no MENU "BUILD SETTINGS", respeitando a Hierarquia;
            SceneManager.LoadScene(Cena_Play);
    }

    /* ######################################################################## Botão de Opções ##############################################################################
        Utiliza-se da função "Set Active Bool" na unity, desativando o Parent do menu Principal e Ativando o do Menu de Opções. 
         Para Modificar as funções relacionadas as configurações contidas nesse menu, verificar o script "Options_Menu"*/

    /* ####################################################################### Botão de Créditos #############################################################################
        Utiliza-se da função "Set Active Bool" na unity, desativando o Parent do menu Principal e Ativando o do Menu de Créditos.*/

    //###################################################################### Botão de Sair do Jogo ###############################################################################

public void Exit()
{
    //Debug.Log("Saindo...");
    // Fecha a aplicação (Lembrete : Não funciona no Editor)
        Application.Quit();
}

}

