using Raylib_cs;

namespace Enlatados.Scenes.Core.Code.Objects.Components
{
    //Aqui está la logica de la explosion y cambio de textura
    public class LataExplosionComponent : Component
    {
        public bool IsExploding { get; private set; }
        private float _timer;
        private readonly float _duration;
        private Texture2D _explosionTexture;

        public LataExplosionComponent(GameObject owner, Texture2D explosionTexture, float duration = 0.3f) : base(owner)
        {
            _explosionTexture = explosionTexture;
            _duration = duration;
            IsExploding = false;
        }

        public void Explode()
        {
            if (IsExploding) return;

            IsExploding = true;
            _timer = _duration;

            // Delegamos el apartado visual completamente al RenderComponent existente
            if (Owner.RenderComponent is RenderComponent rc)
            {
                rc.texture = _explosionTexture;
            }
        }

        public void Update(float deltaTime)
        {
            if (!IsExploding) return;

            _timer -= deltaTime;
            if (_timer <= 0f)
            {
                IsExploding = false;
                if (Owner is Lata lata)
                {
                    lata.setInactive();
                }
            }
        }
    }
}