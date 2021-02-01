using System.Collections.Generic;

namespace Blueprint.RenderEngine
{
    internal class Renderer
    {
        internal List<Renderer> renderStack = new List<Renderer>();

        internal Renderer() { }

        internal virtual void Draw(RenderContext context) { }

        internal void DrawStack(RenderContext renderContext)
        {
            Draw(renderContext);

            for (int i = 0; i < renderStack.Count; i++)
            {
                renderStack[i].DrawStack(renderContext);
            }
        }
    }
}
