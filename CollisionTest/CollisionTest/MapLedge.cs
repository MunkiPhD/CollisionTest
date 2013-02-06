using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace CollisionTest {
    class MapLedge {
        public Vector2 LeftPoint;
        public Vector2 RightPoint;
        public Vector2 Adjustment;
        private Texture2D _lineTexture;

        public MapLedge(Texture2D texture, Vector2 leftPoint, Vector2 rightPoint) {
            LeftPoint = leftPoint;
            RightPoint = rightPoint;
            _lineTexture = texture;
        }


        public void Draw(SpriteBatch spriteBatch) {
            LineRenderer.DrawLine(spriteBatch, _lineTexture, LeftPoint + Adjustment, RightPoint + Adjustment);
        }
    }
}
