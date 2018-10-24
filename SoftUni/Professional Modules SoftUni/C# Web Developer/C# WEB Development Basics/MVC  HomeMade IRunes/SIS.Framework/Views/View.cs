namespace SIS.Framework.Views
{
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using ActionResults.Contracts;

    public class View : IRenderable
    {
        private const string LayoutFile = "Layout.html";
        private const string ViewNotFound = "View does not exist!";
        private const string RenderBody = "@RenderBody";

        private readonly string fullyQualifiedTemplateName;
        private readonly IDictionary<string, object> viewData;

        public View(string fullyQualifiedTemplateName, IDictionary<string, object> viewData)
        {
            this.fullyQualifiedTemplateName = fullyQualifiedTemplateName;
            this.viewData = viewData;
        }

        private string ReadFile()
        {
            if (!File.Exists(this.fullyQualifiedTemplateName))
            {
                throw new FileNotFoundException();
            }

            var html = File.ReadAllText(this.fullyQualifiedTemplateName);
            return html;
        }

        public string Render()
        {
            var html = this.ReadFile();
            var renderHtml = this.RenderHtml(html);

            var layout = this.AddViewToLayout(renderHtml);
            return layout;
        }

        private string RenderHtml(string fullHtml)
        {
            var renderHtml = fullHtml;

            if (this.viewData.Any())
            {
                foreach (var pair in this.viewData)
                {
                    renderHtml = renderHtml.Replace($"{{{{{{{pair.Key}}}}}}}", pair.Value.ToString());
                }
            }

            return renderHtml;
        }

        private string AddViewToLayout(string renderHtml)
        {
            var layoutPath = $"../../../{MvcContext.Get.ViewsFolder}/{LayoutFile}";

            if (!File.Exists(layoutPath))
            {
                throw new FileNotFoundException(ViewNotFound);
            }

            var layoutHtml = File.ReadAllText(layoutPath);
            var layout = layoutHtml.Replace(RenderBody, renderHtml);

            return layout;
        }
    }
}