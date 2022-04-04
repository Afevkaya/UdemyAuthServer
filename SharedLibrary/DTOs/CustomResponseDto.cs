using System.Text.Json.Serialization;

namespace SharedLibrary.Dtos
{
    public class CustomResponseDto<T>
    {
        public T Data { get; private set; }
        public int StatusCode { get; private set; }

        [JsonIgnore]
        public bool IsSuccessful { get; private set; }
        public ErrorDto Error { get; private set; }

        public static CustomResponseDto<T> Success(int statusCode, T data)
        {
            return new CustomResponseDto<T> { StatusCode = statusCode, Data = data };
        }

        public static CustomResponseDto<T> Success(int statusCode)
        {
            return new CustomResponseDto<T> { StatusCode = statusCode };
        }

        public static CustomResponseDto<T> Fail(int statusCode,ErrorDto errorDto)
        {
            return new CustomResponseDto<T> { StatusCode = statusCode, Error = errorDto };
        }

        public static CustomResponseDto<T> Fail(int statusCode, string error,bool isShow)
        {
            var errorDto = new ErrorDto(error, isShow);
            return new CustomResponseDto<T> { StatusCode = statusCode, Error = errorDto };
        }

    }
}
