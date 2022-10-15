using saitynai_server.Data.Dtos.Games;

namespace saitynai_server.Helpers
{
    public class MultipleFilesGeneric<T> where T : class
    {
        public T? Data { get; set; }
        public List<IFormFile>? Files { get; set; }
    }

    //public record MultipleFilesGeneric
    //{
    //    public List<IFormFile>? Files { get; set; }
    //    public GamePostDto Data { get; set; }
    //}
}
