using UnityEngine;

namespace BB3D.Utility
{
    public class ParticleEffectBurst : MonoBehaviour
    {
        ParticleSystem particleSystem;
        ParticleSystemRenderer particleSystemRenderer;

        [SerializeField]
        float size;

        private void Awake()
        {
            particleSystem = GetComponent<ParticleSystem>();
            particleSystemRenderer = GetComponent<ParticleSystemRenderer>();
            particleSystemRenderer.material.color = gameObject.GetComponentInParent<MeshRenderer>().materials[0].color;
            transform.parent = transform.parent.parent;
            transform.localScale = new Vector3(1, 1, 1);
        }

        private void Start()
        {
            PlayEffectAndDestroy();
        }

        void ChangeEffectSize(float s)
        {
            size = s;
        }

        void PlayEffectAndDestroy()
        {
            particleSystem.Play();
            ParticleSystem.MainModule m = particleSystem.main;
            Destroy(gameObject, m.startLifetime.constant);
        }

    }
}




















