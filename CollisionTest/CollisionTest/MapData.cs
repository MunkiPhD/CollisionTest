using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace CollisionTest {
    class MapData {
        public List<MapLedge> MapLedges = new List<MapLedge>();
        public Texture2D LineTexture;
        public ContentManager Content;
        public Viewport _view;

        public MapData(ContentManager content, Viewport view) {
            Content = content;
            int bottom = _view.Bounds.Bottom;

            LineTexture = content.Load<Texture2D>("Line");
            AddLedge(new Vector2(0, 10), new Vector2(50, 15));
            AddLedge(new Vector2(50, 15), new Vector2(100, 40));
            AddLedge(new Vector2(100, 40), new Vector2(150, 65));
            AddLedge(new Vector2(150, 65), new Vector2(200, 10));
            AddLedge(new Vector2(200, 10), new Vector2(400, 50));
            AddLedge(new Vector2(400, 50), new Vector2(600, 30));
            AddLedge(new Vector2(600, 30), new Vector2(800, 65));
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="leftPoint"></param>
        /// <param name="rightPoint"></param>
        public void AddLedge(Vector2 leftPoint, Vector2 rightPoint) {
            AddLedge(new MapLedge(LineTexture, leftPoint, rightPoint));
        }


        public void Update(GameTime gameTime, Viewport view) {
            foreach(MapLedge ledge in MapLedges) {
                ledge.Adjustment.Y = view.Bounds.Bottom - 65;
                ledge.Adjustment.X = 0;
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="ledge"></param>
        public void AddLedge(MapLedge ledge) {
            MapLedges.Add(ledge);
        }



        /// <summary>
        /// Returns the specified ledge if the xlocation falls within
        /// </summary>
        /// <param name="xLocation"></param>
        /// <returns></returns>
        public MapLedge GetLedge(float xLocation) {
            foreach(MapLedge ledge in MapLedges) {
                if(xLocation >= ledge.LeftPoint.X && xLocation <= ledge.RightPoint.X) {
                    return ledge;
                }
            }

            return null;
        }



        /// <summary>
        /// 
        /// </summary>
        /// <param name="spriteBatch"></param>
        public void Draw(SpriteBatch spriteBatch) {
            foreach(MapLedge ledge in MapLedges)
                ledge.Draw(spriteBatch);
        }
    }
}
