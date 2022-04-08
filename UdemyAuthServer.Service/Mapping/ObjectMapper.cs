using AutoMapper;

namespace UdemyAuthServer.Service.Mapping
{
    // Static ObjectMapper class'ı ihtiyaç duyulduğu anda bir IMapper nesnesi üretiyor.

    // Static ObjectMapper class
    public static class ObjectMapper
    {

        // IMapper üretme metodu
        private static readonly Lazy<IMapper> lazy = new Lazy<IMapper>(() =>
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<DtoMapper>();
            });
            return config.CreateMapper();
        });

        // Private kodu dışarıya açma.
        public static IMapper Mapper => lazy.Value;
    }
}
