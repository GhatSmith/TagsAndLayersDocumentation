using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif


[CreateAssetMenu(fileName = "TagsAndLayersDocumentation", menuName = "Tools/TagsAndLayersDocumentation")]
public class TagsAndLayersDocumentation : ScriptableObject
{
#if UNITY_EDITOR
    [System.Serializable]
    private struct Description
    {
        [HideInInspector] public string name;
        [TextArea] public string description;
    }


    [SerializeField, Header("TAGS")] private Description[] tagsDocumentation;
    [SerializeField, Space(20f), Header("SORTING LAYERS")] private Description[] sortingLayersDocumentation;
    [SerializeField, Space(20f), Header("LAYERS")] private Description[] layersDocumentation;


    void Reset()
    {
        tagsDocumentation = new Description[0];
        sortingLayersDocumentation = new Description[0];
        layersDocumentation = new Description[0];

        OnValidate();

        SetDefaultTagsDocumentation();
        SetDefaultSortingLayersDocumentation();
        SetDefaultLayersDocumentation();
    }

    private void SetDefaultTagsDocumentation()
    {
        for (int i = 0; i < tagsDocumentation.Length; i++)
        {
            switch (tagsDocumentation[i].name)
            {
                case "Untagged":
                    tagsDocumentation[i].description = "Unity built in tag.";
                    break;
                case "Respawn":
                    tagsDocumentation[i].description = "Unity built in tag.";
                    break;
                case "Finish":
                    tagsDocumentation[i].description = "Unity built in tag.";
                    break;
                case "EditorOnly":
                    tagsDocumentation[i].description = "Unity built in tag. An object tagged this will not appear in a build.";
                    break;
                case "MainCamera":
                    tagsDocumentation[i].description = "Unity built in tag. An object tagged this will respond to Camera.main.";
                    break;
                case "Player":
                    tagsDocumentation[i].description = "Unity built in tag.";
                    break;
                case "GameController":
                    tagsDocumentation[i].description = "Unity built in tag.";
                    break;
                default:
                    Debug.LogWarning("Need to add documentation for tag " + tagsDocumentation[i].name);
                    break;
            }
        }

    }

    private void SetDefaultSortingLayersDocumentation()
    {
        for (int i = 0; i < sortingLayersDocumentation.Length; i++)
        {
            switch (sortingLayersDocumentation[i].name)
            {
                case "Default":
                    sortingLayersDocumentation[i].description = "Unity built in sorting layer.";
                    break;
                default:
                    Debug.LogWarning("Need to add documentation for sorting layer " + sortingLayersDocumentation[i].name);
                    break;
            }
        }
    }

    private void SetDefaultLayersDocumentation()
    {
        for (int i = 0; i < layersDocumentation.Length; i++)
        {
            switch (layersDocumentation[i].name)
            {
                case "Default":
                    layersDocumentation[i].description = "Unity built in layer.";
                    break;
                case "TransparentFX":
                    layersDocumentation[i].description = "Unity built in layer. Lens flares will show through the collider of an object on this layer.";
                    break;
                case "Ignore Raycast":
                    layersDocumentation[i].description = "Unity built in layer. An object on this layer will be ignored by raycasts (including OnMouseOver, etc.).";
                    break;
                case "Water":
                    layersDocumentation[i].description = "Unity built in layer.";
                    break;
                case "UI":
                    layersDocumentation[i].description = "Unity built in layer.";
                    break;
                default:
                    Debug.LogWarning("Need to add documentation for layer " + layersDocumentation[i].name);
                    break;
            }
        }
    }

    public void OnValidate()
    {
        string[] tags = UnityEditorInternal.InternalEditorUtility.tags;
        if (tagsDocumentation.Length != tags.Length) System.Array.Resize(ref tagsDocumentation, tags.Length);

        for (int i = 0; i < tags.Length; i++)
        {
            tagsDocumentation[i].name = tags[i];
        }

        SortingLayer[] sortingLayers = SortingLayer.layers;
        if (sortingLayersDocumentation.Length != sortingLayers.Length) System.Array.Resize(ref sortingLayersDocumentation, sortingLayers.Length);

        for (int i = 0; i < sortingLayers.Length; i++)
        {
            sortingLayersDocumentation[i].name = sortingLayers[i].name;
        }

        string[] layers = UnityEditorInternal.InternalEditorUtility.layers;
        if (layersDocumentation.Length != layers.Length) System.Array.Resize(ref layersDocumentation, layers.Length);

        for (int i = 0; i < layersDocumentation.Length; i++)
        {
            layersDocumentation[i].name = layers[i];
        }
    }
#endif
}


#if UNITY_EDITOR
[CustomEditor(typeof(TagsAndLayersDocumentation))]
public class TagsAndLayersDocumentationEditor : Editor
{
    void OnEnable()
    {
        // Force calling OnValidate method when displaying inspector
        (target as TagsAndLayersDocumentation).OnValidate();
    }
}
#endif