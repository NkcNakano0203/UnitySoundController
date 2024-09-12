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

            EditorGUILayout.PropertyField(audioClipProperty, new GUIContent("�����f�[�^"));
            EditorGUILayout.Slider(audioVolumeProperty, 0, 1, new GUIContent("����"));
            EditorGUILayout.PropertyField(randomPitchProperty, new GUIContent("�s�b�`�������_����"));
            if (randomPitchProperty.boolValue)
            {
                EditorGUILayout.Slider(minPitchProperty, -3f, 3f, new GUIContent("�Œ�s�b�`"));
                EditorGUILayout.Slider(maxPitchProperty, -3f, 3f, new GUIContent("�ō��s�b�`"));
            }
            EditorGUILayout.PropertyField(audio3DProperty, new GUIContent("���̉���"));
            EditorGUILayout.PropertyField(maxMultiPlayCountProperty, new GUIContent("�����Đ���"));

            EditorGUILayout.EndFoldoutHeaderGroup();
            // �����L���b�V���ɒl��ۑ�����
            serializedObject.ApplyModifiedProperties();
        }
    }
}