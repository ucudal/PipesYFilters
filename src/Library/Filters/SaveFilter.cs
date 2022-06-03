using System.IO;

namespace CompAndDel.Filters
{
    public class SaveFilter : IFilter
    {
        private string id;
        
        public SaveFilter(string id)
        {
            this.id = id;
        }
        
        /// Un filtro que retorna el negativo de la imagen recibida.
        /// </summary>
        /// <param name="image">La imagen a la cual se le va a aplicar el filtro.</param>
        /// <returns>La imagen recibida pero en negativo.</returns>
        public IPicture Filter(IPicture image)
        {
            var pProvider = new PictureProvider();
            pProvider.SavePicture(image, Path.Combine("..", "..", "..", "..", "..","resultados", "result_"+id+".jpg"));
            return image;
        }
    }
}