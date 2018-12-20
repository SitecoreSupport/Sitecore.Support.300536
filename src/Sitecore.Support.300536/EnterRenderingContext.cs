namespace Sitecore.Mvc.Pipelines.Response.RenderRendering
{
  using Sitecore.Diagnostics;
  using Sitecore.Mvc.Presentation;
  using System;

  public class EnterRenderingContext : RenderRenderingProcessor
  {
    protected virtual void EnterContext(Rendering rendering, RenderRenderingArgs args)
    {
      if (string.IsNullOrEmpty(rendering.DataSource))
      {
        rendering.DataSource = args.Rendering.Item.ID.ToString();
      }

      IDisposable item = RenderingContext.EnterContext(rendering);
      args.Disposables.Add(item);
    }

    public override void Process(RenderRenderingArgs args)
    {
      Assert.ArgumentNotNull(args, "args");
      if (!args.Rendered)
      {
        this.EnterContext(args.Rendering, args);
      }
    }
  }
}
