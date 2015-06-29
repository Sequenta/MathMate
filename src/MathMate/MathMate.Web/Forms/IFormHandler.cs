namespace MathMate.Web.Forms
{
    public interface IFormHandler<in TForm, out TResult>where TForm : class where TResult : class
    {
        IFormResult<TResult> Handle(TForm form);
    }
}