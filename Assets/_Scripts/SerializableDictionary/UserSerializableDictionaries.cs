using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

[Serializable]
public class StringStringDictionary : SerializableDictionary<string, string> {}

[Serializable]
public class StringAudioSourceSettingDictionary : SerializableDictionary<string, AudioSourceSetting> { }

[Serializable]
public class ObjectColorDictionary : SerializableDictionary<UnityEngine.Object, Color> {}

[Serializable]
public class ClipsStorage : SerializableDictionary.Storage<AudioClip[]> {}

[Serializable]
public class MaterialClipsArrayDictionary : SerializableDictionary<PhysicsMaterial2D, AudioClip[], ClipsStorage> {}

[Serializable]
public class MyClass
{
    public int i;
    public string str;
}

[Serializable]
public class QuaternionMyClassDictionary : SerializableDictionary<Quaternion, MyClass> {}