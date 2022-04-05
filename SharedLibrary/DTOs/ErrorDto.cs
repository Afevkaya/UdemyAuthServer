namespace SharedLibrary.Dtos
{
    // ErrorDto class
    // API'lerde bir hata geldiğinde kullanılacak class
    // Amaç client'a tek bir model döndürmek.
    public class ErrorDto
    {
        // Hatalar birden fazla olabilir.
        public List<string> Errors { get; private set; }

        // Client'ın görüp görmemesi gerek hatalarda kullanılır.
        // Bir hatayı client görmemesi gerekiyorsa false olarak atanır.
        public bool IsShow { get; private set; }

        public ErrorDto()
        {
            Errors = new List<string>();
        }

        public ErrorDto(string error, bool isShow)
        {
            Errors.Add(error);
            IsShow = isShow;
        }
        public ErrorDto(List<string> errors, bool isShow)
        {
            this.Errors = errors;
            this.IsShow = isShow;
        }
    }
}
