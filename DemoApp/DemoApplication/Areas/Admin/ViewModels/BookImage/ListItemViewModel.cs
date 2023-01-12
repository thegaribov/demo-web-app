namespace DemoApplication.Areas.Admin.ViewModels.BookImage
{
    public class BookImagesViewModel
    {
        public int BookId { get; set; }
        public List<ListItem>? Images { get; set; }





        public class ListItem
        {
            public int Id { get; set; }
            public string? ImageUrL { get; set; }
            public DateTime CreatedAt { get; set; }
        }
    }


}
