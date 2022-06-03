using CompAndDel.Filters;
using CompAndDel.Pipes;
using Path = System.IO.Path;

namespace CompAndDel
{
    class Program
    {
        static void Main(string[] args)
        {
            string prePath = Path.Combine("..", "..", "..");
            var pProvider = new PictureProvider();
            IPicture beer = pProvider.GetPicture(Path.Combine(prePath, "beer.jpg"));
            var pipeSerial = new PipeSerial(
                new FilterGreyscale(), new PipeSerial(
                    new SaveFilter("mitad"), new PipeSerial(
                        new FilterNegative(), new PipeNull()
                        )
                    )
                );
            var resultadoBeer = pipeSerial.Send(beer);
            pProvider.SavePicture(resultadoBeer, Path.Combine(prePath, "..", "..", "resultados", "resultado_beer.jpg"));
        }
    }
}
