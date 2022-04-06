using AutoMapper;

namespace UdemyAuthServer.Service.Mapping
{
    // Bu class ihtiyaç duyduğu zaman IMapper üretimi yapıyor.

    // Static ObjectMapper class
    public static class ObjectMapper
    {
        private static readonly Lazy<IMapper> lazy = new Lazy<IMapper>(() =>
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<DtoMapper>();
            });
            return config.CreateMapper();
        });

        public static IMapper Mapper => lazy.Value;
    }
}
