namespace MathMate.Web.Forms
{
    public class FormResult<TResult> : IFormResult<TResult> where TResult : class
    {
        public bool IsError { get; private set; }
        public TResult Data { get; private set; }
        public string Comment { get; private set; }

        public FormResult(bool isError, TResult data, string comment = null)
        {
            IsError = isError;
            Data = data;
            Comment = comment;
        }

        public static FormResult<TResult> SuccessResult(TResult result)
        {
            return new FormResult<TResult>(false, result);
        }
        public static FormResult<TResult> ErrorResult(string errorMessage = "Server error")
        {
            return new FormResult<TResult>(true, null, errorMessage);
        }
    }
}