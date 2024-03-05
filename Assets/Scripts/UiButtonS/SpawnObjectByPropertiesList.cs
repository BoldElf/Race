using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpawnObjectByPropertiesList : MonoBehaviour
{
    [SerializeField] private Transform parent;
    [SerializeField] private GameObject prefab;
    [SerializeField] private ScriptableObject[] properties;

    [ContextMenu(nameof(SpawnInEditMode))]
    public void SpawnInEditMode()
    {
        if (Application.isPlaying == true) return;

        GameObject[] allObject = new GameObject[parent.childCount];

        for(int i = 0; i < parent.childCount;i++)
        {
            allObject[i] = parent.GetChild(i).gameObject;
        }

        for (int i = 0; i < allObject.Length; i++)
        {
            DestroyImmediate(allObject[i]);
        }

        for (int i = 0; i < properties.Length; i++)
        {
            /*
            UIRaceButton button = Instantiate(prefab, parent);
            button.ApplayProperty(properties[i]);
            */
            GameObject go = Instantiate(prefab, parent);
            IScriptableObjectProperty scriptableObjectProperty = go.GetComponent<IScriptableObjectProperty>();
            scriptableObjectProperty.ApplayProperty(properties[i]);
        }
    }

}
