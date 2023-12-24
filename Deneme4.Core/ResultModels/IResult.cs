namespace Deneme4.Core.ResultModels
{
    public interface IResult
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
    }
}
