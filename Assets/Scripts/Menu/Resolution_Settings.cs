using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Resolution_Settings : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private TMP_Dropdown resoldropdown;
    // Array que receber� as informa��es de resolu��o
    private Resolution[] resolutions;
    // Lista de Filtragem de RefreshRate
    List<Resolution> filterResol = new List<Resolution>();
    //Double, Recebe o refreshRate atual para a filtragem.
    private double currentRefreshRate;
    //Pega o valor Index da resolu��o atual sendo utilizada na tela. "Automatizando a resolu��o"
    private int CurrentResolInd = 0;

    void Start()
    {
        //Atribui as Informa��es de Resolu��o a
        resolutions = Screen.resolutions;
        //Declara��o da Lista de Filtro
        filterResol = new List<Resolution>();

        // Limpa o menu Dropdown
        resoldropdown.ClearOptions();
        // Obtem o RefreshRate da tela, em Hz;
        currentRefreshRate = Screen.currentResolution.refreshRateRatio.value;

        //Filtragem Inicial das resolu��es
        for (int i = 0; i < resolutions.Length; i++)
        { 
            if (resolutions[i].refreshRateRatio.value == currentRefreshRate)
            {
                filterResol.Add(resolutions[i]);
            }
        }
        //Lista que receber� as informa��es filtradas
        List<string> options = new List<string>(); 
        //Organiza as resolu��es filtradas e obtem a resolu��o atual da tela
        for (int i = 0; i < filterResol.Count; i++) 
        {
            //Preenche a lista com as resolu��es, o par�metro "System.Math.Round" � utilizado para arrendondar o RefreshRate e exibi-lo como n�mero inteiro no menu.
            string resolutionOPT = filterResol[i].width + "x" + filterResol[i].height + " " + System.Math.Round(filterResol[i].refreshRateRatio.value) + "Hz";
            options.Add(resolutionOPT); 
            //Checa se i � a resolu��o atual e, caso positivo, registra o index.
            if (filterResol[i].width == Screen.width && filterResol[i].height == Screen.height) 
            {
                CurrentResolInd = i;
            }
        }
        //Preenche o Menu DropDown com as resolu��es da lista
        resoldropdown.AddOptions(options);
        //Seta a sele��o do menu DropDown com a resolu��o atual da tela;
        resoldropdown.value = CurrentResolInd;
        resoldropdown.RefreshShownValue();

    }
    //Realiza a atualiza��o das resolu��es
    public void SetResolution(int resolutionIndex)   
    {
        //Quando ocorre modifica��o no menu, coleta o index e aplica a altera��o
        Resolution resolution = filterResol[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, true);
    }

    // Update is called once per frame
}
