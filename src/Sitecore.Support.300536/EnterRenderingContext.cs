namespace Sitecore.Support.Mvc.Pipelines.Response.RenderRendering
{
  using Sitecore.Diagnostics;
  using Sitecore.Mvc.Pipelines.Response.RenderRendering;
  using Sitecore.Mvc.Presentation;
  using System;

  public class EnterRenderingContext : RenderRenderingProcessor
  {
    protected virtual void EnterContext(Rendering rendering, RenderRenderingArgs args)
    {
      IDisposable item = RenderingContext.EnterContext(rendering);
      args.Disposables.Add(item);
    }

    public override void Process(RenderRenderingArgs args)
    {
      
      Assert.ArgumentNotNull(args, "args");
      if (!args.Rendered)
      {

        if(args.Rendering.Renderer is ItemRenderer)
        { 
        foreach (var r in ((Sitecore.Mvc.Presentation.ItemRenderer)args.Rendering.Renderer).Renderings)
        {
          if (string.IsNullOrEmpty(r.DataSource))
          {
            r.DataSource = args.Rendering.Item.ID.ToString();
          }
        }
        }
        this.EnterContext(args.Rendering, args);

      }
    }
  }
}
