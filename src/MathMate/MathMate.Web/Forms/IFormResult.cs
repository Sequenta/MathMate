namespace MathMate.Web.Forms
{
    public interface IFormResult<out TResult> where TResult : class
    {
        bool IsError { get; }
        TResult Data { get; }
        string Comment { get; }
    }
}