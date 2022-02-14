namespace ApiTraining;

using Entities.ViewModels;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Net.Http.Headers;
using System.Text;

public class CsvOutputFormatter : TextOutputFormatter
{
    public CsvOutputFormatter()
    {
        SupportedMediaTypes.Add(MediaTypeHeaderValue.Parse("text/csv"));
        SupportedEncodings.Add(Encoding.UTF8);
        SupportedEncodings.Add(Encoding.Unicode);
    }

    public override async Task WriteResponseBodyAsync(OutputFormatterWriteContext context, Encoding selectedEncoding)
    {
        var response = context.HttpContext.Response;
        var buffer = new StringBuilder();

        if(context.Object is IEnumerable<CompanyViewModel>)
        {
            foreach(var companyViewModel in (IEnumerable<CompanyViewModel>)context.Object)
            {
                FormatCsv(buffer, companyViewModel);
            }
        }
        else if(context.Object is CompanyViewModel)
        {
            FormatCsv(buffer, (CompanyViewModel)context.Object);
        }

        await response.WriteAsync(buffer.ToString());
    }
    private void FormatCsv(StringBuilder buffer, CompanyViewModel company) => buffer.AppendLine($"{company.Id},\"{company.Name},\"{company.FullAddress}\"");
}