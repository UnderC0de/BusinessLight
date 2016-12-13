using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Web.Mvc;

namespace BusinessLight.PhoneBook.Mvc.Results
{
    public class CsvResult<T> : ActionResult
    {
        private Type sourceType;
        private readonly IList<T> _source;
        private readonly string _fileName = "export.csv";
        private readonly bool _headerOnFirstRow = true;

        public CsvResult(IList<T> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            _source = source;
            sourceType = typeof(T);
        }
        public CsvResult(IList<T> source, string filename, bool headerOnFirstRow)
            : this(source)
        {
            _fileName = filename;
            _headerOnFirstRow = headerOnFirstRow;
        }

        public override void ExecuteResult(ControllerContext context)
        {
            context.HttpContext.Response.ClearContent();
            context.HttpContext.Response.AddHeader("Content-Disposition", "attachment; filename=" + _fileName);
            context.HttpContext.Response.ContentType = "application/ms-excel";
            context.HttpContext.Response.Flush();
            context.HttpContext.Response.Write(ToString());
            context.HttpContext.Response.End();
        }

        public override string ToString()
        {
            var builder = new StringBuilder();
            
            PropertyInfo[] properties = sourceType.GetProperties();
            foreach (var item in _source)
            {
                if (_headerOnFirstRow)
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