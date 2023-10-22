using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using SQLite4Unity3d;

public class NewBehaviourScript : MonoBehaviour
{
    public TextMeshProUGUI textMeshPro;
    public TextMeshProUGUI datashit;
    public string satatic = "";
    public SQLiteConnection _connection;
    public double memory1 = 0;
    public double memory = 0;
    public double memory2 = 0;
    public string res = "";
    public int times = 0;
    public int casenumber = 1;
    public int equla = 0;
    public int state = 0;
    public double result = 0;
    public string tri = "";
    public bool plus = false;
    public bool minus = false;
    public bool divi = false;
    public bool multi = false;
    public bool cosine = false;
    public bool sine = false;
    public bool tanz = false;
    public bool Pow = false;
    public bool quyu = false;


    private void Start()
    {
        string databasePath = Application.streamingAssetsPath + "/SqliteDatabase.db";
        _connection = new SQLiteConnection(databasePath,SQLiteOpenFlags.ReadWrite | SQLiteOpenFlags.Create);
    }
    public void num0()
    {
        Initial();
        textMeshPro.text += "0";
        satatic += "0";

    }
    public void num1()
    {
        Initial();
        textMeshPro.text += "1";
        satatic += "1";

    }
    public void num2()
    {
        Initial();
        textMeshPro.text += "2";
        satatic += "2";
    }
    public void num3()
    {
        Initial();
        textMeshPro.text += "3";
        satatic += "3";
    }
    public void num4()
    {
        Initial();
        textMeshPro.text += "4";
        satatic += "4";

    }
    public void num5()
    {
        Initial();
        textMeshPro.text += "5";
        satatic += "5";

    }
    public void num6()
    {
        Initial();
        textMeshPro.text += "6";
        satatic += "6";
    }
    public void num7()
    {
        Initial();
        textMeshPro.text += "7";
        satatic += "7";
    }


    public void num8()
    {
        Initial();
        textMeshPro.text += "8";
        satatic += "8";
    }
    public void num9()
    {
        Initial();
        textMeshPro.text += "9";
        satatic += "9";
    }
    public void COS()
    {
        memory = float.Parse(textMeshPro.text);
        ClearShow();
        textMeshPro.text += tri = memory.ToString();
        textMeshPro.text = "cos(" + tri + ")";
        satatic += "cos(" + tri + ")";
        cosine = true;
    }
    public void SIN()
    {
        memory = float.Parse(textMeshPro.text);
        ClearShow();
        textMeshPro.text += tri = memory.ToString();
        textMeshPro.text = "sin(" + tri + ")";
        satatic += "sin(" + tri + ")";
        sine = true;    
    }
    public void Tan()
    {
        memory = float.Parse(textMeshPro.text);
        ClearShow();
        textMeshPro.text += tri = memory.ToString();
        textMeshPro.text = "tan(" + tri + ")";
        satatic += "cos(" + tri + ")";
        tanz = true;
    }
    public void pow()
    {
        memory = float.Parse(textMeshPro.text);
        satatic += "^";
        ClearShow();
        Pow = true;
    }
    public void Quyu()
    {
        memory = float.Parse(textMeshPro.text);
        satatic += "%";
        ClearShow();
        quyu = true;
    }
    public void Poin()
    {
        textMeshPro.text += ".";
        satatic += ".";
    }



    public void Plus()
    {
        if (times > 0)
        {
            num14();
            memory = result;
            ClearShow();

        }
        else
        {
            memory = float.Parse(textMeshPro.text);
            memory2 = memory;
            ClearShow();
            times++;
        }
        plus = true;
        satatic += "+";
        state = 2;
    }
    public void Initial()
    {
        if (textMeshPro.text == "0")
        {
            ClearShow();
        }
    }
    public void ClearShow()
    {
        textMeshPro.text = null;
    }
    public void Minus()
    {
        if (times > 0)
        {
            num14();
            memory = result;
            ClearShow();

        }
        else
        {
            memory = float.Parse(textMeshPro.text);
            memory2 = memory;
            ClearShow();
            times++;
        }
        minus = true;
        satatic += "-";
        state = 3;
    }
    public void Multi()
    {
        if (times > 0)
        {
            num14();
            memory = result;
            ClearShow();

        }
        else
        {
            memory = float.Parse(textMeshPro.text);
            ClearShow();
            times++;
        }
        multi = true;
        satatic += "*";
    }
    public void Divi()
    {
        if (times > 0)
        {
            num14();
            memory = result;
            ClearShow();

        }
        else
        {
            memory = float.Parse(textMeshPro.text);
            ClearShow();
            times++;
        }
        divi = true;
        satatic += "/";

    }


    public void num14()
    {
        if (plus)
        {
            memory1 = float.Parse(textMeshPro.text);
            result = memory + memory1;
            plus = false;
        }
        else if (minus)
        {
            memory1 = float.Parse(textMeshPro.text);
            result = memory - memory1;
            minus = false;
        }
   

        else if (multi)
        {
            memory1 = float.Parse(textMeshPro.text);
            if (state == 2)
            {
                memory = memory - memory2;
                result = memory * memory1 + memory2;
                state = 0;
                memory2 = 0;
            }
            else if (state == 3)
            {
                memory = memory + memory2;
                result = memory * memory1 - memory2;
                memory2 = 0;
            }
            else
            {
                result = memory * memory1;
            }
        }
        else if (divi)
        {
            memory1 = float.Parse(textMeshPro.text);
            if (state == 2)
            {
                memory = memory - memory2;
                result = memory / memory1 + memory2;
                memory2 = 0;
            }
            else if (state == 3)
            {
                memory = memory + memory2;
                result = memory / memory1 - memory2;
                memory2 = 0;
            }
            else
            {
                result = memory / memory1;
            }
            divi = false;
        }


        ClearShow();
        textMeshPro.text = result.ToString();
    }

    public void num15()
    {
        satatic += "=";
        if (plus)
        {
            memory1 = float.Parse(textMeshPro.text);
            result = memory + memory1;

            plus = false;
        }
        else if (minus)
        {
            memory1 = float.Parse(textMeshPro.text);
            result = memory - memory1;
            minus = false;
        }
        else if (multi)
        {
            memory1 = float.Parse(textMeshPro.text);
            if (state == 2)
            {
                memory = memory - memory2;
                result = memory * memory1 + memory2;
                memory2 = 0;
            }
            else if (state == 3)
            {
                memory = memory + memory2;
                result = memory * memory1 - memory2;
                memory2 = 0;
            }
            else
            {
                result = memory * memory1;
            }

            multi = false;
        }
        else if (divi)
        {
            memory1 = float.Parse(textMeshPro.text);
            if (state == 2)
            {
                memory = memory - memory2;
                result = memory / memory1 + memory2;
                memory2 = 0;
            }
            else if (state == 3)
            {
                memory = memory + memory2;
                result = memory / memory1 - memory2;
                memory2 = 0;
            }
            else
            {
                result = memory / memory1;
            }
            divi = false;
        }
        else if (cosine)
        {
            result = Math.Cos((memory / 360) * 2 * Math.PI);
            cosine = false;
        }
        else if (sine)
        {
            result = Math.Sin((memory / 360) * 2 * Math.PI);
            sine = false;
        }
        else if (tanz)
        {
            result = Math.Tan((memory / 360) * 2 * Math.PI);
            tanz = false;
        }
        else if (Pow)
        {
            memory1 = float.Parse(textMeshPro.text);
            result = Math.Pow(memory, memory1);
            Pow = false;
        }
        else if (quyu)
        {
            memory1 = float.Parse(textMeshPro.text);
            result = memory % memory1;
            quyu = false;
        }
        ClearShow();

        switch (casenumber)
        {
            case 1:
                PlayerPrefs.SetString("shizi1", satatic);
                textMeshPro.text = result.ToString();
                res = result.ToString();
                PlayerPrefs.SetString("jieguo1", res);
                PlayerPrefs.Save();
                casenumber++;
                break;
            case 2:
                PlayerPrefs.SetString("shizi2", satatic);
                textMeshPro.text = result.ToString();
                res = result.ToString();
                PlayerPrefs.SetString("jieguo2", res);
                PlayerPrefs.Save();
                casenumber++;
                break;
            case 3:
                PlayerPrefs.SetString("shizi3", satatic);
                textMeshPro.text = result.ToString();
                res = result.ToString();
                PlayerPrefs.SetString("jieguo3", res);
                PlayerPrefs.Save();
                casenumber++;
                break;
            case 4:
                PlayerPrefs.SetString("shizi4", satatic);
                textMeshPro.text = result.ToString();
                res = result.ToString();
                PlayerPrefs.SetString("jieguo4", res);
                PlayerPrefs.Save();
                casenumber++;
                break;
            case 5:
                PlayerPrefs.SetString("shizi5", satatic);
                textMeshPro.text = result.ToString();
                res = result.ToString();
                PlayerPrefs.SetString("jieguo5", res);
                PlayerPrefs.Save();
                casenumber++;
                break;
            case 6:
                PlayerPrefs.SetString("shizi6", satatic);
                textMeshPro.text = result.ToString();
                res = result.ToString();
                PlayerPrefs.SetString("jieguo6", res);
                PlayerPrefs.Save();
                casenumber++;
                break;
            case 7:
                PlayerPrefs.SetString("shizi7", satatic);
                textMeshPro.text = result.ToString();
                res = result.ToString();
                PlayerPrefs.SetString("jieguo7", res);
                PlayerPrefs.Save();
                casenumber++;
                break;
            case 8:
                PlayerPrefs.SetString("shizi8", satatic);
                textMeshPro.text = result.ToString();
                res = result.ToString();
                PlayerPrefs.SetString("jieguo8", res);
                PlayerPrefs.Save();
                casenumber++;
                break;
            case 9:
                PlayerPrefs.SetString("shizi9", satatic);
                textMeshPro.text = result.ToString();
                res = result.ToString();
                PlayerPrefs.SetString("jieguo9", res);
                PlayerPrefs.Save();
                casenumber++;
                break;
            case 10:
                PlayerPrefs.SetString("shizi10", satatic);
                textMeshPro.text = result.ToString();
                res = result.ToString();
                PlayerPrefs.SetString("jieguo10", res);
                PlayerPrefs.Save();
                casenumber = 1;
                break;
        }
  
        memory = 0;
        memory1 = 0;
        result = 0;
        times = 0;
        state = 0;
        satatic = null;
    }
    public void clear()
    {
        textMeshPro.text = "0";

    }
   

    public string delete;
    public int i = 0;
    public void dele()
    {
        textMeshPro.text = textMeshPro.text.Substring(0, textMeshPro.text.Length - 1);
        satatic = satatic.Substring(0, satatic.Length - 1);

    }


        public void ReadAllData()
        {
            string[] shiziData = new string[10];
            string[] jieguoData = new string[10];

            for (int casenumber = 1; casenumber <= 10; casenumber++)
            {
                string shiziKey = "shizi" + casenumber;
                string jieguoKey = "jieguo" + casenumber;

                shiziData[casenumber - 1] = PlayerPrefs.GetString(shiziKey, "");
                jieguoData[casenumber - 1] = PlayerPrefs.GetString(jieguoKey, "");
            }

            // 显示所有事件的数据
            for (int casenumber = 1; casenumber <= 10; casenumber++)
            {
                datashit.text += shiziData[casenumber - 1]  + "= " + jieguoData[casenumber - 1] + "\n";
            }
        }
    

}