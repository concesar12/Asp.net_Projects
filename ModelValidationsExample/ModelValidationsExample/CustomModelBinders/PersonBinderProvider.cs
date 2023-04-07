using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using ModelValidationsExample.Models;

namespace ModelValidationsExample.CustomModelBinders
{
    public class PersonBinderProvider : IModelBinderProvider // I have to add this class as a reusable service to the controller
    {
        public IModelBinder? GetBinder(ModelBinderProviderContext context)
        {
            if (context.Metadata.ModelType == typeof(Person))
            {
                // this says whenever modal binding is the Person type then use the personmodal binder so that will be enabled for the entire project
                return new BinderTypeModelBinder(typeof(PersonModelBinder));
            }
            return null;
        }
    }
}
