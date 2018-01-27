﻿using Assets.Scripts.Managers;
using UnityEngine;

namespace Assets.Scripts.Echoes
{
    [RequireComponent(typeof(AudioSource))]
    [RequireComponent(typeof(SonarShader))]
    public class EcoLocationAudioSource : MonoBehaviour
    {
        public float intensity = 100f;

        public bool isAmbientSound = false;

        [ContextMenu("Play Sound")]
        public void PlaySound(AudioClip audio)
        {
            foreach (var meshSpawner in EchoMeshSpawner.MeshSpawners)
            {
                meshSpawner.CreateCopyOfMesh();
            }
            var audioSource = GetComponent<AudioSource>();
            audioSource.clip = audio;
            audioSource.Play();
            GetComponent<SonarShader>().StartSonarRing(transform.position, intensity);

            if (!isAmbientSound)
            {
                GameManager.Instance.SoundWasPlayed(transform.position, intensity);
            }
        }

        //void StartRadiusIncrease()
        //{
        //    StartCoroutine(LinearUpdate(0, goalLength, increaseTime, ScaleGo, StartRadiusDecrease));
        //}

        //void StartRadiusDecrease()
        //{
        //    StartCoroutine(LinearUpdate(goalLength, 0, decreaseTime, ScaleGo));
        //}

        //void ScaleGo(float value)
        //{
        //    go.transform.localScale = new Vector3(value, value, value);
        //}

        //IEnumerator LinearUpdate(float from, float to, float endTimeInSeconds, Action<float> func, Action onFinished = null)
        //{
        //    float diff = to - from;
        //    float time = 0;

        //    while (time < endTimeInSeconds)
        //    {
        //        time += Time.deltaTime;

        //        if (time > endTimeInSeconds)
        //        {
        //            time = endTimeInSeconds;
        //        }

        //        float value = from + diff * (time / endTimeInSeconds);

        //        func(value);

        //        yield return new WaitForEndOfFrame();
        //    }

        //    if (onFinished != null)
        //    {
        //        onFinished();
        //    }
        //}
    }
}
