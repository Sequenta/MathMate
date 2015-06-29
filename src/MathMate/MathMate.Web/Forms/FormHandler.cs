namespace MathMate.Web.Forms
{
    public abstract class FormHandler<TForm, TResult> : IFormHandler<TForm, TResult> where TForm : class where TResult : class
    {
        protected abstract IFormResult<TResult> InnerValidate(TForm form);
        protected abstract IFormResult<TResult> InnerHandle(TForm form);

        protected readonly IFormResult<TResult> DefaultNoError = new FormResult<TResult>(false, null);

        protected readonly IFormResult<TResult> DefaultError = new FormResult<TResult>(true, null);
        public IFormResult<TResult> Handle(TForm form)
        {
            var validationResult = InnerValidate(form);
            if (validationResult.IsError)
            {
                return validationResult;
            }
            IFormResult<TResult> result;
            try
            {
                result = InnerHandle(form);
            }
            catch
            {
                result = FormResult<TResult>.ErrorResult();
            }
            return result;
        }
    }
}