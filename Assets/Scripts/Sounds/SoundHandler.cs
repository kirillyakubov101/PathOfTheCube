using UnityEngine;

namespace EndlessCube.Sounds
{
    public class SoundHandler : MonoBehaviour
    {
        [SerializeField] private AudioSource m_coinAudioSourcePrefab;
        [SerializeField] private AudioSource m_jumpAudioSourcePrefab;
        [SerializeField] private AudioSource m_slideAudioSourcePrefab;
        [SerializeField] private AudioSource m_hitAudioSourcePrefab;
        [SerializeField] private AudioSource m_loseAudioSourcePrefab;
        public void PlayCoinCollect()
        {
            var temp = Instantiate(m_coinAudioSourcePrefab);
            temp.Play();
            Destroy(temp.gameObject, temp.clip.length);
        
        }

        public void PlayJumpSound()
        {
            var temp = Instantiate(m_jumpAudioSourcePrefab);
            temp.Play();
            Destroy(temp.gameObject, temp.clip.length);
        }

        public void PlaySlideSound()
        {
            var temp = Instantiate(m_slideAudioSourcePrefab);
            temp.Play();
            Destroy(temp.gameObject, temp.clip.length);
        }

        public void PlayHitSound()
        {
            var temp = Instantiate(m_hitAudioSourcePrefab);
            temp.Play();
            Destroy(temp.gameObject, temp.clip.length);
        }

        public void PlayLoseSound()
        {
            var temp = Instantiate(m_loseAudioSourcePrefab);
            temp.Play();
            Destroy(temp.gameObject, temp.clip.length);
        }
    }

}

