using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using UnityEngine;
using HutongGames.PlayMaker;

namespace MyAssetMod.Helper;

public class FindFsmString
{
    public static void SearchInterations()
    {
        string gameObjectName = "InteractionsLoader/InteractionRandomizerRepository";
        GameObject targetGameObject = GameObject.Find(gameObjectName);
        if (targetGameObject == null)
        {
            Debug.LogError($"GameObject '{gameObjectName}' not found in the scene.");
            return;
        }

        // Get all PlayMakerArrayListProxy components on the GameObject
        PlayMakerArrayListProxy[] proxies = targetGameObject.GetComponents<PlayMakerArrayListProxy>();

        int x = 0;

        foreach (PlayMakerArrayListProxy proxy in proxies)
        {

            // Check the contents of the _arrayList
            foreach (var value in proxy._arrayList)
            {
                if (value is string strValue && strValue.Contains("such a"))
                {
                    Debug.Log($"Found string in GameObject '{x}': {strValue}");
                }
            }
            x++;
        }
    }

    public static void SearchAllGameObjects()
    {
        // Get all GameObjects in the scene
        GameObject[] allGameObjects = MyAssetMod.FindObjectsOfType<GameObject>();
        Debug.Log($"Trying my best boss!");

        foreach (GameObject gameObject in allGameObjects)
        {
            // Get all PlayMakerFSM components on the GameObject
            PlayMakerFSM[] fsms = gameObject.GetComponents<PlayMakerFSM>();

            foreach (PlayMakerFSM fsm in fsms)
            {
                // Get ArrayVariables from the FsmVariables
                FsmArray[] arrayVariables = fsm.FsmVariables.ArrayVariables;

                foreach (FsmArray arrayVariable in arrayVariables)
                {
                    // Ensure the array holds strings
                    if (arrayVariable.ElementType == VariableType.String)
                    {
                        foreach (var value in arrayVariable.Values)
                        {
                            if (value is string strValue && strValue.ToLower().Contains("such a"))
                            {
                                string fullPath = GetFullPath(gameObject);
                                Debug.Log($"Found string in GameObject '{fullPath}': {strValue}");
                            }
                        }
                    }
                }
            }
        }
    }


    static string GetFullPath(GameObject gameObject)
    {
        string path = gameObject.name;
        Transform parent = gameObject.transform.parent;

        while (parent != null)
        {
            path = parent.name + "/" + path;
            parent = parent.parent;
        }

        return path;
    }
}