namespace ApiTraining.ModelBinders;


using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel;
using System.Reflection;
using System.Threading.Tasks;

public class ArrayModelBinder : IModelBinder
{
    public Task BindModelAsync(ModelBindingContext bindingContext)
    {
        if (!bindingContext.ModelMetadata.IsEnumerableType)
        {
            bindingContext.Result = ModelBindingResult.Failed();
            return Task.CompletedTask;
        }

        string providedValue = bindingContext.ValueProvider.GetValue(bindingContext.ModelName).ToString();
        if (string.IsNullOrEmpty(providedValue))
        {
            bindingContext.Result = ModelBindingResult.Success(null);
            return Task.CompletedTask;
        }

        Type genericType = bindingContext.ModelType.GetTypeInfo().GenericTypeArguments[0];
        TypeConverter converter = TypeDescriptor.GetConverter(genericType);

        Array objectArray = providedValue.Split(new[] {","}, StringSplitOptions.RemoveEmptyEntries)
            .Select(e => converter.ConvertFromString(e.Trim()))
            .ToArray();

        Array guidArray = Array.CreateInstance(genericType, objectArray.Length);
        objectArray.CopyTo(guidArray, 0);

        bindingContext.Result = ModelBindingResult.Success(guidArray);
        return Task.CompletedTask;
    }
}
