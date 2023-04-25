using Castle.DynamicProxy;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Interceptors;
using FluentValidation;
using System;
using System.Linq;

namespace Core.Aspects.AutoFac.Validation
{
    public class ValidationAspect : MethodInterception
    {
        private Type _validatorType;
        public ValidationAspect(Type validatorType)
        {
            if (!typeof(IValidator).IsAssignableFrom(validatorType))
            {
                throw new System.Exception("Bu bir doğrulama sınıfı değil");
            }

            _validatorType = validatorType;
        }
        protected override void OnBefore(IInvocation invocation)
        {
            var validator = (IValidator)Activator.CreateInstance(_validatorType); // Reflection(Çalışma anında Bir şeyleri çalıştıabilmeyi sağlıyor) (ProductValidatorün bi instancesini oluştur)
            var entityType = _validatorType.BaseType.GetGenericArguments()[0]; //(ProductValidator de çalıştığı veri tiğini bul ve generic argümanlarından ilk olanını getir)
            var entities = invocation.Arguments.Where(t => t.GetType() == entityType); //(PM'de bulunan(add) parametrelerini bul)
            foreach (var entity in entities)
            {
                ValidationTool.Validate(validator, entity); // parametre de gelen dataların içini dön
            }
        }
    }
}
