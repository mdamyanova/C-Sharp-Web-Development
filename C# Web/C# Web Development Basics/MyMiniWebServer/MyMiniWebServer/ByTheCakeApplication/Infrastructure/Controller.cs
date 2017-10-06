﻿namespace MyMiniWebServer.ByTheCakeApplication.Infrastructure
{
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using MyMiniWebServer.ByTheCakeApplication.Views;
    using Server.Enums;
    using Server.Http.Contracts;
    using Server.Http.Response;

    public abstract class CalcController
    {
        private const string DefaultPath = @"ByTheCakeApplication\Resources\{0}.html";
        private const string ContentPlaceholder = "{{{content}}}";

        public IHttpResponse FileViewResponse(string fileName)
        {
            var result = this.ProcessFileHtml(fileName);

            return new ViewResponse(HttpStatusCode.Ok, new FileView(result));
        }

        public IHttpResponse FileViewResponse(string fileName, Dictionary<string, string> values)
        {
            var result = this.ProcessFileHtml(fileName);

            if (values != null && values.Any())
            {
                foreach (var value in values)
                {
                    result = result.Replace($"{{{{{{{value.Key}}}}}}}", value.Value);
                }
            }

            return new ViewResponse(HttpStatusCode.Ok, new FileView(result));
        }

        private string ProcessFileHtml(string fileName)
        {
            var layoutHtml = File.ReadAllText(string.Format(DefaultPath, "layout"));
            var fileHtml = File.ReadAllText(string.Format(DefaultPath, fileName));

            var result = layoutHtml.Replace(ContentPlaceholder, fileHtml);

            return result;
        }
    }
}