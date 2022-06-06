using System.IO;
using TwitterUCU;

namespace CompAndDel.Filters
{
    public class TwitterShareFilter : IFilter
    {
        private readonly string post;
        
        public TwitterShareFilter(string post)
        {
            this.post = post;
        }
        
        public IPicture Filter(IPicture image)
        {
            TwitterImage twitterImage = new TwitterImage();
            var pProvider = new PictureProvider();
            string path = Path.Combine("..", "..", "..", "..", "..", "resultados", "result_twitter.jpg");
            pProvider.SavePicture(image, path);
            twitterImage.PublishToTwitter(post, path);
            return image;
        }
    }
}