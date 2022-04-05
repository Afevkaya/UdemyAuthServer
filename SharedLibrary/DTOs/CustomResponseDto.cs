using System.Text.Json.Serialization;

namespace SharedLibrary.Dtos
{
    // Generic CustomResponseDto class
    // Client tarafına tek bir model döndürmek için yazdığımız class
    // IsSuccessful property'si proje içinde işlemin başarılı olup olmadığını kontrol etmek için kullanıyoruz.
    // IsSuccessful property'si proje içinde kullanılcak bir propertydir. Kullanıcıya açılmayacak.
    public class CustomResponseDto<T>
    {
        public T Data { get; private set; }
        public int StatusCode { get; private set; }
        [JsonIgnore]
        public bool IsSuccessful { get; private set; }
        public ErrorDto Error { get; private set; }

        public static CustomResponseDto<T> Success(int statusCode, T data)
        {
            return new CustomResponseDto<T> { StatusCode = statusCode, Data = data, IsSuccessful = true };
        }

        public static CustomResponseDto<T> Success(int statusCode)
        {
            return new CustomResponseDto<T> { StatusCode = statusCode, IsSuccessful = true };
        }

        public static CustomResponseDto<T> Fail(int statusCode,ErrorDto errorDto)
        {
            return new CustomResponseDto<T> { StatusCode = statusCode, Error = errorDto, IsSuccessful = false };
        }

        public static CustomResponseDto<T> Fail(int statusCode, string errorMessage,bool isShow)
        {
            var errorDto = new ErrorDto(errorMessage, isShow);
            return new CustomResponseDto<T> { StatusCode = statusCode, Error = errorDto, IsSuccessful = false };
        }

    }
}
