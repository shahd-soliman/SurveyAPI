namespace Survey.app.Abstraction
{
    public class Result
    {
        public Result(bool isSuccess, Error error)
        {
            if ((isSuccess && error != Error.None) || (!isSuccess && error == Error.None))
                throw new InvalidOperationException();
            IsSuccess = isSuccess;
            Error = error;
        }
        public bool IsSuccess { get; }
        public bool IsFailure => !IsSuccess;
        public Error Error { get; }

        public static Result Success() => new(true, Error.None);
        public static Result Failure(Error error) => new(false, error);
        public static Result<TValue> Success<TValue>(TValue value) => new(true, Error.None, value);
        public new static Result<TValue> Failure<TValue>(Error error) => new(false, error, default);
    }

    public class Result<TValue> : Result
    {
        public readonly TValue? _value;
        public Result(bool isSuccess, Error error, TValue? value) : base(isSuccess, error)
        {
            _value = value;
        }

       

        public TValue GetValueOrThrow()
        {
            if (IsFailure)
                throw new InvalidOperationException("Failure result");
            return _value!;
        }
    }
}
