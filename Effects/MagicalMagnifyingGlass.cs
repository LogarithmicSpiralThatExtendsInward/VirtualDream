using Microsoft.Xna.Framework.Graphics;

using Terraria.Graphics.Shaders;

namespace VirtualDream.Effects
{
    // This ModNPC serves as an example of a complete AI example.
    public class IllusionScreenShaderData : ScreenShaderData
    {
        public IllusionScreenShaderData(string passName) : base(passName)
        {
        }
        public IllusionScreenShaderData(Ref<Effect> shader, string passName) : base(shader, passName)
        {
        }

        public override void Apply()
        {
            Shader.Parameters["mousePos"].SetValue(new Vector2((Main.MouseWorld - Main.screenPosition).X / Main.screenWidth, (Main.MouseWorld - Main.screenPosition).Y / Main.screenHeight));
            Shader.Parameters["lightConst"].SetValue(IllusionBoundMod.lightConst);
            base.Apply();
        }
    }
}