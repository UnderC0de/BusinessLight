namespace BusinessLight.PhoneBook.Mvc.Results
{
    using System;
    using System.Collections.Generic;
    using System.Reflection;
    using System.Text;
    using System.Web.Mvc;

    public class CsvResult<T> : ActionResult
    {
        private readonly Type sourceType;
        private readonly IList<T> source;
        private readonly string fileName = "export.csv";
        private readonly bool headerOnFirstRow = true;

        public CsvResult(IList<T> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            this.source = source;
            sourceType = typeof(T);
        }

        public CsvResult(IList<T> source, string filename, bool headerOnFirstRow)
            : this(source)
        {
            this.fileName = filename;
            this.headerOnFirstRow = headerOnFirstRow;
        }

        public override void ExecuteResult(ControllerContext context)
        {
            context.HttpContext.Response.ClearContent();
            context.HttpContext.Response.AddHeader("Content-Disposition", "attachment; filename=" + this.fileName);
            context.HttpContext.Response.ContentType = "application/ms-excel";
            context.HttpContext.Response.Flush();
            context.HttpContext.Response.Write(ToString());
            context.HttpContext.Response.End();
        }

        public override string ToString()
        {
            var builder = new StringBuilder();
            
            var properties = sourceType.GetProperties();
            foreach (var item in this.source)
            {
                if (this.headerOnFirstRow)
                {
                    // header
                    foreach (var property in properties)
                    {
                        builder.AppendFormat("{0};", property.Name);
                    }

                    builder.AppendFormat(Environment.NewLine);
                }

                foreach (var property in properties)
                {
                    builder.AppendFormat("{0};", property.GetValue(item, null) != null ? property.GetValue(item, null).ToString().Trim() : null);
                }

                builder.AppendFormat(Environment.NewLine);
            }
            return builder.ToString();
        }

    }
}