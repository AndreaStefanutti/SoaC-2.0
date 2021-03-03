using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NameTrasfer : MonoBehaviour { 
public GameObject TextDisplay;
public string nome;
public GameObject Input;


public void Tornanome()
{
    nome = Input.GetComponent<Text>().text = " Login corretto";
}
    }

