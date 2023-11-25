using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Resolution_Settings : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private TMP_Dropdown resoldropdown;
    // Array que receberá as informações de resolução
    private Resolution[] resolutions;
    // Lista de Filtragem de RefreshRate
    List<Resolution> filterResol = new List<Resolution>();
    //Double, Recebe o refreshRate atual para a filtragem.
    private double currentRefreshRate;
    //Pega o valor Index da resolução atual sendo utilizada na tela. "Automatizando a resolução"
    private int CurrentResolInd = 0;

    void Start()
    {
        //Atribui as Informações de Resolução a
        resolutions = Screen.resolutions;
        //Declaração da Lista de Filtro
        filterResol = new List<Resolution>();

        // Limpa o menu Dropdown
        resoldropdown.ClearOptions();
        // Obtem o RefreshRate da tela, em Hz;
        currentRefreshRate = Screen.currentResolution.refreshRateRatio.value;

        //Filtragem Inicial das resoluções
        for (int i = 0; i < resolutions.Length; i++)
        { 
            if (resolutions[i].refreshRateRatio.value == currentRefreshRate)
            {
                filterResol.Add(resolutions[i]);
            }
        }
        //Lista que receberá as informações filtradas
        List<string> options = new List<string>(); 
        //Organiza as resoluções filtradas e obtem a resolução atual da tela
        for (int i = 0; i < filterResol.Count; i++) 
        {
            //Preenche a lista com as resoluções, o parâmetro "System.Math.Round" é utilizado para arrendondar o RefreshRate e exibi-lo como número inteiro no menu.
            string resolutionOPT = filterResol[i].width + "x" + filterResol[i].height + " " + System.Math.Round(filterResol[i].refreshRateRatio.value) + "Hz";
            options.Add(resolutionOPT); 
            //Checa se i é a resolução atual e, caso positivo, registra o index.
            if (filterResol[i].width == Screen.width && filterResol[i].height == Screen.height) 
            {
                CurrentResolInd = i;
            }
        }
        //Preenche o Menu DropDown com as resoluções da lista
        resoldropdown.AddOptions(options);
        //Seta a seleção do menu DropDown com a resolução atual da tela;
        resoldropdown.value = CurrentResolInd;
        resoldropdown.RefreshShownValue();

    }
    //Realiza a atualização das resoluções
    public void SetResolution(int resolutionIndex)   
    {
        //Quando ocorre modificação no menu, coleta o index e aplica a alteração
        Resolution resolution = filterResol[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, true);
    }

    // Update is called once per frame
}
