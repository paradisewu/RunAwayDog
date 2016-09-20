using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class UIManager
{
    public enum EUI
    {
        UILogin,

        Num,
    }

    private static Dictionary<EUI, UIBase> dUIs = new Dictionary<EUI, UIBase>();
    public static UIBase GetUI(EUI eUI)
    {
        if (dUIs.ContainsKey(eUI))
        {
            return dUIs[eUI];
        }
        return null;
    }

    public static UIBase CreateUI(EUI eUI)
    {
        if (dUIs.ContainsKey(eUI))
        {
            if (dUIs[eUI] != null)
            {
                return dUIs[eUI];
            }
            else
            {
                dUIs.Remove(eUI);
            }
        }

        Transform tr = Resources.Load<Transform>("UI/" + eUI);
        Transform uiTr = null;
        if (tr == null)
        {
            //加载AssetBundle
        }
        else
        {
            uiTr = GameObject.Instantiate(tr) as Transform;
        }
        uiTr.name = eUI.ToString();

        UIBase ui = uiTr.GetComponent<UIBase>();
        if (ui == null)
        {
            ui = uiTr.gameObject.AddComponent(Type.GetType(eUI.ToString())) as UIBase;
        }
        ui.transform.localPosition = Vector3.zero;
        dUIs.Add(eUI, ui);
        return ui;
    }
}
