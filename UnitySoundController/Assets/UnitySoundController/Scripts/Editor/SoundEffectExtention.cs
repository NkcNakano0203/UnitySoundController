using UnityEditor;
using UnityEngine;

namespace UnitySoundController.SE.Data
{
    [CustomEditor(typeof(SoundEffect))]
    public class SoundEffectExtention : Editor
    {
        public override void OnInspectorGUI()
        {
            var moguEvolutionTree = target as SoundEffect;

            serializedObject.Update();

            SerializedProperty audioClipProperty =
                serializedObject.FindProperty(nameof(SoundEffect.Clip));

            SerializedProperty audioVolumeProperty =
                serializedObject.FindProperty(nameof(SoundEffect.Volume));

            SerializedProperty randomPitchProperty =
                serializedObject.FindProperty(nameof(SoundEffect.RandomPitch));

            SerializedProperty maxPitchProperty =
                serializedObject.FindProperty(nameof(SoundEffect.MaxPitch));

            SerializedProperty minPitchProperty =
                serializedObject.FindProperty(nameof(SoundEffect.MinPitch));

            SerializedProperty audio3DProperty =
                serializedObject.FindProperty(nameof(SoundEffect.Audio3D));

            SerializedProperty maxMultiPlayCountProperty =
                serializedObject.FindProperty(nameof(SoundEffect.MaxMultiPlayCount));

            EditorGUILayout.PropertyField(audioClipProperty, new GUIContent("音声データ"));
            EditorGUILayout.Slider(audioVolumeProperty, 0, 1, new GUIContent("音量"));
            EditorGUILayout.PropertyField(randomPitchProperty, new GUIContent("ピッチをランダム化"));
            if (randomPitchProperty.boolValue)
            {
                EditorGUILayout.Slider(minPitchProperty, -3f, 3f, new GUIContent("最低ピッチ"));
                EditorGUILayout.Slider(maxPitchProperty, -3f, 3f, new GUIContent("最高ピッチ"));
            }
            EditorGUILayout.PropertyField(audio3DProperty, new GUIContent("立体音響"));
            EditorGUILayout.PropertyField(maxMultiPlayCountProperty, new GUIContent("同時再生数"));

            EditorGUILayout.EndFoldoutHeaderGroup();
            // 内部キャッシュに値を保存する
            serializedObject.ApplyModifiedProperties();
        }
    }
}