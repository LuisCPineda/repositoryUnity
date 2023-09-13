using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControllerInterface : MonoBehaviour
{
    //Nom des agents
    [SerializeField] private TMP_InputField nomJoueur1;
    [SerializeField] private TMP_InputField nomJoueur2;
    //Points d'actions des agents
    [SerializeField] private TMP_InputField pointAction1;
    [SerializeField] private TMP_InputField pointAction2;
    //Tours de jeu
    [SerializeField] private TMP_InputField toursTotal;

    private GameManager _gameManager;
    

    // Start is called before the first frame update
    void Start()
    {
        _gameManager = GameManager.Instance;
        nomJoueur1.text = _gameManager.Nom1;
        nomJoueur2.text = _gameManager.Nom2.ToString();
        pointAction1.text = _gameManager.Point1.ToString();
        pointAction2.text = _gameManager.Point2.ToString();
        toursTotal.text = _gameManager.Tours.ToString();
    }

    public void Quitter()
    {
#if UNITY_EDITOR
        EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

    public void NouvellePartie()
    {
        ChargerInfo();
        SceneManager.LoadScene("PremierNiveau");
    }
    public void ChargerInfo()
    {
        _gameManager.Nom1 = nomJoueur1.text;
        _gameManager.Nom2 = nomJoueur2.text;
        _gameManager.Point1 = float.Parse(pointAction1.text);
        _gameManager.Point2 = float.Parse(pointAction2.text);
        _gameManager.Tours = Int32.Parse(toursTotal.text);
    }
    public void ChargerNom1()
    {
        if(nomJoueur1.text != null)
        {
            //gameManager
        }
    }
}
