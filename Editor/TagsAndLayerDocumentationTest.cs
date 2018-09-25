using UnityEngine;
using UnityEditor;
using NUnit.Framework;


public class TagsAndLayerDocumentationTest
{
    private TagsAndLayersDocumentation GetDocumentation()
    {
        TagsAndLayersDocumentation[] instances = GetAllInstances<TagsAndLayersDocumentation>();
        if (instances == null || instances.Length != 1) return null;
        else return instances[0];
    }

    [Test]
    public void TestInstanceExistence()
    {
        TagsAndLayersDocumentation[] instances = GetAllInstances<TagsAndLayersDocumentation>();

        Assert.IsTrue(instances != null && instances.Length > 0, "Instance of scriptable object TagsAndLayersDocumentation doesn't exists.");
        Assert.IsTrue(instances.Length == 1, "Multiple instance of scriptable object TagsAndLayersDocumentation have been found.");
    }

    [Test]
    public void TestTagsDocumentation()
    {
        TagsAndLayersDocumentation documentation = GetDocumentation();
        Assert.IsNotNull(documentation, "Can't get instance of scriptable object. Refers to TestInstanceExistence for more details.");

        SerializedObject serializedObject = new SerializedObject(documentation);
        SerializedProperty tagsProperty = serializedObject.FindProperty("tagsDocumentation");

        for (int i = 0; i < tagsProperty.arraySize; i++)
        {
            SerializedProperty tagProperty = tagsProperty.GetArrayElementAtIndex(i);
            string name = tagProperty.FindPropertyRelative("name").stringValue;
            string description = tagProperty.FindPropertyRelative("description").stringValue;
            Assert.IsNotEmpty(description, string.Format("Tag {0} has empty description", name));
        }
    }

    [Test]
    public void TestSortingLayersDocumentation()
    {
        TagsAndLayersDocumentation documentation = GetDocumentation();
        Assert.IsNotNull(documentation, "Can't get instance of scriptable object. Refers to TestInstanceExistence for more details.");

        SerializedObject serializedObject = new SerializedObject(documentation);
        SerializedProperty sortingLayersProperty = serializedObject.FindProperty("sortingLayersDocumentation");

        for (int i = 0; i < sortingLayersProperty.arraySize; i++)
        {
            SerializedProperty sortingLayerProperty = sortingLayersProperty.GetArrayElementAtIndex(i);
            string name = sortingLayerProperty.FindPropertyRelative("name").stringValue;
            string description = sortingLayerProperty.FindPropertyRelative("description").stringValue;
            Assert.IsNotEmpty(description, string.Format("Sorting layer {0} has empty description", name));
        }
    }

    [Test]
    public void TestLayersDocumentation()
    {
        TagsAndLayersDocumentation documentation = GetDocumentation();
        Assert.IsNotNull(documentation, "Can't get instance of scriptable object. Refers to TestInstanceExistence for more details.");

        SerializedObject serializedObject = new SerializedObject(documentation);
        SerializedProperty layersProperty = serializedObject.FindProperty("layersDocumentation");

        for (int i = 0; i < layersProperty.arraySize; i++)
        {
            SerializedProperty layerProperty = layersProperty.GetArrayElementAtIndex(i);
            string name = layerProperty.FindPropertyRelative("name").stringValue;
            string description = layerProperty.FindPropertyRelative("description").stringValue;
            Assert.IsNotEmpty(description, string.Format("Layer {0} has empty description", name));
        }
    }

    private static T[] GetAllInstances<T>() where T : ScriptableObject
    {
        string[] guids = AssetDatabase.FindAssets("t:" + typeof(T).Name);  //FindAssets uses tags check documentation for more info
        T[] a = new T[guids.Length];
        for (int i = 0; i < guids.Length; i++)         //probably could get optimized 
        {
            string path = AssetDatabase.GUIDToAssetPath(guids[i]);
            a[i] = AssetDatabase.LoadAssetAtPath<T>(path);
        }

        return a;
    }
}