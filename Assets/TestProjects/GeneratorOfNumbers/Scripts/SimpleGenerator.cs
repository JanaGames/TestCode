using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SimpleGenerator : MonoBehaviour
{
    string[] curentSymbols;

    public Image panelGrid;
    float widthGrid;
    float heigthGrid;
    int rows;
    int columns;

    public TMP_InputField textWidth;
    public TMP_InputField textHeigth;
    public Button buttonMixSymbols;
    //prefub
    public Image slotSymbol;

    void Start() 
    {
        widthGrid = panelGrid.GetComponent<RectTransform>().rect.width;
        heigthGrid = panelGrid.GetComponent<RectTransform>().rect.height;
        //becouse a curentSymbols is empty
        buttonMixSymbols.interactable = false;
    }

    public void SetRandom() 
    {
        //check
        if (!CheckInputField()) return;

        buttonMixSymbols.interactable = true;
        curentSymbols = GetSymbols(rows*columns);
        ButtonPress();
    }
    public void SetMix() 
    {
        //check
        if (!CheckInputField()) return;

        curentSymbols = GetSymbols(curentSymbols);
        ButtonPress();
    }

    //same actions for all buttons
    void ButtonPress() 
    {
        ClearSlots();
        SpawnSymbols(curentSymbols);
    }
    void SpawnSymbols(string[] symbols) 
    {
        panelGrid.GetComponent<GridLayoutGroup>().cellSize = GetSizeSlot();
        int indexSymbol = 0;
        for (int i = 0; i < rows; i++) 
        {
            for (int j = 0; j < columns && indexSymbol < symbols.Length; j++) 
            {
                Image slot = Instantiate(slotSymbol);
                slot.transform.SetParent(panelGrid.transform);
                //slot.transform.parent = panelGrid.transform;
                slot.transform.GetChild(0).GetComponent<TMP_Text>().text = curentSymbols[indexSymbol];
                indexSymbol +=1;
            }
        }
    }
    Vector2 GetSizeSlot() 
    {
        int w = (int)widthGrid/rows;
        int h = (int)heigthGrid/columns;

        return new Vector2(w, h);
    }
    //delete all slots for load a new slots after
    void ClearSlots() 
    {
        for (int i = 0; i < panelGrid.transform.childCount; i++) Destroy(panelGrid.transform.GetChild(i).gameObject); 
    }
    //for mix of symbols
    string[] GetSymbols(string[] symbols) 
    {
        //create list for edit when choice a symbol
        List<string> list = new List<string>(symbols);
        string[] res = new string[symbols.Length];
        for (int i = 0; i < res.Length; i++) 
        {
            string symbol = list[Random.Range(0, list.Count)];
            res[i] = symbol;
            list.Remove(symbol);
        }
        return res;
    }
    //for random a spawn of symbols
    string[] GetSymbols(int count) 
    {
        string[] array = new string[10] {"A", "B", "C", "D", "E", "F", "J", "K", "L", "M",};
        string[] res = new string[count];
        for (int i = 0; i < res.Length; i++) res[i] = array[Random.Range(0, 10)]; 
        return res;
    }
    bool CheckInputField() 
    {
        int res;
        if (!int.TryParse(textWidth.text, out res) || !int.TryParse(textHeigth.text, out res)) 
        {
            //create message if a input text inpossible parse to int
            UIMessagePanel.Instance.CreateMessage("Incorrect a input value!");
            //retorn start text
            textWidth.text = "Width";
            textHeigth.text = "Heigth";
            return false;
        }
        else 
        {
            rows = int.Parse(textWidth.text);
            columns = int.Parse(textHeigth.text);
        }
        return true;
    }
}
